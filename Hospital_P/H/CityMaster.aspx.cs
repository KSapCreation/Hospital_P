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
    public partial class CityMaster : System.Web.UI.Page
    {
        protected bool blAccess = true;
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        CommonClass objCommonClass = new CommonClass();

        BL_City_Master objBL_City_Master = new BL_City_Master();
        ML_City_Master objML_City_Master = new ML_City_Master();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {                
                 getState();
                 BindCity();
            }
           
        }

        protected void btnSaved(object sender, EventArgs e)
        {
            try
            {
                if (txtCityName.Text.ToString() != null && txtCityName.Text.ToString().Length > 0)
                {
                    if (btnSave.Text == "Save")
                    {
                        con.Open();
                        SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);
                        string qry = "";
                        qry = "select  MAX(City_code) as CityID from SPCN_City_Master";
                        SqlCommand cmd = new SqlCommand();
                        cmd = new SqlCommand(qry, con);
                        cmd.Transaction = trans;
                        cmd.Clone();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            objML_City_Master.CityId = dr["CityID"].ToString();
                        }
                        if (objML_City_Master.CityId == null || objML_City_Master.CityId.Length <= 0 || objML_City_Master.CityId.Equals(""))
                        {
                            objML_City_Master.CityId = "CT000000001";
                        }
                        else
                        {
                            objML_City_Master.CityId = clsCommon.incval(objML_City_Master.CityId);
                        }
                        con.Close();

                        objML_City_Master.CityName = txtCityName.Text != "" ? txtCityName.Text : "";
                        objML_City_Master.StateId = ddlState.SelectedValue.ToString();
                        objML_City_Master.CreatedBy = Session["UserName"].ToString();
                        objML_City_Master.ModifyBy = Session["UserName"].ToString();

                        int x = objBL_City_Master.BL_InsCityDetail(objML_City_Master);
                        if (x == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data saved successfully')", true);
                            txtCityId.Text = objML_City_Master.CityId;
                            btnSave.Text = "Update";
                            BindCity();
                        }
                        }
                        else // data modify
                        {
                            objML_City_Master.CityId = txtCityId.Text != "" ? txtCityId.Text : "";
                            objML_City_Master.CityName = txtCityName.Text != "" ? txtCityName.Text : "";
                            objML_City_Master.StateId = ddlState.SelectedValue.ToString();
                            objML_City_Master.CreatedBy = Session["UserName"].ToString();
                            objML_City_Master.ModifyBy = Session["UserName"].ToString();

                            int x = objBL_City_Master.BL_InsCityDetail(objML_City_Master);
                            if (x == 1)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data updated successfully')", true);
                                txtCityId.Text = objML_City_Master.CityId;
                                btnSave.Text = "Update";
                                BindCity();
                            }
                        }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Please enter city name')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + " ')", true);
            }
        }

        protected void btnClear(object sender, EventArgs e)
        {
            txtCityName.Text = "";
            txtCityId.Text = "";
            ddlState.SelectedIndex = 0;
            btnSave.Text = "Save";

        }

        private void getState()
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

        private void BindCity()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objBL_City_Master.BL_BindCity(objML_City_Master);
                if (dt.Rows.Count > 0)
                {
                    GrdCity.DataSource = dt;
                    GrdCity.DataBind();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
        protected void GrdCity_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdCity.PageIndex = e.NewPageIndex;
            BindCity();
        }
        protected void Delete(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            {
                Label lblID = (Label)gvr.FindControl("lblAccountType");
                DataTable dt = new DataTable();
                objML_City_Master.CityId = lblID.Text != "" ? lblID.Text : null;
                int x = objBL_City_Master.BL_DeleteCity(objML_City_Master);
                if (x == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Delete')", true);
                    BindCity();
                }
            }
        }
        protected void Update(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
                {
                    Label lblProgramsID = (Label)gvr.FindControl("lblAccountType");
                    DataTable dt = new DataTable();
                    objML_City_Master.CityId = lblProgramsID.Text != "" ? lblProgramsID.Text : null;
                    dt = objBL_City_Master.BL_EditCity(objML_City_Master);
                    if (dt.Rows.Count > 0)
                    {
                        txtCityId.Text = dt.Rows[0]["City_Code"].ToString();
                        txtCityName.Text = dt.Rows[0]["City_Name"].ToString();
                        ddlState.SelectedValue = dt.Rows[0]["State_Code"].ToString();
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