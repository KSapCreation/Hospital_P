using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using hotelManagement.H.layers.ModelLayers;
using hotelManagement.H.layers.BusinessLayers;
using System.Data;
using System.Data.SqlClient;
using common;
using hotelManagement.H.layers.DataLayers;
using System.Configuration;

namespace hotelManagement.H
{
    public partial class DesignationMaster : System.Web.UI.Page
    {
        protected bool blAccess = true;
        BL_CommonServices objBL_CommonService = new BL_CommonServices();
        ML_CommonServices objML_CommonService = new ML_CommonServices();
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                BindDepartment();
                BindDesignation();

            }
        }
        private void BindDepartment()
        {
            DataTable dt = new DataTable();
            dt = objBL_CommonService.BL_BindDepartment(objML_CommonService);
            if (dt.Rows.Count > 0)
            {
                ddlDepartment.DataSource = dt;
                ddlDepartment.DataTextField = "DepartmentName";
                ddlDepartment.DataValueField = "DepID";
                ddlDepartment.DataBind();
                ddlDepartment.Items.Insert(0, "Select Department");
            }
        }
        private void BindDesignation()
        {
            DataTable dt = new DataTable();
            dt = objBL_CommonService.BL_BindDesigantion(objML_CommonService);
            if (dt.Rows.Count > 0)
            {
                GrdItemList.DataSource = dt;
                GrdItemList.DataBind();
            }
        }
        protected void GrdItemList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdItemList.PageIndex = e.NewPageIndex;
            BindDesignation();
        }
        protected void Save(object sender, EventArgs e)
        {
            try
            {
                if (txtDesName.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('Enter Designation')", true);
                }
                else if (btnSave.Text == "Save")
                {
                    con.Open();
                    SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);

                    string qry = "";
                    qry = "select  MAX(DesID) as DesID  from SPCN_Desigantion_Master ";
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(qry, con);
                    cmd.Transaction = trans;
                    cmd.Clone();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        objML_CommonService.ID = dr["DesID"].ToString();
                    }
                    if (clsCommon.myLen(objML_CommonService.ID) <= 0)
                    {
                        objML_CommonService.ID = "DESG000000001";
                    }
                    else
                    {
                        objML_CommonService.ID = clsCommon.incval(objML_CommonService.ID);
                    }
                    con.Close();
                    objML_CommonService.Designation = txtDesName.Text != "" ? txtDesName.Text : null;
                    objML_CommonService.Department = ddlDepartment.SelectedValue != "" ? ddlDepartment.SelectedValue : null;
                    objML_CommonService.CraetedBy = Session["UserName"].ToString();
                    objML_CommonService.ModifyBy = Session["UserName"].ToString();
                    int x = objBL_CommonService.BL_InsUpdDesignation(objML_CommonService);
                    if (x == 1)
                    {
                        BindDesignation();
                        ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('Data Saved')", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('Already Data Saved')", true);
                    }
                }
                else
                {
                    objML_CommonService.ID = txtdesId.Text != "" ? txtdesId.Text : null;
                    objML_CommonService.Designation = txtDesName.Text != "" ? txtDesName.Text : null;
                    objML_CommonService.Department = ddlDepartment.SelectedValue != "" ? ddlDepartment.SelectedValue : null;
                    objML_CommonService.CraetedBy = Session["UserName"].ToString();
                    objML_CommonService.ModifyBy = Session["UserName"].ToString();
                    int x = objBL_CommonService.BL_InsUpdDesignation(objML_CommonService);
                    if (x == 1)
                    {
                        BindDesignation();
                        ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('Data Updated')", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('Already Data Saved')", true);
                    }
                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('" + ex.Message.ToString() + "');", true);
            }
        }

        protected void Clear(object sender, EventArgs e)
        {
            ddlDepartment.SelectedIndex = 0;
            txtDesName.Text = "";
            txtdesId.Text = "";
            btnSave.Text = "Save";
        }
        protected void Delete(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            {
                Label lblID = (Label)gvr.FindControl("lblDesID");
                DataTable dt = new DataTable();
                objML_CommonService.ID = lblID.Text != "" ? lblID.Text : null;
                int x = objBL_CommonService.BL_DeleteDesignation(objML_CommonService);
                if (x == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Delete');", true);
                    BindDesignation();
                }
            }
        }
        protected void Update(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
                {
                    Label lblProgramsID = (Label)gvr.FindControl("lblDesID");
                    DataTable dt = new DataTable();
                    objML_CommonService.ID = lblProgramsID.Text != "" ? lblProgramsID.Text : null;
                    dt = objBL_CommonService.BL_SelectDesingation(objML_CommonService);
                    if (dt.Rows.Count > 0)
                    {
                     
                        txtdesId.Text = dt.Rows[0]["DesID"].ToString();
                        txtDesName.Text = dt.Rows[0]["DesignationName"].ToString();
                        ddlDepartment.SelectedValue = dt.Rows[0]["DepID"].ToString();
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