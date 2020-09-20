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
    public class DL_Secuirty
    {
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        public DataTable DL_BindModules(ML_Secuirty objML_Secuirty)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Secuirty.ID)
                               };
            return SqlHelper.ExecuteDataset(con, "SPCN_Modules", par).Tables[0];
        }
        public int DL_InsUpdModules(ML_Secuirty objML_Secuirty)
        {
            SqlParameter[] par ={new SqlParameter("@Select",objML_Secuirty.Select),
                                    new SqlParameter("@ModulesID",objML_Secuirty.ModulesID),
                                    new SqlParameter("@Modules",objML_Secuirty.Modules),
                                    new SqlParameter("@UserName",objML_Secuirty.UserName)
                               };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_InsUpdModulePermissions", par);
        }
        public DataTable DL_SelectuserModules(ML_Secuirty objML_Secuirty)
        {
            SqlParameter[] par ={new SqlParameter("@UserName",objML_Secuirty.UserName)
                               };
            return SqlHelper.ExecuteDataset(con, "SPCN_Module_Permissions_Select", par).Tables[0];
        }
    }
}