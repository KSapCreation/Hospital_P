using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using hotelManagement.H.layers.ModelLayers;
using Microsoft.ApplicationBlocks.Data;
using System.Data;

namespace hotelManagement.H.layers.DataLayers
{
    public class DL_User_Access
    {
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        public DataTable DL_BindUserDetail(ML_User_Access objML_UserAccess)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_UserAccess.ID)
                               };
            return SqlHelper.ExecuteDataset(con, "OSP_BindUserDetail", par).Tables[0];
        }
        public DataTable DL_FindLoginDetail(ML_User_Access objML_Default)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Default.UserName),                                    
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_User_Login_Forget", par).Tables[0];

        }
        public DataTable DL_LoginUser(ML_User_Access objML_Default)
        {
            SqlParameter[] par ={new SqlParameter("@UserName",objML_Default.UserName),
                                    new SqlParameter("@Password",objML_Default.Passsword)
                                };
            return SqlHelper.ExecuteDataset(con, "OSP_CheckLogin_Detail", par).Tables[0];

        }
        public DataTable DL_InsertLoginHistory(ML_User_Access objML_Default)
        {
            SqlParameter[] par ={new SqlParameter("@UserId",objML_Default.UserName),
                                    new SqlParameter("@Ip",objML_Default.IP),
                                    new SqlParameter("@loginTime",objML_Default.LoginDate),
                                     new SqlParameter("@Name",objML_Default.UserName)
                                    
                                };
            return SqlHelper.ExecuteDataset(con, "OSP_LoginHistory_Insert", par).Tables[0];
        }
        public DataTable DL_UserDetailNamewise(ML_User_Access objML_Default)
        {
            SqlParameter[] par ={new SqlParameter("@UserName",objML_Default.UserName)
                                    
                                };
            return SqlHelper.ExecuteDataset(con, "OSP_UserDetailNameWise", par).Tables[0];

        }
        public int DL_InsUpdUserDetail(ML_User_Access objML_Default)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Default.ID),
                                    new SqlParameter("@UserName",objML_Default.UserName),
                                    new SqlParameter("@LastName",objML_Default.LastName),
                                    new SqlParameter("@EmailID",objML_Default.EmailID),
                                    new SqlParameter("@MobileNo",objML_Default.MobileNo),
                                    new SqlParameter("@Address",objML_Default.Address),
                                    new SqlParameter("@Activation",objML_Default.Activation),
                                    new SqlParameter("@country",objML_Default.country),
                                    new SqlParameter("@State",objML_Default.State),
                                    new SqlParameter("@City",objML_Default.City),
                                    new SqlParameter("@password",objML_Default.Passsword),
                                    new SqlParameter("@ConformPwd",objML_Default.ConformPasword) ,
                                    new SqlParameter("@CreatedBy",objML_Default.CreatedBy), 
                                    new SqlParameter("@ModifyBy",objML_Default.ModifyBy)
                                    
                                 };
            return SqlHelper.ExecuteNonQuery(con, "OSP_InsUpdUserDetail", par);
        }
        public DataTable DL_ModulePermisson(ML_User_Access objML_Default)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Default.ID),
                                    new SqlParameter("@ModulesName",objML_Default.ModulesName),
                                 };
            return SqlHelper.ExecuteDataset(con, "SPCN_Modules_Permissions_Select", par).Tables[0];

        }
        public int DL_ChangePassword(ML_User_Access objML_Default)
        {
            SqlParameter[] par ={   new SqlParameter("@UserName",objML_Default.UserName),
                                    new SqlParameter("@OldPassowrd",objML_Default.OldPassword),
                                    new SqlParameter("@password",objML_Default.Passsword),
                                    new SqlParameter("@ConformPwd",objML_Default.ConformPasword) ,                                    
                                    new SqlParameter("@ModifyBy",objML_Default.ModifyBy)
                                    
                                 };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_Change_Password", par);
        }
        public DataTable DL_BindUser(ML_User_Access objML_UserAccess)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_UserAccess.ID)
                               };
            return SqlHelper.ExecuteDataset(con, "SPCN_User_MasterAccess_Bind", par).Tables[0];
        }
        public int DL_DeleteUserDetail(ML_User_Access objML_Default)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Default.ID),                                                                                                     
                                 };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_User_MasterAccess_Delete", par);
        }
        public DataTable DL_EditUserDetail(ML_User_Access objML_Default)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Default.ID)
                                    
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_User_MasterAccess_Select", par).Tables[0];

        }
    }
}