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
    public class DL_State_Master
    {
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);

      /*  public int DL_UpdateStateMaster(ML_State_Master objML_Default)
        {
            SqlParameter[] par ={new SqlParameter("@UserName", objML_Default.UserName)
                                    
                                };
            return SqlHelper.ExecuteNonQuery(con, "OSP_UserDetailNameWise", par).Tables[0];

        }*/

        public int DL_InsStateMaster(ML_State_Master objML_Default)
        {
            SqlParameter[] par = { new SqlParameter("@stateId",objML_Default.StateId),
                                    new SqlParameter("@stateName",objML_Default.StateName),
                                    new SqlParameter("@CreatedBy",objML_Default.CreatedBy), 
                                    new SqlParameter("@ModifyBy",objML_Default.ModifyBy)
                                    
                                 };
            return SqlHelper.ExecuteNonQuery(con, "OSP_InsState", par);
        }
        public DataTable DL_BindState(ML_State_Master objML_Default)
        {
            SqlParameter[] par = { new SqlParameter("@ID",objML_Default.StateId),
                                                                      
                                 };
            return SqlHelper.ExecuteDataset(con, "SPCN_State_Bind", par).Tables[0];
        }
        public int DL_DeleteState(ML_State_Master objML_Default)
        {
            SqlParameter[] par = { new SqlParameter("@ID",objML_Default.StateId),
                                                                       
                                 };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_State_Delete", par);
        }
        public DataTable DL_EditState(ML_State_Master objML_Default)
        {
            SqlParameter[] par = { new SqlParameter("@ID",objML_Default.StateId),
                                                                      
                                 };
            return SqlHelper.ExecuteDataset(con, "SPCN_State_Edit", par).Tables[0];
        }
    }
}