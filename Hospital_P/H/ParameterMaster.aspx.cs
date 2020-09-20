using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using hotelManagement.H.layers.BusinessLayers;
using hotelManagement.H.layers.ModelLayers;
using System.Data.SqlClient;
using hotelManagement.H.layers.DataLayers;
using common;

namespace hotelManagement.H
{
    public partial class ParameterMaster : System.Web.UI.Page
    {
        BL_Laboratory objBL_Laboratory = new BL_Laboratory();
        ML_Laboratory objML_Laboratory = new ML_Laboratory();
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                BindParameter();
            }
        }
        protected void Save(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);
                if (txtParamterName.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Fill Parameter Name')", true);
                }
                
                else if (btnSave.Text == "Save")
                {
                    string qry = "";
                    qry = "select  MAX(ParameterID) as ParameterID  from SPCN_Parameter_Master ";
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(qry, con);
                    cmd.Transaction = trans;
                    cmd.Clone();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        objML_Laboratory.ID = dr["ParameterID"].ToString();
                    }
                    if (objML_Laboratory.ID == null || objML_Laboratory.ID.Length <= 0 || objML_Laboratory.ID.Equals(""))
                    {
                        objML_Laboratory.ID = "P000000001";
                    }
                    else
                    {
                        objML_Laboratory.ID = clsCommon.incval(objML_Laboratory.ID);
                    }
                    con.Close();

                    objML_Laboratory.TestName = txtParamterName.Text != "" ? txtParamterName.Text : null;
                    objML_Laboratory.CreatedBy = Session["UserName"].ToString();
                    objML_Laboratory.ModifyBy = Session["UserName"].ToString();
                    objML_Laboratory.DefaultRange = txtefault.Text != "" ? txtefault.Text : null;

                }
                else if (btnSave.Text == "Update")
                {
                    objML_Laboratory.ID = txtTestID.Text != "" ? txtTestID.Text : null;
                    objML_Laboratory.TestName = txtParamterName.Text != "" ? txtParamterName.Text : null;                    
                    objML_Laboratory.CreatedBy = Session["UserName"].ToString();
                    objML_Laboratory.ModifyBy = Session["UserName"].ToString();
                    objML_Laboratory.DefaultRange = txtefault.Text != "" ? txtefault.Text : null;

                }
                int x = objBL_Laboratory.BL_InsParameterMaster(objML_Laboratory);
                if (x == 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Parameter Saved')", true);
                    txtTestID.Text = objML_Laboratory.ID;
                    BindParameter();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
        protected void Cancel(object sender, EventArgs e)
        {
            txtTestID.Text = "";
            txtParamterName.Text = "";
            btnSave.Text = "Save";
            txtefault.Text = "";
        }
        protected void BindParameter()
        {
            try{
                DataTable dt = new DataTable();
                dt = objBL_Laboratory.BL_BindParameter(objML_Laboratory);
                if (dt.Rows.Count > 0)
                {
                    GRdParameter.DataSource = dt;
                    GRdParameter.DataBind();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
        protected void GRdParameter_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GRdParameter.PageIndex = e.NewPageIndex;
            BindParameter();
        }
        protected void Delete(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            {                
                Label lblID = (Label)gvr.FindControl("lblProgramsID");
                DataTable dt = new DataTable();
                objML_Laboratory.ID = lblID.Text != "" ? lblID.Text : null;
                int x = objBL_Laboratory.BL_DeleteParameter(objML_Laboratory);
                if (x == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Delete')", true);
                    BindParameter();
                }
            }
        }
        protected void Update(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
                {
                    Label lblProgramsID = (Label)gvr.FindControl("lblProgramsID");
                    DataTable dt = new DataTable();
                    objML_Laboratory.ID = lblProgramsID.Text != "" ? lblProgramsID.Text : null;
                    dt = objBL_Laboratory.BL_EditParameter(objML_Laboratory);
                    if (dt.Rows.Count > 0)
                    {
                        txtTestID.Text = dt.Rows[0]["ParameterID"].ToString();
                        txtParamterName.Text = dt.Rows[0]["ParameterName"].ToString();
                        txtefault.Text = dt.Rows[0]["DefaultRange"].ToString();
                        btnSave.Text = "Update";
                    }
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
    }
}