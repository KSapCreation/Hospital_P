using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Hospital_P.H.layers.BusinessLayers;
using Hospital_P.H.layers.ModelLayers;

namespace Hospital_P.H
{
    public partial class Discharge : System.Web.UI.Page
    {
        protected bool blAccess = true;
        BL_Patient objBL_Patient = new BL_Patient();
        ML_Patient objML_Patient = new ML_Patient();
        Label lblID = new Label();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetCompletionList(string prefixText, int count)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.AppSettings["Hospital"];

                using (SqlCommand com = new SqlCommand())
                {
                    com.CommandText = "select Patient_ID,Patient_ID+' '+Patient_FirstName+' '+Patient_LastName as Name from SPCN_PATEINT_REGISTRATION_ENTRY where " + "Patient_FirstName like '%' + @Search + '%'";

                    com.Parameters.AddWithValue("@Search", prefixText);
                    com.Connection = con;
                    con.Open();
                    List<string> countryNames = new List<string>();
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            countryNames.Add(sdr["Patient_ID"].ToString());
                            
                       }
                    }
                    con.Close();
                    return countryNames;
                    
                }
            }
        }
        protected void Search(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                objML_Patient.ID = txtSerach.Text != "" ? txtSerach.Text : null;
                dt = objBL_Patient.BL_SerachPatient(objML_Patient);
                if (dt.Rows.Count > 0)
                {
                    lblPatientNo.Text = dt.Rows[0]["Patient_ID"].ToString();
                    lblName.Text = dt.Rows[0]["Name"].ToString();
                    lblAge.Text = dt.Rows[0]["Age"].ToString();
                    lblAddmissionDate.Text = dt.Rows[0]["AdmissionDate"].ToString();
                    lblDep.Text = dt.Rows[0]["DepartmentName"].ToString();
                    lblDoctor.Text = dt.Rows[0]["Ref_Under_Doc"].ToString();
                    RefBy.Text = dt.Rows[0]["Ref_By"].ToString();
                    lblWardBed.Text = dt.Rows[0]["WardName"].ToString();
                    lblgender.Text = dt.Rows[0]["Gender"].ToString();

                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
    }
}