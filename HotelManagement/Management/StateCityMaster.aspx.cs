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
using common;
using hotelManagement.Mangement.layers.DataLayers;

namespace HotelManagement.Management
{
    public partial class StateCityMaster : System.Web.UI.Page
    {
        BL_Masters objBL_Masters = new BL_Masters();
        ML_Masters objML_Masters = new ML_Masters();
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindStateMaster();
            }
        }
        private void BindStateMaster()
        {
            DataTable dt = new DataTable();
            objML_Masters.ProjectName = "Hotel";
            dt = objBL_Masters.BL_BindStateMaster(objML_Masters);
            if (dt.Rows.Count > 0)
            {
                ddlState.DataSource = dt;
                ddlState.DataValueField = "State_Code";
                ddlState.DataTextField = "State_Name";
                ddlState.DataBind();
                ddlState.Items.Insert(0, "Select");
            }
        }
        protected void SaveState(object sender, EventArgs e)
        {
            try
            {
                objML_Masters.ID = txtStateCode.Text != "" ? txtStateCode.Text : null;
                objML_Masters.StateName = txtState.Text != "" ? txtState.Text : null;
                objML_Masters.ProjectName = "Hotel";
                objML_Masters.CreatedBy = Session["UserName"].ToString();
                objML_Masters.ModifyBy = Session["UserName"].ToString();
                int x = objBL_Masters.BL_SaveStateMaster(objML_Masters);
                if (x == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Saved !')", true);
                    StateClear(sender, e);
                }
                
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
        protected void StateClear(object sender, EventArgs e)
        {
            txtStateCode.Text = "";
            txtState.Text = "";
        }
        protected void SaveCity(object sender, EventArgs e)
        {
            try
            {
                if (ddlState.SelectedValue == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Select State')", true);
                }
                else
                {
                    con.Open();
                    SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);

                    string qry = "";
                    qry = "select  MAX(City_Code) as City_Code  from SPCN_City_Master ";
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(qry, con);
                    cmd.Transaction = trans;
                    cmd.Clone();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        objML_Masters.ID = dr["City_Code"].ToString();
                    }
                    if (clsCommon.myLen(objML_Masters.ID) <= 0)
                    {
                        objML_Masters.ID = "City0000001";
                    }
                    else
                    {
                        objML_Masters.ID = clsCommon.incval(objML_Masters.ID);
                    }
                    con.Close();
                    objML_Masters.StateName = ddlState.SelectedValue != "" ? ddlState.SelectedValue : null;
                    objML_Masters.CityName = txtCity.Text != "" ? txtCity.Text : null;
                    objML_Masters.CreatedBy = Session["UserName"].ToString();
                    objML_Masters.ModifyBy = Session["UserName"].ToString();
                    int x = objBL_Masters.BL_SaveCityMaster(objML_Masters);
                    if (x == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Saved !')", true);
                        CityClear(sender, e);
                        BindStateMaster();
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
        protected void CityClear(object sender, EventArgs e)
        {
            txtCity.Text = "";
            ddlState.SelectedIndex = 0;
        }
    }
}