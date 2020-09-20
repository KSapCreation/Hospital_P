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
    public partial class Departure : System.Web.UI.Page
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
                BindDepartureVisitorList();
            }
        }
        private void BindDepartureVisitorList()
        {
            DataTable dt = new DataTable();
            dt = objBL_Visitors.BL_Bind_Departure_List(objML_Visitors);
            if (dt.Rows.Count > 0)
            {
                GrdDepartureList.DataSource = dt;
                GrdDepartureList.DataBind();          
            }
        }
    }
}