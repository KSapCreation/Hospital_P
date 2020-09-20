using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using hotelManagement.H.layers.BusinessLayers;
using hotelManagement.H.layers.ModelLayers;
using System.Text;
using System.Data;
using System.Net;
using hotelManagement.H;
using System.Data.SqlClient;
using hotelManagement.H.layers.DataLayers;
using common;
using System.Web.Services;
using System.Configuration;

namespace hotelManagement.H
{
    public partial class TokanComplete : System.Web.UI.Page
    {
        BL_Patient objBL_Patient = new BL_Patient();
        ML_Patient objML_Patient = new ML_Patient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                BindTokenDisplay();
            }
        }
        protected void BindTokenDisplay()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objBL_Patient.BL_DisplayToken(objML_Patient);
                if (dt.Rows.Count > 0)
                {
                    GrdDoctorTokan.DataSource = dt;
                    GrdDoctorTokan.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('No Token Display')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
        protected void GrdDoctorTokan_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdDoctorTokan.PageIndex = e.NewPageIndex;
            BindTokenDisplay();
        }
    }
}