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
    public partial class StateMaster : System.Web.UI.Page
    {
        BL_State_Master objBL_User_Master = new BL_State_Master();
        ML_State_Master objML_User_Master = new ML_State_Master();

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
                BindState();
            }
        }


        protected void btnSaved(object sender, EventArgs e)
        {
            try
            {
                if (txtStateName.Text.ToString() != null && txtStateName.Text.ToString().Length > 0)
                {
                    if (btnSave.Text == "Save")
                    {
                        con.Open();
                        SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);
                        string qry = "";
                        qry = "select  MAX(State_Code) as StateID  from SPCN_State_Master ";
                        SqlCommand cmd = new SqlCommand();
                        cmd = new SqlCommand(qry, con);
                        cmd.Transaction = trans;
                        cmd.Clone();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            objML_User_Master.StateId = dr["StateID"].ToString();
                        }
                        if (objML_User_Master.StateId == null || objML_User_Master.StateId.Length <= 0 || objML_User_Master.StateId.Equals(""))
                        {
                            objML_User_Master.StateId = "ST000000001";
                        }
                        else
                        {
                            objML_User_Master.StateId = clsCommon.incval(objML_User_Master.StateId);
                        }
                        con.Close();

                        objML_User_Master.StateName = txtStateName.Text != "" ? txtStateName.Text : "";
                        objML_User_Master.CreatedBy = Session["UserName"].ToString();
                        objML_User_Master.ModifyBy = Session["UserName"].ToString();

                        int x = objBL_User_Master.BL_InsStateDetail(objML_User_Master);
                        if (x == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data saved successfully')", true);
                            txtSateId.Text = objML_User_Master.StateId;
                            btnSave.Text = "Update";
                            BindState();
                        }
                    }
                    else // data modify
                    {
                        objML_User_Master.StateName = txtStateName.Text != "" ? txtStateName.Text : "";
                        objML_User_Master.CreatedBy = Session["UserName"].ToString();
                        objML_User_Master.ModifyBy = Session["UserName"].ToString();
                        objML_User_Master.StateId = txtSateId.Text != "" ? txtSateId.Text : "";

                        int x = objBL_User_Master.BL_InsStateDetail(objML_User_Master);
                        if (x == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data updated successfully')", true);
                            txtSateId.Text = objML_User_Master.StateId;
                            btnSave.Text = "Update";
                            BindState();
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Please enter state name')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + " ')", true);
            }
        }

        protected void btnClear(object sender, EventArgs e)
        {
            txtStateName.Text = "";
            btnSave.Text = "Save";
            txtSateId.Text = "";
        }
        private void BindState()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objBL_User_Master.BL_BindState(objML_User_Master);
                if (dt.Rows.Count > 0)
                {
                    GrdState.DataSource = dt;
                    GrdState.DataBind();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
        protected void GrdState_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdState.PageIndex = e.NewPageIndex;
            BindState();
        }
        protected void Delete(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            {
                Label lblID = (Label)gvr.FindControl("lblAccountType");
                DataTable dt = new DataTable();
                objML_User_Master.StateId = lblID.Text != "" ? lblID.Text : null;
                int x = objBL_User_Master.BL_DeleteState(objML_User_Master);
                if (x == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Delete')", true);
                    BindState();
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
                    objML_User_Master.StateId = lblProgramsID.Text != "" ? lblProgramsID.Text : null;
                    dt = objBL_User_Master.BL_EditState(objML_User_Master);
                    if (dt.Rows.Count > 0)
                    {
                        txtSateId.Text = dt.Rows[0]["State_Code"].ToString();
                        txtStateName.Text = dt.Rows[0]["State_Name"].ToString();
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