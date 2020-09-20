using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospital_P.H.layers.BusinessLayers;
using Hospital_P.H.layers.ModelLayers;
using System.Text;
using System.Data;
using System.Net;
using Hospital_P.H;
using System.Data.SqlClient;
using Hospital_P.H.layers.DataLayers;
using common;
using System.Configuration;

namespace Hospital_P.H
{
    public partial class UnitMaster : System.Web.UI.Page
    {
        BL_Pharmacy objBL_Pharmacy = new BL_Pharmacy();
        ML_Pharmacy objML_Pharmacy = new ML_Pharmacy();
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                BindUnitMaster();
            }
        }
        protected void Save(object sender, EventArgs e)
        {
            try
            {
                if (txtUnitName.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Unit Code');", true);
                }
                else if (btnSave.Text == "Save")
                {
                    con.Open();
                    SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);

                    string qry = "";
                    qry = "select  MAX(UnitID) as UnitID  from SPCN_UNIT_MASTER ";
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(qry, con);
                    cmd.Transaction = trans;
                    cmd.Clone();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        objML_Pharmacy.UnitID = dr["UnitID"].ToString();
                    }
                    if (clsCommon.myLen(objML_Pharmacy.UnitID) <= 0)
                    {
                        objML_Pharmacy.UnitID = "U000000001";
                    }
                    else
                    {
                        objML_Pharmacy.UnitID = clsCommon.incval(objML_Pharmacy.UnitID);
                    }
                    con.Close();
                    objML_Pharmacy.UnitName = txtUnitName.Text != "" ? txtUnitName.Text : null;
                    objML_Pharmacy.CreatedBy = Session["UserName"].ToString();
                    objML_Pharmacy.ModifyBy = Session["UserName"].ToString();
                    objML_Pharmacy.Description = txtDesc.Text != "" ? txtDesc.Text : null;
                    int x = objBL_Pharmacy.BL_InsUpdUnitMaster(objML_Pharmacy);
                    if (x == 1)
                    {
                        BindUnitMaster();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Saved');", true);
                        txtUnitCode.Text = objML_Pharmacy.UnitID;
                    }
                }
                else if (btnSave.Text == "Update")
                {
                    objML_Pharmacy.UnitID = txtUnitCode.Text != "" ? txtUnitCode.Text : null;
                    objML_Pharmacy.UnitName = txtUnitName.Text != "" ? txtUnitName.Text : null;
                    objML_Pharmacy.CreatedBy = Session["UserName"].ToString();
                    objML_Pharmacy.ModifyBy = Session["UserName"].ToString();
                    objML_Pharmacy.Description = txtDesc.Text != "" ? txtDesc.Text : null;
                    int x = objBL_Pharmacy.BL_InsUpdUnitMaster(objML_Pharmacy);
                    if (x == 1)
                    {
                        BindUnitMaster();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Updated');", true);
                        txtUnitCode.Text = objML_Pharmacy.UnitID;
                    }
                }
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('"+ ex.Message.ToString() +"');", true);
            }
        }
        private void Reset()
        {
            txtUnitName.Text = "";
            txtUnitCode.Text = "";
            btnSave.Text = "Save";
            txtSerach.Text = "";
            txtDesc.Text = "";
        }
        protected void Cancel(object sender, EventArgs e)
        {
            Reset();
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
                    com.CommandText = "select UnitID from SPCN_UNIT_MASTER where " + "UnitName like '%' + @Search + '%'";

                    com.Parameters.AddWithValue("@Search", prefixText);
                    com.Connection = con;
                    con.Open();
                    List<string> countryNames = new List<string>();
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            countryNames.Add(sdr["UnitID"].ToString());
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
                objML_Pharmacy.ID = txtSerach.Text != "" ? txtSerach.Text : null;
                dt = objBL_Pharmacy.BL_SearchUnitMaster(objML_Pharmacy);
                if (dt.Rows.Count > 0)
                {
                    txtUnitCode.Text = dt.Rows[0]["UnitID"].ToString();
                    txtUnitName.Text = dt.Rows[0]["UnitName"].ToString();
                    btnSave.Text = "Update";
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        private void BindUnitMaster()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objBL_Pharmacy.BL_BindUnitMaster(objML_Pharmacy);
                if (dt.Rows.Count > 0)
                {
                    GrdUnitMaster.DataSource = dt;
                    GrdUnitMaster.DataBind();
                }
           }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        protected void GrdUnitMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdUnitMaster.PageIndex = e.NewPageIndex;
            BindUnitMaster();
        }
    }
}