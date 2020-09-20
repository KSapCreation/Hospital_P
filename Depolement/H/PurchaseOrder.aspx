<%@ Page Title="" Language="C#" MasterPageFile="~/H/Hospital.Master" AutoEventWireup="true" CodeBehind="PurchaseOrder.aspx.cs" Inherits="Hospital_P.H.PurchaseOrder" %>
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
                                            <a href="Appointment.aspx">Pharmacy Management</a>
                                            <i class="fa fa-angle-right"></i>
                                        </li>
                                 <li>
                                     <a href="#">Purchase Order</a>
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
                             <table style="width:auto;">
                                 <tr>
                                     <td>
                                         Find:
                                     </td>
                                     <td>
                                        <asp:TextBox ID="txtSerach" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Enter Purchase Order ID" ></asp:TextBox>
                                          <asp:AutoCompleteExtender ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                                                CompletionInterval="10" EnableCaching="false" CompletionSetCount="1" TargetControlID="txtSerach"
                                                ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">
                                            </asp:AutoCompleteExtender>   
                                     </td>
                                     <td>
                                         <asp:Button ID="btnSerach" runat="server" CssClass="btn btn-arrow-link" Text=">>>" />
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
                                                    <i class="fa fa-cogs"></i>Purchase Order
                                                </div>
                                                <div class="tools">
                                                    <a href="javascript:;" class="collapse"></a>
                                                    <a href="javascript:;" class="reload"></a>

                                                </div>
                                            </div>
                                            <div class="portlet-body">
                                                 <div class="col-sm-12">
                                                        <div class="panel panel-default" style="border:0px solid transparent;">
                                                            <div id="Tabs" role="tabpanel">
                                                                <!-- Nav tabs -->
                                                                <ul class="nav nav-tabs" role="tablist">
                                                                    <li class="active"><a href="#personal" aria-controls="personal" role="tab" data-toggle="tab">Purchase Order</a></li>
                                                                    <li><a href="#employment" aria-controls="employment" role="tab" data-toggle="tab">Taxes</a></li>
                                                                </ul>
                                                                <!-- Tab panes -->
                                                                <div class="tab-content" style="padding-top: 10px">
                                                                    <div role="tabpanel" class="tab-pane active" id="personal">
                                                                        <div class="row">
                                                                            <div class="col-sm-6">
                                                                                <div class="form-group">
                                                                                    Purchase Order ID:                          
                                <asp:TextBox ID="txtBedID" runat="server" CssClass="form-control placeholder-no-fix" placeholder="PO ID" ReadOnly="true"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-sm-6">
                                                                                <div class="form-group">
                                                                                    Purchase Order Date:                          
                                <asp:TextBox ID="txtdate" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Date" TextMode="Date"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="row">
                                                                            <div class="col-sm-6">
                                                                                <div class="form-group">
                                                                                    Description:                          
                                <asp:TextBox ID="txtDesc" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Description"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-sm-6">
                                                                                <div class="form-group">
                                                                                    Department:                          
                                <asp:TextBox ID="txtDepartment" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Department"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="row">
                                                                            <div class="col-sm-6">
                                                                                <div class="form-group">
                                                                                    Vendor Name:                          
                                <asp:TextBox ID="txtVendorName" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Vendor Name" AutoCompleteType="Disabled"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-sm-6">
                                                                                <div class="form-group">
                                                                                    Location:                          
                                <asp:TextBox ID="txtLocation" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Location" AutoCompleteType="Disabled"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="row">
                                                                            <div class="col-sm-6">
                                                                                <div class="form-group">
                                                                                    Mode of Transport:                          
                                <asp:DropDownList ID="DdlModeofTransport" runat="server" CssClass="form-control placeholder-no-fix">
                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="By Road"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="By Air"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="By Train"></asp:ListItem>
                                </asp:DropDownList>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-sm-6">
                                                                                <div class="form-group">
                                                                                    PO Type:                          
                                <asp:DropDownList ID="ddlPOType" runat="server" CssClass="form-control placeholder-no-fix">
                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Domestic"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Import"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="Job Work"></asp:ListItem>
                                </asp:DropDownList>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="row">
                                                                            <asp:Panel ID="pnlgrid" runat="server" ScrollBars="Auto">
                                                                                <asp:GridView ID="GrdPurchaseItem" runat="server" CssClass="table table-hover" ShowFooter="true" AutoGenerateColumns="false">
                                                                                    <Columns>
                                                                                        <asp:BoundField DataField="RowNumber" HeaderText="Row" />
                                                                                        <asp:TemplateField HeaderText="Item Code">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox ID="txtItemCode" runat="server" CssClass="form-control placeholder-no-fix" Width="100px"></asp:TextBox>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Description">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox ID="txtItemName" runat="server" CssClass="form-control placeholder-no-fix" ReadOnly="true" Width="200px"></asp:TextBox>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="HSN Code">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox ID="txtHsnCode" runat="server" CssClass="form-control placeholder-no-fix"></asp:TextBox>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="PO Qty">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox ID="txtPOQty" runat="server" CssClass="form-control placeholder-no-fix"></asp:TextBox>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="UOM">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox ID="txtUOM" runat="server" CssClass="form-control placeholder-no-fix"></asp:TextBox>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="UOM Desc">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox ID="txtUOMDesc" runat="server" CssClass="form-control placeholder-no-fix" ReadOnly="true"></asp:TextBox>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Remarks">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control placeholder-no-fix"></asp:TextBox>
                                                                                            </ItemTemplate>
                                                                                            <FooterStyle HorizontalAlign="Right" />
                                                                                            <FooterTemplate>
                                                                                                <asp:LinkButton ID="lnkAdd" runat="server" OnClick="AddNew">
                                                                            <img src="img/add.png" width="20" /></asp:LinkButton>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </asp:Panel>
                                                                        </div>
                                                                    </div>
                                                                    <div role="tabpanel" class="tab-pane" id="employment">
                                                                        This is Taxes Tab
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                              
                                                </div>

                                                <div class="form-group">
                                                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-info" />
                                                    <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-circle" />
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
                    
</asp:Content>
