using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HotelManagement.Management.Layers.ModelLayer;
using HotelManagement.Management.Layers.Businesslayer;
using System.Data.SqlClient;
using common;
using hotelManagement.Mangement.layers.DataLayers;

namespace HotelManagement.Management
{
    public partial class TaxGroupMaster : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        BL_TaxDetail objBL_Tax_Detail = new BL_TaxDetail();
        ML_TaxDetail objMLTax_Detail = new ML_TaxDetail();
        protected void Page_Load(object sender, EventArgs e)
        {
             if (Session["UserName"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
             if (!IsPostBack)
             {
                 BindtTaxRate();
                 BindTaxRateList(sender, e);
                 BindtaxGroupList();
             }
        }
        private void BindtTaxRate()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objBL_Tax_Detail.BL_BindTaxRateDetail(objMLTax_Detail);
                if (dt.Rows.Count > 0)
                {
                    //ddltaxratecode.DataSource = dt;
                    //ddltaxratecode.DataTextField = "TaxName";
                    //ddltaxratecode.DataValueField = "TaxrateID";
                    //ddltaxratecode.DataBind();
                    //ddltaxratecode.Items.Insert(0, "Select");
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void BindTaxRateList(object sender,EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
              //  objMLTax_Detail.ID = ddltaxratecode.SelectedValue != "" ? ddltaxratecode.SelectedValue : null;
                dt = objBL_Tax_Detail.BL_BindTaxRateinfo(objMLTax_Detail);
                if (dt.Rows.Count > 0)
                {
                    GrdtaxRateList.DataSource = dt;
                    GrdtaxRateList.DataBind();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void Save(object sender, EventArgs e)
        {
            try
            {
                if (txttaxCode.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Tax Group Code')", true);
                }
                else if (txttaxName.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Tax Group Name')", true);
               }              
                else
                {
                    objMLTax_Detail.ID = txttaxCode.Text != "" ? txttaxCode.Text : null;
                    objMLTax_Detail.TaxGroup = txttaxName.Text != "" ? txttaxName.Text : null;
                    if (chkactive.Checked == true)
                    {
                        objMLTax_Detail.isActive = 1;
                    }
                    else
                    {
                        objMLTax_Detail.isActive = 0;
                    }
                    // Detail Table delete for this Document_code
                    int z = objBL_Tax_Detail.BL_DeleteTaxGroupDetail(objMLTax_Detail);
                    // End
                    objMLTax_Detail.CreatedBy = Session["Username"].ToString();
                    objMLTax_Detail.ModifyBy = Session["Username"].ToString();
                    int x = objBL_Tax_Detail.BL_InsUpdTaxGroup(objMLTax_Detail);
                    if (x == 1)
                    {
                        // Detail Part
                        foreach (GridViewRow gvr in GrdtaxRateList.Rows)
                        {
                            Label lblTaxRateID = ((Label)gvr.FindControl("lblProgramsID"));
                            Label lblTaxRate = ((Label)gvr.FindControl("lblTaxRate"));
                            CheckBox chkSelect = ((CheckBox)gvr.FindControl("chkactive"));
                            objMLTax_Detail.TaxRateID = lblTaxRateID.Text != "" ? lblTaxRateID.Text : null;
                            objMLTax_Detail.ID = txttaxCode.Text != "" ? txttaxCode.Text : null;
                            objMLTax_Detail.TaxRate = Convert.ToDecimal(lblTaxRate.Text != "" ? lblTaxRate.Text : null);
                            if (chkSelect.Checked == true)
                            {
                                objMLTax_Detail.Is_Default = 1;
                            }
                            else
                            {
                                objMLTax_Detail.Is_Default = 0;
                            }
                            int Detail = objBL_Tax_Detail.BL_InsUpdTaxGroupDetail(objMLTax_Detail);
                            if (Detail == 1)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Saved !')", true);

                            }
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
        protected void Reset(object sender, EventArgs e)
        {
            txttaxCode.Text = "";
            txttaxName.Text = "";
            chkactive.Checked = false;
            btnSave.Text = "Save";
            BindTaxRateList(sender, e);
        }
        protected void SelecttaxGroupDetail(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            objMLTax_Detail.ID = ddlGroupCode.Text != "" ? ddlGroupCode.Text : null;
            dt = objBL_Tax_Detail.BL_SelectTaxGroupDetail(objMLTax_Detail);
            if (dt.Rows.Count > 0)
            {
                txttaxCode.Text = dt.Rows[0]["TaxGroupID"].ToString();
                txttaxName.Text = dt.Rows[0]["TaxGroupName"].ToString();
                chkactive.Checked = Convert.ToBoolean(dt.Rows[0]["Is_Active"]);
                GrdtaxRateList.DataSource = dt;
                GrdtaxRateList.DataBind();
                btnSave.Text = "Update";
            }
        }
        private void BindtaxGroupList()
        {
            DataTable dt = new DataTable();
            dt = objBL_Tax_Detail.BL_BindTaxGroup(objMLTax_Detail);
            if (dt.Rows.Count > 0)
            {
                ddlGroupCode.DataSource = dt;
                ddlGroupCode.DataValueField = "TaxGroupID";
                ddlGroupCode.DataTextField = "TaxGroupName";
                ddlGroupCode.DataBind();
                ddlGroupCode.Items.Insert(0, "Choose a Tax group code...");
            }
        }

    }
}