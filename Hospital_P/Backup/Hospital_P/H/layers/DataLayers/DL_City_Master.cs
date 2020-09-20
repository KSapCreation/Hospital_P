using Hospital_P.H.layers.ModelLayers;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace Hospital_P.H.layers.DataLayers
{
    public class DL_City_Master
    {
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);

        public int DL_InsCityMaster(ML_City_Master objML_Default)
        {
            SqlParameter[] par = { new SqlParameter("@CityId",objML_Default.CityId),
                                    new SqlParameter("@CityName",objML_Default.CityName),
                                    new SqlParameter("@StateId",objML_Default.StateId),
                                    new SqlParameter("@CreatedBy",objML_Default.CreatedBy), 
                                    new SqlParameter("@ModifyBy",objML_Default.ModifyBy)
                                 };
            return SqlHelper.ExecuteNonQuery(con, "OSP_InsUpdCity", par);
        }
        public DataTable DL_BindCity(ML_City_Master objML_Default)
        {
            SqlParameter[] par = { new SqlParameter("@ID",objML_Default.CityId),
                                    
                                 };
            return SqlHelper.ExecuteDataset(con, "SPCN_City_Bind", par).Tables[0];
        }
        public int DL_DeleteCity(ML_City_Master objML_Default)
        {
            SqlParameter[] par = { new SqlParameter("@ID",objML_Default.CityId),
                                   
                                 };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_City_Delete", par);
        }
        public DataTable DL_EditCity(ML_City_Master objML_Default)
        {
            SqlParameter[] par = { new SqlParameter("@ID",objML_Default.CityId),
                                    
                                 };
            return SqlHelper.ExecuteDataset(con, "SPCN_City_Edit", par).Tables[0];
        }
    }
}