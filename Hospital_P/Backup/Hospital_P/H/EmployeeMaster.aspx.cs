using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospital_P.H.layers.ModelLayers;
using Hospital_P.H.layers.BusinessLayers;
using System.Data;
using System.Data.SqlClient;
using common;
using Hospital_P.H.layers.DataLayers;
using System.Configuration;
using CommonFile;

namespace Hospital_P.H
{
    public partial class EmployeeMaster : System.Web.UI.Page
    {
        protected bool blAccess = true;
        BL_CommonServices objBL_CommonService = new BL_CommonServices();
        ML_CommonServices objML_CommonService = new ML_CommonServices();
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                BindDepartment();
                BindDesignation();
                getState();
                GetCity();
                BindEmployeeList();
            }
        }

        #region "Page Load Function"
        
        private void BindDepartment()
        {
            DataTable dt = new DataTable();
            dt = objBL_CommonService.BL_BindDepartment(objML_CommonService);
            if (dt.Rows.Count > 0)
            {
                ddlDepartment.DataSource = dt;
                ddlDepartment.DataTextField = "DepartmentName";
                ddlDepartment.DataValueField = "DepID";
                ddlDepartment.DataBind();
                ddlDepartment.Items.Insert(0, "Select Department");
            }
        }
        private void BindDesignation()
        {
            DataTable dt = new DataTable();
            dt = objBL_CommonService.BL_BindDesigantion(objML_CommonService);
            if (dt.Rows.Count > 0)
            {
                ddlDesignation.DataSource = dt;
                ddlDesignation.DataTextField = "DesignationName";
                ddlDesignation.DataValueField = "DesID";
                ddlDesignation.DataBind();
                ddlDesignation.Items.Insert(0, "Select Department");
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
        private void BindEmployeeList()
        {
            DataTable dt = new DataTable();
            dt = objBL_CommonService.BL_BindEmployeeMaster(objML_CommonService);
            if (dt.Rows.Count > 0)
            {
                GrdEmpoyeeMaster.DataSource = dt;
                GrdEmpoyeeMaster.DataBind();
                
            }
        }
        protected void GrdEmployeeMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdEmpoyeeMaster.PageIndex = e.NewPageIndex;
            BindEmployeeList();
        }
        #endregion


        #region "Events"

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
        protected void Save(object sender, EventArgs e)
        {
            try
            {
                if (txtFirstName.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('Enter First Name')", true);
                }
                else if (txtLastName.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('Enter Last Name')", true);
                }
                else if (txtMobileNo.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('Enter Mobile No')", true);
                }
                else if (txtEmailID.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('Enter Email ID')", true);
                }
                else if (ddlDepartment.SelectedIndex == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('Select Department')", true);
                }
                else if (ddlDesignation.SelectedIndex == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('Select Desigation')", true);
                }
                else if (btnSave.Text == "Save")
                {
                    con.Open();
                    SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);

                    string qry = "";
                    qry = "select  MAX(EmployeeID) as EmployeeID  from SPCN_Employee_Master ";
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(qry, con);
                    cmd.Transaction = trans;
                    cmd.Clone();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        objML_CommonService.ID = dr["EmployeeID"].ToString();
                    }
                    if (clsCommon.myLen(objML_CommonService.ID) <= 0)
                    {
                        objML_CommonService.ID = "EMP000000001";
                    }
                    else
                    {
                        objML_CommonService.ID = clsCommon.incval(objML_CommonService.ID);
                    }
                    con.Close();
                    objML_CommonService.FirstName = txtFirstName.Text != "" ? txtFirstName.Text : null;
                    objML_CommonService.LastName = txtLastName.Text != "" ? txtLastName.Text : null;
                    objML_CommonService.EmailID = txtEmailID.Text != "" ? txtEmailID.Text : null;
                    objML_CommonService.Age = txtAge.Text != "" ? txtAge.Text : null;
                    objML_CommonService.Department = ddlDepartment.SelectedValue != "" ? ddlDepartment.SelectedValue : null;
                    objML_CommonService.Designation = ddlDesignation.SelectedValue != "" ? ddlDesignation.SelectedValue : null;
                    objML_CommonService.Gender = ddlGender.SelectedValue != "" ? ddlGender.SelectedValue : null;
                    objML_CommonService.MarriedStatus = ddlMarried.SelectedValue != "" ? ddlMarried.SelectedValue : null;
                    objML_CommonService.State = ddlState.SelectedValue != "" ? ddlState.SelectedValue : null;
                    objML_CommonService.City = ddlCity.SelectedValue != "" ? ddlCity.SelectedValue : null;
                    objML_CommonService.Country = txtCountry.Text != "" ? txtCountry.Text : null;
                    objML_CommonService.MobileNo = txtMobileNo.Text != "" ? txtMobileNo.Text : null;
                    objML_CommonService.Address = txtAddress.Text != "" ? txtAddress.Text : null;
                    objML_CommonService.Website = txtWebsite.Text != "" ? txtWebsite.Text : null;
                    objML_CommonService.DOB = txtDOB.Text != "" ? txtDOB.Text : null;
                    objML_CommonService.CraetedBy = Session["UserName"].ToString();
                    objML_CommonService.ModifyBy = Session["UserName"].ToString();
                    int x = objBL_CommonService.BL_InsUpdEmployeeMaster(objML_CommonService);
                    if (x == 1)
                    {
                        BindEmployeeList();                        
                        Clear();
                        ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('Data Saved');", true);

                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('Already Data Saved')", true);
                    }
                }
                else
                {
                    objML_CommonService.ID = txtEmpID.Text != "" ? txtEmpID.Text : null;
                    objML_CommonService.FirstName = txtFirstName.Text != "" ? txtFirstName.Text : null;
                    objML_CommonService.LastName = txtLastName.Text != "" ? txtLastName.Text : null;
                    objML_CommonService.EmailID = txtEmailID.Text != "" ? txtEmailID.Text : null;
                    objML_CommonService.Age = txtAge.Text != "" ? txtAge.Text : null;
                    objML_CommonService.Department = ddlDepartment.SelectedValue != "" ? ddlDepartment.SelectedValue : null;
                    objML_CommonService.Designation = ddlDesignation.SelectedValue != "" ? ddlDesignation.SelectedValue : null;
                    objML_CommonService.Gender = ddlGender.SelectedValue != "" ? ddlGender.SelectedValue : null;
                    objML_CommonService.MarriedStatus = ddlMarried.SelectedValue != "" ? ddlMarried.SelectedValue : null;
                    objML_CommonService.State = ddlState.SelectedValue != "" ? ddlState.SelectedValue : null;
                    objML_CommonService.City = ddlCity.SelectedValue != "" ? ddlCity.SelectedValue : null;
                    objML_CommonService.Country = txtCountry.Text != "" ? txtCountry.Text : null;
                    objML_CommonService.MobileNo = txtMobileNo.Text != "" ? txtMobileNo.Text : null;
                    objML_CommonService.Address = txtAddress.Text != "" ? txtAddress.Text : null;
                    objML_CommonService.Website = txtWebsite.Text != "" ? txtWebsite.Text : null;
                    objML_CommonService.DOB = txtDOB.Text != "" ? txtDOB.Text : null;
                    objML_CommonService.CraetedBy = Session["UserName"].ToString();
                    objML_CommonService.ModifyBy = Session["UserName"].ToString();
                    int x = objBL_CommonService.BL_InsUpdEmployeeMaster(objML_CommonService);
                    if (x == 1)
                    {
                        BindEmployeeList();                       
                        Clear();
                        ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('Data Updated');", true);
                    }                    
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void Delete(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            {
                Label lblID = (Label)gvr.FindControl("lblEmployeeID");
                DataTable dt = new DataTable();
                objML_CommonService.ID = lblID.Text != "" ? lblID.Text : null;
                int x = objBL_CommonService.BL_DeleteEmployeeMaster(objML_CommonService);
                if (x == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Delete');", true);
                    BindEmployeeList();
                }
            }
        }
        protected void Update(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
                {
                    Label lblProgramsID = (Label)gvr.FindControl("lblEmployeeID");
                    DataTable dt = new DataTable();
                    objML_CommonService.ID = lblProgramsID.Text != "" ? lblProgramsID.Text : null;
                    dt = objBL_CommonService.BL_SelectEmpolyeeMaster(objML_CommonService);
                    if (dt.Rows.Count > 0)
                    {

                        txtEmpID.Text = dt.Rows[0]["EmployeeID"].ToString();
                        txtFirstName.Text = dt.Rows[0]["FirstName"].ToString();
                        txtLastName.Text = dt.Rows[0]["LastName"].ToString();
                        txtEmailID.Text = dt.Rows[0]["EmailID"].ToString();
                        txtMobileNo.Text = dt.Rows[0]["MobileNo"].ToString();
                        txtAddress.Text = dt.Rows[0]["Address"].ToString();
                        ddlGender.SelectedValue = dt.Rows[0]["Gender"].ToString();
                        txtAge.Text = dt.Rows[0]["Age"].ToString();
                        txtDOB.Text = dt.Rows[0]["DOB"].ToString();
                        if (clsCommon.myLen(ddlDepartment.SelectedValue) > 0)
                        {
                            ddlDepartment.SelectedValue = dt.Rows[0]["Department"].ToString();
                        }
                        if (clsCommon.myLen(ddlDesignation.SelectedValue) > 0)
                        {
                            ddlDesignation.SelectedValue = dt.Rows[0]["Desingation"].ToString();
                        }
                        txtCountry.Text = dt.Rows[0]["Country"].ToString();
                        if (clsCommon.myLen(ddlCity.SelectedValue) > 0)
                        {
                            ddlCity.SelectedValue = dt.Rows[0]["City"].ToString();
                        }
                        if (clsCommon.myLen(ddlState.SelectedValue) > 0)
                        {
                            ddlState.SelectedValue = dt.Rows[0]["State"].ToString();
                        }
                        if (clsCommon.myLen(ddlMarried.SelectedValue) > 0)
                        {
                            ddlMarried.SelectedValue = dt.Rows[0]["MarriedStatus"].ToString();
                        }
                        txtWebsite.Text = dt.Rows[0]["Website"].ToString();
                        btnSave.Text = "Update";

                    }

                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void Clear(object sender, EventArgs e)
        {
            Clear();
        }
        private void Clear()
        {
            txtEmpID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmailID.Text = "";
            txtAddress.Text = "";
            txtAge.Text = "";
            txtCountry.Text = "";
            txtDOB.Text = "";
            txtMobileNo.Text = "";
            txtWebsite.Text = "";
            ddlCity.SelectedIndex = 0;
            ddlDepartment.SelectedIndex = 0;
            ddlDesignation.SelectedIndex = 0;
            ddlGender.SelectedIndex = 0;
            ddlMarried.SelectedIndex = 0;
            ddlState.SelectedIndex = 0;
            btnSave.Text = "Save";
        }

        #endregion
    }
}