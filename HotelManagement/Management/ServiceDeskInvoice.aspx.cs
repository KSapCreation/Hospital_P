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
using System.Drawing.Printing;
using System.IO;
using System.Text;

namespace HotelManagement.Management
{
    public partial class ServiceDeskInvoice : System.Web.UI.Page
    {
        ML_InvoiceDetail objML_InvoiceDetail = new ML_InvoiceDetail();
        BL_InvoiceDetail objBL_InvoiceDetail = new BL_InvoiceDetail();
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindVisitorList();
            }
        }
        private void BindVisitorList()
        {
            
            DataTable dt = new DataTable();
            dt = objBL_InvoiceDetail.BL_BindVisitorList(objML_InvoiceDetail);
            if (dt.Rows.Count > 0)
            {
                ddlGuestName.DataSource = dt;
                ddlGuestName.DataValueField = "VisitorID";
                ddlGuestName.DataTextField = "GuestName";
                ddlGuestName.DataBind();
                ddlGuestName.Items.Insert(0, "Choose a Guest Name...");
            }
        }
        protected void Serach(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);
                DataTable dt = new DataTable();
                string qry = "";
                string GuestName = "";
                if (ddlGuestName.SelectedValue == "Choose a Guest Name...")
                {
                    GuestName = "";
                }
                else
                {
                    GuestName = ddlGuestName.SelectedValue;
                }
                qry = " select ROW_NUMBER() OVER(ORDER BY SPCN_Service_Desk_Master.ServiceID ASC) AS RowNo,SPCN_Service_Desk_Master.*,spcn_check_in.GuestName,SPCN_Hotel_Item_Master.ItemName from SPCN_Service_Desk_Master left join spcn_check_in on spcn_check_in.VisitorID=SPCN_Service_Desk_Master.GuestName inner join SPCN_Hotel_Item_Master on SPCN_Hotel_Item_Master.ItemID=SPCN_Service_Desk_Master.ItemID where 2=2 and (SPCN_Service_Desk_Master.GuestName='" + ddlGuestName.SelectedValue + "'  or isnull('" + GuestName + "','')='') and (SPCN_Service_Desk_Master.ModifyDate>=convert(datetime,'" + txtfromdate.Text + "',103)) and (SPCN_Service_Desk_Master.ModifyDate>=convert(datetime,'" + txtfromdate.Text + "',103)) ";
                SqlCommand cmd = new SqlCommand();
                dt = clsDBFuncationality.GetDataTable(qry);
                //cmd = new SqlCommand(qry, con);
                //cmd.Transaction = trans;
                //cmd.Clone();
                //SqlDataReader dr = cmd.ExecuteReader();
                                
                //while (dr.Read())
                //{
                //    dt.Load(dr);
                //}
          
                if (dt.Rows.Count > 0)
                {
                    GrdServiceDesk.DataSource = dt;
                    GrdServiceDesk.DataBind();
                    lblMsg.Text = "";
                }
                else
                {
                    lblMsg.Text = "No Records Found";
                    GrdServiceDesk.DataSource = "";
                    GrdServiceDesk.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
        protected void Reset(object sender, EventArgs e)
        {
            txtfromdate.Text = "";
            txttodate.Text =     "";
        }
        protected void PrintCurrentPage(object sender, EventArgs e)
        {

            GrdServiceDesk.PagerSettings.Visible = false;

            GrdServiceDesk.DataBind();

            StringWriter sw = new StringWriter();

            HtmlTextWriter hw = new HtmlTextWriter(sw);

//            GrdServiceDesk.RenderControl(hw);

            string gridHTML = sw.ToString().Replace("\"", "'")

                .Replace(System.Environment.NewLine, "");

            StringBuilder sb = new StringBuilder();

            sb.Append("<script type = 'text/javascript'>");

            sb.Append("window.onload = new function(){");

            sb.Append("var printWin = window.open('', '', 'left=0");

            sb.Append(",top=0,width=1000,height=600,status=0');");

            sb.Append("printWin.document.write(\"");

            sb.Append(gridHTML);

            sb.Append("\");");

            sb.Append("printWin.document.close();");

            sb.Append("printWin.focus();");

            sb.Append("printWin.print();");

            sb.Append("printWin.close();};");

            sb.Append("</script>");

            ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());

            GrdServiceDesk.PagerSettings.Visible = true;

            GrdServiceDesk.DataBind();

        }
        protected void PrintAllPages(object sender, EventArgs e)
        {

            GrdServiceDesk.AllowPaging = false;

            GrdServiceDesk.DataBind();

            StringWriter sw = new StringWriter();

            HtmlTextWriter hw = new HtmlTextWriter(sw);

            GrdServiceDesk.RenderControl(hw);

            string gridHTML = sw.ToString().Replace("\"", "'")

                .Replace(System.Environment.NewLine, "");

            StringBuilder sb = new StringBuilder();

            sb.Append("<script type = 'text/javascript'>");

            sb.Append("window.onload = new function(){");

            sb.Append("var printWin = window.open('', '', 'left=0");

            sb.Append(",top=0,width=1000,height=600,status=0');");

            sb.Append("printWin.document.write(\"");

            sb.Append(gridHTML);

            sb.Append("\");");

            sb.Append("printWin.document.close();");

            sb.Append("printWin.focus();");

            sb.Append("printWin.print();");

            sb.Append("printWin.close();};");

            sb.Append("</script>");

            ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());

            GrdServiceDesk.AllowPaging = true;

            GrdServiceDesk.DataBind();

        }
    }
}