<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>
<script runat="server">
    void Application_Start(object sender, EventArgs e) 
    {
        RegisterRoutes(RouteTable.Routes);
    }
    
    static void RegisterRoutes(RouteCollection routes)
    {         
        routes.MapPageRoute("HotelDashboard", "Management/HotelDashboard", "~/Management/Dashboard.aspx");
        routes.MapPageRoute("Visitors", "Management/Visitors", "~/Management/Visitor.aspx");
        routes.MapPageRoute("Rooms", "Management/Rooms", "~/Management/RoomMaster.aspx");
        routes.MapPageRoute("StateCity", "Management/StateCity", "~/Management/StateCityMaster.aspx");
        routes.MapPageRoute("Items", "Management/Items", "~/Management/ItemMaster.aspx");
        routes.MapPageRoute("Service", "Management/Service", "~/Management/ServiceDesk.aspx");
        routes.MapPageRoute("Reservation", "Management/Reservation", "~/Management/ReservationList.aspx");
        routes.MapPageRoute("ServiceCheckOut", "Management/ServiceCheckOut", "~/Management/CheckOutService.aspx");
        routes.MapPageRoute("SignOut", "Management/SignOut", "~/Management/SignOut.aspx");
        routes.MapPageRoute("CheckOutList", "Management/CheckOutList", "~/Management/Departure.aspx");
        routes.MapPageRoute("HotelDescription", "Management/HotelDescription", "~/Management/HotelMaster.aspx");
        routes.MapPageRoute("GSTInformation", "Management/GSTInformation", "~/Management/TaxMaster.aspx");
        routes.MapPageRoute("GSTInformationGroup", "Management/GSTInformationGroup", "~/Management/TaxGroupMaster.aspx");
        routes.MapPageRoute("ServiceInvoice", "Management/ServiceInvoice", "~/Management/ServiceDeskinvoice.aspx");
        routes.MapPageRoute("CheckOutInvoice", "Management/CheckOutInvoice", "~/Management/CheckOutInvoice.aspx");
    }
</script>

