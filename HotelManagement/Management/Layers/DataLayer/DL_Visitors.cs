using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using HotelManagement.Management.Layers.ModelLayer;
using hotelManagement.Mangement.layers.DataLayers;
using Microsoft.ApplicationBlocks.Data;

namespace HotelManagement.Management.Layers.DataLayer
{
    public class DL_Visitors
    {
        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);

        //public int DL_SaveRoomMaster(ML_Visitor objML_Visitor)
        //{
        //    SqlParameter[] par ={new SqlParameter("@RoomID",objML_Visitor.ID),
        //                            new SqlParameter("@RoomName",objML_Visitor.RoomName),
        //                            new SqlParameter("@RoomNo",objML_Visitor.RoomNo),
        //                            new SqlParameter("@RoomPrice",objML_Visitor.RoomPrice),
        //                            new SqlParameter("@IsActive",objML_Visitor.Is_Active),
        //                            new SqlParameter("@CreatedBy",objML_Visitor.CreatedBy),
        //                            new SqlParameter("@ModifyBy",objML_Visitor.ModifyBy),
        //                        };
        //    return SqlHelper.ExecuteNonQuery(con, "SPCN_Insert_Room_Master", par);

        //}
        public DataTable DL_BindRoomList(ML_Visitors objML_Visitor)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Visitor.ID)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_RoomMaster_Bind", par).Tables[0];
        }
        public DataTable DL_SelectRoomNo(ML_Visitors objML_Visitor)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Visitor.ID)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_RoomMaster_Select", par).Tables[0];
        }
        public DataTable DL_BindStateList(ML_Visitors objML_Visitor)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Visitor.ID)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_StateMasterProjectWise_Select", par).Tables[0];
        }
        public DataTable DL_BindCityList(ML_Visitors objML_Visitor)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Visitor.ID)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_City_Select", par).Tables[0];
        }
        public int DL_SaveVisitorDetail(ML_Visitors objML_Visitor)
        {
            SqlParameter[] par ={new SqlParameter("@VisitorID",objML_Visitor.ID),
                                    new SqlParameter("@NamePrefix",objML_Visitor.NamePrefix),
                                    new SqlParameter("@GuestName",objML_Visitor.Name),
                                    new SqlParameter("@Address",objML_Visitor.Address),
                                    new SqlParameter("@State",objML_Visitor.State),
                                    new SqlParameter("@City",objML_Visitor.City),
                                    new SqlParameter("@ZipCode",objML_Visitor.ZipCode),
                                    new SqlParameter("@Country",objML_Visitor.Country),
                                    new SqlParameter("@RoomName",objML_Visitor.RoomName),
                                    new SqlParameter("@RoomNo",objML_Visitor.RoomNo),
                                    new SqlParameter("@ArrivalDate",objML_Visitor.ArrivalDate),
                                    new SqlParameter("@ArrivalTime",objML_Visitor.ArrivalTime),
                                    new SqlParameter("@DepartureDate",objML_Visitor.DepartureDate),
                                    new SqlParameter("@DepartureTime",objML_Visitor.DepartureTime),
                                    new SqlParameter("@Days",objML_Visitor.Days),
                                    new SqlParameter("@Adults",objML_Visitor.Adults),
                                    new SqlParameter("@Child",objML_Visitor.Child),
                                    new SqlParameter("@ReservationType",objML_Visitor.ReservationType),
                                    new SqlParameter("@Email",objML_Visitor.Email),
                                    new SqlParameter("@PhoneNo",objML_Visitor.PhoneNo),
                                    new SqlParameter("@MobileNo",objML_Visitor.MobileNo),
                                    new SqlParameter("@Fax",objML_Visitor.Fax),
                                    new SqlParameter("@Identity",objML_Visitor.Identity),
                                    new SqlParameter("@IdentityNo",objML_Visitor.IdentityNo),
                                    new SqlParameter("@Gender",objML_Visitor.Gender),
                                    new SqlParameter("@BillType",objML_Visitor.BillType),
                                    new SqlParameter("@PaymentType",objML_Visitor.PaymentType),
                                    new SqlParameter("@PaymentMode",objML_Visitor.PaymentMode),
                                    new SqlParameter("@RoomPrice",objML_Visitor.RoomPrice),
                                    new SqlParameter("@CreatedBy",objML_Visitor.CreatedBy),
                                    new SqlParameter("@ModifyBy",objML_Visitor.ModifyBy),
                                    new SqlParameter("@Discount",objML_Visitor.DiscountPer),
                                    new SqlParameter("@TaxName1",objML_Visitor.TaxName1),
                                    new SqlParameter("@TaxRate1",objML_Visitor.TaxRate1),
                                    new SqlParameter("@TaxAmt1",objML_Visitor.TaxAmt1),
                                      new SqlParameter("@TaxName2",objML_Visitor.TaxName2),
                                    new SqlParameter("@TaxRate2",objML_Visitor.TaxRate2),
                                    new SqlParameter("@TaxAmt2",objML_Visitor.TaxAmt2),
                                      new SqlParameter("@TaxName3",objML_Visitor.TaxName3),
                                    new SqlParameter("@TaxRate3",objML_Visitor.TaxRate3),
                                    new SqlParameter("@TaxAmt3",objML_Visitor.TaxAmt3),
                                    new SqlParameter("@TaxableAmount",objML_Visitor.TaxableAmount),
                                    new SqlParameter("@DiscountAmt",objML_Visitor.DiscountAmt),
                                    new SqlParameter("@GrandTotal",objML_Visitor.GrandTotal),
                                };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_Insert_Hotel_Check_In", par);
        }
        public DataTable DL_Check_In_Room_List(ML_Visitors objML_Visitor)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Visitor.ID)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_Check_In_Room_List", par).Tables[0];
        }
        public DataTable DL_Bind_Check_In_List(ML_Visitors objML_Visitor)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Visitor.ID)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_Hotel_Check_In_bind", par).Tables[0];
        }
        public DataTable DL_Select_Check_In_List(ML_Visitors objML_Visitor)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Visitor.ID)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_Hotel_Check_In_Select", par).Tables[0];
        }
        public DataTable DL_Bind_Item_List(ML_Visitors objML_Visitor)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Visitor.ID)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_Hotel_Item_Master_bind", par).Tables[0];
        }
        public DataTable DL_Select_Item_List(ML_Visitors objML_Visitor)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Visitor.ID),
                                    new SqlParameter("@ItemID",objML_Visitor.Name)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_ITEM_Price_List", par).Tables[0];
        }
        public int DL_InsUpdServiceDesk(ML_Visitors objML_Visitor)
        {
            SqlParameter[] par ={new SqlParameter("@ServiceID",objML_Visitor.ID),
                                    new SqlParameter("@GuestName",objML_Visitor.Name),
                                    new SqlParameter("@RoomNo",objML_Visitor.RoomNo),
                                    new SqlParameter("@ItemID",objML_Visitor.ItemName),
                                    new SqlParameter("@ItemType",objML_Visitor.ItemType),
                                    new SqlParameter("@ItemPrice",objML_Visitor.RoomPrice),
                                         new SqlParameter("@CreatedBy",objML_Visitor.CreatedBy),
                                    new SqlParameter("@ModifyBy",objML_Visitor.ModifyBy)
                                };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_InsUpd_Service_Desk_Master", par);
        }
        public DataTable DL_Select_Service_Desk_Details(ML_Visitors objML_Visitor)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Visitor.Name),
                                    new SqlParameter("@RoomNo",objML_Visitor.RoomNo)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_Service_Desk_Select_Against_Guest", par).Tables[0];
        }
        public int DL_InsUpdVisitorCheckout(ML_Visitors objML_Visitor)
        {
            SqlParameter[] par ={new SqlParameter("@CheckOutID",objML_Visitor.ID),
                                    new SqlParameter("@VisitorID",objML_Visitor.VisitorID),
                                    new SqlParameter("@RoomNo",objML_Visitor.RoomNo),
                                    new SqlParameter("@RoomPrice",objML_Visitor.RoomAmount),
                                    new SqlParameter("@ServiceDeskPrice",objML_Visitor.ServiceDeskAmount),                                                               
                                         new SqlParameter("@CreatedBy",objML_Visitor.CreatedBy),
                                    new SqlParameter("@ModifyBy",objML_Visitor.ModifyBy),
                                      new SqlParameter("@TotolAmount",objML_Visitor.TotolAmount),
                                        new SqlParameter("@TaxName1",objML_Visitor.TaxName1),
                                    new SqlParameter("@TaxRate1",objML_Visitor.TaxRate1),
                                    new SqlParameter("@TaxAmt1",objML_Visitor.TaxAmt1),
                                      new SqlParameter("@TaxName2",objML_Visitor.TaxName2),
                                    new SqlParameter("@TaxRate2",objML_Visitor.TaxRate2),
                                    new SqlParameter("@TaxAmt2",objML_Visitor.TaxAmt2),
                                      new SqlParameter("@TaxName3",objML_Visitor.TaxName3),
                                    new SqlParameter("@TaxRate3",objML_Visitor.TaxRate3),
                                    new SqlParameter("@TaxAmt3",objML_Visitor.TaxAmt3),
                                    new SqlParameter("@TaxableAmount",objML_Visitor.TaxableAmount),
                                    new SqlParameter("@DiscountAmt",objML_Visitor.DiscountAmt),
                                    new SqlParameter("@GrandTotal",objML_Visitor.GrandTotal),

                                };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_InsUpd_CheckOut_Visitor", par);
        }
        public int DL_InsUpdVisitorCheckoutDetail(ML_Visitors objML_Visitor)
        {
            SqlParameter[] par ={new SqlParameter("@CheckOutID",objML_Visitor.ID),
                                 new SqlParameter("@ServiceID",objML_Visitor.ServiceDaskID),                                                               
                               
                                };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_InsUpd_CheckOut_Visitor_Detail", par);
        }
        public int DL_UpdVisitorCheckoutData(ML_Visitors objML_Visitor)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Visitor.VisitorID),                                 
                                };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_Update_CheckOut_Visitor_Detail", par);
        }
        public DataTable DL_DropDownSelectionVisitors(ML_Visitors objML_Visitor)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Visitor.ID)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_Checkout_DropdownSelection", par).Tables[0];
        }
        public DataTable DL_Bind_Departure_List(ML_Visitors objML_Visitor)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Visitor.ID)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_Hotel_Departure_bind", par).Tables[0];
        }
        public DataTable DL_Get_Tax_Rate(ML_Visitors objML_Visitor)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Visitor.ID)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_GET_Tax_Rate", par).Tables[0];
        }
    }
}