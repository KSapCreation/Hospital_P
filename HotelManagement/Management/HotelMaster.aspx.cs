using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HotelManagement.Management.Layers.Businesslayer;
using HotelManagement.Management.Layers.ModelLayer;
using System.Data.SqlClient;
using hotelManagement.Mangement.layers.DataLayers;
using common;
using System.Data;

namespace HotelManagement.Management
{
    public partial class HotelMaster : System.Web.UI.Page
    {
        BL_Masters objBL_Masters = new BL_Masters();
        ML_Masters objML_Masters = new ML_Masters();
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (!IsPostBack)
            {
                BindState();
                BindHotelDetail();
            }
        }
        protected void BindState()
        {
            DataTable dt = new DataTable();
            objML_Masters.ID = "Hotel";
            dt = objBL_Masters.BL_BindStateList(objML_Masters);
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
            objML_Masters.ID = ddlState.SelectedValue != "" ? ddlState.SelectedValue : null;
            dt = objBL_Masters.BL_BindCityList(objML_Masters);
            if (dt.Rows.Count > 0)
            {
                ddlcity.DataSource = dt;
                ddlcity.DataValueField = "City_Code";
                ddlcity.DataTextField = "City_Name";
                ddlcity.DataBind();
                ddlcity.Items.Insert(0, "Select");
            }
        }
        private void BindHotelDetail()
        {
            DataTable dt = new DataTable();
            dt = objBL_Masters.BL_BindHotelMaster(objML_Masters);
            if (dt.Rows.Count > 0)
            {
                GrdHotelList.DataSource = dt;
                GrdHotelList.DataBind();
            }
        }
        protected void Reset(object sender, EventArgs e)
        {
            txtAddress.Text = "";
            txtEmailID.Text = "";
            txtGSTIN.Text = "";
            txtHotelCreatedDate.Text = "";
            txtHotelName.Text = "";
            txtMobile.Text = "";
            txtPanNo.Text = "";
            txtPhone1.Text = "";
            txtPhone2.Text = "";
            txtTanNo.Text = "";
            txtWebSite.Text = "";
            txtZip.Text = "";
            ddlcity.SelectedIndex = 0;
            ddlCountry.SelectedIndex = 0;
            ddlState.SelectedIndex = 0;
            btnSave.Text = "Save";
        }
        protected void Save(object sender, EventArgs e)
        {
            try
            {
                if (txtHotelName.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Hotel Name')", true);
                }
                else if (txtEmailID.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Email ID')", true);
                }
                else if (txtGSTIN.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill GSTIN No')", true);
                }
                else
                {
                    con.Open();
                    SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);

                    string qry = "";
                    qry = "select  MAX(HOTELID) as HOTELID  from SPCN_HOTEL_MASTER ";
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(qry, con);
                    cmd.Transaction = trans;
                    cmd.Clone();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        objML_Masters.ID = dr["HOTELID"].ToString();
                    }
                    if (clsCommon.myLen(objML_Masters.ID) <= 0)
                    {
                        objML_Masters.ID = "HOTEL0000001";                        
                    }
                    else
                    {
                        objML_Masters.ID = clsCommon.incval(objML_Masters.ID);                        
                    }
                    con.Close();
                    objML_Masters.Name = txtHotelName.Text != "" ? txtHotelName.Text : null;
                    objML_Masters.PublishDate = txtHotelCreatedDate.Text != "" ? txtHotelCreatedDate.Text : null;
                    objML_Masters.Address = txtAddress.Text != "" ? txtAddress.Text : null;
                    objML_Masters.State = ddlState.SelectedValue != "" ? ddlState.SelectedValue : null;
                    objML_Masters.City = ddlcity.SelectedValue != "" ? ddlcity.SelectedValue : null;
                    objML_Masters.Country = ddlCountry.SelectedValue != "" ? ddlCountry.SelectedValue : null;
                    objML_Masters.ZipCode = txtZip.Text != "" ? txtZip.Text : null;
                    objML_Masters.Website = txtWebSite.Text != "" ? txtWebSite.Text : null;
                    objML_Masters.EmailID = txtEmailID.Text != "" ? txtEmailID.Text : null;
                    objML_Masters.Phone1 = txtPhone1.Text != "" ? txtPhone1.Text : null;
                    objML_Masters.Phone2 = txtPhone2.Text != "" ? txtPhone2.Text : null;
                    objML_Masters.MobileNo = txtMobile.Text != "" ? txtMobile.Text : null;
                    objML_Masters.PanNo = txtPanNo.Text != "" ? txtPanNo.Text : null;
                    objML_Masters.TanNo = txtTanNo.Text != "" ? txtTanNo.Text : null;
                    objML_Masters.GSTIN = txtGSTIN.Text != "" ? txtGSTIN.Text : null;
                    objML_Masters.CreatedBy = Session["UserName"].ToString();
                    objML_Masters.ModifyBy = Session["UserName"].ToString();
                    int x = objBL_Masters.BL_SaveHotelMaster(objML_Masters);
                    if (x == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Saved !')", true);
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