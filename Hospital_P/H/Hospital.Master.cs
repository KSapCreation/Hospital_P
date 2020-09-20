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

namespace hotelManagement
{
    public partial class Hospital : System.Web.UI.MasterPage
    {
        BL_HospitalMaster objBL_HospitalMaster = new BL_HospitalMaster();
        ML_HospitalMaster objML_HospitalMaster = new ML_HospitalMaster();
        protected bool blAccess1 = false;
        protected bool blAccess2 = false;
        protected bool blAccess3 = false;
        protected bool blAccess4 = false;
        protected bool blAccess5 = false;
        protected bool blAccess6 = false;
        protected bool blAccess7 = false;
        protected bool blAccess8 = false;
        protected bool blAccess9 = false;
        protected bool blAccess10 = false;
        protected bool blAccess11 = false;
        protected bool blAccess12 = false;
        protected bool blAccess13 = false;
        protected bool blAccess14 = false;
        protected bool blAccess15 = false;
        protected bool blAccess16 = false;        
        protected bool blAccess17 = false;
        protected bool blAccess18 = false;
        


        CommonClass objCommanClass = new CommonClass();


        protected void Page_Load(object sender, EventArgs e)
        {
            blAccess1 = objCommanClass.GetPageAccess(Convert.ToString(Session["UserName"]), "DashBoard");
            blAccess2 = objCommanClass.GetPageAccess(Convert.ToString(Session["UserName"]), "Common Services");
            blAccess3 = objCommanClass.GetPageAccess(Convert.ToString(Session["UserName"]), "Appointment");
            blAccess4 = objCommanClass.GetPageAccess(Convert.ToString(Session["UserName"]), "Patient Management");
            blAccess5 = objCommanClass.GetPageAccess(Convert.ToString(Session["UserName"]), "Token Management");
            blAccess6 = objCommanClass.GetPageAccess(Convert.ToString(Session["UserName"]), "Laborartory Management");
            blAccess7 = objCommanClass.GetPageAccess(Convert.ToString(Session["UserName"]), "Pharmacy Management");
            blAccess8 = objCommanClass.GetPageAccess(Convert.ToString(Session["UserName"]), "Consultant Management");
            blAccess9 = objCommanClass.GetPageAccess(Convert.ToString(Session["UserName"]), "Store Management");
            blAccess10 = objCommanClass.GetPageAccess(Convert.ToString(Session["UserName"]), "Security Management");
            blAccess11 = objCommanClass.GetPageAccess(Convert.ToString(Session["UserName"]), "Payroll & HRD Management");
            blAccess12 = objCommanClass.GetPageAccess(Convert.ToString(Session["UserName"]), "MRD Management");
            blAccess13 = objCommanClass.GetPageAccess(Convert.ToString(Session["UserName"]), "Reception Management");
            blAccess14 = objCommanClass.GetPageAccess(Convert.ToString(Session["UserName"]), "Medical Data");
            blAccess15 = objCommanClass.GetPageAccess(Convert.ToString(Session["UserName"]), "Service Management");
            blAccess16 = objCommanClass.GetPageAccess(Convert.ToString(Session["UserName"]), "Blood Bank Management");
            blAccess17 = objCommanClass.GetPageAccess(Convert.ToString(Session["UserName"]), "Product Management");
            blAccess18 = objCommanClass.GetPageAccess(Convert.ToString(Session["UserName"]), "Hotel Management");
            if (!IsPostBack)
            {
                if (Session["UserName"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                lblUserName.Text = Session["UserName"].ToString();
            }
        }
        protected void BindUserInfo()
        {
            //try
            //{
            //    DataTable dtDep = new DataTable();
            //    objML_HospitalMaster.UserName = Session["UserName"];
            //    dtDep = objBL_Default.BL_BindDepartment(objML_Default);
            //    if (dtDep.Rows.Count > 0)
            //    {
                   
            //    }
            //}
            //catch(Exception ex)
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('"+ ex.Message.ToString() +"')", true);
            //}
        }
    }
}