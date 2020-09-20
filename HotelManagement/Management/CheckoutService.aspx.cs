using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HotelManagement.Management.Layers.Businesslayer;
using HotelManagement.Management.Layers.ModelLayer;
using System.Data;
using hotelManagement.Mangement.layers.DataLayers;
using common;
using System.Drawing;
using System.Data.SqlClient;


namespace HotelManagement.Management
{
    public partial class CheckoutService : System.Web.UI.Page
    {
        BL_Visitors objBL_Visitors = new BL_Visitors();
        ML_Visitors objML_Visitors = new ML_Visitors();
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (!IsPostBack)
            {
                BindVisitorList();
            }
        }
        private void BindVisitorList()
        {
            DataTable dt = new DataTable();
            dt = objBL_Visitors.BL_DropdownSelectionVisitors(objML_Visitors);
            if (dt.Rows.Count > 0)
            {
                ddlGuestName.DataSource = dt;
                ddlGuestName.DataValueField = "VisitorID";
                ddlGuestName.DataTextField = "GuestName";
                ddlGuestName.DataBind();
                ddlGuestName.Items.Insert(0, "Choose a Guest Name...");
            }
        }
        protected void SelectGuestDetail(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                objML_Visitors.ID = ddlGuestName.SelectedValue != "" ? ddlGuestName.SelectedValue : null;
                dt = objBL_Visitors.BL_Select_Check_In_List(objML_Visitors);
                if (dt.Rows.Count > 0)
                {                    
                    txtRoomNo.Text = dt.Rows[0]["RoomNo"].ToString();
                    lblID.Text = dt.Rows[0]["VisitorID"].ToString();
                    lblRoomPrice1.Text = dt.Rows[0]["RoomPrice"].ToString();
                    lbltaxAmt1.Text = dt.Rows[0]["TaxAmt1"].ToString();
                    lbltaxAmt2.Text = dt.Rows[0]["TaxAmt2"].ToString();
                    lbltaxAmt3.Text = dt.Rows[0]["TaxAmt3"].ToString();
                    lblTaxName1.Text = dt.Rows[0]["TaxName1"].ToString();
                    lblTaxName2.Text = dt.Rows[0]["TaxName2"].ToString();
                    lblTaxName3.Text = dt.Rows[0]["TaxName3"].ToString();
                    lblTaxRate1.Text = dt.Rows[0]["Taxrate1"].ToString();
                    lblTaxRate2.Text = dt.Rows[0]["Taxrate2"].ToString();
                    lblTaxRate3.Text = dt.Rows[0]["Taxrate3"].ToString();
                    lbltaxableamt.Text = dt.Rows[0]["TaxableAmount"].ToString();
                    lblDiscountPer.Text = dt.Rows[0]["Discount"].ToString();
                    lblDisocuntAmt.Text = dt.Rows[0]["DiscountAmt"].ToString();
                    GrdGuestList.DataSource = dt;
                    GrdGuestList.DataBind();
                    ServiceDeskDetail();
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "')", true);

            }
        }
        private void ServiceDeskDetail()
        {
            try
            {
                Decimal Amount = 0;
                Decimal ItemPrice = 0;
                Decimal TotalPrice = 0;
                int i = 0;
                DataTable dt = new DataTable();
                objML_Visitors.Name = ddlGuestName.SelectedValue != "" ? ddlGuestName.SelectedValue : null;
                objML_Visitors.RoomNo = txtRoomNo.Text != "" ? txtRoomNo.Text : null;
                dt = objBL_Visitors.BL_Select_Service_Desk_Detail(objML_Visitors);
                if (dt.Rows.Count > 0)
                {
                    GrdServiceDesk.DataSource = dt;
                    GrdServiceDesk.DataBind();
                    for (i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        Amount = Convert.ToDecimal(dt.Rows[i]["ItemPrice"]);
                        ItemPrice = ItemPrice + Amount;
                    }

                    DivServiceDesk.Visible = true;
                    divCaptionServiceDesk.Visible = true;
                }
                else
                {
                    DivServiceDesk.Visible = false;
                    divCaptionServiceDesk.Visible = false;
                    divTotalCheckOutPrice.Visible = false;
                }
                // taxable AMount and Service Desk Amount
                TotalPrice = Convert.ToDecimal(lbltaxableamt.Text);
                TotalPrice = TotalPrice + ItemPrice;
                lblServiceDeskAmt.Text = Convert.ToString(ItemPrice);
                lblTotalAmount.Text = Convert.ToString(TotalPrice);
                // End

                // Grand Total After Discount
                decimal GrandTotal = TotalPrice - Convert.ToDecimal(lblDisocuntAmt.Text);
                lblGrandTotal.Text = Convert.ToString(GrandTotal);
                // ENd
                DivGuestDetail.Visible = true;
                divTotalCheckOutPrice.Visible = true;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "')", true);

            }
        }
       
        protected void Clear(object sender, EventArgs e)
        {
            txtRoomNo.Text = "";          
            btnSave.Text = "Save";
            ddlGuestName.SelectedIndex = 0;
            DivServiceDesk.Visible = false;
            divCaptionServiceDesk.Visible = false;
            divTotalCheckOutPrice.Visible = false;
            GrdGuestList.DataSource = null;
            GrdGuestList.DataBind();
            GrdServiceDesk.DataSource = null;
            GrdServiceDesk.DataBind();
            lbltaxableamt.Text = "";
            lbltaxAmt1.Text = "";
            lbltaxAmt2.Text = "";
            lbltaxAmt3.Text = "";
            lblTaxName1.Text = "";
            lblTaxName2.Text = "";
            lblTaxName3.Text = "";
            lblTaxRate1.Text = "";
            lblTaxRate2.Text = "";
            lblTaxRate3.Text = "";
            lblGrandTotal.Text = "";
            lblDisocuntAmt.Text = "";
            lblDiscountPer.Text = "";
        }
        protected void Save(object sender, EventArgs e)
        {
            try
            {
                if (ddlGuestName.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Select Guest Name')", true);
                }
                else if (lblTotalAmount.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('No Data Saved, please verify room no for checkout !')", true);
                }
                else if (lblGrandTotal.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('No Data Saved, please verify room no for checkout !')", true);
                }
                else
                {
                    con.Open();
                    SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);

                    string qry = "";
                    qry = "select  MAX(CheckOutID) as CheckOutID  from SPCN_Visitor_CheckOut_HEAD ";
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(qry, con);
                    cmd.Transaction = trans;
                    cmd.Clone();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        objML_Visitors.ID = dr["CheckOutID"].ToString();
                    }
                    if (clsCommon.myLen(objML_Visitors.ID) <= 0)
                    {
                        objML_Visitors.ID = "CHOUT0000001";
                        lblID.Text = objML_Visitors.ID;
                    }
                    else
                    {
                        objML_Visitors.ID = clsCommon.incval(objML_Visitors.ID);
                        lblID.Text = objML_Visitors.ID;
                    }
                   // GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
                    {
                        con.Close();
                        objML_Visitors.VisitorID = ddlGuestName.SelectedValue != "" ? ddlGuestName.SelectedValue : null;
                        objML_Visitors.RoomNo = txtRoomNo.Text != "" ? txtRoomNo.Text : null;
                        objML_Visitors.TotolAmount = Convert.ToDecimal(lblTotalAmount.Text != "" ? lblTotalAmount.Text : null);
                        objML_Visitors.RoomAmount = Convert.ToDecimal(lblRoomPrice1.Text != "" ? lblRoomPrice1.Text : null);
                        objML_Visitors.ServiceDeskAmount = Convert.ToDecimal(lblServiceDeskAmt.Text != "" ? lblServiceDeskAmt.Text : null);
                        objML_Visitors.CreatedBy = Session["Username"].ToString();
                        objML_Visitors.ModifyBy = Session["Username"].ToString();
                        objML_Visitors.TaxName1 = lblTaxName1.Text != "" ? lblTaxName1.Text : null;
                        objML_Visitors.TaxRate1 = Convert.ToDecimal(lblTaxRate1.Text != "" ? lblTaxRate1.Text : null);
                        objML_Visitors.TaxAmt1 = Convert.ToDecimal(lbltaxAmt1.Text != "" ? lbltaxAmt1.Text : null);
                        objML_Visitors.TaxName2 = lblTaxName2.Text != "" ? lblTaxName2.Text : null;
                        objML_Visitors.TaxRate2 = Convert.ToDecimal(lblTaxRate2.Text != "" ? lblTaxRate2.Text : null);
                        objML_Visitors.TaxAmt2 = Convert.ToDecimal(lbltaxAmt2.Text != "" ? lbltaxAmt2.Text : null);
                        objML_Visitors.TaxName3 = lblTaxName3.Text != "" ? lblTaxName3.Text : null;
                        objML_Visitors.TaxRate3 = Convert.ToDecimal(lblTaxRate3.Text != "" ? lblTaxRate3.Text : null);
                        objML_Visitors.TaxAmt3 = Convert.ToDecimal(lbltaxAmt3.Text != "" ? lbltaxAmt3.Text : null);
                        objML_Visitors.TaxableAmount = Convert.ToDecimal(lbltaxableamt.Text != "" ? lbltaxableamt.Text : null);
                        objML_Visitors.DiscountAmt = Convert.ToDecimal(lblDisocuntAmt.Text != "" ? lblDisocuntAmt.Text : null);
                        objML_Visitors.GrandTotal = Convert.ToDecimal(lblGrandTotal.Text != "" ? lblGrandTotal.Text : null);
                        int x = objBL_Visitors.BL_InsUpdVisitorCheckOut(objML_Visitors);
                        if (x == 1)
                        {
                            // Detail Table Insert
                            foreach(GridViewRow gvr in GrdServiceDesk.Rows)
                            {
                                Label lblServiceID = (Label)gvr.FindControl("lblServiceDeskID");
                                objML_Visitors.ServiceDaskID = lblServiceID.Text != "" ? lblServiceID.Text : null;
                                objML_Visitors.ID = lblID.Text != "" ? lblID.Text : null;
                                int Detail = objBL_Visitors.BL_InsUpdVisitorCheckOutDetail(objML_Visitors);
                                if (Detail == 1)
                                {}
                            }
                            // Update Check_In Table Records
                            objML_Visitors.VisitorID = ddlGuestName.SelectedValue != "" ? ddlGuestName.SelectedValue : null;
                            int UpdateVisitor = objBL_Visitors.BL_UpdVisitorCheckOutData(objML_Visitors);
                            if (UpdateVisitor == 1)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Saved !)", true);   
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
        

    }
}