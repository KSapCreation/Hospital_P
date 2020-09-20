using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using HotelManagement.Management.Layers.Businesslayer;
using HotelManagement.Management.Layers.ModelLayer;
using System.Data;
using System.Data.SqlClient;
using hotelManagement.Mangement.layers.DataLayers;
using common;
using System.Drawing;

namespace HotelManagement.Management
{
    public partial class ServiceDesk : System.Web.UI.Page
    {
        BL_Visitors objBL_Visitors = new BL_Visitors();
        ML_Visitors objML_Visitors = new ML_Visitors();
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (!IsPostBack)
            { BindVisitorList(); BindItemList(); }
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
        private void BindItemList()
        {
            DataTable dt = new DataTable();
            dt = objBL_Visitors.BL_Bind_Item_List(objML_Visitors);
            if (dt.Rows.Count > 0)
            {
                ddlItemList.DataSource = dt;
                ddlItemList.DataValueField = "ItemID";
                ddlItemList.DataTextField = "ItemName";
                ddlItemList.DataBind();
                ddlItemList.Items.Insert(0, "Choose a Item Name...");
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
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "');", true);

            }
        }
        protected void SelectItemPriceList(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                objML_Visitors.ID = ddlItemType.SelectedItem.Text != "" ? ddlItemType.SelectedItem.Text : null;
                objML_Visitors.Name = ddlItemList.SelectedValue != "" ? ddlItemList.SelectedValue : null;
                dt = objBL_Visitors.BL_Select_Item_List(objML_Visitors);
                if (dt.Rows.Count > 0)
                {
                    txtItemPrice.Text = dt.Rows[0]["ItemPrice"].ToString();
                }
                else
                {
                    txtItemPrice.Text = "";
                }
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
                if (txtItemPrice.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Select Guest Name')", true);
                }
                else if (txtRoomNo.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Select Item Name')", true);
                }
                else if (btnSave.Text == "Save")
                {
                    con.Open();
                    SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);

                    string qry = "";
                    qry = "select  MAX(ServiceID) as ServiceID  from SPCN_Service_Desk_Master ";
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(qry, con);
                    cmd.Transaction = trans;
                    cmd.Clone();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        objML_Visitors.ID = dr["ServiceID"].ToString();
                    }
                    if (clsCommon.myLen(objML_Visitors.ID) <= 0)
                    {
                        objML_Visitors.ID = "SERV0000001";
                        lblID.Text = objML_Visitors.ID;
                    }
                    else
                    {
                        objML_Visitors.ID = clsCommon.incval(objML_Visitors.ID);
                        lblID.Text = objML_Visitors.ID;
                    }
                    con.Close();
                    objML_Visitors.Name = ddlGuestName.SelectedValue != "" ? ddlGuestName.SelectedValue : null;
                    objML_Visitors.RoomNo = txtRoomNo.Text != "" ? txtRoomNo.Text : null;
                    objML_Visitors.ItemName = ddlItemList.SelectedValue != "" ? ddlItemList.SelectedValue : null;
                    objML_Visitors.ItemType = ddlItemType.SelectedItem.Text != "" ? ddlItemType.SelectedItem.Text : null;
                    objML_Visitors.RoomPrice = txtItemPrice.Text != "" ? txtItemPrice.Text : null;
                    objML_Visitors.CreatedBy = Session["UserName"].ToString();
                    objML_Visitors.ModifyBy = Session["UserName"].ToString();
                    int x = objBL_Visitors.BL_InsUpdServiceDesk(objML_Visitors);
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
            txtItemPrice.Text = ""; txtRoomNo.Text = "";
            ddlGuestName.SelectedIndex = 0;
            ddlItemList.SelectedIndex = 0;
            ddlItemType.SelectedIndex = 0;
        }
    }
}