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
using System.Web.Services;
using System.Configuration;
namespace Hospital_P.H
{
    public partial class Appointment : System.Web.UI.Page
    {
        protected bool blAccess = true;
        BL_Patient objBL_Patient = new BL_Patient();
        ML_Patient objML_Patient = new ML_Patient();
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        CommonClass objCommonClass = new CommonClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                if (!IsPostBack)
                {
                    BindAppointment();
                }
            }
        }
        protected void btnSaved(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "")
            {
                txtFirstName.Focus();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill First Name')", true);
            }
            else if (txtMobileNo.Text == "")
            {
                txtMobileNo.Focus();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Mobile No')", true);
            }
            else if (txtAmount.Text == "")
            {
                txtAmount.Focus();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Amount')", true);
            }
            else if (btnSave.Text == "Save")
            {
                con.Open();
                SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);

                string qry = "";
                qry = "select  MAX(Slip_No) as Slip_No  from SPCN_Slip_Book_Entry ";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(qry, con);
                cmd.Transaction = trans;
                cmd.Clone();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objML_Patient.AppointmentNo = dr["Slip_No"].ToString();
                }
                if (clsCommon.myLen(objML_Patient.AppointmentNo) <= 0)
                {
                    objML_Patient.AppointmentNo = "A000000001";
                }
                else
                {
                    objML_Patient.AppointmentNo = clsCommon.incval(objML_Patient.AppointmentNo);
                }
                con.Close();

                objML_Patient.AppointmentDate = txtAppDate.Text != "" ? txtAppDate.Text : "";
                objML_Patient.FirstName = txtFirstName.Text != "" ? txtFirstName.Text : "";
                objML_Patient.LastName = txtLastName.Text != "" ? txtLastName.Text : "";
                objML_Patient.W_D_F_Name = txtWDF.Text != "" ? txtWDF.Text : "";
                objML_Patient.Gender = ddlGender.SelectedValue != "" ? ddlGender.SelectedValue : "";
                objML_Patient.DOB = txtDOB.Text != "" ? txtDOB.Text : "";
                objML_Patient.MobileNo = txtMobileNo.Text != "" ? txtMobileNo.Text : "";
                objML_Patient.Address = txtAdess.Text != "" ? txtAdess.Text : "";
                objML_Patient.City = txtCity.Text != "" ? txtCity.Text : "";
                objML_Patient.State = txtState.Text != "" ? txtState.Text : "";
                objML_Patient.Amount = txtAmount.Text != "" ? txtAmount.Text : "";
                objML_Patient.Doctor = txtDoctor.Text != "" ? txtDoctor.Text : null;
                objML_Patient.CreatedBy = Session["UserName"].ToString();
                objML_Patient.ModifyBy = Session["UserName"].ToString();
                int x = objBL_Patient.BL_InsUpdUserDetail(objML_Patient);
                if (x == 1)
                {
                //    objCommonClass.SendSMS("Hi this is demo sms", txtMobileNo.Text);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Appointment Saved')", true);
                }
            }
            else
            {
                objML_Patient.AppointmentNo = txtAppNo.Text != "" ? txtAppNo.Text : null;
                objML_Patient.AppointmentDate = txtAppDate.Text != "" ? txtAppDate.Text : null;
                objML_Patient.FirstName = txtFirstName.Text != "" ? txtFirstName.Text : "";
                objML_Patient.LastName = txtLastName.Text != "" ? txtLastName.Text : "";
                objML_Patient.W_D_F_Name = txtWDF.Text != "" ? txtWDF.Text : "";
                objML_Patient.Gender = ddlGender.SelectedValue != "" ? ddlGender.SelectedValue : "";
                objML_Patient.DOB = txtDOB.Text != "" ? txtDOB.Text : "";
                objML_Patient.MobileNo = txtMobileNo.Text != "" ? txtMobileNo.Text : "";
                objML_Patient.Address = txtAdess.Text != "" ? txtAdess.Text : "";
                objML_Patient.City = txtCity.Text != "" ? txtCity.Text : "";
                objML_Patient.State = txtState.Text != "" ? txtState.Text : "";
                objML_Patient.Amount = txtAmount.Text != "" ? txtAmount.Text : "";
                objML_Patient.Doctor = txtDoctor.Text != "" ? txtDoctor.Text : null;
                objML_Patient.CreatedBy = Session["UserName"].ToString();
                objML_Patient.ModifyBy = Session["UserName"].ToString();
                int x = objBL_Patient.BL_InsUpdUserDetail(objML_Patient);
                if (x == 1)
                {
                    objCommonClass.SendSMS("Hi this is demo sms", txtMobileNo.Text);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Appointment Saved')", true);
                }
            }
            
        }
        protected void btnCleared(object sender, EventArgs e)
        {
            txtAppNo.Text = "";
            txtAdess.Text = "";
            txtAmount.Text = "";
            txtCity.Text = "";
            txtAppDate.Text = "";
            txtDOB.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtMobileNo.Text = "";
            txtState.Text = "";
            txtWDF.Text = "";
            txtDoctor.Text = "";
        }
        private void BindAppointment()
        {
            DataTable dt = new DataTable();
            dt = objBL_Patient.BL_BindAppointment(objML_Patient);
            if (dt.Rows.Count > 0)
            {
                GrdAppointmentList.DataSource = dt;
                GrdAppointmentList.DataBind();
            }
        }
        protected void GrdAppointmentList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdAppointmentList.PageIndex = e.NewPageIndex;
            BindAppointment();
        }
        [System.Web.Script.Services.ScriptMethod()]
        [WebMethod]
        public static List<string> GetCompletionList(string prefixText)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.AppSettings["Hospital"];

                List<string> empResult = new List<string>();
              
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "select Slip_No from SPCN_Slip_Book_Entry where Name LIKE '%'+@SearchText+'%'";
                        cmd.Connection = con;
                        con.Open();
                        cmd.Parameters.AddWithValue("@SearchEmpName", prefixText);
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            empResult.Add(dr["Slip_No"].ToString());
                        }
                        con.Close();
                        return empResult;
                    }
                

            }
        }
        protected void Search(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                objML_Patient.ID = txtSerach.Text != "" ? txtSerach.Text : null;
                dt = objBL_Patient.BL_SelectAppointment(objML_Patient);
                if (dt.Rows.Count > 0)
                {
                    txtAppNo.Text = dt.Rows[0]["Slip_No"].ToString();
                    txtFirstName.Text = dt.Rows[0]["Name"].ToString();
                    txtLastName.Text = dt.Rows[0]["LastName"].ToString();
                    txtAppDate.Text = dt.Rows[0]["AppointmentDate"].ToString();
                    txtMobileNo.Text = dt.Rows[0]["MobileNo"].ToString();
                    ddlGender.SelectedValue = dt.Rows[0]["Gender"].ToString();
                    txtDOB.Text = dt.Rows[0]["DOB"].ToString();
                    txtAdess.Text = dt.Rows[0]["Address"].ToString();
                    txtWDF.Text = dt.Rows[0]["Wo-Fo_Name"].ToString();
                    txtCity.Text = dt.Rows[0]["City"].ToString();
                    txtState.Text = dt.Rows[0]["State"].ToString();
                    txtDoctor.Text = dt.Rows[0]["Doctor"].ToString();
                    txtAmount.Text = dt.Rows[0]["SlipAmount"].ToString();
                    btnSave.Text = "Update";
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
    }
}