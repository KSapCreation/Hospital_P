using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using hotelManagement.H.layers.BusinessLayers;
using hotelManagement.H.layers.ModelLayers;

namespace hotelManagement.H
{
    public partial class ADT : System.Web.UI.Page
    {
        protected bool blAccess = true;
        BL_Patient objBL_Patient = new BL_Patient();
        ML_Patient objML_Patient = new ML_Patient();
        CommonClass objCommonClass = new CommonClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                BindPatientList();
            }
        }
        protected void BindPatientList()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objBL_Patient.BL_BindPatientList(objML_Patient);
                if (dt.Rows.Count > 0)
                {
                    GrdPatientList.DataSource = dt;
                    GrdPatientList.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('No Records Found');", true);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('System Problem');", true);
            }
        }

        protected void GrdPatientList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdPatientList.PageIndex = e.NewPageIndex;
            BindPatientList();
        }

    }
}