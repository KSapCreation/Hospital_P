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
    public partial class Department : System.Web.UI.Page
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
                BindDepartment();

            }
        }
        private void BindDepartment()
        {
            DataTable dt = new DataTable();
            dt = objBL_CommonSeervice.BL_BindDepartment(objML_CommonService);
            if (dt.Rows.Count > 0)
            {
                GrdItemList.DataSource = dt;
                GrdItemList.DataBind();
            }
        }
        protected void GrdItemList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdItemList.PageIndex = e.NewPageIndex;
            BindDepartment();
        }
        protected void btnSaved(object sender, EventArgs e)
        {
            try
            {
                if (txtDepartment.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('Enter Department')", true);
                }
                else if (btnSave.Text == "Save")
                {
                    con.Open();
                    SqlTransaction trans = con.BeginTransaction(IsolationLevel.ReadCommitted);

                    string qry = "";
                    qry = "select  MAX(DepID) as DepID  from SPCN_Department_Master ";
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand(qry, con);
                    cmd.Transaction = trans;
                    cmd.Clone();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        objML_CommonService.ID = dr["DepID"].ToString();
                    }
                    if (clsCommon.myLen(objML_CommonService.ID) <= 0)
                    {
                        objML_CommonService.ID = "Dep000000001";
                    }
                    else
                    {
                        objML_CommonService.ID = clsCommon.incval(objML_CommonService.ID);
                    }
                    con.Close();
                    objML_CommonService.Department = txtDepartment.Text != "" ? txtDepartment.Text : null;
                    objML_CommonService.CraetedBy = Session["UserName"].ToString();
                    objML_CommonService.ModifyBy = Session["UserName"].ToString();
                    int x = objBL_CommonSeervice.BL_InsUpdDepartment(objML_CommonService);
                    if (x == 1)
                    {
                        BindDepartment();
                        ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('Data Saved')", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('Already Data Saved')", true);
                    }
                }
                else
                {
                    objML_CommonService.ID = txtDepId.Text != "" ? txtDepId.Text : null;
                    objML_CommonService.Department = txtDepartment.Text != "" ? txtDepartment.Text : null;
                    objML_CommonService.CraetedBy = Session["UserName"].ToString();
                    objML_CommonService.ModifyBy = Session["UserName"].ToString();
                    int x = objBL_CommonSeervice.BL_InsUpdDepartment(objML_CommonService);
                    if (x == 1)
                    {
                        BindDepartment();
                        ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('Data Updated')", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('Already Data Saved')", true);
                    }
                }
               
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "message", "alert('" + ex.Message.ToString() + "');", true);
            }
        }

        protected void Cleared(object sender, EventArgs e)
        {
            txtDepartment.Text = "";
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
                    com.CommandText = "select DepID from SPCN_Department_master where " + "DepartmentName like '%' + @Search + '%'";

                    com.Parameters.AddWithValue("@Search", prefixText);
                    com.Connection = con;
                    con.Open();
                    List<string> countryNames = new List<string>();
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            countryNames.Add(sdr["DepID"].ToString());
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
                dt = objBL_CommonSeervice.BL_SelectDepartment(objML_CommonService);
                if (dt.Rows.Count > 0)
                {
                    txtDepartment.Text = dt.Rows[0]["DepartmentName"].ToString();
                    txtDepId.Text = dt.Rows[0]["DepID"].ToString();   
                    btnSave.Text = "Update";
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + "')", true);
            }
        }
    }
}