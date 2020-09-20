using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using hotelManagement.H.layers.BusinessLayers;
using hotelManagement.H.layers.ModelLayers;
using System.Data.SqlClient;
using System.Data;
using hotelManagement.H.layers.DataLayers;
using common;

namespace hotelManagement.H
{
    public partial class ChangePasssword : System.Web.UI.Page
    {
        BL_User_Access objBL_User_Master = new BL_User_Access();
        ML_User_Access objML_User_Master = new ML_User_Access();
        protected bool blAccess = true;
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        CommonClass objCommonClass = new CommonClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                txtUserName.Text = Session["UserName"].ToString();
            }
        }
        protected void btnSaved(object sender, EventArgs e)
        {
            try
            {
                if (btnSave.Text == "Save")
                {
                    objML_User_Master.UserName = Session["UserCode"].ToString();
                    objML_User_Master.OldPassword = objCommonClass.GetEncrptPassword(txtOldPassword.Text);
                    objML_User_Master.Passsword = objCommonClass.GetEncrptPassword(txtPwd.Text);
                    objML_User_Master.ConformPasword = objCommonClass.GetEncrptPassword(txtCPwd.Text);
                    objML_User_Master.ModifyBy = Session["UserName"].ToString();
                    int x = objBL_User_Master.BL_ChangePassword(objML_User_Master);
                    if (x == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Password Change')", true);
                    }
                }



            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + ex.Message.ToString() + " ')", true);
            }
        }
        protected void btnClear(object sender, EventArgs e)
        {
            txtCPwd.Text = "";
            txtOldPassword.Text = "";
            txtPwd.Text = "";

        }
    }
}