using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using hotelManagement.H.layers.BusinessLayers;
using hotelManagement.H.layers.ModelLayers;
using System.Data.SqlClient;
using System.Data;
using hotelManagement.H.layers.DataLayers;
using common;

namespace hotelManagement.H.M
{
    public partial class UserM : System.Web.UI.Page
    {
        BL_User_Access objBL_User_Master = new BL_User_Access();
        ML_User_Access objML_User_Master = new ML_User_Access();
        protected bool blAccess = true;
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        CommonClass objCommonClass = new CommonClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                getState();
                BindUserMaster();
                getCity();
            }
        }
        protected void btnSaved(object sender, EventArgs e)
        {
            try
            {
                if (btnSave.Text == "Save")
                {
                    con.Open();
                    SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);

                    string qry = "";
                    qry = "select  MAX(UserID) as UserID  from SPCN_User_Master_Access ";
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(qry, con);
                    cmd.Transaction = trans;
                    cmd.Clone();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        objML_User_Master.ID = dr["UserID"].ToString();
                    }
                    if (clsCommon.myLen(objML_User_Master.ID) < 0)
                    {
                        objML_User_Master.ID = "UA000000001";
                    }
                    else
                    {
                        objML_User_Master.ID = clsCommon.incval(objML_User_Master.ID);
                    }
                    con.Close();

                    objML_User_Master.UserName = txtUserName.Text != "" ? txtUserName.Text : "";
                    objML_User_Master.LastName = txtlastName.Text != "" ? txtlastName.Text : null;
                    objML_User_Master.EmailID = txtEmailID.Text != "" ? txtEmailID.Text : null;
                    objML_User_Master.MobileNo = txtPhoneNo.Text != "" ? txtPhoneNo.Text : null;
                    objML_User_Master.Address = txtAddress.Text != "" ? txtAddress.Text : null;
                    if (chkActive.Checked == true)
                    {
                        objML_User_Master.Activation = true;
                    }
                    else
                    {
                        objML_User_Master.Activation = false;
                    }
                    objML_User_Master.country = txtCountry.Text != "" ? txtCountry.Text : null;
                    objML_User_Master.State = ddlState.SelectedItem.Value != "" ? ddlState.SelectedItem.Value : null;
                    objML_User_Master.City = ddlcity.SelectedItem.Value != "" ? ddlcity.SelectedItem.Value : null;
                    objML_User_Master.Passsword = objCommonClass.GetEncrptPassword(txtPwd.Text);
                    objML_User_Master.ConformPasword = objCommonClass.GetEncrptPassword(txtCPwd.Text);
                    objML_User_Master.CreatedBy = Session["UserName"].ToString();
                    objML_User_Master.ModifyBy = Session["UserName"].ToString();
                    int x = objBL_User_Master.BL_InsUpdUserDetail(objML_User_Master);
                    if (x == 1)
                    {
                        BindUserMaster();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('User Saved')", true);
                    }
                }
                else
                {
                    objML_User_Master.ID = lblID.Text != "" ? lblID.Text : null;
                    objML_User_Master.UserName = txtUserName.Text != "" ? txtUserName.Text : "";
                    objML_User_Master.LastName = txtlastName.Text != "" ? txtlastName.Text : null;
                    objML_User_Master.EmailID = txtEmailID.Text != "" ? txtEmailID.Text : null;
                    objML_User_Master.MobileNo = txtPhoneNo.Text != "" ? txtPhoneNo.Text : null;
                    objML_User_Master.Address = txtAddress.Text != "" ? txtAddress.Text : null;
                    if (chkActive.Checked == true)
                    {
                        objML_User_Master.Activation = true;
                    }
                    else
                    {
                        objML_User_Master.Activation = false;
                    }
                    objML_User_Master.country = txtCountry.Text != "" ? txtCountry.Text : null;
                    objML_User_Master.State = ddlState.SelectedItem.Value != "" ? ddlState.SelectedItem.Value : null;
                    objML_User_Master.City = ddlcity.SelectedItem.Value != "" ? ddlcity.SelectedItem.Value : null;
                    objML_User_Master.Passsword = objCommonClass.GetEncrptPassword(txtPwd.Text);
                    objML_User_Master.ConformPasword = objCommonClass.GetEncrptPassword(txtCPwd.Text);
                    objML_User_Master.CreatedBy = Session["UserName"].ToString();
                    objML_User_Master.ModifyBy = Session["UserName"].ToString();
                    int x = objBL_User_Master.BL_InsUpdUserDetail(objML_User_Master);
                    if (x == 1)
                    {
                        BindUserMaster();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('User Updated')", true);
                    }
                }         
                

            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + " ')", true);     
            }
        }
        protected void btnClear(object sender, EventArgs e)
        {
            txtCPwd.Text = "";
            txtUserName.Text = "";
            txtPwd.Text = "";
            txtEmailID.Text = "";
            txtPhoneNo.Text = "";
            txtAddress.Text = "";
            txtCountry.Text = "";
            chkActive.Checked = false;
            ddlcity.SelectedIndex = 0;
            ddlState.SelectedIndex = 0;
            txtlastName.Text = "";

        }
        protected void getState()
        {
            con.Open();
            DataTable dt = new DataTable();
            string qry = "select State_Code, State_Name from SPCN_State_Master";
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adpt = new SqlDataAdapter(qry, con);
            adpt.Fill(dt);
            con.Close();
            ddlState.DataSource = dt;
            ddlState.DataTextField = "State_Name";
            ddlState.DataValueField = "State_Code";
            ddlState.DataBind();
            ddlState.Items.Insert(0, "Select");
        }
        protected void getCity()
        {
            con.Open();
            DataTable dt = new DataTable();
            string qry = "select City_Code, City_Name from SPCN_City_Master";
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adpt = new SqlDataAdapter(qry, con);
            adpt.Fill(dt);
            con.Close();
            ddlcity.DataSource = dt;
            ddlcity.DataTextField = "City_Name";
            ddlcity.DataValueField = "City_Code";
            ddlcity.DataBind();
            ddlcity.Items.Insert(0, "Select");
        }
        protected void getCity(object sender, EventArgs e)
        {
            con.Open();
            string stateId = ddlState.SelectedItem.Value;
            DataTable dt = new DataTable();
            string qry = "select City_Code, City_Name from SPCN_City_Master where State_Code='" + stateId + "'";
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adpt = new SqlDataAdapter(qry, con);
            adpt.Fill(dt);
            con.Close();
            ddlcity.DataSource = dt;
            if (dt != null && dt.Rows.Count > 0)
            {
                ddlcity.Enabled = true;
                ddlcity.DataTextField = "City_Name";
                ddlcity.DataValueField = "City_Code";
                ddlcity.DataBind();
            }
            else
            {
                ddlcity.Enabled = false;
                ddlcity.Items.Insert(0, new ListItem("Select City", "0"));
            }
        }
        protected void BindUserMaster()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objBL_User_Master.BL_BindUser(objML_User_Master);
                if (dt.Rows.Count > 0)
                {
                    GrduserMaster.DataSource = dt;
                    GrduserMaster.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('No Data Found)", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + " ')", true);
            }
        }
        protected void GrduserMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrduserMaster.PageIndex = e.NewPageIndex;
            BindUserMaster();
        }
        protected void Delete(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            {
                Label lblID = (Label)gvr.FindControl("lblUserID");
                DataTable dt = new DataTable();
                objML_User_Master.ID = lblID.Text != "" ? lblID.Text : null;
                int x = objBL_User_Master.BL_DeleteUserDetail(objML_User_Master);
                if (x == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Delete')", true);
                    BindUserMaster();
                }
            }
        }
        protected void Update(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
                {
                    Label lblProgramsID = (Label)gvr.FindControl("lblUserID");
                    DataTable dt = new DataTable();
                    string ActiveUser = "";
                    objML_User_Master.ID = lblProgramsID.Text != "" ? lblProgramsID.Text : null;
                    dt = objBL_User_Master.BL_EditUserDetail(objML_User_Master);
                    if (dt.Rows.Count > 0)
                    {
                        lblID.Text = dt.Rows[0]["USerID"].ToString();
                        txtUserName.Text = dt.Rows[0]["UserName"].ToString();
                        txtlastName.Text = dt.Rows[0]["LastName"].ToString();
                        txtEmailID.Text = dt.Rows[0]["EmailID"].ToString();
                        txtPhoneNo.Text = dt.Rows[0]["PhoneNo"].ToString();
                        txtAddress.Text = dt.Rows[0]["Address"].ToString();
                        if (clsCommon.myLen(dt.Rows[0]["city"]) > 0)
                        {
                            ddlcity.SelectedValue = dt.Rows[0]["city"].ToString();
                        }
                        if (clsCommon.myLen(dt.Rows[0]["state"]) > 0)
                        {
                            ddlState.SelectedValue = dt.Rows[0]["State"].ToString();
                        }
                                               
                        ActiveUser = dt.Rows[0]["Activation"].ToString();
                        if (ActiveUser == "True")
                        {
                            chkActive.Checked = true;
                        }
                        else
                        {
                            chkActive.Checked = false;
                        }
                        txtCountry.Text = dt.Rows[0]["Country"].ToString();                        
                        btnSave.Text = "Update";

                    }

                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
    }
}