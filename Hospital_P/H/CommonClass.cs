using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net.Mail;
using System.Data;
using hotelManagement.H.layers.BusinessLayers;
using hotelManagement.H.layers.ModelLayers;
using System.Net;
using System.IO;

namespace hotelManagement.H
{
    public class CommonClass
    {
        #region Password Encrpt
        public string GetEncrptPassword(string password)
        {
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(encode);


        }
        public string GetDecrptPassword(string password)
        {
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(password);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            return new String(decoded_char);
        }
        public string GetEncrptProductKey(string password)
        {
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(encode);


        }
        #endregion

        #region Page Control
        public bool GetPageAccess(string strUserId, string strPage)
        {
            bool blAccess = false;
            if (HttpContext.Current.Session["UserName"] == null && HttpContext.Current.Request.Cookies["SPCN"] != null)
            {
                //SetSessionFromCookies();
                blAccess = GetScreenAccess(strPage);
            }
            else if (HttpContext.Current.Session["UserName"] == null && HttpContext.Current.Request.Cookies["SPCN"] == null)
            {
                SetSessionFromCookies();
                blAccess = GetScreenAccess(strPage);
            }
            else
            {
                blAccess = GetScreenAccess(strPage);
            }
            return blAccess;
        }

        private bool GetScreenAccess(string strPage)
        {
            bool blAccess = false;
            BL_User_Access objBL_UserAccess = new BL_User_Access();
            ML_User_Access objML_UserAccess = new ML_User_Access();
            objML_UserAccess.ID = Convert.ToString(HttpContext.Current.Session["UserName"]);
            objML_UserAccess.ModulesName = strPage;
            DataTable dt = objBL_UserAccess.BL_ModulePermision(objML_UserAccess);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    blAccess = true;
                }
                else
                {
                    blAccess = false;
                }
            }
            return blAccess;
        }
        public bool SetSessionFromCookies()
        {
            bool blCookie = false;
            if (HttpContext.Current.Request.Cookies["SPCN"] != null)
            {
                HttpContext.Current.Session["UserName"] = HttpContext.Current.Request.Cookies["Tecxpert"]["UserName"];
                HttpContext.Current.Session["UserType"] = HttpContext.Current.Request.Cookies["Tecxpert"]["UserType"];
                blCookie = true;
            }
            else
            {
                blCookie = false;
            }
            return blCookie;

        }
        #endregion

        #region Email
        public void SendMail(string mailTo, string strmailcc, string mailBody, string subject)
        {
            SendMail1("sappal.parteek90@gmail.com", "sappal.parteek90@gmail.com", "Hii", "Password");
        }
        public void SendSMS(string Message, string MobileNo)
        {
            string SMSUserName = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["SMSUserName"]);
            string SMSPassword = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["SMSPassword"]);
            string SMSSender = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["SMSSender"]);
            string SMSRoute = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["SMSRoute"]);
            string SMSCountryCode = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["SMSCountryCode"]);
            string SMSMessage = Message;
            string SMSMobile = MobileNo;

            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("https://www.txtguru.in/imobile/api.php?username=" + SMSUserName + "&password=" + SMSPassword + "&source=senderid&dmobile=91" + SMSMobile + "&message=" + SMSMessage + "");            
            HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
            System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = respStreamReader.ReadToEnd();
            respStreamReader.Close();
            myResp.Close();
        }
        public void SendMail1(string mailTo, string strmailcc, string mailBody, string subject)
        {
            string strMailCredentialUserName = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["MailCredentialUserName"]);
            string strMailCredentialPassword = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["MailCredentialPassword"]);
            string strMailClientHost = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["MailClientHost"]);
            string strWebSmtpPort = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["SmtpPort"]);
            string strMailFrom = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["MailFrom"]);

            SmtpClient SmtpServer = new SmtpClient();
            SmtpServer.Credentials = new System.Net.NetworkCredential(strMailCredentialUserName, strMailCredentialPassword);
            SmtpServer.Port = 25;
            SmtpServer.Host = strMailClientHost;
            SmtpServer.EnableSsl = false;
            MailMessage mail = new MailMessage();
            try
            {
                mail.From = new MailAddress(strMailCredentialUserName, "Tecxpert", System.Text.Encoding.UTF8);
                if (!string.IsNullOrEmpty(strmailcc))
                {
                    mail.CC.Add(strmailcc);
                }
                mail.Subject = subject;
                mail.Body = mailBody;
                mail.IsBodyHtml = true;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                mail.ReplyTo = new MailAddress(strMailFrom);

                string[] strMAilToArr = mailTo.Split(',');
                if (mailTo.Contains(","))
                {
                    char[] delimiters = new char[] { ',', ';' };
                    string[] strArrMailto = mailTo.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string strMailToLocal in strArrMailto)
                    {
                        try
                        {
                            mail.To.Add(strMailToLocal);
                            SmtpServer.Send(mail);
                        }
                        catch
                        {
                        }
                    }
                }
                else
                {
                    mail.To.Add(mailTo);
                    SmtpServer.Send(mail);
                }

                //SmtpServer.Send(mail);

            }
            catch (Exception err)
            {

            }
        }

        #endregion

        #region Profile
        public bool UserPrifleAccess(string EmpDep)
        {
            bool blAccess = false;
            if (EmpDep == "Dep/1004")
            {
                blAccess = false;
            }
            else
            {
                blAccess = true;
            }
            return blAccess;

        }

        #endregion
    }
}