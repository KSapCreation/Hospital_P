using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Hospital_P.H.layers.BusinessLayers;
using Hospital_P.H.layers.ModelLayers;
using System.Data.SqlClient;
using Hospital_P.H.layers.DataLayers;
using common;


namespace Hospital_P.H
{
    public partial class Mapping : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                BindTestMaster();
                BindParameter();
            }
        }
        protected void BindTestMaster()
        {
            DataTable dt = new DataTable();
            dt = objBL_Laboratory.BL_BindTestMaster(objML_Laboratory);
            if (dt.Rows.Count > 0)
            {
                ddlTestName.DataSource = dt;
                ddlTestName.DataValueField = "TestID";
                ddlTestName.DataTextField = "TestName";
                ddlTestName.DataBind();
                ddlTestName.Items.Insert(0, "Select");
            }
        }
        protected void BindParameter()
        {
            DataTable dt = new DataTable();
            dt = objBL_Laboratory.BL_BindParameter(objML_Laboratory);
            if (dt.Rows.Count > 0)
            {
                DlParameterMapping.DataSource = dt;
                DlParameterMapping.DataBind();
              
            }
        }

        protected void Cancel(object sender, EventArgs e)
        {
            Reset();
        }
        private void Reset()
        {
            ddlTestName.SelectedIndex = 0;
            BindParameter();
            btnSave.Text = "Save";
        }
        protected void Save(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                int j = 0;
                if (ddlTestName.SelectedValue == "Select")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('First Select Test !');", true);
                }
                foreach (DataListItem dlist in DlParameterMapping.Items)
                {
                    CheckBox chkSelect = ((CheckBox)dlist.FindControl("chkParameter"));
                    if (chkSelect.Checked == true)
                    {
                        j = j + 1;
                    }
                }
                if (j <= 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please Select Atleast One Paramter !');", true);
                }
                else
                {

                    foreach (DataListItem dlist in DlParameterMapping.Items)
                    {
                        Label ParameterName = ((Label)dlist.FindControl("lblParameterName"));
                        Label lblParameterID = ((Label)dlist.FindControl("lblParameterID"));
                        CheckBox chkSelect = ((CheckBox)dlist.FindControl("chkParameter"));

                        if (chkSelect.Checked == true)
                        {
                            objML_Laboratory.chkSelect = 1;
                        }
                        else
                        {
                            objML_Laboratory.chkSelect = 0;
                        }
                        objML_Laboratory.ParameterName = ParameterName.Text != "" ? ParameterName.Text : null;
                        objML_Laboratory.TestName = ddlTestName.SelectedItem.Text != "" ? ddlTestName.SelectedItem.Text : null;
                        objML_Laboratory.TestID = ddlTestName.SelectedValue != "" ? ddlTestName.SelectedValue : null;
                        objML_Laboratory.ParameterID = lblParameterID.Text != "" ? lblParameterID.Text : null;

                        int x = objBL_Laboratory.BL_InsUpdParameterMapping(objML_Laboratory);
                        if (x == 1)
                        { }

                        i = i + 1;
                    }
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Parameter Mapping Complete. ');", true);
                    btnSave.Text = "Update";
                }
               
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void SelectTestParameter(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            objML_Laboratory.TestID = ddlTestName.SelectedItem.Text != "" ? ddlTestName.SelectedItem.Text : null;
            dt = objBL_Laboratory.BL_SelectTestParameterMapping(objML_Laboratory);
            if (dt.Rows.Count > 0)
            {
                DlParameterMapping.DataSource = dt;
                DlParameterMapping.DataBind();
                btnSave.Text = "Update";

            }
            else
            {
                BindParameter();
                btnSave.Text = "Save";
            }
        }
    }
}