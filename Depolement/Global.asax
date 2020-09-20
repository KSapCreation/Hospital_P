<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>
<script runat="server">
    void Application_Start(object sender, EventArgs e) 
    {
        RegisterRoutes(RouteTable.Routes);
    }
    
    static void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("DashBoard", "H/DashBoard", "~/H/index.aspx");
        routes.MapPageRoute("Hospital", "h/Hospital", "~/h/HospitalMaster.aspx");
        routes.MapPageRoute("User", "h/User", "~/h/UserM.aspx");
        routes.MapPageRoute("City", "h/City", "~/h/CistyMaster.aspx");
        routes.MapPageRoute("State", "h/Industry", "~/h/StateMaster.aspx");
        routes.MapPageRoute("Ward", "h/Ward", "~/h/Ward.aspx");
        routes.MapPageRoute("Bed", "h/Bed", "~/h/BedSystem.aspx");
        routes.MapPageRoute("Department", "h/Department", "~/h/Department.aspx");
        routes.MapPageRoute("Appointment", "h/Appointment", "~/h/Appointment.aspx");
        routes.MapPageRoute("PatientRegisration", "h/PatientRegisration", "~/h/PatientRegisration.aspx");
        routes.MapPageRoute("Discharge", "h/Discharge", "~/h/Discharge.aspx");
        routes.MapPageRoute("ADT", "h/ADT", "~/h/ADT.aspx");
        routes.MapPageRoute("TokenFile", "h/TokenFile", "~/h/Token.aspx");
        routes.MapPageRoute("TokanAvailability", "h/TokanAvailability", "~/h/TokanComplete.aspx");
        routes.MapPageRoute("CreateTest", "h/CreateTest", "~/h/TestMaster.aspx");
        routes.MapPageRoute("Parameter", "h/Parameter", "~/h/ParameterMaster.aspx");
        routes.MapPageRoute("Mapped", "h/Mapped", "~/h/Mapping.aspx");
        routes.MapPageRoute("LaboratoryEntry", "h/LaboratoryEntry", "~/h/LaboratoryEntry.aspx");
        routes.MapPageRoute("LaboratoryValues", "h/LaboratoryValues", "~/h/ParameterValues.aspx");
        routes.MapPageRoute("LabReport", "h/LabReport", "~/h/LabReport.aspx");
        routes.MapPageRoute("Customer", "h/Customer", "~/h/CustomerMaster.aspx");
        routes.MapPageRoute("Vendor", "h/Vendor", "~/h/VendorMaster.aspx");
        routes.MapPageRoute("Items", "h/Items", "~/h/ItemMaster.aspx");
        routes.MapPageRoute("Units", "h/Units", "~/h/UnitMaster.aspx");
        routes.MapPageRoute("UserRights", "h/UserRights", "~/h/Permissions.aspx");
        routes.MapPageRoute("Utility", "h/Utility", "~/h/Settings.aspx");
        routes.MapPageRoute("CPassword", "h/CPassword", "~/h/ChangePasssword.aspx");
        routes.MapPageRoute("EM", "h/EM", "~/h/EmployeeMaster.aspx");
        routes.MapPageRoute("StoreItem", "h/StoreItem", "~/h/StoreItem.aspx");
        routes.MapPageRoute("Designation", "h/Designation", "~/h/DesignationMaster.aspx");
        routes.MapPageRoute("ProfileDashBoard", "UserDashBoard/ProfileDashBoard", "~/UserDashBoard/UserIndex.aspx");
        routes.MapPageRoute("KeyActivation", "h/KeyActivation", "~/h/ProductKey.aspx");   
          
    }
</script>

