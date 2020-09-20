using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospital_P.H.layers.ModelLayers;
using Hospital_P.H.layers.BusinessLayers;
using System.Data;
using System.Data.SqlClient;
using common;
using Hospital_P.H.layers.DataLayers;
using System.Configuration;

namespace Hospital_P.H.M
{
    public partial class BedSystem : System.Web.UI.Page
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
                BindWardDetail();
                BindBedMaster();
            }
        }
        protected void BindWardDetail()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objBL_CommonSeervice.BL_BindWardMaster(objML_CommonService);
                if (dt.Rows.Count > 0)
                {
                    ddlWard.DataSource = dt;
                    ddlWard.DataValueField = "WardID";
                    ddlWard.DataTextField = "WardName";
                    ddlWard.DataBind();
                    ddlWard.Items.Insert(0, "Select");

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('No Records Found');", true);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('System Problem');", true);
            }
        }
        protected void btnSaved(object sender, EventArgs e)
        {
            try
            {
                if (ddlWard.SelectedItem.Text == "Select")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Select Ward First')", true);
                }
                else if (txtBed.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Fill Bed Name')", true);
                }
                else if (btnSave.Text == "Save")
                {
                    con.Open();
                    SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);

                    string qry = "";
                    qry = "select  MAX(BedID) as BedID  from SPCN_Bed_Master ";
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(qry, con);
                    cmd.Transaction = trans;
                    cmd.Clone();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        objML_CommonService.ID = dr["BedID"].ToString();
                    }
                    if (clsCommon.myLen(objML_CommonService.ID) <= 0)
                    {
                        objML_CommonService.ID = "BED000000001";
                    }
                    else
                    {
                        objML_CommonService.ID = clsCommon.incval(objML_CommonService.ID);
                    }
                    con.Close();
                    objML_CommonService.WardName = ddlWard.SelectedItem.Value != "" ? ddlWard.SelectedItem.Value : null;
                    objML_CommonService.BedName = txtBed.Text != "" ? txtBed.Text : null;
                    objML_CommonService.No_Of_Bed = txtNo_of_Bed.Text != "" ? txtNo_of_Bed.Text : null;
                    objML_CommonService.CraetedBy = Session["UserName"].ToString();
                    objML_CommonService.ModifyBy = Session["UserName"].ToString();
                    int x = objBL_CommonSeervice.BL_InsUpdBedDetail(objML_CommonService);
                    if (x == 1)
                    {
                        txtBedID.Text = objML_CommonService.ID;
                        BindBedMaster();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Saved')", true);
                    }
                }
                else
                {
                    objML_CommonService.ID = txtBedID.Text != "" ? txtBedID.Text : null;
                    objML_CommonService.WardName = ddlWard.SelectedItem.Value != "" ? ddlWard.SelectedItem.Value : null;
                    objML_CommonService.BedName = txtBed.Text != "" ? txtBed.Text : null;
                    objML_CommonService.No_Of_Bed = txtNo_of_Bed.Text != "" ? txtNo_of_Bed.Text : null;
                    objML_CommonService.ModifyBy = Session["UserName"].ToString();
                    objML_CommonService.ModifyBy = Session["UserName"].ToString();
                    int x = objBL_CommonSeervice.BL_InsUpdBedDetail(objML_CommonService);
                    if (x == 1)
                    {
                        txtBedID.Text = objML_CommonService.ID;
                        BindBedMaster();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Saved')", true);
                    }
                }
                
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
        protected void Cleared(object sender, EventArgs e)
        {
            txtNo_of_Bed.Text = ""; txtBed.Text = ""; ddlWard.SelectedIndex = 0; txtBedID.Text = ""; btnSave.Text = "Save"; txtSerach.Text = "";
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
                    com.CommandText = "select BedID from SPCN_Bed_MASTER where " + "BedID like '%' + @Search + '%'";

                    com.Parameters.AddWithValue("@Search", prefixText);
                    com.Connection = con;
                    con.Open();
                    List<string> countryNames = new List<string>();
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            countryNames.Add(sdr["BedID"].ToString());
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
                dt = objBL_CommonSeervice.BL_SelectBedMaster(objML_CommonService);
                if (dt.Rows.Count > 0)
                {
                    txtBed.Text = dt.Rows[0]["BedName"].ToString();
                    txtBedID.Text = dt.Rows[0]["BedID"].ToString();
                    txtNo_of_Bed.Text = dt.Rows[0]["No_Of_Bed"].ToString();
                    ddlWard.SelectedValue = dt.Rows[0]["WardID"].ToString();
                    btnSave.Text = "Update";
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
        private void BindBedMaster()
        {
            DataTable dt = new DataTable();
            dt = objBL_CommonSeervice.BL_BindBedMaster(objML_CommonService);
            if (dt.Rows.Count > 0)
            {
                GrdBedMaster.DataSource = dt;
                GrdBedMaster.DataBind();
            }
        }
        protected void GrdBedMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdBedMaster.PageIndex = e.NewPageIndex;
            BindBedMaster();
        }
    }
}