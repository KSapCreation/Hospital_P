using Hospital_P.H.layers.DataLayers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospital_P.H.layers.BusinessLayers;
using Hospital_P.H.layers.ModelLayers;
using System.Configuration;
using common;

namespace Hospital_P.H
{
    public partial class CustomerMaster : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        BL_Pharmacy objBL_Pharmacy = new BL_Pharmacy();
        ML_Pharmacy objML_Pharmacy = new ML_Pharmacy();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (!IsPostBack)
            {
                getState();
                BindCustomerMaster();
                GetCity();
            }
        }
        protected void getState()
        {
            con.Open();
            DataTable dt = new DataTable();
            string qry = "select State_Code, State_Name from SPCN_State_Master";
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adpt = new SqlDataAdapter(qry, con);
            adpt.Fill(dt);
            con.Close();
            ddlState.DataSource = dt;
            ddlState.DataTextField = "State_Name";
            ddlState.DataValueField = "State_Code";
            ddlState.DataBind();
            ddlState.Items.Insert(0, "Select");
        }
        protected void GetCity()
        {
            con.Open();

            DataTable dt = new DataTable();
            string qry = "select City_Code, City_Name from SPCN_City_Master ";
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adpt = new SqlDataAdapter(qry, con);
            adpt.Fill(dt);
            con.Close();
            ddlCity.DataSource = dt;
                        
            ddlCity.DataTextField = "City_Name";
            ddlCity.DataValueField = "City_Code";
            ddlCity.DataBind();

        }
        protected void getCity(object sender, EventArgs e)
        {
            con.Open();
            string stateId = ddlState.SelectedItem.Value;
            DataTable dt = new DataTable();
            string qry = "select City_Code, City_Name from SPCN_City_Master where State_Code='" + stateId + "'";
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adpt = new SqlDataAdapter(qry, con);
            adpt.Fill(dt);
            con.Close();
            ddlCity.DataSource = dt;
            if (dt != null && dt.Rows.Count > 0)
            {
                ddlCity.DataTextField = "City_Name";
                ddlCity.DataValueField = "City_Code";
                ddlCity.DataBind();
            }
            else
            {
                ddlCity.DataBind();
                ddlCity.Items.Insert(0, "Select");                
            }
        }
        private void Reset()
        {
            txtAccountCode.Text = "";
            txtAdress.Text = "";
            txtAppNo.Text = ""; ;
            txtCountry.Text = ""; ;
            txtCustomerName.Text = ""; 
            txtEmail.Text = "";
            txtGSTIN.Text = "";
            txtMobileNo.Text = "";
            txtPhone1.Text = "";
            txtPhone2.Text = "";
            txtWebsite.Text = "";
            ddlCity.SelectedIndex = 0;
            ddlState.SelectedIndex = 0;
            btnSave.Text = "Save";
            txtDesc.Text = "";
            txtSerach.Text = "";

        }
        protected void Cancel(object sender, EventArgs e)
        {
            Reset();
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
                    com.CommandText = "select CustomerName,CustomerCode from SPCN_Customer_Master where " + "CustomerName like '%' + @Search + '%'";

                    com.Parameters.AddWithValue("@Search", prefixText);
                    com.Connection = con;
                    con.Open();
                    List<string> countryNames = new List<string>();
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            countryNames.Add(sdr["CustomerCode"].ToString());
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
                objML_Pharmacy.ID = txtSerach.Text != "" ? txtSerach.Text : null;
                dt = objBL_Pharmacy.BL_SelectCustomerMaster(objML_Pharmacy);
                if (dt.Rows.Count > 0)
                {
                    txtAppNo.Text = dt.Rows[0]["CustomerCode"].ToString();
                    txtCustomerName.Text = dt.Rows[0]["CustomerName"].ToString();
                    txtDesc.Text = dt.Rows[0]["Description"].ToString();
                    txtAdress.Text = dt.Rows[0]["Address"].ToString();
                    txtMobileNo.Text = dt.Rows[0]["MobileNo"].ToString();
                    txtCountry.Text = dt.Rows[0]["Country"].ToString();
                    ddlState.SelectedValue = dt.Rows[0]["State"].ToString();
                    txtMobileNo.Text = dt.Rows[0]["MobileNo"].ToString();
                    txtPhone1.Text = dt.Rows[0]["Phone1"].ToString();
                    txtPhone2.Text = dt.Rows[0]["Phone2"].ToString();
                    txtEmail.Text = dt.Rows[0]["EmailID"].ToString();
                    txtWebsite.Text = dt.Rows[0]["Website"].ToString();
                    txtAccountCode.Text = dt.Rows[0]["AccountCode"].ToString();
                    txtGSTIN.Text = dt.Rows[0]["GSTIN_No"].ToString();
                    ddlCity.SelectedValue = dt.Rows[0]["City"].ToString();
                    btnSave.Text = "Update";
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
        private void BindCustomerMaster()
        {
            DataTable dt = new DataTable();
            dt = objBL_Pharmacy.BL_BindCustomerMaster(objML_Pharmacy);
            if (dt.Rows.Count > 0)
            {
                GrdCustomerMaster.DataSource = dt;
                GrdCustomerMaster.DataBind();
            }
        }
        protected void GrdCustomerMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdCustomerMaster.PageIndex = e.NewPageIndex;
            BindCustomerMaster();
        }
        protected void Save(object sender, EventArgs e)
        {
            try
            {
                if (txtCustomerName.Text == "")
                {
                    txtCustomerName.Focus();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Customer Name');", true);
                }
                else if (txtMobileNo.Text == "")
                {
                    txtMobileNo.Focus();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill MobileNo');", true);
                }
                else if (txtEmail.Text == "")
                {
                    txtEmail.Focus();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Email ID');", true);
                }
                else if (ddlState.SelectedItem.Text == "Select")
                {
                    txtEmail.Focus();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Select State First');", true);
                }
                else if (ddlCity.SelectedItem.Text == "Select")
                {
                    txtEmail.Focus();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Select City First');", true);
                }
                else if (btnSave.Text == "Save")
                {
                    con.Open();
                    SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);

                    string qry = "";
                    qry = "select  MAX(CustomerCode) as CustomerID  from SPCN_Customer_Master ";
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(qry, con);
                    cmd.Transaction = trans;
                    cmd.Clone();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        objML_Pharmacy.ID = dr["CustomerID"].ToString();
                    }
                    if (clsCommon.myLen(objML_Pharmacy.ID) <= 0)
                    {
                        objML_Pharmacy.ID = "CUST000000001";
                    }
                    else
                    {
                        objML_Pharmacy.ID = clsCommon.incval(objML_Pharmacy.ID);
                    }
                    con.Close();
                    objML_Pharmacy.CustomerName = txtCustomerName.Text != "" ? txtCustomerName.Text : null;
                    objML_Pharmacy.Description = txtDesc.Text != "" ? txtDesc.Text : null;
                    objML_Pharmacy.Address = txtAdress.Text != "" ? txtAdress.Text : null;
                    objML_Pharmacy.Country = txtCountry.Text != "" ? txtCountry.Text : null;
                    objML_Pharmacy.State = ddlState.SelectedValue != "" ? ddlState.SelectedValue : null;
                    objML_Pharmacy.City = ddlCity.SelectedValue != "" ? ddlCity.SelectedValue : null;
                    objML_Pharmacy.MobileNo = txtMobileNo.Text != "" ? txtMobileNo.Text : null;
                    objML_Pharmacy.Phone1 = txtPhone1.Text != "" ? txtPhone1.Text : null;
                    objML_Pharmacy.Phone2 = txtPhone2.Text != "" ? txtPhone2.Text : null;
                    objML_Pharmacy.EmailID = txtEmail.Text != "" ? txtEmail.Text : null;
                    objML_Pharmacy.WebSite = txtWebsite.Text != "" ? txtWebsite.Text : null;
                    objML_Pharmacy.AccountCode = txtAccountCode.Text != "" ? txtAccountCode.Text : null;
                    objML_Pharmacy.GSTINNo = txtGSTIN.Text != "" ? txtGSTIN.Text : null;
                    objML_Pharmacy.CreatedBy = Session["Username"].ToString();
                    objML_Pharmacy.ModifyBy = Session["Username"].ToString();
                    int x = objBL_Pharmacy.BL_InsUpdCustomerMaster(objML_Pharmacy);
                    if (x == 1)
                    {
                        txtAppNo.Text = objML_Pharmacy.ID;
                        BindCustomerMaster();
                        btnSave.Text = "Update";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Saved!');", true);

                    }
                }
                else
                {
                    objML_Pharmacy.ID = txtAppNo.Text != "" ? txtAppNo.Text : null;
                    objML_Pharmacy.VendorName = txtCustomerName.Text != "" ? txtCustomerName.Text : null;
                    objML_Pharmacy.Description = txtDesc.Text != "" ? txtDesc.Text : null;
                    objML_Pharmacy.Address = txtAdress.Text != "" ? txtAdress.Text : null;
                    objML_Pharmacy.Country = txtCountry.Text != "" ? txtCountry.Text : null;
                    objML_Pharmacy.State = ddlState.SelectedValue != "" ? ddlState.SelectedValue : null;
                    objML_Pharmacy.City = ddlCity.SelectedValue != "" ? ddlCity.SelectedValue : null;
                    objML_Pharmacy.MobileNo = txtMobileNo.Text != "" ? txtMobileNo.Text : null;
                    objML_Pharmacy.Phone1 = txtPhone1.Text != "" ? txtPhone1.Text : null;
                    objML_Pharmacy.Phone2 = txtPhone2.Text != "" ? txtPhone2.Text : null;
                    objML_Pharmacy.EmailID = txtEmail.Text != "" ? txtEmail.Text : null;
                    objML_Pharmacy.WebSite = txtWebsite.Text != "" ? txtWebsite.Text : null;
                    objML_Pharmacy.AccountCode = txtAccountCode.Text != "" ? txtAccountCode.Text : null;
                    objML_Pharmacy.GSTINNo = txtGSTIN.Text != "" ? txtGSTIN.Text : null;
                    objML_Pharmacy.ModifyBy = Session["Username"].ToString();
                    objML_Pharmacy.ModifyBy = Session["Username"].ToString();
                    int x = objBL_Pharmacy.BL_InsUpdCustomerMaster(objML_Pharmacy);
                    if (x == 1)
                    {
                        BindCustomerMaster();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Saved!');", true);
                    }
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
    }
}