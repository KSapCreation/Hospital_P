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
    public partial class RoomMaster : System.Web.UI.Page
    {
        ML_RoomMaster objML_RoomMaster = new ML_RoomMaster();
        BL_RoomMaster objBL_RoomMaster = new BL_RoomMaster();
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (!IsPostBack)
            {
                BindRoomList();
                BindtaxGroup();
            }
         
        }
        private void BindtaxGroup()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objBL_RoomMaster.BL_BindTaxGroup(objML_RoomMaster);
                if (dt.Rows.Count > 0)
                {
                    ddlTaxGroup.DataSource = dt;
                    ddlTaxGroup.DataTextField = "TaxgroupName";
                    ddlTaxGroup.DataValueField = "taxgroupid";
                    ddlTaxGroup.DataBind();
                    ddlTaxGroup.Items.Insert(0, "Choose a Tax Group...");
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
        protected void Save(object sender, EventArgs e)
        {
            try
            {
                if (txtRoomName.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Room Name')", true);
                }
                else if (txtRoomPrice.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Room Price')", true);
                }
                else if (txtRoomNo.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Room No')", true);
                }
                else if (ddlTaxGroup.SelectedValue == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Select Tax Group')", true);
                }
                else if (btnSave.Text == "Save")
                {
                    con.Open();
                    SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);

                    string qry = "";
                    qry = "select  MAX(RoomID) as RoomID  from SPCN_Room_Master ";
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(qry, con);
                    cmd.Transaction = trans;
                    cmd.Clone();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        objML_RoomMaster.ID = dr["RoomID"].ToString();
                    }
                    if (clsCommon.myLen(objML_RoomMaster.ID) <= 0)
                    {
                        objML_RoomMaster.ID = "ROOM0000001";
                        lblID.Text = objML_RoomMaster.ID;
                    }
                    else
                    {
                        objML_RoomMaster.ID = clsCommon.incval(objML_RoomMaster.ID);
                        lblID.Text = objML_RoomMaster.ID;
                    }
                    con.Close();
                }
                else
                {
                    objML_RoomMaster.ID = lblID.Text;
                    int z = objBL_RoomMaster.BL_DeleteRoomMasterDetail(objML_RoomMaster);
                }
                
                objML_RoomMaster.RoomName = txtRoomName.Text != "" ? txtRoomName.Text : null;
                objML_RoomMaster.TaxGroup = ddlTaxGroup.SelectedValue != "" ? ddlTaxGroup.SelectedValue : null;
                objML_RoomMaster.RoomPrice = txtRoomPrice.Text != "" ? txtRoomPrice.Text : null;
                if (chkActive.Checked == true)
                {
                    objML_RoomMaster.Is_Active = 1;
                }
                else
                {
                    objML_RoomMaster.Is_Active = 0;
                }

                objML_RoomMaster.CreatedBy = Session["Username"].ToString();
                objML_RoomMaster.ModifyBy = Session["Username"].ToString();
                int x = objBL_RoomMaster.BL_SaveRoomMaster(objML_RoomMaster);
                if (x == 1)
                {
                    //Detail Part
                    string[] parts = txtRoomNo.Text.Split(',');
                    foreach (string s in parts)
                    {
                        objML_RoomMaster.RoomNo = s;
                        objML_RoomMaster.ID = lblID.Text;                        
                        int Detail = objBL_RoomMaster.BL_SaveRoomMasterDetail(objML_RoomMaster);
                        if (Detail == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Saved !')", true);
                            Clear(sender, e);
                        }
                    }
                   
                  
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
        protected void Clear(object sender, EventArgs e)
        {
            txtRoomName.Text = "";
            txtRoomNo.Text = "";
            txtRoomPrice.Text = "";
            chkActive.Checked = false;
            btnSave.Text = "Save";
            ddlTaxGroup.SelectedIndex = 0;
        }

        private void BindRoomList()
        {
            DataTable dt = new DataTable();
            dt = objBL_RoomMaster.BL_BindRoomList(objML_RoomMaster);
            if (dt.Rows.Count > 0)
            {
                GrdRoomList.DataSource = dt;
                GrdRoomList.DataBind();
            }
        }
        protected void GrdRoomList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdRoomList.PageIndex = e.NewPageIndex;
            BindRoomList();
        }
        protected void Delete(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            {
                Label lblID = (Label)gvr.FindControl("lblProgramsID");
                DataTable dt = new DataTable();
                objML_RoomMaster.ID = lblID.Text != "" ? lblID.Text : null;
                int x = objBL_RoomMaster.BL_DeleteRoomMaster(objML_RoomMaster);
                if (x == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Delete')", true);
                    BindRoomList();
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
                    objML_RoomMaster.ID = lblProgramsID.Text != "" ? lblProgramsID.Text : null;
                    dt = objBL_RoomMaster.BL_SelectRoomMaster(objML_RoomMaster);
                    if (dt.Rows.Count > 0)
                    {
                        txtRoomName.Text = dt.Rows[0]["RoomName"].ToString();
                        txtRoomPrice.Text = dt.Rows[0]["RoomPrice"].ToString();
                        lblID.Text = dt.Rows[0]["RoomID"].ToString();
                        chkActive.Checked = Convert.ToBoolean(dt.Rows[0]["Is_Active"]);
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (i != 0)
                            {
                                RoomNo += ",";
                            }
                            RoomNo += dr["RoomNo"].ToString();
                            i = i + 1;
                        }
                        
                        txtRoomNo.Text = RoomNo;                        
                        btnSave.Text = "Update";
                    }
                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
    }
}