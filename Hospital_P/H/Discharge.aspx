<%@ Page Title="" Language="C#" MasterPageFile="~/H/Hospital.Master" AutoEventWireup="true" CodeBehind="Discharge.aspx.cs" Inherits="hotelManagement.H.Discharge" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>  
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta content="width=device-width, initial-scale=1" name="viewport"/>
<meta content="" name="description"/>
<meta content="" name="author"/>
<!-- BEGIN GLOBAL MANDATORY STYLES -->
<link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css"/>
<link href="plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
<link href="plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css"/>
<link href="plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
<link href="plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css"/>
<link href="plugins/bootstrap-switch/css/bootstrap-switch.min.css" rel="stylesheet" type="text/css"/>
<!-- END GLOBAL MANDATORY STYLES -->
<!-- BEGIN PAGE LEVEL PLUGIN STYLES -->
<link href="plugins/bootstrap-daterangepicker/daterangepicker-bs3.css" rel="stylesheet" type="text/css"/>
<link href="plugins/fullcalendar/fullcalendar.min.css" rel="stylesheet" type="text/css"/>
<link href="plugins/jqvmap/jqvmap/jqvmap.css" rel="stylesheet" type="text/css"/>

<!-- END PAGE LEVEL PLUGIN STYLES -->
<!-- BEGIN PAGE STYLES -->
<link href="page/tasks.css" rel="stylesheet" type="text/css"/>
<!-- END PAGE STYLES -->
    
<!-- BEGIN THEME STYLES -->
<!-- DOC: To use 'rounded corners' style just load 'components-rounded.css' stylesheet instead of 'components.css' in the below style tag -->
<link href="css/components-rounded.css" id="style_components" rel="stylesheet" type="text/css"/>
<link href="css/plugins.css" rel="stylesheet" type="text/css"/>
<link href="css/layout/css/layout.css" rel="stylesheet" type="text/css"/>
<link href="css/layout/css/theme/darkblue.css" rel="stylesheet" type="text/css" id="style_color"/>
<link href="css/layout/css/custom.css" rel="stylesheet" type="text/css"/>
    <link rel="shortcut icon" href="css/Layout/img/logo.png">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <% if (blAccess)
       { %>
     
            <form id="form1" runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="page-content-wrapper">
                            <div class="page-content">
                                <div class="page-bar">
                                    <ul class="page-breadcrumb">
                                        <li>
                                            <i class="fa fa-home"></i>
                                            <a href="Appointment.aspx">Patient Management</a>
                                            <i class="fa fa-angle-right"></i>
                                        </li>
                                 <li>
                                     <a href="#">Discharge</a>
                                 </li>

                                    </ul>
                                    <div class="page-toolbar">
                                        <div>
                                            <img src="css/Layout/img/logo.png" class="logo-default" />
                                        </div>
                                    </div>
                                </div>
                                 <div><br /></div>
                         <div class="page-bar">
                             <table style="width:auto">
                                 <tr>
                                     <td>
                                         Patient Name:
                                     </td>
                                     <td>
<asp:TextBox ID="txtSerach" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Enter Patient Name"></asp:TextBox>
                                          <asp:AutoCompleteExtender ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                                                CompletionInterval="10" EnableCaching="false" CompletionSetCount="1" TargetControlID="txtSerach"
                                                ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">
                                            </asp:AutoCompleteExtender>  
                                     </td>
                                     <td>
                                         <asp:Button ID="btnSerach" runat="server" CssClass="btn btn-arrow-link" Text=">>>" OnClick="Search" />
                                     </td>
                                 </tr>
                             </table>                                                          
                             </div>
                                <div><br /></div>
                                <!-- END PAGE HEADER-->
                                <div class="row">
                                    <div class="col-md-12">
                                        <!-- BEGIN ALERTS PORTLET-->
                                        <div class="portlet yellow box">
                                            <div class="portlet-title">
                                                <div class="caption">
                                                    <i class="fa fa-cogs"></i>Patient Discharge
                                                </div>
                                                <div class="tools">
                                                    <a href="javascript:;" class="collapse"></a>
                                                    <a href="javascript:;" class="reload"></a>

                                                </div>
                                            </div>
                                            <div class="portlet-body">
                                                <div class="well well-lg">
                                                    <div class="row">
                                                        <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                Patient No:&nbsp;&nbsp;
                                      <asp:Label ID="lblPatientNo" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                Name: &nbsp;&nbsp;                                      
                                <asp:Label ID="lblName" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                Age/Gender: &nbsp;&nbsp;                                     
                                <asp:Label ID="lblAge" runat="server"></asp:Label>/<asp:Label ID="lblgender" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                                                              
                                                    <div class="row">
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                Appointment No:&nbsp;&nbsp;
                                      <asp:Label ID="lblApp" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                Department: &nbsp;&nbsp;                                      
                                <asp:Label ID="lblDep" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                Doctor: &nbsp;&nbsp;                                     
                                <asp:Label ID="lblDoctor" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                Addmission Date:&nbsp;&nbsp;
                                      <asp:Label ID="lblAddmissionDate" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                Ref Hospital: &nbsp;&nbsp;                                      
                                <asp:Label ID="RefBy" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                Ward/bed: &nbsp;&nbsp;                                     
                                <asp:Label ID="lblWardBed" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                 </div>
                                                <!-- patient Discharge status -->
                                                <div><b>Patient Discharge Status</b></div>
                                                <div class="well well-lg">
                                                    <div class="row">
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                Initiate Discharge 
                                                                <h1 style="margin-left: 40px;border-style: groove;border-radius: 100px;margin-right: 220px;padding-left: 10px;BORDER-COLOR: #0f8fde;COLOR: WHITE;BACKGROUND-COLOR: #1da1f2;">1</h1>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                Clinical Discharge                                       
                                                                <h1 style="margin-left: 40px;border-style: groove;border-radius: 100px;margin-right: 220px;padding-left: 10px;BORDER-COLOR: #0f8fde;COLOR: WHITE;BACKGROUND-COLOR: #1da1f2;">2</h1>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-4">
                                                            <div class="form-group">
                                                                Physical Discharge                                    
                                                                <h1 style="margin-left: 40px;border-style: groove;border-radius: 100px;margin-right: 220px;padding-left: 10px;BORDER-COLOR: #0f8fde;COLOR: WHITE;BACKGROUND-COLOR: #1da1f2;">3</h1>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!-- Initiate Discharge  -->
                                                <div><b>Initiate Discharge</b></div>
                                                <div class="well well-lg">
                                                    <div class="row">
                                                        <div class="col-sm-3">
                                                            <div class="form-group">
                                                                Initiate Discharge:
                                      <asp:CheckBox ID="CHKInitiateDischarge" runat="server" CssClass="form-control placeholder-no-fix" />
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <div class="form-group">
                                                                Expected Discharge Date:                                       
                                <asp:TextBox ID="txtDischageDate" runat="server" TextMode="Date" CssClass="form-control placeholder-no-fix"></asp:TextBox>

                                                            </div>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <div class="form-group">
                                                                Expected Discharge Time:                                      
                                <asp:TextBox ID="txtDischageTime" runat="server" TextMode="Time" CssClass="form-control placeholder-no-fix"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <div class="form-group">
                                                                Discharging Doctor :                                      
                                <asp:TextBox ID="txtDischageDoctor" runat="server" CssClass="form-control placeholder-no-fix"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-12">
                                                            <div class="form-group">
                                                                Initiate Discharge Remarks :                                      
                                <asp:TextBox ID="txtInitiateDischargeRemarks" runat="server" CssClass="form-control placeholder-no-fix" TextMode="MultiLine"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <asp:Button ID="btnInitiateSave" runat="server" Text="Save" CssClass="btn btn-info" />

                                                    </div>
                                                </div>
                                               <!-- Clinical Discharge  -->
                                                <div><b>Clinical Discharge</b></div>
                                                <div class="well well-lg">
                                                    <div class="row">
                                                        <div class="col-sm-3">
                                                            <div class="form-group">
                                                                Clinical Discharge:
                                      <asp:CheckBox ID="chkClinicaDischarge" runat="server" CssClass="form-control placeholder-no-fix" />
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-9">
                                                            <div class="form-group">
                                                                Clinical Discharge Remarks:                                       
                                <asp:TextBox ID="txtClinicalDischargeRemarks" runat="server" CssClass="form-control placeholder-no-fix" TextMode="MultiLine"></asp:TextBox>

                                                            </div>
                                                        </div>                                                       
                                                    </div>
                                                     <div class="form-group">
                                                            <asp:Button ID="btnClinicalDischarge" runat="server" Text="Save" CssClass="btn btn-info" Enabled="false" />

                                                        </div>
                                                    </div>
                                                   <!-- Physical Discharge  -->
                                                <div><b>Physical Discharge</b></div>
                                                <div class="well well-lg">
                                                    <div class="form-group" style="margin-left:90%;">
                                                        <asp:Button ID="btnFinalDischarge" runat="server" Text="Discharge" CssClass="btn btn-info" Enabled="false" />
                                                    </div>
                                                    </div>
                                            </div>
                                        </div>
                                        <!-- END ALERTS PORTLET-->
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel> 
            </form>
       <script src="plugins/jquery.min.js" type="text/javascript"></script>
<script src="plugins/jquery-migrate.min.js" type="text/javascript"></script>
<script src="plugins/jquery-ui/jquery-ui.min.js" type="text/javascript"></script>
<script src="plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
<script src="plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js" type="text/javascript"></script>
<script src="plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
<script src="plugins/jquery.blockui.min.js" type="text/javascript"></script>
<script src="plugins/jquery.cokie.min.js" type="text/javascript"></script>
<script src="plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>
<script src="plugins/bootstrap-switch/js/bootstrap-switch.min.js" type="text/javascript"></script>
<!-- END CORE PLUGINS -->
<!-- BEGIN PAGE LEVEL PLUGINS -->
<script src="plugins/jqvmap/jqvmap/jquery.vmap.js" type="text/javascript"></script>
<script src="plugins/jqvmap/jqvmap/maps/jquery.vmap.russia.js" type="text/javascript"></script>
<script src="plugins/jqvmap/jqvmap/maps/jquery.vmap.world.js" type="text/javascript"></script>
<script src="plugins/jqvmap/jqvmap/maps/jquery.vmap.europe.js" type="text/javascript"></script>
<script src="plugins/jqvmap/jqvmap/maps/jquery.vmap.germany.js" type="text/javascript"></script>
<script src="plugins/jqvmap/jqvmap/maps/jquery.vmap.usa.js" type="text/javascript"></script>
<script src="plugins/jqvmap/jqvmap/data/jquery.vmap.sampledata.js" type="text/javascript"></script>
<script src="plugins/flot/jquery.flot.min.js" type="text/javascript"></script>
<script src="plugins/flot/jquery.flot.resize.min.js" type="text/javascript"></script>
<script src="plugins/flot/jquery.flot.categories.min.js" type="text/javascript"></script>
<script src="plugins/jquery.pulsate.min.js" type="text/javascript"></script>
<script src="plugins/bootstrap-daterangepicker/moment.min.js" type="text/javascript"></script>
<script src="plugins/bootstrap-daterangepicker/daterangepicker.js" type="text/javascript"></script>+
    <script src="plugins/fullcalendar/fullcalendar.min.js" type="text/javascript"></script>
<script src="plugins/jquery-easypiechart/jquery.easypiechart.min.js" type="text/javascript"></script>
<script src="plugins/jquery.sparkline.min.js" type="text/javascript"></script>
<!-- BEGIN PAGE LEVEL SCRIPTS -->
<script src="css/layout/scripts/metronic.js" type="text/javascript"></script>
<script src="css/layout/scripts/layout.js" type="text/javascript"></script>
<script src="css/layout/scripts/quick-sidebar.js" type="text/javascript"></script>
<script src="css/layout/scripts/demo.js" type="text/javascript"></script>
<script src="css/page/scripts/index.js" type="text/javascript"></script>
<script src="css/page/scripts/tasks.js" type="text/javascript"></script>
                                   
    <%} %>
</asp:Content>
