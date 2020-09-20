﻿<%@ Page Title="" Language="C#" MasterPageFile="~/H/Hospital.Master" AutoEventWireup="true" CodeBehind="ItemMaster.aspx.cs" Inherits="Hospital_P.H.ItemMaster" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta content="width=device-width, initial-scale=1" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />
    <link href="plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css" />
    <link href="plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css" />
    <link href="plugins/bootstrap-switch/css/bootstrap-switch.min.css" rel="stylesheet" type="text/css" />
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL PLUGIN STYLES -->
    <link href="plugins/bootstrap-daterangepicker/daterangepicker-bs3.css" rel="stylesheet" type="text/css" />
    <link href="plugins/fullcalendar/fullcalendar.min.css" rel="stylesheet" type="text/css" />
    <link href="plugins/jqvmap/jqvmap/jqvmap.css" rel="stylesheet" type="text/css" />

    <!-- END PAGE LEVEL PLUGIN STYLES -->
    <!-- BEGIN PAGE STYLES -->
    <link href="page/tasks.css" rel="stylesheet" type="text/css" />
    <!-- END PAGE STYLES -->

    <!-- BEGIN THEME STYLES -->
    <!-- DOC: To use 'rounded corners' style just load 'components-rounded.css' stylesheet instead of 'components.css' in the below style tag -->
    <link href="css/components-rounded.css" id="style_components" rel="stylesheet" type="text/css" />
    <link href="css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="css/layout/css/layout.css" rel="stylesheet" type="text/css" />
    <link href="css/layout/css/theme/darkblue.css" rel="stylesheet" type="text/css" id="style_color" />
    <link href="css/layout/css/custom.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="css/Layout/img/logo.png" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form2" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods = "true">    
    </asp:ScriptManager>  
   
        <div class="page-content-wrapper">
            <div class="page-content">
                <div class="page-bar">
                    <ul class="page-breadcrumb">
                        <li>
                            <i class="fa fa-home"></i>
                            <a href="#">Pharmacy Management</a>
                            <i class="fa fa-angle-right"></i>
                        </li>
                        <li>
                            Master
                            <i class="fa fa-angle-right"></i>
                        </li>
                        <li>
                            <a href="#">Item Master</a>
                        </li>
                    </ul>
                    <div class="page-toolbar">
                        <div>
                            <img src="css/Layout/img/logo.png" class="logo-default" />
                        </div>
                    </div>
                </div>
                 <div class="page-bar">
                             <table style="width:40%;">
                                 <tr>
                                     <td>
                                         Find:
                                     </td>
                                     <td>
<asp:TextBox ID="txtSerach" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Enter Item Name" ></asp:TextBox>
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
                                
                <!-- END PAGE HEADER-->
                <div class="row">
                    <div class="col-md-12">
                        <!-- BEGIN ALERTS PORTLET-->
                        <div class="portlet yellow box">
                            <div class="portlet-title">
                                <div class="caption">
                                    <i class="fa fa-cogs"></i>Item Master
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
                                            Item Code
                                      <asp:TextBox ID="txtItemCode" runat="server" CssClass="form-control placeholder-no-fix" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            Item Name
                                      <asp:TextBox ID="txtItemName" runat="server" CssClass="form-control placeholder-no-fix"></asp:TextBox>
                                        </div>
                                    </div>
                                    
                                </div>    
                                 <div class="row">
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            Sale Account
                                      <asp:TextBox ID="txtSaleAccount" runat="server" CssClass="form-control placeholder-no-fix"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            Purchase Account
                                      <asp:TextBox ID="txtPurchaseAcount" runat="server" CssClass="form-control placeholder-no-fix"></asp:TextBox>
                                        </div>
                                    </div>
                                    
                                </div>
                                 <div class="row">
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            Item Cost
                                      <asp:TextBox ID="txtCost" runat="server" CssClass="form-control placeholder-no-fix"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            MRP
                                      <asp:TextBox ID="txtMRP" runat="server" CssClass="form-control placeholder-no-fix"></asp:TextBox>
                                        </div>
                                    </div>
                                    
                                </div>  
                                 <div class="row">
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            HSN Code
                                      <asp:TextBox ID="txtHSN" runat="server" CssClass="form-control placeholder-no-fix"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="col-sm-6">
                                         <div class="form-group">
                                             UOM
                                     <asp:DropDownList ID="ddlUnit" runat="server" CssClass="form-control"></asp:DropDownList>
                                         </div>
                                     </div>
                                    
                                </div>    
                                <div class="row">
                                    <div class="col-sm-6">
                                         <div class="form-group">
                                             Active
                                     <asp:CheckBox ID="chkActive" runat="server" CssClass="form-control" />
                                         </div>
                                     </div>
                                </div>                                                                                   

                                <div class="form-group">
                                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-info" OnClick="Save" />
                                    <asp:Button ID="btnCleared" runat="server" Text="Clear" CssClass="btn btn-circle" OnClick="Cancel" />
                                </div>
                            </div>
                        </div>
                        <!-- END ALERTS PORTLET-->
                    </div>
                </div>
                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:GridView ID="GrdItemList" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnPageIndexChanging="GrdItemList_PageIndexChanging">
                                                    <Columns>
                                                          <asp:TemplateField HeaderText="SrNo">
                                                            <ItemTemplate>
                                                                      <asp:Label ID="lblLine" runat="server" Text='<%#Eval("RowNo")%>'></asp:Label>
                                                                  
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Item Name">
                                                            <ItemTemplate>
                                                                      <asp:Label ID="lblAccountType" runat="server" Text='<%#Eval("ItemName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Sales Account">
                                                            <ItemTemplate>
                                                                      <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("SaleAccount")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="Purchase Account">
                                                            <ItemTemplate>
                                                                     <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("PurchaseAccount")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="HSN Code">
                                                            <ItemTemplate>
                                                                     <asp:Label ID="lblAdmissionDate" runat="server" Text='<%#Eval("HSNCode")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="UOM">
                                                            <ItemTemplate>
                                                                     <asp:Label ID="lblDoctor" runat="server" Text='<%#Eval("UOM")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="MRP">
                                                            <ItemTemplate>
                                                                     <asp:Label ID="lblAdmissionDate" runat="server" Text='<%#Eval("MRP")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView> 
                                    </div>
                                </div>
            </div>
        </div>
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
    </form>
</asp:Content>
