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
    public partial class TaxMaster : System.Web.UI.Page
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
                BindTaxRateList();
            }
        }
        protected void Save(object sender, EventArgs e)
        {
            try
            {                
                if (txttaxCode.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Tax Code')", true);
                }
                else if (txttaxName.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Tax Name')", true);
                }
                else if (txtRate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Tax Rate')", true);
                }
                else
                {
                    objMLTax_Detail.ID = txttaxCode.Text != "" ? txttaxCode.Text : null;
                    objMLTax_Detail.TaxName = txttaxName.Text != "" ? txttaxName.Text : null;
                    if (chkactive.Checked == true)
                    {
                        objMLTax_Detail.isActive = 1;
                    }
                    else
                    {
                        objMLTax_Detail.isActive = 0;
                    }
                    int z = objBL_Tax_Detail.BL_DeleteTaxRateDetail(objMLTax_Detail);
                    objMLTax_Detail.CreatedBy = Session["Username"].ToString();
                    objMLTax_Detail.ModifyBy = Session["Username"].ToString();
                    int x = objBL_Tax_Detail.BL_InsUpdTaxRate(objMLTax_Detail);
                    if (x == 1)
                    {
                        // Detail Part
                        string[] parts = txtRate.Text.Split(',');
                        foreach (string s in parts)
                        {
                            objMLTax_Detail.TaxRate = Convert.ToDecimal(s);
                            objMLTax_Detail.ID = txttaxCode.Text != "" ? txttaxCode.Text : null;
                            int Detail = objBL_Tax_Detail.BL_InsUpdTaxRateDetail(objMLTax_Detail);
                            if (Detail == 1)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Saved !')", true);
                                BindTaxRateList();
                            }
                        }
                        Reset(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
        private void BindTaxRateList()
        {
            DataTable dt = new DataTable();
            dt = objBL_Tax_Detail.BL_BindTaxRateDetail(objMLTax_Detail);
            if (dt.Rows.Count > 0)
            {
                GrdtaxRateList.DataSource = dt;
                GrdtaxRateList.DataBind();
            }
        }
        protected void GrdtaxRateList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdtaxRateList.PageIndex = e.NewPageIndex;
            BindTaxRateList();
        }
        protected void Delete(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            {
                Label lblID = (Label)gvr.FindControl("lblProgramsID");
                DataTable dt = new DataTable();
                objMLTax_Detail.ID = lblID.Text != "" ? lblID.Text : null;
                int z = objBL_Tax_Detail.BL_DeleteTaxRateDetail(objMLTax_Detail);
                int x = objBL_Tax_Detail.BL_DeleteTaxRateMaster(objMLTax_Detail);
                if (x == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Delete')", true);
                    BindTaxRateList();
                }
            }
        }
        protected void Update(object sender, EventArgs e)
        {
            try
            {
                Int32 i = 0;
                String RoomNo = "";
                GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
                {
                    Label lblProgramsID = (Label)gvr.FindControl("lblProgramsID");
                    DataTable dt = new DataTable();
                    objMLTax_Detail.ID = lblProgramsID.Text != "" ? lblProgramsID.Text : null;
                    dt = objBL_Tax_Detail.BL_SelectTaxRateDetail(objMLTax_Detail);
                    if (dt.Rows.Count > 0)
                    {
                        txttaxCode.Text = dt.Rows[0]["taxrateid"].ToString();
                        txttaxName.Text = dt.Rows[0]["Taxname"].ToString();
                        lblID.Text = dt.Rows[0]["taxrateid"].ToString();
                        chkactive.Checked = Convert.ToBoolean(dt.Rows[0]["Is_Active"]);
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (i != 0)
                            {
                                RoomNo += ",";
                            }
                            RoomNo += dr["TaxRate"].ToString();
                            i = i + 1;
                        }

                        txtRate.Text = RoomNo;
                        btnSave.Text = "Update";
                    }
                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void Reset(object sender, EventArgs e)
        {
            txtRate.Text = "";
            txttaxCode.Text = "";
            txttaxName.Text = "";
            chkactive.Checked = false;
            btnSave.Text = "Save";
        }
    }
}