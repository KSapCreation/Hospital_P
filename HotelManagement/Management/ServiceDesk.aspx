<%@ Page Title="" Language="C#" MasterPageFile="~/Management/Management.Master" AutoEventWireup="true" CodeBehind="ServiceDesk.aspx.cs" Inherits="HotelManagement.Management.ServiceDesk" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta content="width=device-width, initial-scale=1" name="viewport">
<meta content="" name="description">
<meta content="" name="author">
<!-- BEGIN GLOBAL MANDATORY STYLES -->
<link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css">
<link href="global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
<link href="global/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css">
<link href="global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css">
<link href="global/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css">
<!-- END GLOBAL MANDATORY STYLES -->
<!-- BEGIN PAGE LEVEL PLUGIN STYLES -->
<link href="global/plugins/jqvmap/jqvmap/jqvmap.css" rel="stylesheet" type="text/css">
<link href="global/plugins/morris/morris.css" rel="stylesheet" type="text/css">
<!-- END PAGE LEVEL PLUGIN STYLES -->
<!-- BEGIN PAGE STYLES -->
    
<link href="admin/pages/css/tasks.css" rel="stylesheet" type="text/css"/>
<!-- END PAGE STYLES -->
<!-- BEGIN THEME STYLES -->
<!-- DOC: To use 'rounded corners' style just load 'components-rounded.css' stylesheet instead of 'components.css' in the below style tag -->
<link href="global/css/components-rounded.css" id="style_components" rel="stylesheet" type="text/css">
<link href="global/css/plugins.css" rel="stylesheet" type="text/css">
<link href="admin/layout3/css/layout.css" rel="stylesheet" type="text/css">
<link href="admin/layout3/css/themes/default.css" rel="stylesheet" type="text/css" id="style_color">
<link href="admin/layout3/css/custom.css" rel="stylesheet" type="text/css">
<!-- END THEME STYLES -->
<link rel="shortcut icon" href="favicon.ico">
     <style>
        a img{border: none;}
        ol li{list-style: decimal outside;}
        div#container{width: 780px;margin: 0 auto;padding: 1em 0;}
        div.side-by-side{width: 100%;margin-bottom: 1em;}
        div.side-by-side > div{float: left;width: 50%;}
        div.side-by-side > div > em{margin-bottom: 10px;display: block;}
        .clearfix:after{content: "\0020";display: block;height: 0;clear: both;overflow: hidden;visibility: hidden;}
        
    </style>
    <link rel="stylesheet" href="css/chosen.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <form runat="server" id="form1">
        <asp:ScriptManager id="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="page-content">
            <div class="container">

                <!-- BEGIN PAGE CONTENT INNER -->
                <div class="row">
                    <div class="col-md-12">
                      
                                <div class="portlet light">
                                    <div class="portlet-title">
                                        <div class="caption">
                                            <i class="icon-home"></i>
                                            <span class="caption-subject font-green-sharp bold uppercase">Room Service </span>
                                        </div>
                                        <div class="actions btn-set">
                                            <asp:Button ID="btnReset" runat="server" Text="Clear" class="btn btn-default btn-circle" OnClick="Reset"></asp:Button>
                                            <asp:Button ID="btnSave" class="btn green-haze btn-circle" runat="server" Text="Save" OnClick="Save"></asp:Button>

                                        </div>
                                    </div>
                                    <div class="portlet-body">
                                        <div class="tab-content">
                                            <div class="tab-pane active">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12">
                                                        <div class="portlet green-meadow box">
                                                            <div class="portlet-title">
                                                                <div class="caption">
                                                                    <i class="fa fa-cogs"></i>Detail
                                                                </div>
                                                            </div>
                                                            <div class="portlet-body">
                                                                <div class="row static-info">
                                                                    <div class="col-md-2 name">
                                                                        Guest Name:
                                                                    </div>
                                                                    <div class="col-md-3 value">
                                                                        <asp:DropDownList ID="ddlGuestName" runat="server" class="chzn-select" Width="100%" OnSelectedIndexChanged="SelectGuestDetail" AutoPostBack="true"></asp:DropDownList>
                                                                        <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>
                                                                    </div>
                                                                    <div class="col-md-2 name">
                                                                        Room Number
                                                                    </div>
                                                                    <div class="col-md-5 value">
                                                                        <asp:TextBox ID="txtRoomNo" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>

                                                                    </div>
                                                                </div>
                                                                <div class="row static-info">
                                                                    <div class="col-md-2 name">
                                                                        Item Name:
                                                                    </div>
                                                                    <div class="col-md-3 value">
                                                                        <asp:DropDownList ID="ddlItemList" runat="server" class="chzn-select" Width="100%"></asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-md-2 name">
                                                                        Category:
                                                                    </div>
                                                                    <div class="col-md-5 value">
                                                                        <asp:DropDownList ID="ddlItemType" runat="server" class="form-control" OnSelectedIndexChanged="SelectItemPriceList" AutoPostBack="true">
                                                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                            <asp:ListItem Value="1" Text="Full"></asp:ListItem>
                                                                            <asp:ListItem Value="2" Text="Half"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="row static-info">
                                                                    <div class="col-md-2 name">
                                                                        Item Price:
                                                                    </div>
                                                                    <div class="col-md-3 value">
                                                                        <asp:TextBox ID="txtItemPrice" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                                    </div>

                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>


                                                </div>


                                            </div>

                                        </div>
                                    </div>

                                    <asp:Panel ID="pnl" runat="server" ScrollBars="Auto">
                                        <asp:GridView ID="GrdRoomList" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" AllowPaging="true" PageSize="10">
                                            <Columns>
                                                <asp:TemplateField HeaderText="SrNo">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLine" runat="server" Text='<%#Eval("RowNo")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Room Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRoomName" runat="server" Text='<%#Eval("RoomName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Room No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRoomNo" runat="server" Text='<%#Eval("RoomNo")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Room Price">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRoomPrice" runat="server" Text='<%#Eval("RoomPrice")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Active">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIs_Active" runat="server" Text='<%#Eval("Status")%>' CssClass="label label-success"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>

                                </div>

                        
                        
                    </div>
                </div>
                <!-- END PAGE CONTENT INNER -->
            </div>
        </div>
        <!-- END PAGE CONTENT -->
        
      <script src="Script/jquery.min.js" type="text/javascript"></script>
        <script src="Script/chosen.jquery.js" type="text/javascript"></script>
        <script type="text/javascript"> $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>
    </form>
</asp:Content>
