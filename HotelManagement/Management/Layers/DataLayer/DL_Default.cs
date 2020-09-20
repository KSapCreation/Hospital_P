using hotelManagement.Mangement.layers.DataLayers;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HotelManagement.Management.Layers.ModelLayer;

namespace HotelManagement.Management.Layers.DataLayer
{
    public class DL_Default
    {
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        public DataTable DL_FindLoginDetail(ML_Default objML_Default)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Default.UserName),                                    
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_User_Login_Forget", par).Tables[0];

        }
        public DataTable DL_LoginUser(ML_Default objML_Default)
        {
            SqlParameter[] par ={new SqlParameter("@UserName",objML_Default.UserName),
                                    new SqlParameter("@Password",objML_Default.Passsword)
                                };
            return SqlHelper.ExecuteDataset(con, "OSP_CheckLogin_Detail", par).Tables[0];

        }
        public DataTable DL_ModulePermisson(ML_Default objML_Default)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Default.ID),
                                    new SqlParameter("@ModulesName",objML_Default.ModulesName),
                                 };
            return SqlHelper.ExecuteDataset(con, "SPCN_Modules_Permissions_Select", par).Tables[0];

        }
    }
}