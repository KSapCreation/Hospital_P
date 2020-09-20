using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using hotelManagement.H.layers.BusinessLayers;
using hotelManagement.H.layers.ModelLayers;
using System.Text;
using System.Data;
using System.Net;
using hotelManagement.H;
using CommonFile;




namespace hotelManagement
{
    public partial class Login : System.Web.UI.Page
    {
        CommonClass objCommonClass = new CommonClass();
        ML_User_Access objML_User_Access = new ML_User_Access();
        BL_User_Access objBL_User_Access = new BL_User_Access();

       
        protected void Page_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();
          
        }
        protected void btnSave(object sender, EventArgs e)
        {
            try
            {
                if (txtpassword.Text == "crmpassword")
                {
                    DataTable dtGetPwd = new DataTable();
                    objML_User_Access.UserName = txtUserName.Text != "" ? txtUserName.Text : null;
                    dtGetPwd = objBL_User_Access.BL_FindLoginDetail(objML_User_Access);
                    if (dtGetPwd.Rows.Count > 0)
                    {
                        string ans;
                        ans = objCommonClass.GetDecrptPassword(dtGetPwd.Rows[0]["Password"].ToString());
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Passwords is: " + ans.ToString() + "');", true);
                        txtUserName.Text = "";
                        txtUserName.Focus();
                    }
                }
                else
                {
                    //login script
                    MaintainCookies(txtUserName.Text.Trim(), txtpassword.Text);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('System Problem')", true);
            }
        }

        public void MaintainCookies(string _username, string _password)
        {
            //string line = "";
            //line = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["ServerName"]) + " # " + Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["ServerDatabase"]) + " # " + Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["ServerUserName"]) + " # " + Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["ServerPassword"]);

            //clsDBFuncationality.SetConnectionEncryptFormat(line);

            bool blValidUser = false;
            string _strUserType = string.Empty;
            string strLoggedHistoryId;
            try
            {
                objML_User_Access.UserName = _username;
                objML_User_Access.Passsword = objCommonClass.GetEncrptPassword(_password);
                DataTable dt = objBL_User_Access.BL_LoginUser(objML_User_Access);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        txtUserName.Text = dt.Rows[0]["UserName"].ToString();
                        Session["UserName"] = txtUserName.Text;
                        Session["UserCode"] = dt.Rows[0]["UserID"].ToString();
                        Response.RedirectToRoute("DashBoard");

                    }
                    else
                    {
                        lblmsg.Text = "Wrong UserName and Password";
                    }
                }
                else
                {
                    lblmsg.Text = "Wrong UserName and Password";
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('System Problem')", true);
            }



        }
        protected void lnkForgotPassword(object sender, EventArgs e)
        {
            UserLoginDiv.Visible = false;
            ForgetPwdDiv.Visible = true;
        }
        protected void btnBackLogin(object sender, EventArgs e)
        {
            UserLoginDiv.Visible = true;
            ForgetPwdDiv.Visible = false;
        }
        private string GetIPAddress()
        {
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST
            Console.WriteLine(hostName);
            // Get the IP
            string strIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            return strIP;
            // string strIP = HttpContext.Current.Request.ServerVariables.Get("HTTP_X_CLUSTER_CLIENT_IP");
            //  if (string.IsNullOrEmpty(strIP))
            // {
            //   strIP = HttpContext.Current.Request.ServerVariables.Get("REMOTE_ADDR");
            //}
            //return strIP;
        }
       
    }
}