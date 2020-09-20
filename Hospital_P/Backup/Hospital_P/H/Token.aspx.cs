using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospital_P.H.layers.BusinessLayers;
using Hospital_P.H.layers.ModelLayers;
using System.Text;
using System.Data;
using System.Net;
using Hospital_P.H;
using System.Data.SqlClient;
using Hospital_P.H.layers.DataLayers;
using common;
using System.Configuration;

namespace Hospital_P.H
{
    public partial class Token : System.Web.UI.Page
    {
        BL_Patient objBL_Patient = new BL_Patient();
        ML_Patient ObjML_Patient = new ML_Patient();
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        System.Data.DataTable mytable = new System.Data.DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
               
            }
        }
        protected void Save(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);
                if (btnSave.Text == "Save")
                {
                  
                    string qry1 = "";
                    qry1 = "select  MAX(TokenID) as TokenID  from SPCN_Token_Master where Slip_No='"+ txtPatientID.Text +"' ";
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1 = new SqlCommand(qry1, con);
                    cmd1.Transaction = trans;
                    cmd1.Clone();
                    SqlDataReader dr1 = cmd1.ExecuteReader();
                    while (dr1.Read())
                    {
                        ObjML_Patient.ID = dr1["TokenID"].ToString();           
                        
                    }
                    dr1.Close();
                    if (ObjML_Patient.ID == null || ObjML_Patient.ID.Length <= 0 || ObjML_Patient.ID.Equals(""))
                    {

                        string qry = "";
                        qry = "select  MAX(TokenID) as TokenID  from SPCN_Token_Master ";
                        SqlCommand cmd = new SqlCommand();
                        cmd = new SqlCommand(qry, con);
                        cmd.Transaction = trans;
                        cmd.Clone();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            ObjML_Patient.ID = dr["TokenID"].ToString();
                        }
                        if (ObjML_Patient.ID == null || ObjML_Patient.ID.Length <= 0 || ObjML_Patient.ID.Equals(""))
                        {
                            ObjML_Patient.ID = "TKN000000001";
                        }
                        else
                        {
                            ObjML_Patient.ID = clsCommon.incval(ObjML_Patient.ID);
                        }
                        con.Close();

                        ObjML_Patient.FirstName = txtPatientID.Text != "" ? txtPatientID.Text : null;
                        ObjML_Patient.CreatedBy = Session["UserName"].ToString();
                        ObjML_Patient.ModifyBy = Session["UserName"].ToString();
                        ObjML_Patient.AppointmentNo = txtPatientID.Text != "" ? txtPatientID.Text : null;
                        int x = objBL_Patient.BL_InsUpdToken(ObjML_Patient);
                        if (x == 1)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Token Created')", true);
                            TokenID.Visible = true;
                            lblTokenNo.Text = ObjML_Patient.ID;

                        }                       
                    }
                    else
                    {
                        VerifyToken(txtPatientID.Text);
                    }
                }
                else if (btnSave.Text == "Search")
                {
                    DataTable dt = new DataTable();
                    ObjML_Patient.ID = txtPatientID.Text != "" ? txtPatientID.Text : null;
                    dt = objBL_Patient.BL_SearchApplicant(ObjML_Patient);
                    if (dt.Rows.Count > 0)
                    {
                        Applicant.Visible = true;
                        lblFirstName.Text = dt.Rows[0]["Name"].ToString() + ' ' + dt.Rows[0]["LastName"].ToString();
                        btnSave.Text = "Save";
                    }
                }
                
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
        private void VerifyToken(string SlipNo)
        {
            DataTable dt = new DataTable();
            ObjML_Patient.ID = txtPatientID.Text != "" ? txtPatientID.Text : null;
            dt = objBL_Patient.BL_BindToken(ObjML_Patient);
            if (dt.Rows.Count > 0)
            {
                Applicant.Visible = true;
                TokenID.Visible = true;
                lblTokenNo.Text = dt.Rows[0]["TokenID"].ToString();
                btnSave.Text = "Search";
                ObjML_Patient.ID = dt.Rows[0]["TokenID"].ToString();
            }
        }
        protected void Cancel(object sender, EventArgs e)
        {
            txtPatientID.Text = "";
            btnSave.Text = "Search";
            TokenID.Visible = false;
            lblTokenNo.Text = "";
            Applicant.Visible = false;
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
                    com.CommandText = "select Slip_No from SPCN_Slip_Book_Entry where " + "Slip_No like '%' + @Search + '%'";

                    com.Parameters.AddWithValue("@Search", prefixText);
                    com.Connection = con;
                    con.Open();
                    List<string> countryNames = new List<string>();
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            countryNames.Add(sdr["Slip_No"].ToString());
                            
                        }
                    }
                    con.Close();
                    return countryNames;


                }

            }

        }  
    }
}