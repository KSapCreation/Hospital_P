using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelManagement.Management.Layers.DataLayer;
using HotelManagement.Management.Layers.ModelLayer;
using System.Data;

namespace HotelManagement.Management.Layers.Businesslayer
{
    public class BL_RoomMaster
    {
        DL_RoomMaster objDL_RoomMaster = new DL_RoomMaster();
        public int BL_SaveRoomMaster(ML_RoomMaster objML_RoomMaster)
        {
            return objDL_RoomMaster.DL_SaveRoomMaster(objML_RoomMaster);
        }
        public DataTable BL_BindRoomList(ML_RoomMaster objML_RoomMaster)
        {
            return objDL_RoomMaster.DL_BindRoomList(objML_RoomMaster);
        }
        public int BL_DeleteRoomMaster(ML_RoomMaster objML_RoomMaster)
        {
            return objDL_RoomMaster.DL_DeleteRoomMaster(objML_RoomMaster);
        }
        public DataTable BL_SelectRoomMaster(ML_RoomMaster objML_RoomMaster)
        {
            return objDL_RoomMaster.DL_SelectRoomList(objML_RoomMaster);
        }
        public int BL_SaveRoomMasterDetail(ML_RoomMaster objML_RoomMaster)
        {
            return objDL_RoomMaster.DL_SaveRoomMasterDetail(objML_RoomMaster);
        }
        public int BL_DeleteRoomMasterDetail(ML_RoomMaster objML_RoomMaster)
        {
            return objDL_RoomMaster.DL_DeleteRoomMasterDetail(objML_RoomMaster);
        }
        public DataTable BL_BindRoomDashboard(ML_RoomMaster objML_RoomMaster)
        {
            return objDL_RoomMaster.DL_BindRoomDashbard(objML_RoomMaster);
        }
        public int BL_SaveHotelItemMaster(ML_RoomMaster objML_RoomMaster)
        {
            return objDL_RoomMaster.DL_SaveHotelItemMaster(objML_RoomMaster);
        }
        public DataTable BL_BindHotelItemList(ML_RoomMaster objML_RoomMaster)
        {
            return objDL_RoomMaster.DL_BindHotelItemList(objML_RoomMaster);
        }
        public DataTable BL_SelectHotelItemMaster(ML_RoomMaster objML_RoomMaster)
        {
            return objDL_RoomMaster.DL_SelectHotelItemList(objML_RoomMaster);
        }
        public int BL_DeleteHotelItemMaster(ML_RoomMaster objML_RoomMaster)
        {
            return objDL_RoomMaster.DL_DeletehotelItemMaster(objML_RoomMaster);
        }
        public DataTable BL_BindRoomDashboardCheckIn(ML_RoomMaster objML_RoomMaster)
        {
            return objDL_RoomMaster.DL_BindRoomDashbardCheckIn(objML_RoomMaster);
        }
        public DataTable BL_BindGuestListDashboard(ML_RoomMaster objML_RoomMaster)
        {
            return objDL_RoomMaster.DL_BindGuestListDashbard(objML_RoomMaster);
        }
        public DataTable BL_EditRoomVisitorDetail(ML_Visitors objML_RoomMaster)
        {
            return objDL_RoomMaster.DL_EditRoomVisitorList(objML_RoomMaster);
        }
        public DataTable BL_BindTaxGroup(ML_RoomMaster objML_RoomMaster)
        {
            return objDL_RoomMaster.DL_BindTaxGroup(objML_RoomMaster);
        }
    }

    public class BL_Masters
    {
        DL_Masters objDL_Master = new DL_Masters();
        public int BL_SaveStateMaster(ML_Masters objML_Masters)
        {
            return objDL_Master.DL_SaveStateMaster(objML_Masters);
        }
        public DataTable BL_BindStateMaster(ML_Masters objML_Masters)
        {
            return objDL_Master.DL_BindStateMaster(objML_Masters);
        }
        public int BL_SaveCityMaster(ML_Masters objML_Masters)
        {
            return objDL_Master.DL_SaveCityMaster(objML_Masters);
        }
        public DataTable BL_BindStateList(ML_Masters objML_Masters)
        {
            return objDL_Master.DL_BindStateList(objML_Masters);
        }
        public DataTable BL_BindCityList(ML_Masters objML_Masters)
        {
            return objDL_Master.DL_BindCityList(objML_Masters);
        }
        public int BL_SaveHotelMaster(ML_Masters objML_Masters)
        {
            return objDL_Master.DL_SaveHotelMaster(objML_Masters);
        }
        public DataTable BL_BindHotelMaster(ML_Masters objML_Masters)
        {
            return objDL_Master.DL_BindHotelMaster(objML_Masters);
        }
    }
}