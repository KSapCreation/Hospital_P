using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelManagement.Management.Layers.DataLayer;
using HotelManagement.Management.Layers.ModelLayer;
using System.Data;

namespace HotelManagement.Management.Layers.Businesslayer
{
    public class BL_Default
    {
        DL_Default objDL_Default = new DL_Default();
        public DataTable BL_FindLoginDetail(ML_Default objML_Default)
        {
            return objDL_Default.DL_FindLoginDetail(objML_Default);
        }
        public DataTable BL_LoginUser(ML_Default objML_Default)
        {
            return objDL_Default.DL_LoginUser(objML_Default);
        }
        public DataTable BL_ModulePermision(ML_Default objML_Default)
        {
            return objDL_Default.DL_ModulePermisson(objML_Default);
        }
    }
}