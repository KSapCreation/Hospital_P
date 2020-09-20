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
using System.Configuration;

namespace hotelManagement.H
{
    public partial class ItemMaster : System.Web.UI.Page
    {
        BL_Pharmacy objBL_Pharmacy = new BL_Pharmacy();
        ML_Pharmacy objML_Pharmacy = new ML_Pharmacy();
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                BindUnit();
                BindItemMaster();
            }
        }
        protected void BindUnit()
        {
            DataTable dt = new DataTable();
            dt = objBL_Pharmacy.BL_BindUnitMaster(objML_Pharmacy);
            if (dt.Rows.Count > 0)
            {
                ddlUnit.DataSource = dt;
                ddlUnit.DataTextField = "UnitName";
                ddlUnit.DataValueField = "UnitID";
                ddlUnit.DataBind();
                ddlUnit.Items.Insert(0, "Select");
            }
        }
        protected void Save(object sender, EventArgs e)
        {
            try
            {
                if (btnSave.Text == "Save")
                {
                    con.Open();
                    SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);

                    string qry = "";
                    qry = "select  MAX(ItemCode) as ItemCode  from SPCN_ITEM_MASTER ";
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(qry, con);
                    cmd.Transaction = trans;
                    cmd.Clone();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        objML_Pharmacy.ItemCode = dr["ItemCode"].ToString();
                    }
                    if (clsCommon.myLen(objML_Pharmacy.ItemCode) <= 0)
                    {
                        objML_Pharmacy.ItemCode = "IT000000001";
                    }
                    else
                    {
                        objML_Pharmacy.ItemCode = clsCommon.incval(objML_Pharmacy.ItemCode);
                    }
                    con.Close();
                    objML_Pharmacy.ItemName = txtItemName.Text != "" ? txtItemName.Text : null;
                    objML_Pharmacy.SaleAccount = txtSaleAccount.Text != "" ? txtSaleAccount.Text : null;
                    objML_Pharmacy.PurchaseAccount = txtPurchaseAcount.Text != "" ? txtPurchaseAcount.Text : null;
                    objML_Pharmacy.ItemCost = txtCost.Text != "" ? txtCost.Text : null;
                    objML_Pharmacy.MRP = txtMRP.Text != "" ? txtMRP.Text : null;
                    objML_Pharmacy.HSNCode = txtHSN.Text != "" ? txtHSN.Text : null;
                    objML_Pharmacy.UOM = ddlUnit.SelectedValue != "" ? ddlUnit.SelectedValue : null;
        
                    if (chkActive.Checked == true)
                    {
                        objML_Pharmacy.Active = "1";
                    }
                    else
                    {
                        objML_Pharmacy.Active = "0";
                    }
                    objML_Pharmacy.CreatedBy = Session["UserName"].ToString();
                    objML_Pharmacy.ModifyBy = Session["UserName"].ToString();
                    int x = objBL_Pharmacy.BL_InsUpdItemMaster(objML_Pharmacy);
                    if (x == 1)
                    {
                        BindItemMaster();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Saved')", true);
                        txtItemCode.Text = objML_Pharmacy.ItemCode;
                        btnSave.Text = "Update";
                        
                    }
                }
                else
                {
                    objML_Pharmacy.ItemCode = txtItemCode.Text != "" ? txtItemCode.Text : null;
                    objML_Pharmacy.ItemName = txtItemName.Text != "" ? txtItemName.Text : null;
                    objML_Pharmacy.SaleAccount = txtSaleAccount.Text != "" ? txtSaleAccount.Text : null;
                    objML_Pharmacy.PurchaseAccount = txtPurchaseAcount.Text != "" ? txtPurchaseAcount.Text : null;
                    objML_Pharmacy.ItemCost = txtCost.Text != "" ? txtCost.Text : null;
                    objML_Pharmacy.MRP = txtMRP.Text != "" ? txtMRP.Text : null;
                    objML_Pharmacy.HSNCode = txtHSN.Text != "" ? txtHSN.Text : null;
                    objML_Pharmacy.UOM = ddlUnit.SelectedValue != "" ? ddlUnit.SelectedValue : null;
                    if (chkActive.Checked == true)
                    {
                        objML_Pharmacy.Active = "1";
                    }
                    else
                    {
                        objML_Pharmacy.Active = "0";
                    }
                    objML_Pharmacy.CreatedBy = Session["UserName"].ToString();
                    objML_Pharmacy.ModifyBy = Session["UserName"].ToString();
                    int x = objBL_Pharmacy.BL_InsUpdItemMaster(objML_Pharmacy);
                    if (x == 1)
                    {
                        BindItemMaster();
                        ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('Data Saved')", true);
                    }
                }
            }
            catch(Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('" + ex.Message.ToString() + "');", true);
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
                    com.CommandText = "select ItemCode from SPCN_ITEM_MASTER where " + "ItemName like '%' + @Search + '%'";

                    com.Parameters.AddWithValue("@Search", prefixText);
                    com.Connection = con;
                    con.Open();
                    List<string> countryNames = new List<string>();
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            countryNames.Add(sdr["ItemCode"].ToString());
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
                Label lblCheck = new Label();
                DataTable dt = new DataTable();
                objML_Pharmacy.ID = txtSerach.Text != "" ? txtSerach.Text : null;
                dt = objBL_Pharmacy.BL_SearchItem(objML_Pharmacy);
                if (dt.Rows.Count > 0)
                {
                    txtItemCode.Text = dt.Rows[0]["ItemCode"].ToString();
                    txtItemName.Text = dt.Rows[0]["ItemName"].ToString();
                    txtHSN.Text = dt.Rows[0]["HSNCode"].ToString();
                    ddlUnit.SelectedValue = dt.Rows[0]["UOM"].ToString();
                    txtSaleAccount.Text = dt.Rows[0]["SaleAccount"].ToString();
                    txtPurchaseAcount.Text = dt.Rows[0]["PurchaseAccount"].ToString();
                    txtCost.Text = dt.Rows[0]["Cost"].ToString();
                    txtMRP.Text = dt.Rows[0]["MRP"].ToString();
                    lblCheck.Text = dt.Rows[0]["Active"].ToString();
                    if (lblCheck.Text == "1")
                    {
                        chkActive.Checked = true;
                    }
                    else
                    {
                        chkActive.Checked = false;
                    }
                    btnSave.Text = "Update";
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void Cancel(object sender, EventArgs e)
        {
            Reset();
        }
        private void Reset()
        {
            txtCost.Text = "";
            txtHSN.Text = "";
            txtItemCode.Text = "";
            txtItemName.Text = "";
            txtMRP.Text = "";
            txtPurchaseAcount.Text = "";
            txtSaleAccount.Text = "";
            txtSerach.Text = "";
            btnSave.Text = "Save";
            ddlUnit.SelectedIndex = 0;
            chkActive.Checked = false;
        }
        private void BindItemMaster()
        {
            DataTable dt = new DataTable();
            dt = objBL_Pharmacy.BL_BindItemMaster(objML_Pharmacy);
            if (dt.Rows.Count > 0)
            {
                GrdItemList.DataSource = dt;
                GrdItemList.DataBind();
            }
        }
        protected void GrdItemList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdItemList.PageIndex = e.NewPageIndex;
            BindItemMaster();
        }
    }
}