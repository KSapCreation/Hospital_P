<%@ Page Title="" Language="C#" MasterPageFile="~/H/Hospital.Master" AutoEventWireup="true" CodeBehind="EmployeeMaster.aspx.cs" Inherits="hotelManagement.H.EmployeeMaster" %>
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
    <link rel="shortcut icon" href="css/Layout/img/logotitle.png">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <% if (blAccess)
       { %>
     
            <form id="form1" runat="server">
           
                        <div class="page-content-wrapper">
                            <div class="page-content">
                                <div class="page-bar">
                                    <ul class="page-breadcrumb">
                                        <li>
                                            <i class="fa fa-home"></i>
                                            <a href="Appointment.aspx">Common Services</a>
                                            <i class="fa fa-angle-right"></i>
                                        </li>
                                        <li>
                                            <a href="#">Employee Master</a>
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
                                                    <i class="fa fa-cogs"></i>Employee's
                                                </div>                                              
                                            </div>
                                            <div class="portlet-body">
                                                <div class="row">
                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                            Employee ID:                          
                                <asp:TextBox ID="txtEmpID" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Employee ID" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                            First Name:                          
                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control placeholder-no-fix" placeholder="First Name" AutoCompleteType="Disabled"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                            Last Name:                          
                                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Last Name" AutoCompleteType="Disabled"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                </div>
                                                 <div class="row">
                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                            Age:                          
                                <asp:TextBox ID="txtAge" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Age" AutoCompleteType="Disabled" MaxLength="2"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                            DOB:                          
                                <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Date of Birth" AutoCompleteType="Disabled" TextMode="Date"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                </div>
                                                 <div class="row">
                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                            Gender:                          
                                <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="0" Text="Select" Enabled="true"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Male"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Female"></asp:ListItem>
                                </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                            Married Status:                          
                               <asp:DropDownList ID="ddlMarried" runat="server" CssClass="form-control">
                                      <asp:ListItem Value="0" Text="Select" Enabled="true"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Single"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Married"></asp:ListItem>
                               </asp:DropDownList>
                                                        </div>
                                                    </div>

                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                            Email ID:                          
                                <asp:TextBox ID="txtEmailID" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Email ID" AutoCompleteType="Disabled"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                            Mobile No:                          
                                <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Mobile No" AutoCompleteType="Disabled" MaxLength="10" ></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                 <div class="row">
                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                            Department:                          
            <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-control"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                            Designation:                          
                                <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="form-control"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                            Country
                                      <asp:TextBox ID="txtCountry" runat="server" CssClass="form-control placeholder-no-fix" Text="India" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                            State                         
                                <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control placeholder-no-fix" OnSelectedIndexChanged="getCity" AutoPostBack="true">
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
                                                            WebSite:                            
                                <asp:TextBox ID="txtWebsite" runat="server" CssClass="form-control placeholder-no-fix" placeholder="WebSite" AutoCompleteType="Disabled"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                 <div class="row">
                                                        <div class="col-sm-12">
                                                        <div class="form-group">
                                                             <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Address" AutoCompleteType="Disabled"></asp:TextBox>
                                                            </div>
                                                            </div>
                                                     </div>
                                                <div class="form-group">
                                                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-info" OnClick="Save" />
                                                    <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-circle" OnClick="Clear" />
                                                </div>
                                            </div>
                                        </div>
                                        <!-- END ALERTS PORTLET-->
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                          <asp:Panel ID="pnl" runat="server" ScrollBars="Auto">
                                        <asp:GridView ID="GrdEmpoyeeMaster" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnPageIndexChanging="GrdEmployeeMaster_PageIndexChanging">
                                                    <Columns>
                                                          <asp:TemplateField HeaderText="SrNo">
                                                            <ItemTemplate>
                                                                      <asp:Label ID="lblLine" runat="server" Text='<%#Eval("RowNo")%>'></asp:Label>                                                                 
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Employee ID">
                                                            <ItemTemplate>
                                                                      <asp:Label ID="lblEmployeeID" runat="server" Text='<%#Eval("EmployeeID")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="First Name">
                                                            <ItemTemplate>
                                                                      <asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("FirstName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                           <asp:TemplateField HeaderText="Last Name">
                                                            <ItemTemplate>
                                                                      <asp:Label ID="lblLastName" runat="server" Text='<%#Eval("LastName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="Email ID">
                                                            <ItemTemplate>
                                                                     <asp:Label ID="lblEmailID" runat="server" Text='<%#Eval("EmailID")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="Mobile No">
                                                            <ItemTemplate>
                                                                     <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("MobileNo")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                      
                                                      <asp:TemplateField HeaderText="Action">
                                                            <ItemTemplate>
                                                                   <asp:LinkButton ID="lnkEdit" runat="server" OnClick="Update"><img src="img/edit.png" alt="" width="20" /></asp:LinkButton>&nbsp;
                                                                   <asp:LinkButton ID="lnkDelete" runat="server" OnClientClick="return confirm('Are you sure you want to delete this record?');" OnClick="Delete"  ><img src="img/delete.png" alt="" width="20" /></asp:LinkButton>
                                                            </ItemTemplate>
                                                       </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView> 
                                            </asp:Panel>
                                    </div>
                                </div>
                            </div>
                        </div>
                   
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
