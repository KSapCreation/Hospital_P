using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hospital_P.H.layers.DataLayers;
using Hospital_P.H.layers.ModelLayers;
using System.Data;


namespace Hospital_P.H.layers.BusinessLayers
{
    public class BL_HospitalMaster
    {
        DL_Hospital_Master objDL_HopsitalMaster = new DL_Hospital_Master();
        public DataTable BL_BindHospital(ML_Hospital_Master objML_Hospital)
        {
            return objDL_HopsitalMaster.DL_BindHospital(objML_Hospital);
        }

        public int BL_InsHospitalMaster(ML_Hospital_Master objML_Hospital)
        {
            return objDL_HopsitalMaster.DL_InsHospitalMaster(objML_Hospital);
        }

    }
}