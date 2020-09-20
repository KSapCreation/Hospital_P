using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelManagement.Management.Layers.DataLayer;
using HotelManagement.Management.Layers.ModelLayer;
using System.Data;

namespace HotelManagement.Management.Layers.Businesslayer
{
    public class BL_Visitors
    {
        DL_Visitors objDL_Visitor = new DL_Visitors();
        public DataTable BL_BindRoomList(ML_Visitors objML_Visitor)
        {
            return objDL_Visitor.DL_BindRoomList(objML_Visitor);
        }
        public DataTable BL_SelectRoomNo(ML_Visitors objML_Visitor)
        {
            return objDL_Visitor.DL_SelectRoomNo(objML_Visitor);
        }
        public DataTable BL_BindStateList(ML_Visitors objML_Visitor)
        {
            return objDL_Visitor.DL_BindStateList(objML_Visitor);
        }
        public DataTable BL_BindCityList(ML_Visitors objML_Visitor)
        {
            return objDL_Visitor.DL_BindCityList(objML_Visitor);
        }
        public int BL_SaveVisitorsDetail(ML_Visitors objML_Visitor)
        {
            return objDL_Visitor.DL_SaveVisitorDetail(objML_Visitor);
        }
        public DataTable BL_Check_In_Room_List(ML_Visitors objML_Visitor)
        {
            return objDL_Visitor.DL_Check_In_Room_List(objML_Visitor);
        }
        public DataTable BL_Bind_Check_In_List(ML_Visitors objML_Visitor)
        {
            return objDL_Visitor.DL_Bind_Check_In_List(objML_Visitor);
        }
        public DataTable BL_Select_Check_In_List(ML_Visitors objML_Visitor)
        {
            return objDL_Visitor.DL_Select_Check_In_List(objML_Visitor);
        }
        public DataTable BL_Bind_Item_List(ML_Visitors objML_Visitor)
        {
            return objDL_Visitor.DL_Bind_Item_List(objML_Visitor);
        }
        public DataTable BL_Select_Item_List(ML_Visitors objML_Visitor)
        {
            return objDL_Visitor.DL_Select_Item_List(objML_Visitor);
        }
        public int BL_InsUpdServiceDesk(ML_Visitors objML_Visitor)
        {
            return objDL_Visitor.DL_InsUpdServiceDesk(objML_Visitor);
        }
        public DataTable BL_Select_Service_Desk_Detail(ML_Visitors objML_Visitor)
        {
            return objDL_Visitor.DL_Select_Service_Desk_Details(objML_Visitor);
        }
        public int BL_InsUpdVisitorCheckOut(ML_Visitors objML_Visitor)
        {
            return objDL_Visitor.DL_InsUpdVisitorCheckout(objML_Visitor);
        }
        public int BL_InsUpdVisitorCheckOutDetail(ML_Visitors objML_Visitor)
        {
            return objDL_Visitor.DL_InsUpdVisitorCheckoutDetail(objML_Visitor);
        }
        public int BL_UpdVisitorCheckOutData(ML_Visitors objML_Visitor)
        {
            return objDL_Visitor.DL_UpdVisitorCheckoutData(objML_Visitor);
        }
        public DataTable BL_DropdownSelectionVisitors(ML_Visitors objML_Visitor)
        {
            return objDL_Visitor.DL_DropDownSelectionVisitors(objML_Visitor);
        }
        public DataTable BL_Bind_Departure_List(ML_Visitors objML_Visitor)
        {
            return objDL_Visitor.DL_Bind_Departure_List(objML_Visitor);
        }
        public DataTable BL_GET_Tax_Rate(ML_Visitors objML_Visitor)
        {
            return objDL_Visitor.DL_Get_Tax_Rate(objML_Visitor);
        }

    }

}