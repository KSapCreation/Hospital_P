using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hotelManagement.H.layers.DataLayers;
using hotelManagement.H.layers.ModelLayers;
using System.Data;

namespace hotelManagement.H.layers.BusinessLayers
{
    public class BL_User_Access
    {
        DL_User_Access objDL_UserAccess = new DL_User_Access();
        public DataTable BL_BindUserDetail(ML_User_Access objML_UserAccess)
        {
            return objDL_UserAccess.DL_BindUserDetail(objML_UserAccess);
        }
        public DataTable BL_FindLoginDetail(ML_User_Access objML_Default)
        {
            return objDL_UserAccess.DL_FindLoginDetail(objML_Default);
        }
        public DataTable BL_LoginUser(ML_User_Access objML_Default)
        {
            return objDL_UserAccess.DL_LoginUser(objML_Default);
        }
        public DataTable BL_InsertLoginHistory(ML_User_Access objML_Default)
        {
            return objDL_UserAccess.DL_InsertLoginHistory(objML_Default);
        }
        public DataTable BL_UserDetailNameWise(ML_User_Access objML_Default)
        {
            return objDL_UserAccess.DL_UserDetailNamewise(objML_Default);
        }
        public int BL_InsUpdUserDetail(ML_User_Access objML_Default)
        {
            return objDL_UserAccess.DL_InsUpdUserDetail(objML_Default);
        }
        public int BL_ChangePassword(ML_User_Access objML_Default)
        {
            return objDL_UserAccess.DL_ChangePassword(objML_Default);
        }
        public DataTable BL_ModulePermision(ML_User_Access objML_Default)
        {
            return objDL_UserAccess.DL_ModulePermisson(objML_Default);
        }
        public DataTable BL_BindUser(ML_User_Access objML_UserAccess)
        {
            return objDL_UserAccess.DL_BindUser(objML_UserAccess);
        }
        public int BL_DeleteUserDetail(ML_User_Access objML_Default)
        {
            return objDL_UserAccess.DL_DeleteUserDetail(objML_Default);
        }
        public DataTable BL_EditUserDetail(ML_User_Access objML_Default)
        {
            return objDL_UserAccess.DL_EditUserDetail(objML_Default);
        }
    }
}