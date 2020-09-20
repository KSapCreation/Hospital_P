﻿<%@ Page Title="" Language="C#" MasterPageFile="~/H/Hospital.Master" AutoEventWireup="true" CodeBehind="ParameterValues.aspx.cs" Inherits="hotelManagement.H.ParameterValues" %>
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
                            <a href="#">Laboratory Management</a>
                            <i class="fa fa-angle-right"></i>
                        </li>
                        <li>Master<i class="fa fa-angle-right"></i></li>
                        <li>
                            <a href="ParameterValues.aspx">Test Parameter Values</a>
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
                                    <i class="fa fa-cogs"></i>Test Parameter Result
                                </div>
                                <div class="tools">
                                    <a href="javascript:;" class="collapse"></a>
                                    <a href="javascript:;" class="reload"></a>

                                </div>
                            </div>
                            <div class="portlet-body">
                                <div class="row">
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                          PV Code (Parameter Values)
                                     <asp:TextBox ID="txtPVCode" runat="server" CssClass="form-control placeholder-no-fix"></asp:TextBox>                                            <asp:Label ID="Label1" runat="server" CssClass="form-control placeholder-no-fix" Visible="false"></asp:Label>                                       
                                         
                                        </div>

                                    </div> 
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                          Test Name
                                     <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control placeholder-no-fix"></asp:TextBox>                                            <asp:Label ID="lblTestID" runat="server" CssClass="form-control placeholder-no-fix" Visible="false"></asp:Label>                                       
                                           <asp:HiddenField ID="hfCustomerId" runat="server" />
                                        </div>

                                    </div>  
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                            <span> <br /> </span>
                                          <asp:Button ID="btnSerach" runat="server" CssClass="btn btn-arrow-link" Text=">>>" OnClick="Search" />
                                        </div>

                                    </div>                                
                                </div>    
                                  <div class="row">
                                    <div class="col-sm-12">
                                         <div class="form-group">
                                          Patient Name
                                        <asp:TextBox ID="txtPatientName" runat="server"  CssClass="form-control placeholder-no-fix"></asp:TextBox>
                                            
                                        </div>
                                        </div>
                                </div> 
                                <div class="row">
                                    <div class="col-sm-12">
                                        <h4>Parameters Name</h4>
                                        <asp:Panel ID="pnl" runat="server" ScrollBars="Auto">
                                        <asp:DataList ID="DlParametervalues" runat="server" RepeatColumns="3">
                                            <ItemTemplate>
                                                <table class="table table-striped table-bordered table-hover">
                                                    <tr>
                                                        <td>
                                                           <asp:Label ID="lblParameterID" runat="server" Text='<%#Eval("ParameterID")%>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lblParameterName" runat="server" Text='<%#Eval("ParameterName")%>' Visible="true"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtParameterValues" runat="server" CssClass="form-control" Text='<%#Eval("ParameterValues")%>'></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:DataList>
                                            </asp:Panel>

                                    </div>
                                </div>                                 

                                <div class="form-group">
                                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-info" Visible="false" OnClick="Save" />
                                    <asp:Button ID="btnCleared" runat="server" Text="Clear" CssClass="btn btn-circle" Visible="false" OnClick="btnClear"  />
                                </div>
                            </div>
                        </div>
                        <!-- END ALERTS PORTLET-->
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

           <link href="../Content/themes/base/jquery-ui.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            $("[id$=txtUserName]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("Service.asmx/GetTestList") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=hfCustomerId]").val(i.item.val);
                },
                minLength: 1
            });
        });
    </script>

        <!--  Patinet Name list --->
         <link href="../Content/themes/base/jquery-ui.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            $("[id$=txtPVCode]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("Service.asmx/GetParameterValues") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    
                },
                minLength: 1
            });
        });
    </script>

    </form>
</asp:Content>
