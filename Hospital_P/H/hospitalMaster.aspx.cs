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
    public partial class HospitalMaster : System.Web.UI.Page
    {
        BL_HospitalMaster objBL_Hospital_Master = new BL_HospitalMaster();
        ML_Hospital_Master objML_Hospital_Master = new ML_Hospital_Master();

        protected bool blAccess = true;
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        CommonClass objCommonClass = new CommonClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }               
            if (!IsPostBack)
            {
                getState();
                BindHospital();
            }            
        }

        protected void btnSaved(object sender, EventArgs e)
        {
            try
            {
                if (txtHospitalName.Text == "")
                {
                    txtHospitalName.Focus();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Hospital Name')", true);
                }
                else if (txtDate.Text == "")
                {
                    txtDate.Focus();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Choose created date')", true);
                }
                else if (txtAddress.Text == "")
                {
                    txtAddress.Focus();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Address')", true);
                }
                else if (checkHMS.Checked)
                {
                    if (txtProductName.Text == "")
                    {
                        txtAddress.Focus();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Product Name')", true);
                    }
                }

                if (btnSave.Text == "Save") // when save
                {
                    con.Open();
                    SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);
                    string qry = "";
                    qry = "select MAX(HospitalId) as HospitalId from SPCN_Hospital_Master";
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(qry, con);
                    cmd.Transaction = trans;
                    cmd.Clone();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        objML_Hospital_Master.HospitalNo = dr["HospitalId"].ToString();
                    }
                    if (objML_Hospital_Master.HospitalNo == null || objML_Hospital_Master.HospitalNo.Length <= 0 || objML_Hospital_Master.HospitalNo.Equals(""))
                    {
                        objML_Hospital_Master.HospitalNo = "HS000000001";
                    }
                    else
                    {
                        objML_Hospital_Master.HospitalNo = clsCommon.incval(objML_Hospital_Master.HospitalNo);
                    }
                    con.Close();

                    objML_Hospital_Master.HospitalName = txtHospitalName.Text;
                    objML_Hospital_Master.Address = txtAddress.Text;
                    objML_Hospital_Master.CreateDate = txtDate.Text;
                    objML_Hospital_Master.StateId = ddState.SelectedValue;
                    objML_Hospital_Master.CityId = ddlCity.SelectedValue;
                    objML_Hospital_Master.Website = txtWebsite.Text;
                    if (checkHMS.Checked)
                        objML_Hospital_Master.IsHms = "1";
                    else
                        objML_Hospital_Master.IsHms = "0";
                    objML_Hospital_Master.ProductName = txtProductName.Text;
                    objML_Hospital_Master.HospitalType = ddHospitalType.SelectedValue;
                    objML_Hospital_Master.CreatedBy = Session["UserName"].ToString();
                    objML_Hospital_Master.ModifyBy = Session["UserName"].ToString();

                    int x = objBL_Hospital_Master.BL_InsHospitalMaster(objML_Hospital_Master);
                    if (x == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data saved successfully')", true);
                        txtHospitalNo.Text = objML_Hospital_Master.HospitalNo;
                        btnSave.Text = "Update";
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Something wrong, please try again')", true);
                    }

                }
                else // when update
                {
                    objML_Hospital_Master.HospitalNo = txtHospitalNo.Text != "" ? txtHospitalNo.Text:"";
                    objML_Hospital_Master.HospitalName = txtHospitalName.Text != "" ? txtHospitalName.Text:"";
                    objML_Hospital_Master.Address = txtAddress.Text;
                    objML_Hospital_Master.CreateDate = txtDate.Text;
                    objML_Hospital_Master.StateId = ddState.SelectedValue;
                    objML_Hospital_Master.CityId = ddlCity.SelectedValue;
                    objML_Hospital_Master.Website = txtWebsite.Text;
                    if (checkHMS.Checked)
                        objML_Hospital_Master.IsHms = "1";
                    else
                        objML_Hospital_Master.IsHms = "0";
                    objML_Hospital_Master.ProductName = txtProductName.Text != "" ? txtProductName.Text:"";
                    objML_Hospital_Master.HospitalType = ddHospitalType.SelectedValue;
                    objML_Hospital_Master.CreatedBy = Session["UserName"].ToString();
                    objML_Hospital_Master.ModifyBy = Session["UserName"].ToString();

                    int x = objBL_Hospital_Master.BL_InsHospitalMaster(objML_Hospital_Master);
                    if (x == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data update successfully')", true);
                        txtHospitalNo.Text = objML_Hospital_Master.HospitalNo;
                        btnSave.Text = "Update";
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Something wrong, please try again')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + " ')", true);
            }
        }

        protected void btnClear(object sender, EventArgs e)
        {
            txtAddress.Text = "";
            txtHospitalName.Text = "";
            txtHospitalNo.Text = "";
            txtWebsite.Text = "";
            txtProductName.Text = "";
            txtDate.Text = "";
            checkHMS.Checked = false;
            btnSave.Text = "Save";
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
            ddState.DataSource = dt;
            ddState.DataTextField = "State_Name";
            ddState.DataValueField = "State_Code";
            ddState.DataBind();
            ddState.Items.Insert(0, "Select");
        }

        protected void getCity(object sender, EventArgs e)
        {
            con.Open();
            string stateId = ddState.SelectedItem.Value;
            DataTable dt = new DataTable();
            string qry = "select City_Code, City_Name from SPCN_City_Master where State_Code='" + stateId + "'";
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adpt = new SqlDataAdapter(qry, con);
            adpt.Fill(dt);
            con.Close();
            ddlCity.DataSource = dt;
            if (dt != null && dt.Rows.Count > 0)
            {
                ddlCity.Enabled = true;
                ddlCity.DataTextField = "City_Name";
                ddlCity.DataValueField = "City_Code";
                ddlCity.DataBind();
            }
            else
            {
                ddlCity.Enabled = false;
                ddlCity.Items.Insert(0, new ListItem("Select City", "0"));
            } 
        }
        protected void BindHospital()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objBL_Hospital_Master.BL_BindHospital(objML_Hospital_Master);
                if (dt.Rows.Count > 0)
                {
                    GrdHospital.DataSource = dt;
                    GrdHospital.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + " ')", true);
            }
        }
        protected void GrdHospital_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdHospital.PageIndex = e.NewPageIndex;
            BindHospital();
        }
    }
}