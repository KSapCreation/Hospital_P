using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospital_P.H.layers.BusinessLayers;
using Hospital_P.H.layers.ModelLayers;
using Hospital_P.H.layers.DataLayers;
using Microsoft.Reporting.WebForms;
using System.Data;
using common;



namespace Hospital_P.H
{
    public partial class LabReport : System.Web.UI.Page
    {
        BL_Laboratory objBL_Laboratory = new BL_Laboratory();
        ML_Laboratory objML_Laboratory = new ML_Laboratory();
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (IsPostBack)
            {

            }
        }
       
        protected void btnPrint(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            objML_Laboratory.PatientName = txtName.Text != "" ? txtName.Text : null;
            //RptLab.ProcessingMode = ProcessingMode.Local;

            string pathdemo = System.AppDomain.CurrentDomain.BaseDirectory;
            RptLab.LocalReport.ReportPath = Server.MapPath("~/Report/Report1.rdlc"); 

            RptLab.LocalReport.EnableExternalImages = true;
            string imagePath = new Uri(Server.MapPath("~/h/img/logo.png")).AbsoluteUri;
            ReportParameter parameter = new ReportParameter("ImagePath", imagePath);
            RptLab.LocalReport.SetParameters(parameter);

            dt = objBL_Laboratory.BL_BindLabReport(objML_Laboratory);
            if (dt.Rows.Count > 0)
            {
                RptLab.Visible = true;
                ReportDataSource datasource = new ReportDataSource("DataSet1", dt);

                RptLab.LocalReport.DataSources.Clear();
                RptLab.LocalReport.DataSources.Add(datasource);

                RptLab.LocalReport.Refresh();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('No Data Found');", true);
                RptLab.Visible = false;
            }

        }
    }
}