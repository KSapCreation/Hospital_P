<%@ Page Language="C#" MasterPageFile="~/H/Hospital.Master" AutoEventWireup="true" CodeBehind="HospitalMaster.aspx.cs" Inherits="Hospital_P.H.M.HospitalMaster" %>
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
                                            <a href="Appointment.aspx">Hospital Master</a>
                                        </li>

                                    </ul>
                                    <div class="page-toolbar">
                                        <div>
                                             <img src="css/Layout/img/logo.png" class="logo-default" />
                                        </div>
                                    </div>
                                </div>
                                <!-- END PAGE HEADER-->
                                <div class="row">
                                    <div class="col-md-12">
                                        <!-- BEGIN ALERTS PORTLET-->
                                        <div class="portlet yellow box">
                                            <div class="portlet-title">
                                                <div class="caption">
                                                    <i class="fa fa-cogs"></i>Hospital Master
                                                </div>
                                                <div class="tools">
                                                    <a href="javascript:;" class="collapse"></a>
                                                    <a href="javascript:;" class="reload"></a>

                                                </div>
                                            </div>
                                            <div class="portlet-body">
                                                <div class="row">
                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                            Hospital No:
                                      <asp:TextBox ID="txtHospitalNo" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Hospital No" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                            Create Date                                        
                                <asp:TextBox ID="txtDate" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Appointment Date" TextMode="Date"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                            Hospital Name:
                                      <asp:TextBox ID="txtHospitalName" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Hospital Name" AutoCompleteType="Disabled"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    
                                                     <div class="col-sm-6">
                                                        <div class="form-group">
                                                            State                         
                                <asp:DropDownList ID="ddState" runat="server" CssClass="form-control placeholder-no-fix"  AutoPostBack = "true" OnSelectedIndexChanged = "getCity">
                                   
                                </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                   
                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                            City                         
                                <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control placeholder-no-fix">
                                </asp:DropDownList>
                                                        </div>
                                                    </div>

                                                     <div class="col-sm-6">
                                                        <div class="form-group">
                                                            Address
                                      <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Address" MaxLength="5" TextMode="MultiLine"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                </div>


                                                <div class="row">
                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                            Hospital Website:
                                      <asp:TextBox ID="txtWebsite" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Hospital website"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                            Hospital Type                         
                                                            <asp:DropDownList ID="ddHospitalType" runat="server" CssClass="form-control placeholder-no-fix">
                                                            <asp:ListItem>Private</asp:ListItem>
                                                            <asp:ListItem>Gov</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                         <br/>
                                      <asp:CheckBox ID="checkHMS" runat="server" Text="Is HMS"></asp:CheckBox>
                                                        </div>
                                                    </div>
                                               
                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                            Product Name:
                                      <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Product Name"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                     </div>
                                                   
                                               <div class="form-group">
                                                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-info" OnClick="btnSaved" />
                                                   <asp:Button  ID="btnClears" runat="server" Text="Clear" CssClass="btn btn-circle" OnClick="btnClear"/>
                                               </div>

                                            </div>
                                        </div>
                                        <!-- END ALERTS PORTLET-->
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:Panel ID="pnl" runat="server" ScrollBars="Auto">
                                        <asp:GridView ID="GrdHospital" runat="server" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnPageIndexChanging="GrdHospital_PageIndexChanging">
                                                    <Columns>
                                                         <asp:TemplateField HeaderText="Hospital Name">
                                                            <ItemTemplate>
                                                                      <asp:Label ID="lblAccountType" runat="server" Text='<%#Eval("HospitalName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Hospital Type">
                                                            <ItemTemplate>
                                                                      <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("HospitalType")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="Hospital Website">
                                                            <ItemTemplate>
                                                                     <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("HospitalWebsite")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="City">
                                                            <ItemTemplate>
                                                                     <asp:Label ID="lblAdmissionDate" runat="server" Text='<%#Eval("City")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="State">
                                                            <ItemTemplate>
                                                                     <asp:Label ID="lblDoctor" runat="server" Text='<%#Eval("State")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                    </Columns>
                                                </asp:GridView> 
                                            </asp:Panel>
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
</asp:Content>

