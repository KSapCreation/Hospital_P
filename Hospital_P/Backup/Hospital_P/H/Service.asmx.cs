using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace Hospital_P.H
{
    /// <summary>
    /// Summary description for Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string> GetAutoCompleteData(string username)
        {
            List<string> result = new List<string>();
            using (SqlConnection con = new SqlConnection("data source=DESKTOP-0UD42TH/SQLEXPRESS;initial catalog=KSPCN;user id=sa;password=tecxpert;timeout=300000"))
            {
                using (SqlCommand cmd = new SqlCommand("select DISTINCT Name from SPCN_Slip_Book_Entry where Name LIKE '%'+@SearchText+'%'", con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@SearchText", username);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        result.Add(dr["UserName"].ToString());
                    }
                    return result;
                }
            }
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetCustomers(string prefix)
        {
            List<string> customers = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.AppSettings["Hospital"];
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select Slip_No from SPCN_Slip_Book_Entry where " +
                    "Slip_No like @SearchText + '%'";
                    cmd.Parameters.AddWithValue("@SearchText", prefix);
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(string.Format("{0}-{1}", sdr["Slip_No"], sdr["Slip_No"]));
                        }
                    }
                    conn.Close();
                }
                return customers.ToArray();
            }
        }
      // Pateint Registration Search
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetPatientDetail(string prefix)
        {
            List<string> customers = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.AppSettings["Hospital"];
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select Patient_ID from SPCN_Pateint_Registration_Entry where " +
                    "Patient_ID like @SearchText + '%'";
                    cmd.Parameters.AddWithValue("@SearchText", prefix);
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(string.Format("{0}-{1}", sdr["Patient_ID"], sdr["Patient_ID"]));
                        }
                    }
                    conn.Close();
                }
                return customers.ToArray();
            }
        }
        // Token System Registration Search
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetToken(string prefix)
        {
            List<string> customers = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.AppSettings["Hospital"];
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select TokenID from SPCN_Token_Master where " +
                    "Patient_ID like @SearchText + '%'";
                    cmd.Parameters.AddWithValue("@SearchText", prefix);
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(string.Format("{0}-{1}", sdr["TokenID"], sdr["TokenID"]));
                        }
                    }
                    conn.Close();
                }
                return customers.ToArray();
            }
        }
        // Test Name Search
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetTestList(string prefix)
        {
            List<string> customers = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.AppSettings["Hospital"];
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select TestID from SPCN_Test_Master where " +
                    "TestID like @SearchText + '%'";
                    cmd.Parameters.AddWithValue("@SearchText", prefix);
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(string.Format("{0}-{1}", sdr["TestID"], sdr["TestID"]));
                        }
                    }
                    conn.Close();
                }
                return customers.ToArray();
            }
        }
        // Test Parameter Values Search
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetParameterValues(string prefix)
        {
            List<string> customers = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.AppSettings["Hospital"];
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select PVCode from SPCN_Test_Paramter_Values_head where " +
                    "PVCode like @SearchText + '%'";
                    cmd.Parameters.AddWithValue("@SearchText", prefix);
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(string.Format("{0}-{1}", sdr["PVCode"], sdr["PVCode"]));
                        }
                    }
                    conn.Close();
                }
                return customers.ToArray();
            }
        }
        // Users Search
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetUsers(string prefix)
        {
            List<string> customers = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.AppSettings["Hospital"];
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select Username from SPCN_User_Master_Access where " +
                    "Username like @SearchText + '%'";
                    cmd.Parameters.AddWithValue("@SearchText", prefix);
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(string.Format("{0}-{1}", sdr["Username"], sdr["Username"]));
                        }
                    }
                    conn.Close();
                }
                return customers.ToArray();
            }
        }
        // Lab Report Search
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetLabReport(string prefix)
        {
            List<string> customers = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.AppSettings["Hospital"];
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select PatientName from SPCN_Test_Paramter_Values_Head where " +
                    "PatientName like @SearchText + '%'";
                    cmd.Parameters.AddWithValue("@SearchText", prefix);
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(string.Format("{0}-{1}", sdr["PatientName"], sdr["PatientName"]));
                        }
                    }
                    conn.Close();
                }
                return customers.ToArray();
            }
        }
    }
}
