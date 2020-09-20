using hotelManagement.H.layers.ModelLayers;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace hotelManagement.H.layers.DataLayers
{
    public class DL_Hospital_Master
    {
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        public int DL_InsHospitalMaster(ML_Hospital_Master objML_Default)
        {
            SqlParameter[] par = { new SqlParameter("@HospitalId", objML_Default.HospitalNo),
                                     new SqlParameter("@HospitalNam",objML_Default.HospitalName),
                                     new SqlParameter("@StateId",objML_Default.StateId),
                                     new SqlParameter("@CityId",objML_Default.CityId),
                                    new SqlParameter("@HospitalAdd", objML_Default.Address),
                                    new SqlParameter("@HospitalWebsite", objML_Default.Website),
                                    new SqlParameter("@HospitalType", objML_Default.HospitalType),
                                    new SqlParameter("@Is_HMS", objML_Default.IsHms),
                                    new SqlParameter("@ProductName", objML_Default.ProductName),                                    
                                    new SqlParameter("@CreatedBy",objML_Default.CreatedBy), 
                                    new SqlParameter("@ModifyBy",objML_Default.ModifyBy)
                                 };
            return SqlHelper.ExecuteNonQuery(con, "OSP_InsUpdHospital", par);

        }
        public DataTable DL_BindHospital(ML_Hospital_Master objML_Default)
        {
           return SqlHelper.ExecuteDataset(con, "SPCN_BindHospital").Tables[0];
        }
    }
}