using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hospital_P.H.layers.DataLayers;
using Hospital_P.H.layers.ModelLayers;
using System.Data;

namespace Hospital_P.H.layers.BusinessLayers
{
    public class BL_Security
    {
        DL_Secuirty objDL_Secuirty = new DL_Secuirty();
        public DataTable BL_BindModules(ML_Secuirty objML_Secuirty)
        {
            return objDL_Secuirty.DL_BindModules(objML_Secuirty);
        }
        public int BL_InsUpdModules(ML_Secuirty objML_Secuirty)
        {
            return objDL_Secuirty.DL_InsUpdModules(objML_Secuirty);
        }
        public DataTable BL_SelectUserModules(ML_Secuirty objML_Secuirty)
        {
            return objDL_Secuirty.DL_SelectuserModules(objML_Secuirty);
        }

    }
}