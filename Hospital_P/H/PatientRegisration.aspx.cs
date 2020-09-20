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


namespace hotelManagement.H
{
    public partial class PatientRegisration : System.Web.UI.Page
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
                BindWardDetail();
                BindBedDetail();
                BindDepartment();
                getState();
                BindPaitentDetail();
                BindHospital();
            }
        }
        protected void BindWardDetail()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objBL_Patient.BL_BindWard(objML_Patient);
                if (dt.Rows.Count > 0)
                {
                    ddlWardType.DataSource = dt;
                    ddlWardType.DataValueField = "WardID";
                    ddlWardType.DataTextField = "WardName";                    
                    ddlWardType.DataBind();
                    ddlWardType.Items.Insert(0, "Select");
                    
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
        protected void BindDepartment()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objBL_Patient.BL_BindDepartment(objML_Patient);
                if (dt.Rows.Count > 0)
                {
                    ddlDepartment.DataSource = dt;
                    ddlDepartment.DataValueField = "DepID";
                    ddlDepartment.DataTextField = "DepartmentName";
                    ddlDepartment.DataBind();
                    ddlDepartment.Items.Insert(0, "Select");
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
        protected void BindBedDetail()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objBL_Patient.BL_Bindbed(objML_Patient);
                if (dt.Rows.Count > 0)
                {
                    ddlBedType.DataSource = dt;
                    ddlBedType.DataValueField = "BedID";
                    ddlBedType.DataTextField = "BedName";                    
                    ddlBedType.DataBind();
                    ddlBedType.Items.Insert(0, "Select");
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
        protected void BindHospital()
        {
            DataTable dt = new DataTable();
            dt = objBL_Patient.BL_BindHospital(objML_Patient);
            if (dt.Rows.Count > 0)
            {
                txtHospital.Text = dt.Rows[0]["HospitalName"].ToString();
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
            else if (ddlBedType.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Select Bed Type')", true);
            }
            else if (ddlWardType.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Select Ward Type')", true);
            }
            else if (btnSave.Text == "Save")
            {
                con.Open();
                SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);

                string qry = "";
                qry = "select  MAX(Patient_ID) as Patient_ID  from SPCN_Pateint_Registration_Entry ";
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(qry, con);
                cmd.Transaction = trans;
                cmd.Clone();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objML_Patient.AdmissionNo = dr["Patient_ID"].ToString();
                }
                if (clsCommon.myLen(objML_Patient.AdmissionNo) <= 0)
                {
                    objML_Patient.AdmissionNo = "IP000000001";
                }
                else
                {
                    objML_Patient.AdmissionNo = clsCommon.incval(objML_Patient.AdmissionNo);
                }
                con.Close();

                objML_Patient.AdmissionDate = txtAdmisionDate.Text != "" ? txtAdmisionDate.Text : null;
                objML_Patient.FirstName = txtFirstName.Text != "" ? txtFirstName.Text : "";
                objML_Patient.LastName = txtLastName.Text != "" ? txtLastName.Text : null;
                objML_Patient.DOB = txtDOB.Text != "" ? txtDOB.Text : null;
                objML_Patient.Age = txtAge.Text != "" ? txtAge.Text : null;
                objML_Patient.Gender = ddlGender.SelectedItem.Text != "" ? ddlGender.SelectedItem.Text : null;
                objML_Patient.MarriedStatus = ddlMarried.SelectedItem.Text != "" ? ddlMarried.SelectedItem.Text : null;
                objML_Patient.PhoneNo = txtPhoneNo.Text != "" ? txtPhoneNo.Text : null;
                objML_Patient.MobileNo = txtMobileNo.Text != "" ? txtMobileNo.Text : null;
                objML_Patient.EmailID = txtEmailID.Text != "" ? txtEmailID.Text : null;
                objML_Patient.MadicineInformation = txtMadicineInfo.Text != "" ? txtMadicineInfo.Text : null;
                objML_Patient.HospitalName = txtHospital.Text != "" ? txtHospital.Text : null;
                objML_Patient.Doctor = txtdoctor.Text != "" ? txtdoctor.Text : null;
                objML_Patient.Address = txtaddress.Text != "" ? txtaddress.Text : "";
                objML_Patient.City = ddlCity.SelectedValue != "" ? ddlCity.SelectedValue : "";
                objML_Patient.State = ddlState.SelectedValue != "" ? ddlState.SelectedValue : "";
                objML_Patient.Ward = ddlWardType.SelectedValue != "" ? ddlWardType.SelectedValue : null;
                objML_Patient.Bed = ddlBedType.SelectedValue != "" ? ddlBedType.SelectedValue : null;
                objML_Patient.Department = ddlDepartment.SelectedValue != "" ? ddlDepartment.SelectedValue : null;
                objML_Patient.CreatedBy = Session["UserName"].ToString();
                objML_Patient.ModifyBy = Session["UserName"].ToString();
                objML_Patient.Charges = txtCharges.Text != "" ? txtCharges.Text : null;
                objML_Patient.Compilent = txtComplaint.Text != "" ? txtComplaint.Text : null;
                objML_Patient.BillType = ddlBillType.SelectedItem.Text != "" ? ddlBillType.SelectedItem.Text : null;
                int x = objBL_Patient.BL_InsUpdPatientAdmission(objML_Patient);
                if (x == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Patient Admission Saved')", true);
                    Reset();
                    BindPaitentDetail();
                }
            }
            else
            {
                objML_Patient.AdmissionNo = lblID.Text != "" ? lblID.Text : null;
                objML_Patient.AdmissionDate = txtAdmisionDate.Text != "" ? txtAdmisionDate.Text : null;
                objML_Patient.FirstName = txtFirstName.Text != "" ? txtFirstName.Text : "";
                objML_Patient.LastName = txtLastName.Text != "" ? txtLastName.Text : null;
                objML_Patient.DOB = txtDOB.Text != "" ? txtDOB.Text : null;
                objML_Patient.Age = txtAge.Text != "" ? txtAge.Text : null;
                objML_Patient.Gender = ddlGender.SelectedItem.Text != "" ? ddlGender.SelectedItem.Text : null;
                objML_Patient.MarriedStatus = ddlMarried.SelectedItem.Text != "" ? ddlMarried.SelectedItem.Text : null;
                objML_Patient.PhoneNo = txtPhoneNo.Text != "" ? txtPhoneNo.Text : null;
                objML_Patient.MobileNo = txtMobileNo.Text != "" ? txtMobileNo.Text : null;
                objML_Patient.EmailID = txtEmailID.Text != "" ? txtEmailID.Text : null;
                objML_Patient.MadicineInformation = txtMadicineInfo.Text != "" ? txtMadicineInfo.Text : null;
                objML_Patient.HospitalName = txtHospital.Text != "" ? txtHospital.Text : null;
                objML_Patient.Doctor = txtdoctor.Text != "" ? txtdoctor.Text : null;
                objML_Patient.Address = txtaddress.Text != "" ? txtaddress.Text : "";
                objML_Patient.City = ddlCity.SelectedValue != "" ? ddlCity.SelectedValue : "";
                objML_Patient.State = ddlState.SelectedValue != "" ? ddlState.SelectedValue : "";
                objML_Patient.Ward = ddlWardType.SelectedValue != "" ? ddlWardType.SelectedValue : null;
                objML_Patient.Bed = ddlBedType.SelectedValue != "" ? ddlBedType.SelectedValue : null;
                objML_Patient.Department = ddlDepartment.SelectedValue != "" ? ddlDepartment.SelectedValue : null;
                objML_Patient.CreatedBy = Session["UserName"].ToString();
                objML_Patient.ModifyBy = Session["UserName"].ToString();
                objML_Patient.Charges = txtCharges.Text != "" ? txtCharges.Text : null;
                objML_Patient.Compilent = txtComplaint.Text != "" ? txtComplaint.Text : null;
                objML_Patient.BillType = ddlBillType.SelectedItem.Text != "" ? ddlBillType.SelectedItem.Text : null;
                int x = objBL_Patient.BL_InsUpdPatientAdmission(objML_Patient);
                if (x == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Patient Admission Updated')", true);
                    Reset();
                    BindPaitentDetail();
                }
            }
        }
        protected void btnCleared(object sender, EventArgs e)
        {
            Reset();
        }
        private void Reset()
        {
            txtaddress.Text = "";
            txtAge.Text = "";
            txtAppNo.Text = "";
            ddlCity.SelectedIndex = 0;
            txtAdmisionDate.Text = "";
            txtDOB.Text = "";
            txtdoctor.Text = "";
            txtEmailID.Text = "";
            txtFirstName.Text = "";
            txtHospital.Text = "";
            txtLastName.Text = "";
            txtMadicineInfo.Text = "";
            txtMobileNo.Text = "";
            txtPhoneNo.Text = "";
            ddlState.SelectedIndex = 0;
            ddlBedType.SelectedIndex = 0;
            ddlMarried.SelectedIndex = 0;
            ddlWardType.SelectedIndex = 0;
        }
        private void BindPaitentDetail()
        {
            DataTable dt = new DataTable();
            dt = objBL_Patient.BL_BindPaitent(objML_Patient);
            if (dt.Rows.Count > 0)
            {
                GrdPaitent.DataSource = dt;
                GrdPaitent.DataBind();
            }
        }
        protected void GrdPaitent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdPaitent.PageIndex = e.NewPageIndex;
            BindPaitentDetail();
        }
        protected void Delete(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            {
                Label lblID = (Label)gvr.FindControl("lblPatientID");
                DataTable dt = new DataTable();
                objML_Patient.ID = lblID.Text != "" ? lblID.Text : null;
                int x = objBL_Patient.BL_DeletePatient(objML_Patient);
                if (x == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Delete')", true);
                    BindPaitentDetail();
                }
            }
        }
        protected void Update(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
                {
                    Label lblProgramsID = (Label)gvr.FindControl("lblPatientID");
                    DataTable dt = new DataTable();
                    objML_Patient.ID = lblProgramsID.Text != "" ? lblProgramsID.Text : null;
                    dt = objBL_Patient.BL_EditPatient(objML_Patient);
                    if (dt.Rows.Count > 0)
                    {
                        lblID.Text = dt.Rows[0]["Patient_ID"].ToString();
                        txtAppNo.Text = dt.Rows[0]["Patient_ID"].ToString();
                        txtFirstName.Text = dt.Rows[0]["Patient_FirstName"].ToString();
                        txtLastName.Text = dt.Rows[0]["Patient_LastName"].ToString();
                        ddlGender.SelectedItem.Text = dt.Rows[0]["Gender"].ToString();
                        txtAdmisionDate.Text = dt.Rows[0]["AdmissionDate"].ToString();
                        txtDOB.Text = dt.Rows[0]["DOB"].ToString();
                        ddlMarried.SelectedItem.Text = dt.Rows[0]["MarriedStatus"].ToString();
                        txtAge.Text = dt.Rows[0]["Age"].ToString();
                        txtMobileNo.Text = dt.Rows[0]["MobileNo"].ToString();
                        txtPhoneNo.Text = dt.Rows[0]["PhoneNo"].ToString();
                        txtEmailID.Text = dt.Rows[0]["EmailID"].ToString();
                        txtaddress.Text = dt.Rows[0]["Address"].ToString();
                        ddlBillType.SelectedItem.Value = dt.Rows[0]["billType"].ToString();
                        ddlWardType.SelectedItem.Value = dt.Rows[0]["WardType"].ToString();
                        txtMadicineInfo.Text = dt.Rows[0]["Patient_Medical_Description"].ToString();
                        ddlState.SelectedValue = dt.Rows[0]["State"].ToString();
                        ddlCity.SelectedValue = dt.Rows[0]["City"].ToString();
                        txtCharges.Text = dt.Rows[0]["Charges"].ToString();
                        txtComplaint.Text = dt.Rows[0]["Complient"].ToString();
                        ddlDepartment.SelectedItem.Value = dt.Rows[0]["Department"].ToString();
                        btnSave.Text = "Update";

                    }

                }

            }
            catch (Exception ex)
            {                
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "')", true);
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
                ddlCity.Enabled = true;
                ddlCity.DataTextField = "City_Name";
                ddlCity.DataValueField = "City_Code";
                ddlCity.DataBind();
            }
            else
            {
                ddlCity.Enabled = false;
                ddlCity.Items.Insert(0, new ListItem("Select City", "0"));
            }
        }
        protected void Search(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                objML_Patient.ID = txtSerach.Text != "" ? txtSerach.Text : null;
                dt = objBL_Patient.BL_EditPatient(objML_Patient);
                if (dt.Rows.Count > 0)
                {
                    lblID.Text = dt.Rows[0]["Patient_ID"].ToString();
                    txtAppNo.Text = dt.Rows[0]["Patient_ID"].ToString();
                    txtFirstName.Text = dt.Rows[0]["Patient_FirstName"].ToString();
                    txtLastName.Text = dt.Rows[0]["Patient_LastName"].ToString();
                    ddlGender.SelectedItem.Text = dt.Rows[0]["Gender"].ToString();
                    txtAdmisionDate.Text = dt.Rows[0]["AdmissionDate"].ToString();
                    txtDOB.Text = dt.Rows[0]["DOB"].ToString();
                    ddlMarried.SelectedItem.Text = dt.Rows[0]["MarriedStatus"].ToString();
                    txtAge.Text = dt.Rows[0]["Age"].ToString();
                    txtMobileNo.Text = dt.Rows[0]["MobileNo"].ToString();
                    txtPhoneNo.Text = dt.Rows[0]["PhoneNo"].ToString();
                    txtEmailID.Text = dt.Rows[0]["EmailID"].ToString();
                    txtaddress.Text = dt.Rows[0]["Address"].ToString();
                    ddlBillType.SelectedItem.Value = dt.Rows[0]["billType"].ToString();
                    ddlWardType.SelectedItem.Value = dt.Rows[0]["WardType"].ToString();
                    txtMadicineInfo.Text = dt.Rows[0]["Patient_Medical_Description"].ToString();
                    ddlState.SelectedValue = dt.Rows[0]["State"].ToString();
                    ddlCity.SelectedValue = dt.Rows[0]["City"].ToString();
                    txtCharges.Text = dt.Rows[0]["Charges"].ToString();
                    txtComplaint.Text = dt.Rows[0]["Complient"].ToString();
                    ddlDepartment.SelectedItem.Value = dt.Rows[0]["Department"].ToString();
                    btnSave.Text = "Update";

                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
    }
}