using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using hotelManagement.H.layers.BusinessLayers;
using hotelManagement.H.layers.ModelLayers;
using hotelManagement.H.layers.DataLayers;
using common;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace hotelManagement.H
{
    public partial class Permissions : System.Web.UI.Page
    {
        BL_Security objBL_Security = new BL_Security();
        ML_Secuirty objML_Secuirty = new ML_Secuirty();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                BindModules();
            }
        }
        protected void BindModules()
        {
            DataTable dt = new DataTable();
            dt = objBL_Security.BL_BindModules(objML_Secuirty);
            if (dt.Rows.Count > 0)
            {
                GrdModules.DataSource = dt;
                GrdModules.DataBind();
            }
        }
        protected void GrdModules_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdModules.PageIndex = e.NewPageIndex;
            BindModules();
        }
        
        protected void Save(object sender, EventArgs e)
        {
            try 
            {
                int i = 0;
                int j = 0;
                if (txtUserName.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('First fill User Name !');", true);
                }
                foreach (GridViewRow gvr in GrdModules.Rows)
                {
                    CheckBox chkSelect = ((CheckBox)gvr.FindControl("chkModules"));
                    if (chkSelect.Checked == true)
                    {
                        j = j + 1;
                    }
                }
                if (j <= 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please Select Atleast One Modules !');", true);
                }
                else
                {
                    foreach (GridViewRow gvr in GrdModules.Rows)
                    {
                        Label lblModuleID = ((Label)gvr.FindControl("lblParameterID"));
                        Label lblModule = ((Label)gvr.FindControl("lblModule"));
                        CheckBox chkSelect = ((CheckBox)gvr.FindControl("chkModules"));

                        if (chkSelect.Checked == true)
                        {
                            objML_Secuirty.Select = 1;
                        }
                        else
                        {
                            objML_Secuirty.Select = 0;
                        }
                        objML_Secuirty.Modules = lblModule.Text != "" ? lblModule.Text : null;
                        objML_Secuirty.ModulesID = lblModuleID.Text != "" ? lblModuleID.Text : null;
                        objML_Secuirty.UserName = txtUserName.Text != "" ? txtUserName.Text : null;

                        int x = objBL_Security.BL_InsUpdModules(objML_Secuirty);
                        if (x == 1)
                        { }

                        i = i + 1;
                    }
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('User Permissions Complete. ');", true);
                    btnSave.Text = "Update";
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void SelectUserModule(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            objML_Secuirty.UserName = txtUserName.Text != "" ? txtUserName.Text : null;
            dt = objBL_Security.BL_SelectUserModules(objML_Secuirty);
            if (dt.Rows.Count > 0)
            {
                GrdModules.DataSource = dt;
                GrdModules.DataBind();
            }
        }
        protected void Clear(object sender, EventArgs e)
        {
            BindModules();
            txtUserName.Text = "";
        }
    }
}