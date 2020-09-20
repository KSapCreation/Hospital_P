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
    public partial class TestMaster : System.Web.UI.Page
    {
        BL_Laboratory objBL_Laboratory = new BL_Laboratory();
        ML_Laboratory objML_Laboratory = new ML_Laboratory();
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTestMaster();
            }
        }
        protected void Save(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);
                if (txtTestname.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Fill Test Name')", true);
                }
                else if (txtTestname.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Fill Test Cost')", true);
                }
                else if (btnSave.Text == "Save")
                {
                    string qry = "";
                    qry = "select  MAX(TestID) as TestID  from SPCN_Test_Master ";
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(qry, con);
                    cmd.Transaction = trans;
                    cmd.Clone();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        objML_Laboratory.ID = dr["TestID"].ToString();
                    }
                    if (objML_Laboratory.ID == null || objML_Laboratory.ID.Length <= 0 || objML_Laboratory.ID.Equals(""))
                    {
                        objML_Laboratory.ID = "LB000000001";
                    }
                    else
                    {
                        objML_Laboratory.ID = clsCommon.incval(objML_Laboratory.ID);
                    }
                    con.Close();

                    objML_Laboratory.TestName = txtTestname.Text != "" ? txtTestname.Text : null;
                    objML_Laboratory.Cost = txtCost.Text != "" ? txtCost.Text : null;
                    objML_Laboratory.CreatedBy = Session["UserName"].ToString();
                    objML_Laboratory.ModifyBy = Session["UserName"].ToString();

                }
                else if (btnSave.Text == "Update")
                {
                    objML_Laboratory.ID = txtTestID.Text != "" ? txtTestID.Text : null;
                    objML_Laboratory.TestName = txtTestname.Text != "" ? txtTestname.Text : null;
                    objML_Laboratory.Cost = txtCost.Text != "" ? txtCost.Text : null;
                    objML_Laboratory.CreatedBy = Session["UserName"].ToString();
                    objML_Laboratory.ModifyBy = Session["UserName"].ToString();
                                      
                }
                int x = objBL_Laboratory.BL_InsTestMaster(objML_Laboratory); 
                if (x == 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Test Saved')", true);
                    txtTestID.Text = objML_Laboratory.ID;
                    BindTestMaster();

                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
        protected void Cancel(object sender, EventArgs e)
        {
            txtTestID.Text = "";
            txtTestname.Text = "";
            txtCost.Text = "";
            btnSave.Text = "Save";
        }
        protected void Delete(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            {
                Label lblID = (Label)gvr.FindControl("lblAccountType");
                DataTable dt = new DataTable();
                objML_Laboratory.ID = txtTestID.Text != "" ? txtTestID.Text : null;
                int x = objBL_Laboratory.BL_DeleteTestMaster(objML_Laboratory);
                if (x == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Delete')", true);
                    BindTestMaster();
                }
            }
        }
        protected void Update(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
                {
                    Label lblProgramsID = (Label)gvr.FindControl("lblAccountType");
                    DataTable dt = new DataTable();
                    objML_Laboratory.ID = lblProgramsID.Text != "" ? lblProgramsID.Text : null;
                    dt = objBL_Laboratory.BL_EditTestMaster(objML_Laboratory);
                    if (dt.Rows.Count > 0)
                    {
                        txtTestID.Text = dt.Rows[0]["TestID"].ToString();
                        txtTestname.Text = dt.Rows[0]["TestName"].ToString();
                        txtCost.Text = dt.Rows[0]["Cost"].ToString();
                        btnSave.Text = "Update";

                    }

                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
        protected void BindTestMaster()
        {
            DataTable dt = new DataTable();
            dt = objBL_Laboratory.BL_BindTestMaster(objML_Laboratory);
            if (dt.Rows.Count > 0)
            {
                GrdTest.DataSource = dt;
                GrdTest.DataBind();
            }
        }
        protected void GrdTest_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdTest.PageIndex = e.NewPageIndex;
            BindTestMaster();
        }
    }
}