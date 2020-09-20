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
using System.Configuration;


namespace hotelManagement.H
{
    public partial class ParameterValues : System.Web.UI.Page
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
        
        protected void Search(object sender, EventArgs e)
        {
            TestParamterValues();
        }
        protected void TestParamterValues()
        {
            DataTable dt = new DataTable();
            objML_Laboratory.ID = txtUserName.Text != "" ? txtUserName.Text : null;
            objML_Laboratory.PatientID = txtPVCode.Text != "" ? txtPVCode.Text : null;
            dt = objBL_Laboratory.BL_TestParameterValues(objML_Laboratory);
            if (dt.Rows.Count > 0)
            {
                lblTestID.Text = dt.Rows[0]["TestID"].ToString();
                DlParametervalues.DataSource = dt;
                DlParametervalues.DataBind();
                btnSave.Visible = true;
                btnCleared.Visible = true;
                btnSave.Text = "Save";

                if (txtPVCode.Text != "")
                {
                    txtUserName.Text = dt.Rows[0]["TestName"].ToString();
                    btnSave.Text = "Update";
                }
            }
        }
        protected void Save(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                int j = 0;
                if (txtUserName.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('First Select Test !');", true);
                }
                foreach (DataListItem dlist in DlParametervalues.Items)
                {
                    TextBox lblParameterValues = ((TextBox)dlist.FindControl("txtParameterValues"));
                    if (lblParameterValues.Text != "")
                    {
                        j = j + 1;
                    }
                }
                if (j <= 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please Fill Atleast One Paramter !');", true);
                }
                else if (btnSave.Text == "Save")
                {
                    con.Open();
                    SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);
                    string qry = "";
                    qry = "select  MAX(PVCode) as PVCode  from SPCN_Test_Paramter_Values_head ";
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(qry, con);
                    cmd.Transaction = trans;
                    cmd.Clone();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        objML_Laboratory.ID = dr["PVCode"].ToString();
                    }
                    if (objML_Laboratory.ID == null || objML_Laboratory.ID.Length <= 0 || objML_Laboratory.ID.Equals(""))
                    {
                        objML_Laboratory.ID = "PV000000001";
                    }
                    else
                    {
                        objML_Laboratory.ID = clsCommon.incval(objML_Laboratory.ID);
                    }
                    con.Close();

                    foreach (DataListItem dlist in DlParametervalues.Items)
                    {
                        Label lblParameterID = ((Label)dlist.FindControl("lblParameterID"));
                        Label ParameterName = ((Label)dlist.FindControl("lblParameterName"));
                        TextBox lblParameterValues = ((TextBox)dlist.FindControl("txtParameterValues"));

                        objML_Laboratory.ParameterID = lblParameterID.Text != "" ? lblParameterID.Text : null;
                        objML_Laboratory.ParameterName = ParameterName.Text != "" ? ParameterName.Text : null;
                        objML_Laboratory.TestName = txtUserName.Text != "" ? txtUserName.Text : null;
                        objML_Laboratory.Parametervalues = lblParameterValues.Text != "" ? lblParameterValues.Text : null;
                        objML_Laboratory.TestID = lblTestID.Text != "" ? lblTestID.Text : null;
                        objML_Laboratory.CreatedBy = Session["Username"].ToString();
                        objML_Laboratory.ModifyBy = Session["Username"].ToString();
                        objML_Laboratory.PatientName = txtPatientName.Text != "" ? txtPatientName.Text : null;

                        int x = objBL_Laboratory.BL_InsUpdParameterValues(objML_Laboratory);
                        int y = objBL_Laboratory.BL_InsUpdParameterValuesDetail(objML_Laboratory);
                        if (x == 1)
                        { }

                        i = i + 1;
                    }
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Test Report Complete. ');", true);
                    btnSave.Text = "Update";
                    txtPVCode.Text = objML_Laboratory.ID;
                }
                else
                {
                    foreach (DataListItem dlist in DlParametervalues.Items)
                    {
                        Label lblParameterID = ((Label)dlist.FindControl("lblParameterID"));
                        Label ParameterName = ((Label)dlist.FindControl("lblParameterName"));
                        TextBox lblParameterValues = ((TextBox)dlist.FindControl("txtParameterValues"));

                        objML_Laboratory.ID = txtPVCode.Text != "" ? txtPVCode.Text : null;
                        objML_Laboratory.ParameterID = lblParameterID.Text != "" ? lblParameterID.Text : null;
                        objML_Laboratory.ParameterName = ParameterName.Text != "" ? ParameterName.Text : null;
                        objML_Laboratory.Parametervalues = lblParameterValues.Text != "" ? lblParameterValues.Text : null;                 

                        int x = objBL_Laboratory.BL_InsUpdParameterValuesDetail(objML_Laboratory);
                        if (x == 1)
                        { }

                        i = i + 1;
                    }
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Test Report Complete. ');", true);
                    btnSave.Text = "Update";
                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetPVCodeList(string prefixText, int count)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.AppSettings["Hospital"];

                using (SqlCommand com = new SqlCommand())
                {
                    com.CommandText = "select PVCode from SPCN_Test_Paramter_Values_head where " + "PVCode like '%' + @Search + '%'";

                    com.Parameters.AddWithValue("@Search", prefixText);
                    com.Connection = con;
                    con.Open();
                    List<string> countryNames = new List<string>();
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            countryNames.Add(sdr["PVCode"].ToString());
                        }
                    }
                    con.Close();
                    return countryNames;


                }

            }
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetPatientList(string prefixText, int count)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.AppSettings["Hospital"];

                using (SqlCommand com = new SqlCommand())
                {
                    com.CommandText = "select Name from SPCN_SLIP_BOOK_ENTRY where " + "Name like '%' + @Search + '%'";

                    com.Parameters.AddWithValue("@Search", prefixText);
                    com.Connection = con;
                    con.Open();
                    List<string> countryNames = new List<string>();
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            countryNames.Add(sdr["Name"].ToString());
                        }
                    }
                    con.Close();
                    return countryNames;

                }

            }
        }
        protected void btnClear(object sender, EventArgs e)
        {
            DlParametervalues.DataSource = null;
            DlParametervalues.DataBind();
            txtPatientName.Text = "";
            txtPVCode.Text = "";
            txtUserName.Text = "";
            btnSave.Visible = false;
            btnCleared.Visible = false;

        }
    }
}