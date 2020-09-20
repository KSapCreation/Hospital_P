using Hospital_P.H.layers.ModelLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Hospital_P.H.layers.BusinessLayers
{
    public class BL_City_Master
    {
        DataLayers.DL_City_Master objCity = new DataLayers.DL_City_Master();
        public int BL_InsCityDetail(ML_City_Master objML_Default)
        {
            return objCity.DL_InsCityMaster(objML_Default);
        }
        public DataTable BL_BindCity(ML_City_Master objML_Default)
        {
            return objCity.DL_BindCity(objML_Default);
        }
        public int BL_DeleteCity(ML_City_Master objML_Default)
        {
            return objCity.DL_DeleteCity(objML_Default);
        }
        public DataTable BL_EditCity(ML_City_Master objML_Default)
        {
            return objCity.DL_EditCity(objML_Default);
        }
    }
}