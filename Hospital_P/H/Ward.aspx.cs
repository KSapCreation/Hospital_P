using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using hotelManagement.H.layers.ModelLayers;
using hotelManagement.H.layers.BusinessLayers;
using System.Data;
using System.Data.SqlClient;
using common;
using hotelManagement.H.layers.DataLayers;
using System.Configuration;

namespace hotelManagement.H.M
{
    public partial class Ward : System.Web.UI.Page
    {
        protected bool blAccess = true;
        BL_CommonServices objBL_CommonSeervice = new BL_CommonServices();
        ML_CommonServices objML_CommonService = new ML_CommonServices();
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                if (!IsPostBack)
                {
                    BindWardMaster();
                }
                
            }
        }
        protected void btnSaved(object sender, EventArgs e)
        {
            try
            {
                if (txtWard.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Ward Name)", true);
                }
                else if (btnSave.Text == "Save")
                {
                    con.Open();
                    SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);

                    string qry = "";
                    qry = "select  MAX(WardID) as WardID  from SPCN_Ward_Master ";
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(qry, con);
                    cmd.Transaction = trans;
                    cmd.Clone();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        objML_CommonService.ID = dr["WardID"].ToString();
                    }
                    if (clsCommon.myLen(objML_CommonService.ID) <= 0)
                    {
                        objML_CommonService.ID = "WARD000000001";
                    }
                    else
                    {
                        objML_CommonService.ID = clsCommon.incval(objML_CommonService.ID);
                    }
                    con.Close();
                    objML_CommonService.WardName = txtWard.Text != "" ? txtWard.Text : null;
                    objML_CommonService.CraetedBy = Session["UserName"].ToString();
                    objML_CommonService.ModifyBy = Session["UserName"].ToString();
                    int x = objBL_CommonSeervice.BL_InsUpdWardDetail(objML_CommonService);
                    if (x == 1)
                    {
                        txtWardID.Text = objML_CommonService.ID;
                        BindWardMaster();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Saved');", true);
                    }
                }
                else
                {
                    objML_CommonService.ID = txtWardID.Text != "" ? txtWardID.Text : null;
                    objML_CommonService.WardName = txtWard.Text != "" ? txtWard.Text : null;
                    objML_CommonService.ModifyBy = Session["UserName"].ToString();
                    objML_CommonService.ModifyBy = Session["UserName"].ToString();
                    int x = objBL_CommonSeervice.BL_InsUpdWardDetail(objML_CommonService);
                    if (x == 1)
                    {
                        txtWardID.Text = objML_CommonService.ID;
                        BindWardMaster();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Updated!);", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('"+ ex.Message.ToString() +"')", true);
            }
        }

        protected void Cleared(object sender, EventArgs e)
        {
            txtWard.Text = ""; txtWardID.Text = ""; txtSerach.Text = ""; btnSave.Text = "Save";
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetCompletionList(string prefixText, int count)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.AppSettings["Hospital"];

                using (SqlCommand com = new SqlCommand())
                {
                    com.CommandText = "select WardID from SPCN_WARD_MASTER where " + "WardID like '%' + @Search + '%'";

                    com.Parameters.AddWithValue("@Search", prefixText);
                    com.Connection = con;
                    con.Open();
                    List<string> countryNames = new List<string>();
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            countryNames.Add(sdr["WardID"].ToString());
                        }
                    }
                    con.Close();
                    return countryNames;

                }

            }
        }
        protected void Search(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                objML_CommonService.ID = txtSerach.Text != "" ? txtSerach.Text : null;
                dt = objBL_CommonSeervice.BL_SelectWardMaster(objML_CommonService);
                if (dt.Rows.Count > 0)
                {
                    txtWardID.Text = dt.Rows[0]["WardID"].ToString();
                    txtWard.Text = dt.Rows[0]["WardName"].ToString();
                   
                    btnSave.Text = "Update";
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
        private void BindWardMaster()
        {
            DataTable dt = new DataTable();
            dt = objBL_CommonSeervice.BL_BindWardMaster(objML_CommonService);
            if (dt.Rows.Count > 0)
            {
                GrdWardMaster.DataSource = dt;
                GrdWardMaster.DataBind();
            }
        }
        protected void GrdWardMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdWardMaster.PageIndex = e.NewPageIndex;
            BindWardMaster();
        }
    }
}