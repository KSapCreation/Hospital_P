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

namespace HotelManagement.Management
{
    public partial class ItemMaster : System.Web.UI.Page
    {
        ML_RoomMaster objML_ItemMaster = new ML_RoomMaster();
        BL_RoomMaster objBL_ItemMaster = new BL_RoomMaster();
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (!IsPostBack)
            {
                BindHotelItem();
            }
        }
        protected void Save(object sender, EventArgs e)
        {
            try
            {
                if (btnSave.Text == "Save")
                {
                    if (txtItemName.Text == null)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Item Name')", true);
                    }
                    else if (txtItemPrice.Text == null)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Item Price')", true);
                    }
                    else
                    {
                        con.Open();
                        SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);

                        string qry = "";
                        qry = "select  MAX(ItemID) as ItemID  from SPCN_Hotel_Item_Master ";
                        SqlCommand cmd = new SqlCommand();
                        cmd = new SqlCommand(qry, con);
                        cmd.Transaction = trans;
                        cmd.Clone();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            objML_ItemMaster.ID = dr["ItemID"].ToString();
                        }
                        if (clsCommon.myLen(objML_ItemMaster.ID) <= 0)
                        {
                            objML_ItemMaster.ID = "ITEM0000001";
                            lblID.Text = objML_ItemMaster.ID;
                        }
                        else
                        {
                            objML_ItemMaster.ID = clsCommon.incval(objML_ItemMaster.ID);
                        }
                        con.Close();
                    }
                }
                else 
                {
                    objML_ItemMaster.ID = lblID.Text != "" ? lblID.Text : null;
                }
                objML_ItemMaster.Name = txtItemName.Text != "" ? txtItemName.Text : null;
                objML_ItemMaster.Description = txtDesc.Text != "" ? txtDesc.Text : null;
                objML_ItemMaster.Price = txtItemPrice.Text != "" ? txtItemPrice.Text : null;
                if (chkActive.Checked == true)
                {
                    objML_ItemMaster.Is_Active = 1;
                }
                else
                {
                    objML_ItemMaster.Is_Active = 0;
                }
                objML_ItemMaster.CreatedBy = Session["Username"].ToString();
                objML_ItemMaster.ModifyBy = Session["Username"].ToString();
                objML_ItemMaster.HalfPrice = txtHalfPrice.Text != "" ? txtHalfPrice.Text : null;
                int x = objBL_ItemMaster.BL_SaveHotelItemMaster(objML_ItemMaster);
                if (x == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Saved !')", true);
                    Reset(sender, e);
                    BindHotelItem();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
        private void BindHotelItem()
        {
            DataTable dt = new DataTable();
            dt = objBL_ItemMaster.BL_BindHotelItemList(objML_ItemMaster);
            if (dt.Rows.Count > 0)
            {
                GrdItemList.DataSource = dt;
                GrdItemList.DataBind();
            }
        }
        protected void GrdRoomList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdItemList.PageIndex = e.NewPageIndex;
            BindHotelItem();
        }
        protected void Delete(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            {
                Label lblID = (Label)gvr.FindControl("lblProgramsID");
                DataTable dt = new DataTable();
                objML_ItemMaster.ID = lblID.Text != "" ? lblID.Text : null;
                int x = objBL_ItemMaster.BL_DeleteHotelItemMaster(objML_ItemMaster);
                if (x == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Delete')", true);
                    BindHotelItem();
                }
            }
        }
        protected void Update(object sender, EventArgs e)
        {
            try
            {           
                GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
                {
                    Label lblProgramsID = (Label)gvr.FindControl("lblProgramsID");
                    DataTable dt = new DataTable();
                    objML_ItemMaster.ID = lblProgramsID.Text != "" ? lblProgramsID.Text : null;
                    dt = objBL_ItemMaster.BL_SelectHotelItemMaster(objML_ItemMaster);
                    if (dt.Rows.Count > 0)
                    {
                        txtItemName.Text = dt.Rows[0]["ItemName"].ToString();
                        txtItemPrice.Text = dt.Rows[0]["ItemPrice"].ToString();
                        txtDesc.Text = dt.Rows[0]["Description"].ToString();
                        lblID.Text = dt.Rows[0]["ItemID"].ToString();
                        chkActive.Checked = Convert.ToBoolean(dt.Rows[0]["Is_Active"]);
                        txtHalfPrice.Text = dt.Rows[0]["HalfPrice"].ToString();
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
            txtHalfPrice.Text = "";
            txtDesc.Text = "";
            txtItemName.Text = "";
            txtItemPrice.Text = "";
            btnSave.Text = "Save";
            chkActive.Checked = false;
        }
    }
}