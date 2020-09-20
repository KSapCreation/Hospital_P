using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospital_P.H.layers.BusinessLayers;
using Hospital_P.H.layers.ModelLayers;
using Hospital_P.H.layers.DataLayers;
using common;

namespace Hospital_P.H
{
    public partial class LaboratoryEntry : System.Web.UI.Page
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
                BindTest();
                BindLabEntry();
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
                    com.CommandText = "select Patient_ID from SPCN_PATEINT_REGISTRATION_ENTRY where " + "Patient_ID like '%' + @Search + '%'";

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
            DataTable dt = new DataTable();
            objML_Laboratory.ID = txtPatientID.Text != "" ? txtPatientID.Text : null;
            dt = objBL_Laboratory.BL_SearchPatient(objML_Laboratory);
            if (dt.Rows.Count > 0)
            {
                txtPatientName.Text = dt.Rows[0]["Name"].ToString();
                txtDepartment.Text = dt.Rows[0]["DepartmentName"].ToString();
                
            }
        }
        private void BindTest()
        {
            DataTable dt = new System.Data.DataTable();
            dt = objBL_Laboratory.BL_BindTestMaster(objML_Laboratory);
            if (dt.Rows.Count > 0)
            {
                ddlTest.DataSource = dt;
                ddlTest.DataValueField = "TestID";
                ddlTest.DataTextField = "TestName";
                ddlTest.DataBind();
                ddlTest.Items.Insert(0, "Select");
            }
        }
        protected void FetchCost(object sender, EventArgs e)
        {
            DataTable dt = new System.Data.DataTable();
            objML_Laboratory.ID = ddlTest.SelectedValue != "" ? ddlTest.SelectedValue : null;
            dt = objBL_Laboratory.BL_EditTestMaster(objML_Laboratory);
            if (dt.Rows.Count > 0)
            {
                txtCost.Text = dt.Rows[0]["Cost"].ToString();
            }
        }
        protected void Cancel(object sender, EventArgs e)
        {
            Reset();
        }
        private void Reset()
        {
            txtCost.Text = "";
            txtDepartment.Text = "";
            txtLabTestID.Text = "";
            txtPatientID.Text = "";
            txtPatientName.Text = "";
            ddlTest.SelectedIndex = 0;
        }
        protected void Save(object sender, EventArgs e)
        {
            try
            {
                if (txtPatientID.Text == "")
                {
                    txtPatientID.Focus();
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Fill Patient ID');", true);
                }
                else if (btnSave.Text == "Save")
                {
                    con.Open();
                    SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);

                    string qry = "";
                    qry = "select  MAX(LTE_Code) as LTE_Code  from SPCN_Lab_Test_Entry ";
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(qry, con);
                    cmd.Transaction = trans;
                    cmd.Clone();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        objML_Laboratory.ID = dr["LTE_Code"].ToString();
                    }
                    if (clsCommon.myLen(objML_Laboratory.ID) <= 0)
                    {
                        objML_Laboratory.ID = "LTE000000001";
                    }
                    else
                    {
                        objML_Laboratory.ID = clsCommon.incval(objML_Laboratory.ID);
                    }
                    con.Close();
                    objML_Laboratory.PatientID = txtPatientID.Text != "" ? txtPatientID.Text : null;
                    objML_Laboratory.Name = txtPatientName.Text != "" ? txtPatientName.Text : null;
                    objML_Laboratory.TestID = ddlTest.SelectedValue != "" ? ddlTest.SelectedValue : null;
                    objML_Laboratory.Cost = txtCost.Text != "" ? txtCost.Text : null;
                    objML_Laboratory.CreatedBy = Session["UserName"].ToString();
                    objML_Laboratory.ModifyBy = Session["UserName"].ToString();
                    int x = objBL_Laboratory.BL_InsUpdLabTestEntry(objML_Laboratory);
                    if (x == 1)
                    {                        
                        txtLabTestID.Text = objML_Laboratory.ID;
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data Saved.');", true);
                        BindLabEntry();
                    }
                }
                else
                {
                    objML_Laboratory.ID = txtLabTestID.Text != "" ? txtLabTestID.Text : null;
                    objML_Laboratory.PatientID = txtPatientID.Text != "" ? txtPatientID.Text : null;
                    objML_Laboratory.Name = txtPatientName.Text != "" ? txtPatientName.Text : null;
                    objML_Laboratory.TestID = ddlTest.SelectedValue != "" ? ddlTest.SelectedValue : null;
                    objML_Laboratory.Cost = txtCost.Text != "" ? txtCost.Text : null;
                    objML_Laboratory.CreatedBy = Session["UserName"].ToString();
                    objML_Laboratory.ModifyBy = Session["UserName"].ToString();
                    int x = objBL_Laboratory.BL_InsUpdLabTestEntry(objML_Laboratory);
                    if (x == 1)
                    {                       
                        txtLabTestID.Text = objML_Laboratory.ID;
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data Saved.');", true);
                        BindLabEntry();
                    }
                }
               
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
        private void BindLabEntry()
        {
            DataTable dt = new DataTable();
            dt = objBL_Laboratory.BL_SelectLabEntry(objML_Laboratory);
            if (dt.Rows.Count > 0)
            {
                GrdTest.DataSource = dt;
                GrdTest.DataBind();
            }
        }
        protected void Delete(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            {
                Label lblID = (Label)gvr.FindControl("lblLTECode");
                DataTable dt = new DataTable();
                objML_Laboratory.ID = lblID.Text != "" ? lblID.Text : null;
                int x = objBL_Laboratory.BL_DeleteLabTestEntry(objML_Laboratory);
                if (x == 1)
                {                    
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Delete');", true);
                    BindLabEntry();
                }
            }
        }
        protected void Update(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
                {
                    Label lblProgramsID = (Label)gvr.FindControl("lblLTECode");
                    DataTable dt = new DataTable();
                    objML_Laboratory.ID = lblProgramsID.Text != "" ? lblProgramsID.Text : null;
                    dt = objBL_Laboratory.BL_EditLabTestEntry(objML_Laboratory);
                    if (dt.Rows.Count > 0)
                    {
                        txtLabTestID.Text = dt.Rows[0]["LTE_Code"].ToString();
                        txtPatientID.Text = dt.Rows[0]["PatientID"].ToString();
                        txtPatientName.Text = dt.Rows[0]["PatientName"].ToString();
                        txtCost.Text = dt.Rows[0]["Cost"].ToString();
                        ddlTest.SelectedValue = dt.Rows[0]["TestID"].ToString();                      
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