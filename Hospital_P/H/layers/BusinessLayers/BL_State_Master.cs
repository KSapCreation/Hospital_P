using hotelManagement.H.layers.ModelLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace hotelManagement.H.layers.BusinessLayers
{
    public class BL_State_Master
    {
        DataLayers.DL_State_Master objState = new DataLayers.DL_State_Master();
        public int BL_InsStateDetail(ML_State_Master objML_Default)
        {
            return objState.DL_InsStateMaster(objML_Default);
        }

        public DataTable BL_BindState(ML_State_Master objML_Default)
        {
            return objState.DL_BindState(objML_Default);
        }
        public int BL_DeleteState(ML_State_Master objML_Default)
        {
            return objState.DL_DeleteState(objML_Default);
        }
        public DataTable BL_EditState(ML_State_Master objML_Default)
        {
            return objState.DL_EditState(objML_Default);
        }
    }
}