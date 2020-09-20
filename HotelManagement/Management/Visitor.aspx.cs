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
using hotelManagement.Mangement.layers.DataLayers;
using common;

namespace HotelManagement.Management
{
    public partial class Visitor : System.Web.UI.Page
    {
        BL_Visitors objBL_Visitor = new BL_Visitors();
        ML_Visitors objML_Visitor = new ML_Visitors();
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              //  Reset(sender, e);
                btnSave.Text = "Save";
                BindRoomList();
                BindState();             
                BindVisitorDetail();                
                txtArrivalTime.Text = DateTime.Now.ToString("HH:mm:s");               

            }
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
           
        }
        protected void BindVisitorDetail()
        {
            try
            {
                DataTable dt = new DataTable();
                objML_Visitor.ID = Request.QueryString["Id"];                
                dt = objBL_Visitor.BL_Select_Check_In_List(objML_Visitor);
                if (dt.Rows.Count > 0)
                {
                    txtName.Text = dt.Rows[0]["GuestName"].ToString();
                    ddlType.SelectedValue = dt.Rows[0]["GuestPrefix"].ToString();
                    txtAddress.Text = dt.Rows[0]["Address"].ToString();
                    ddlState.SelectedValue = dt.Rows[0]["State_Code"].ToString();
                    ddlcity.SelectedValue = dt.Rows[0]["City_COde"].ToString();
                    txtZip.Text = dt.Rows[0]["Zip_Code"].ToString();
                    ddlCountry.SelectedValue = dt.Rows[0]["Country"].ToString();
                    ddlRoomlist.SelectedValue = dt.Rows[0]["RoomName"].ToString();
                    ddlRoomNo.Visible = false;
                    lblRoomNo.Text = dt.Rows[0]["RoomNo"].ToString();
                    lblRoomNo.Visible = true;
                    ddlRoomNo.SelectedValue = dt.Rows[0]["RoomNo"].ToString();
                    txtArrival.Text = dt.Rows[0]["ArrivalDate"].ToString();
                    txtArrivalTime.Text = dt.Rows[0]["Arrivaltime"].ToString();
                    txtDeparture.Text = dt.Rows[0]["DepartureDate"].ToString();
                    txtDepartureTime.Text = dt.Rows[0]["DepartureTime"].ToString();
                    ddlAdult.SelectedValue = dt.Rows[0]["Adults"].ToString();
                    ddlChild.SelectedValue = dt.Rows[0]["Childs"].ToString();
                    ddlReservationType.SelectedValue = dt.Rows[0]["ReservationType"].ToString();
                    txtEmail.Text = dt.Rows[0]["EmailID"].ToString();
                    txtPhone.Text = dt.Rows[0]["PhoneNo"].ToString();
                    txtMobileno.Text = dt.Rows[0]["Mobileno"].ToString();
                    txtFax.Text = dt.Rows[0]["Fax"].ToString();
                    ddlIdentity.SelectedValue = dt.Rows[0]["Identity_Code"].ToString();
                    txtAadharNo.Text = dt.Rows[0]["Identity_No"].ToString();
                    rbtnGender.SelectedValue = dt.Rows[0]["gender"].ToString();
                    ddlBillTo.SelectedValue = dt.Rows[0]["BillType"].ToString();
                    rbtnPaymentMode.SelectedValue = dt.Rows[0]["paymentMode"].ToString();
                    ddlPaymentType.SelectedValue = dt.Rows[0]["paymentType"].ToString();
                    lblRoomAmount.Text = dt.Rows[0]["RoomPrice"].ToString();
                    txtDays.Text = dt.Rows[0]["Days"].ToString();
                    btnSave.Text = "Update";
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
        protected void BindRoomList()
        {
            DataTable dt = new DataTable();
            dt = objBL_Visitor.BL_BindRoomList(objML_Visitor);
            if (dt.Rows.Count > 0)
            {
                ddlRoomlist.DataSource = dt;                
                ddlRoomlist.DataValueField = "RoomID";
                ddlRoomlist.DataTextField = "RoomName";
                ddlRoomlist.DataBind();
                ddlRoomlist.Items.Insert(0, "Select");                
            }
        }
        protected void BindState()
        {
            DataTable dt = new DataTable();
            objML_Visitor.ID = "Hotel";
            dt = objBL_Visitor.BL_BindStateList(objML_Visitor);
            if (dt.Rows.Count > 0)
            {
                ddlState.DataSource = dt;
                ddlState.DataValueField = "State_Code";
                ddlState.DataTextField = "State_Name";
                ddlState.DataBind();
                ddlState.Items.Insert(0, "Select");
            }
        }
        protected void BindCity(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            objML_Visitor.ID = ddlState.SelectedValue != "" ? ddlState.SelectedValue : null;
            dt = objBL_Visitor.BL_BindCityList(objML_Visitor);
            if (dt.Rows.Count > 0)
            {
                ddlcity.DataSource = dt;
                ddlcity.DataValueField = "City_Code";
                ddlcity.DataTextField = "City_Name";
                ddlcity.DataBind();
                ddlcity.Items.Insert(0, "Select");
            }
        }

        protected void BindRoomNo(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                objML_Visitor.ID = ddlRoomlist.SelectedItem.Value;
                dt = objBL_Visitor.BL_Check_In_Room_List(objML_Visitor);
                if (dt.Rows.Count > 0)
                {
                    lblRoomAmount.Text = dt.Rows[0]["RoomPrice"].ToString();
                    Session["RoomPrice"] = dt.Rows[0]["RoomPrice"].ToString();
                    ddlRoomNo.DataSource = dt;               
                    ddlRoomNo.DataValueField = "RoomID";
                    ddlRoomNo.DataTextField = "RoomNo";
                    ddlRoomNo.DataBind();
                    ddlRoomNo.Items.Insert(0, "Select");
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
        protected void CalculateDays(object sender, EventArgs e)
        {
            try
            {
                double Taxrate = 0;
                double TaxableAmt = 0;
                double TotalAmount = 0;
                DataTable dt = new DataTable();
                objML_Visitor.ID = ddlRoomlist.SelectedValue != "" ? ddlRoomlist.SelectedValue : null;
                dt = objBL_Visitor.BL_GET_Tax_Rate(objML_Visitor);
                if (dt.Rows.Count > 0)
                {
                    double Days = (Convert.ToDateTime(txtDeparture.Text) - Convert.ToDateTime(txtArrival.Text)).TotalDays;
                    txtDays.Text = Convert.ToString(Days);

                    // Room Days wise calculate
                    double BasicAmount = Convert.ToDouble(Session["RoomPrice"]) * Days;
                    lblRoomAmount.Text = Convert.ToString(BasicAmount);

                    // Tax Rate
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        if (i == 0)
                        {
                            lblTaxName1.Text = dt.Rows[i]["TaxRateID"].ToString();
                            lblTaxRate1.Text = dt.Rows[i]["TaxRate"].ToString();
                            Taxrate = Convert.ToDouble(dt.Rows[i]["TaxRate"]);
                            TaxableAmt = BasicAmount * Taxrate / 100;
                            lbltaxAmt1.Text = Convert.ToString(TaxableAmt);
                        }
                        else if (i == 1)
                        {
                            lblTaxName2.Text = dt.Rows[i]["TaxRateID"].ToString();
                            lblTaxRate2.Text = dt.Rows[i]["TaxRate"].ToString();
                            Taxrate = Convert.ToDouble(dt.Rows[i]["TaxRate"]);
                            TaxableAmt = BasicAmount * Taxrate / 100;
                            lbltaxAmt2.Text = Convert.ToString(TaxableAmt);
                        }
                        else if (i == 2)
                        {
                            lblTaxName3.Text = dt.Rows[i]["TaxRateID"].ToString();
                            lblTaxRate3.Text = dt.Rows[i]["TaxRate"].ToString();
                            Taxrate = Convert.ToDouble(dt.Rows[i]["TaxRate"]);
                            TaxableAmt = BasicAmount * Taxrate / 100;
                            lbltaxAmt3.Text = Convert.ToString(TaxableAmt);
                        }
                        TotalAmount += TaxableAmt;
                    }
                    double Amt = TotalAmount + Convert.ToDouble(lblRoomAmount.Text);
                    lbltaxableamt.Text = Convert.ToString(Amt);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Tax Group Not mapped for this Room Name')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "')", true);
            }
           
        }
        protected void txtDiscountCalculate(object sender, EventArgs e)
        {
            try
            {
                double BasicAmount = Convert.ToDouble(lblRoomAmount.Text);
                double DiscountPer = Convert.ToDouble(txtdescount.Text);
                double TotalDiscount = BasicAmount * DiscountPer / 100;
                lblDiscountAmt.Text = Convert.ToString(TotalDiscount);
                lblDiscount.Text = txtdescount.Text;
                decimal AmountafterDiscount = Convert.ToDecimal(lbltaxableamt.Text) - Convert.ToDecimal(TotalDiscount);
                lblGrandTotal.Text = Convert.ToString(AmountafterDiscount);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void Save(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Guest Name')", true);
                }
                else if (ddlType.SelectedValue == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Name Prefix')", true);
                }
                else if (ddlType.SelectedValue == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Name Prefix')", true);
                }
                else if (ddlRoomlist.SelectedValue == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Select Room Name')", true);
                }
                else if (ddlRoomNo.SelectedValue == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Select Room No')", true);
                }
                else if (txtArrival.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Arrival Date')", true);
                }
                else if (txtArrivalTime.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Arrival Time')", true);
                }
                else if (txtDepartureTime.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Departure Time')", true);
                }
                else if (txtDeparture.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Departure Date')", true);
                }
                else if (ddlAdult.SelectedValue == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Select Adults')", true);
                }
                else if (ddlReservationType.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Select Reservation Type')", true);
                }
                else if (txtEmail.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill EmailID')", true);
                }
                else if (txtMobileno.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Mobile No')", true);
                }
                else if (ddlIdentity.SelectedValue == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Select Identity')", true);
                }
                else if (txtAadharNo.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Identity No')", true);
                }
                else if (lblGrandTotal.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Please check Amount !')", true);
                }
                else
                {
                    con.Open();
                    SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);

                    string qry = "";
                    qry = "select  MAX(VisitorID) as VisitorID  from SPCN_Check_In ";
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(qry, con);
                    cmd.Transaction = trans;
                    cmd.Clone();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        objML_Visitor.ID = dr["VisitorID"].ToString();
                    }
                    if (clsCommon.myLen(objML_Visitor.ID) <= 0)
                    {
                        objML_Visitor.ID = "VISIT0000001";
                        lblID.Text = objML_Visitor.ID;
                    }
                    else
                    {
                        objML_Visitor.ID = clsCommon.incval(objML_Visitor.ID);
                        lblID.Text = objML_Visitor.ID;
                    }
                    con.Close();
                    objML_Visitor.Name = txtName.Text != "" ? txtName.Text : null;
                    objML_Visitor.NamePrefix = ddlType.SelectedValue != "" ? ddlType.SelectedValue : null;
                    objML_Visitor.Address = txtAddress.Text != "" ? txtAddress.Text : null;
                    objML_Visitor.State = ddlState.SelectedValue != "" ? ddlState.SelectedValue : null;
                    objML_Visitor.City = ddlcity.SelectedValue != "" ? ddlcity.SelectedValue : null;
                    objML_Visitor.ZipCode = txtZip.Text != "" ? txtZip.Text : null;
                    objML_Visitor.Country = ddlCountry.SelectedValue != "" ? ddlCountry.SelectedValue : null;
                    objML_Visitor.RoomName = ddlRoomlist.SelectedValue != "" ? ddlRoomlist.SelectedValue : null;
                    objML_Visitor.RoomNo = ddlRoomNo.SelectedItem.Text != "" ? ddlRoomNo.SelectedItem.Text : null;
                    objML_Visitor.ArrivalDate = txtArrival.Text != "" ? txtArrival.Text : null;
                    objML_Visitor.ArrivalTime = txtArrivalTime.Text != "" ? txtArrivalTime.Text : null;
                    objML_Visitor.DepartureDate = txtDeparture.Text != "" ? txtDeparture.Text : null;
                    objML_Visitor.DepartureTime = txtDepartureTime.Text != "" ? txtDepartureTime.Text : null;
                    objML_Visitor.Days = Convert.ToInt32(txtDays.Text != "" ? txtDays.Text : null);
                    objML_Visitor.Adults = Convert.ToInt32(ddlAdult.SelectedValue != "" ? ddlAdult.SelectedValue : null);
                    objML_Visitor.Child = Convert.ToInt32(ddlChild.SelectedValue != "" ? ddlChild.SelectedValue : null);
                    objML_Visitor.ReservationType = ddlReservationType.SelectedValue != "" ? ddlReservationType.SelectedValue : null;
                    objML_Visitor.Email = txtEmail.Text != "" ? txtEmail.Text : null;
                    objML_Visitor.PhoneNo = txtPhone.Text != "" ? txtPhone.Text : null;
                    objML_Visitor.MobileNo = txtMobileno.Text != "" ? txtMobileno.Text : null;
                    objML_Visitor.Fax = txtFax.Text != "" ? txtFax.Text : null;
                    objML_Visitor.Identity = ddlIdentity.SelectedValue != "" ? ddlIdentity.SelectedValue : null;
                    objML_Visitor.IdentityNo = txtAadharNo.Text != "" ? txtAadharNo.Text : null;
                    objML_Visitor.Gender = rbtnGender.SelectedValue != "" ? rbtnGender.SelectedValue : null;
                    objML_Visitor.BillType = ddlBillTo.SelectedValue != "" ? ddlBillTo.SelectedValue : null;
                    objML_Visitor.PaymentType = ddlPaymentType.SelectedValue != "" ? ddlPaymentType.SelectedValue : null;
                    objML_Visitor.PaymentMode = rbtnPaymentMode.SelectedValue != "" ? rbtnPaymentMode.SelectedValue : null;
                    objML_Visitor.RoomPrice = lblRoomAmount.Text != "" ? lblRoomAmount.Text : null;
                    objML_Visitor.CreatedBy = Session["Username"].ToString();
                    objML_Visitor.ModifyBy = Session["Username"].ToString();
                    objML_Visitor.DiscountPer = Convert.ToDecimal(txtdescount.Text != "" ? txtdescount.Text : null);
                    objML_Visitor.TaxName1 = lblTaxName1.Text != "" ? lblTaxName1.Text : null;
                    objML_Visitor.TaxRate1 = Convert.ToDecimal(lblTaxRate1.Text != "" ? lblTaxRate1.Text : null);
                    objML_Visitor.TaxAmt1 = Convert.ToDecimal(lbltaxAmt1.Text != "" ? lbltaxAmt1.Text : null);
                    objML_Visitor.TaxName2 = lblTaxName2.Text != "" ? lblTaxName2.Text : null;
                    objML_Visitor.TaxRate2 = Convert.ToDecimal(lblTaxRate2.Text != "" ? lblTaxRate2.Text : null);
                    objML_Visitor.TaxAmt2 = Convert.ToDecimal(lbltaxAmt2.Text != "" ? lbltaxAmt2.Text : null);
                    objML_Visitor.TaxName3 = lblTaxName3.Text != "" ? lblTaxName3.Text : null;
                    objML_Visitor.TaxRate3 = Convert.ToDecimal(lblTaxRate3.Text != "" ? lblTaxRate3.Text : null);
                    objML_Visitor.TaxAmt3 = Convert.ToDecimal(lbltaxAmt3.Text != "" ? lbltaxAmt3.Text : null);
                    objML_Visitor.TaxableAmount=Convert.ToDecimal(lbltaxableamt.Text!=""?lbltaxableamt.Text:null);
                    objML_Visitor.DiscountAmt = Convert.ToDecimal(lblDiscountAmt.Text != "" ? lblDiscountAmt.Text : null);
                    objML_Visitor.GrandTotal = Convert.ToDecimal(lblGrandTotal.Text != "" ? lblGrandTotal.Text : null);
                    int x = objBL_Visitor.BL_SaveVisitorsDetail(objML_Visitor);
                    if (x == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Saved !')", true);
                        Reset(sender, e);
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
            txtAadharNo.Text = "";
            txtAddress.Text = "";
            txtArrival.Text = "";
            txtArrivalTime.Text = "";
            txtDays.Text = "";
            txtDeparture.Text = "";
            txtDepartureTime.Text = "";
            txtEmail.Text = "";
            txtFax.Text = "";
            txtMobileno.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtZip.Text = "";
            ddlAdult.SelectedIndex = 0;
            ddlBillTo.SelectedIndex = 0;
            ddlChild.SelectedIndex = 0;
            ddlcity.SelectedIndex = 0;
            ddlIdentity.SelectedIndex = 0;
            ddlPaymentType.SelectedIndex = 0;
            ddlReservationType.SelectedIndex = 0;
            ddlRoomlist.SelectedIndex = 0;
            ddlRoomNo.SelectedIndex = 0;
            ddlState.SelectedIndex = 0;
            ddlType.SelectedIndex = 0;
            btnSave.Text = "Save";
            lblRoomNo.Text = "";
            lblRoomAmount.Text = "";
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
            lblDiscountAmt.Text = "";
            lblDiscount.Text = "";
        }
    }
}