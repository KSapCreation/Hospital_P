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

    public class DL_RoomMaster
    {

        SqlConnection con = new SqlConnection(DL_Connection.GetConnection);
        public int DL_SaveRoomMaster(ML_RoomMaster objML_RoomMaster)
        {
            SqlParameter[] par ={new SqlParameter("@RoomID",objML_RoomMaster.ID),
                                    new SqlParameter("@RoomName",objML_RoomMaster.RoomName),                                 
                                    new SqlParameter("@RoomPrice",objML_RoomMaster.RoomPrice),
                                    new SqlParameter("@IsActive",objML_RoomMaster.Is_Active),
                                    new SqlParameter("@CreatedBy",objML_RoomMaster.CreatedBy),
                                    new SqlParameter("@ModifyBy",objML_RoomMaster.ModifyBy),
                                    new SqlParameter("@TaxGroup",objML_RoomMaster.TaxGroup),
                                };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_Insert_Room_Master", par);

        }
        public DataTable DL_BindRoomList(ML_RoomMaster objML_RoomMaster)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_RoomMaster.ID)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_RoomMaster_Bind", par).Tables[0];
        }
        public DataTable DL_BindRoomDashbard(ML_RoomMaster objML_RoomMaster)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_RoomMaster.ID)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_Room_Dashboard", par).Tables[0];
        }
        public DataTable DL_BindGuestListDashbard(ML_RoomMaster objML_RoomMaster)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_RoomMaster.ID)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_Hotel_Check_In_Visitor_Dashboard", par).Tables[0];
        }
        public int DL_DeleteRoomMaster(ML_RoomMaster objML_RoomMaster)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_RoomMaster.ID),
                                 
                                };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_RoomMaster_Delete", par);

        }
        public DataTable DL_SelectRoomList(ML_RoomMaster objML_RoomMaster)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_RoomMaster.ID)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_RoomMaster_Select", par).Tables[0];
        }
        public int DL_SaveRoomMasterDetail(ML_RoomMaster objML_RoomMaster)
        {
            SqlParameter[] par ={new SqlParameter("@RoomID",objML_RoomMaster.ID),                                  
                                    new SqlParameter("@RoomNo",objML_RoomMaster.RoomNo),                                   
                                };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_Insert_Room_Detail", par);
        }
        public int DL_DeleteRoomMasterDetail(ML_RoomMaster objML_RoomMaster)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_RoomMaster.ID),
                                 
                                };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_RoomMasterDetail_Delete", par);

        }
        public int DL_SaveHotelItemMaster(ML_RoomMaster objML_ItemMaster)
        {
            SqlParameter[] par ={new SqlParameter("@ItemID",objML_ItemMaster.ID),
                                    new SqlParameter("@ItemName",objML_ItemMaster.Name),                                 
                                    new SqlParameter("@ItemPrice",objML_ItemMaster.Price),
                                    new SqlParameter("@Description",objML_ItemMaster.Description),
                                    new SqlParameter("@IsActive",objML_ItemMaster.Is_Active),
                                    new SqlParameter("@CreatedBy",objML_ItemMaster.CreatedBy),
                                    new SqlParameter("@ModifyBy",objML_ItemMaster.ModifyBy),
                                    new SqlParameter("@HalfPrice",objML_ItemMaster.HalfPrice),
                                };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_Insert_Hotel_Item_Master", par);

        }
        public DataTable DL_BindHotelItemList(ML_RoomMaster objML_ItemMaster)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_ItemMaster.ID)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_Hotel_Item_Master_bind", par).Tables[0];
        }
        public DataTable DL_SelectHotelItemList(ML_RoomMaster objML_ItemMaster)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_ItemMaster.ID)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_Hotel_Item_Master_Select", par).Tables[0];
        }
        public int DL_DeletehotelItemMaster(ML_RoomMaster objML_RoomMaster)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_RoomMaster.ID),                                 
                                };
            return SqlHelper.ExecuteNonQuery(con, "SPCN_Hotel_Item_Master_Delete", par);
        }
        public DataTable DL_BindRoomDashbardCheckIn(ML_RoomMaster objML_RoomMaster)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_RoomMaster.ID)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_Hotel_Check_In_RoomNo", par).Tables[0];
        }
        public DataTable DL_EditRoomVisitorList(ML_Visitors objML_ItemMaster)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_ItemMaster.RoomNo),
                                    new SqlParameter("@VisitorID",objML_ItemMaster.VisitorID)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_Edit_RoomVisitorDetail", par).Tables[0];
        }
        public DataTable DL_BindTaxGroup(ML_RoomMaster objML_RoomMaster)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_RoomMaster.ID)
                                };
            return SqlHelper.ExecuteDataset(con, "SPCN_Tax_Group_Bind", par).Tables[0];
        }
    }

    public class DL_Masters
    {
        SqlConnection conn = new SqlConnection(DL_Connection.GetConnection);
        public int DL_SaveStateMaster(ML_Masters objML_Masters)
        {
            SqlParameter[] par ={new SqlParameter("@StateID",objML_Masters.ID),
                                    new SqlParameter("@StateName",objML_Masters.StateName),                                 
                                    new SqlParameter("@CreatedBy",objML_Masters.CreatedBy),
                                    new SqlParameter("@ModifyBy",objML_Masters.ModifyBy),
                                    new SqlParameter("@ProjectName",objML_Masters.ProjectName),
                                };
            return SqlHelper.ExecuteNonQuery(conn, "OSP_InsState", par);
            
        }
        public int DL_SaveCityMaster(ML_Masters objML_Masters)
        {
            SqlParameter[] par ={new SqlParameter("@cityID",objML_Masters.ID),                                     
                                    new SqlParameter("@CityName",objML_Masters.CityName),    
                                     new SqlParameter("@StateId",objML_Masters.StateName),
                                    new SqlParameter("@CreatedBy",objML_Masters.CreatedBy),
                                    new SqlParameter("@ModifyBy",objML_Masters.ModifyBy),                                    
                                };
            return SqlHelper.ExecuteNonQuery(conn, "OSP_InsUpdCity", par);

        }
        public DataTable DL_BindStateMaster(ML_Masters objML_Masters)
        {
            SqlParameter[] par ={new SqlParameter("@id",objML_Masters.ProjectName),
                                  
                                };
            return SqlHelper.ExecuteDataset(conn, "SPCN_StateMasterProjectWise_Select", par).Tables[0];

        }
        public DataTable DL_BindStateList(ML_Masters objML_Masters)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Masters.ID)
                                };
            return SqlHelper.ExecuteDataset(conn, "SPCN_StateMasterProjectWise_Select", par).Tables[0];
        }
        public DataTable DL_BindCityList(ML_Masters objML_Masters)
        {
            SqlParameter[] par ={new SqlParameter("@ID",objML_Masters.ID)
                                };
            return SqlHelper.ExecuteDataset(conn, "SPCN_City_Select", par).Tables[0];
        }
        public int DL_SaveHotelMaster(ML_Masters objML_Masters)
        {
            SqlParameter[] par ={new SqlParameter("@HotelID",objML_Masters.ID),                                     
                                    new SqlParameter("@HotelName",objML_Masters.Name),
                                    new SqlParameter("@PublishDate",objML_Masters.PublishDate), 
                                     new SqlParameter("@Address",objML_Masters.Address),
                                     new SqlParameter("@State",objML_Masters.State),
                                     new SqlParameter("@City",objML_Masters.City),
                                     new SqlParameter("@Country",objML_Masters.Country),
                                     new SqlParameter("@ZipCode",objML_Masters.ZipCode),
                                     new SqlParameter("@WebSite",objML_Masters.Website),
                                     new SqlParameter("@EmailID",objML_Masters.EmailID),
                                     new SqlParameter("@Phone1",objML_Masters.Phone1),
                                     new SqlParameter("@Phone2",objML_Masters.Phone2),
                                     new SqlParameter("@MobileNo",objML_Masters.MobileNo),
                                     new SqlParameter("@TanNo",objML_Masters.TanNo),
                                     new SqlParameter("@PanNo",objML_Masters.PanNo),
                                     new SqlParameter("@GSTIN",objML_Masters.GSTIN),
                                    new SqlParameter("@CreatedBy",objML_Masters.CreatedBy),
                                    new SqlParameter("@ModifyBy",objML_Masters.ModifyBy),                                    
                                };
            return SqlHelper.ExecuteNonQuery(conn, "SPCN_Insert_Hotel_Master", par);

        }
        public DataTable DL_BindHotelMaster(ML_Masters objML_Masters)
        {
            SqlParameter[] par ={new SqlParameter("@id",objML_Masters.ID),
                                  
                                };
            return SqlHelper.ExecuteDataset(conn, "SPCN_Hotel_Master_Bind", par).Tables[0];

        }
    }
}