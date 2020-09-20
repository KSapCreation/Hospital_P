using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    public partial class ReservationList : System.Web.UI.Page
    {
        BL_Visitors objBL_Visitors = new BL_Visitors();
        ML_Visitors objML_Visitors = new ML_Visitors();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
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
            dt = objBL_Visitors.BL_Bind_Check_In_List(objML_Visitors);
            if (dt.Rows.Count > 0)
            {
                GrdReservationList.DataSource = dt;
                GrdReservationList.DataBind();

                foreach (GridViewRow row in GrdReservationList.Rows)
                {
                    Label lblStatus = (Label)row.FindControl("lblStatus");
                    if (lblStatus.Text == "Leave")
                    {
                        lblStatus.Style.Add("background-color", "#2fa20a");
                        lblStatus.Style.Add("color", "#ffffff");
                        lblStatus.Style.Add("border-radius", "4px");
                    }
                    else
                    {
                        lblStatus.Style.Add("background-color", "#cc103b"); 
                        lblStatus.Style.Add("color", "#ffffff");
                        lblStatus.Style.Add("border-radius", "4px");
                    }
                }
            }
        }
        
    }
}