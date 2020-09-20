using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HotelManagement.Management.Layers.Businesslayer;
using HotelManagement.Management.Layers.ModelLayer;
using System.Data.SqlClient;
using hotelManagement.Mangement.layers.DataLayers;
using common;
using System.Drawing;

namespace HotelManagement.Management
{
    public partial class Dashboard : System.Web.UI.Page
    {
        ML_RoomMaster objML_RoomMaster = new ML_RoomMaster();
        BL_RoomMaster objBL_RoomMaster = new BL_RoomMaster();
        ML_Visitors objML_Visitor = new ML_Visitors();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (!IsPostBack)
            {
                BindRoomList(sender ,e);
                //BindGuestList();
            }
        }
        private void BindRoomList(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();            
            dt = objBL_RoomMaster.BL_BindRoomDashboard(objML_RoomMaster);
            if (dt.Rows.Count > 0)
            {
                dlRoomStatus.DataSource = dt;
                dlRoomStatus.DataBind();
            }
        }
        private void BindGuestList()
        {
            DataTable dt = new DataTable();
            dt = objBL_RoomMaster.BL_BindGuestListDashboard(objML_RoomMaster);
            if (dt.Rows.Count > 0)
            {
                //dlGuestList.DataSource = dt;
                //dlGuestList.DataBind();
            }
        }
        protected void dlBooking_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView dataRowView = e.Item.DataItem as DataRowView;
                string roomNo = dataRowView["RoomNo"].ToString();                        
                {
                    string CheckIn_Room = dataRowView["Check_In_Room_No"].ToString();  
                    string bookingStatus = (e.Item.FindControl("lblRoomNo") as Label).Text;
                    if (bookingStatus.ToUpper().Trim() == CheckIn_Room.ToUpper().Trim())
                    {
                        (e.Item.FindControl("lblRoomNo") as Label).Style.Add("background-color", "#ff1625bd");                        
                    }
                    else
                    {
                        (e.Item.FindControl("lblRoomNo") as Label).Style.Add("background-color", "#00800087");                        
                    }
                }
            
            }
        }
        protected void ViewVisitorDetail(object sender, EventArgs e)
        {
            try
            {

                DataListItem gvr = (DataListItem)(((Control)sender).NamingContainer);
                {
                    Label lblProgramsID = (Label)gvr.FindControl("lblRoomNo");
                    Label lblVisitorID = (Label)gvr.FindControl("lblVisitorID");
                    DataTable dt = new DataTable();
                    objML_Visitor.RoomNo = lblProgramsID.Text != "" ? lblProgramsID.Text : null;
                    objML_Visitor.VisitorID = lblVisitorID.Text != "" ? lblVisitorID.Text : null;
                    dt = objBL_RoomMaster.BL_EditRoomVisitorDetail(objML_Visitor);
                    if (dt.Rows.Count > 0)
                    {     
                        // id fetch for this code
                        //Response.RedirectToRoutePermanent("Visitors", new { id = lblVisitorID.Text });
                        // end
                        Session["VisitorID"] = lblVisitorID.Text;
                        Response.RedirectToRoute("Visitors", new { id = lblVisitorID.Text });
                        
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