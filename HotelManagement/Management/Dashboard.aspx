<%@ Page Title="" Language="C#" MasterPageFile="~/Management/Management.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="HotelManagement.Management.Dashboard" %>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- BEGIN PAGE CONTAINER -->
    <form id="form1" runat="server">
           <asp:ScriptManager ID="ScriptManager1" runat="server" />
<div class="page-container">
	<!-- BEGIN PAGE HEAD -->
	<div class="page-head">
		<div class="container">
			<!-- BEGIN PAGE TITLE -->
			<div class="page-title">
				<h1>Dashboard </h1>
			</div>
			<!-- END PAGE TITLE -->
			
		</div>
	</div>
	<!-- END PAGE HEAD -->
	<!-- BEGIN PAGE CONTENT -->
	<div class="page-content">
		<div class="container">		
			<!-- BEGIN PAGE CONTENT INNER -->
			<div class="row margin-top-10">
                	<%--<div class="col-md-4 col-sm-4">
					<!-- BEGIN PORTLET-->
					<div class="portlet light ">
						<div class="portlet-title">
							<div class="caption caption-md">
								<i class="icon-bar-chart theme-font hide"></i>
								<span class="caption-subject theme-font bold uppercase">Visitor List</span>								
							</div>
                              				
						</div>
						<div class="portlet-body">
							<div class="row list-separated">
								<asp:UpdatePanel ID="updatepanel2" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Panel ID="pnl" runat="server" ScrollBars="Auto">
                                        <asp:DataList ID="dlGuestList" runat="server" CssClass="table table-responsive" AutoGenerateColumns="false" AllowPaging="true" RepeatDirection="Horizontal" RepeatColumns="2">
                                            <ItemTemplate>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <asp:Label ID="lblGuestName" runat="server" CssClass="label label-success" Text='<%#Eval("GuestName")%>'></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        Mobile No-
                                                        <asp:Label ID="lblMobileNo" runat="server" Text='<%#Eval("MobileNo")%>'></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        Room No-
                                                        <asp:Label ID="lblRomNo" runat="server" CssClass="label label-danger" Text='<%#Eval("RoomNo")%>'></asp:Label>
                                                    </div>
                                                </div>

                                            </ItemTemplate>
                                        </asp:DataList>
                                    </asp:Panel>
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
							</div>
						
						</div>
					</div>
					<!-- END PORTLET-->
				</div>--%>
				<div class="col-md-12 col-sm-12">
					<!-- BEGIN PORTLET-->
					<div class="portlet light ">
						<div class="portlet-title">
							<div class="caption caption-md">
								<i class="icon-bar-chart theme-font hide"></i>
								<span class="caption-subject theme-font bold uppercase">Hotel Room Status</span>								
							</div>
                               <div class="actions btn-set">
                                   <img src="admin/layout3/img/Green.png" />
                                   Empty &nbsp;
                                   
                                    <img src="admin/layout3/img/Red.png" />
                                   Reserved &nbsp;
                                   
                                    <img src="admin/layout3/img/Black.png" />
                                   Maintenance
                                    </div>							
						</div>
						<div class="portlet-body">
                            <div class="row">
                                <div class="col-sm-12">
                                    <asp:UpdatePanel ID="updatepanel1" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:Panel ID="pnl" runat="server" ScrollBars="Auto">
                                                <asp:DataList ID="dlRoomStatus" runat="server" CssClass="table table-responsive" AutoGenerateColumns="false" AllowPaging="true" RepeatDirection="Horizontal" RepeatColumns="6" OnItemDataBound="dlBooking_ItemDataBound">
                                                    <ItemTemplate>
                                                        <div class="row">
                                                            <div class="col-sm-12">
                                                                <asp:Label ID="lblVisitorID" runat="server" Text='<%#Eval("VisitorID")%>' Visible="false"></asp:Label>
                                                              <h6 class="text-justify"><asp:Label ID="Label1" runat="server" CssClass="form-control" Text='<%#Eval("RoomName")%>' Style="text-align: center;"></asp:Label></h6>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-sm-12">
                                                                <asp:LinkButton ID="lnkRoomNo" runat="server" OnClick="ViewVisitorDetail">
                                                                    <asp:Label ID="lblRoomNo" runat="server" CssClass="form-control" Text='<%#Eval("RoomNo")%>' Style="text-align: center; color: white;"></asp:Label>
                                                                </asp:LinkButton>

                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-sm-12">
                                                          <h5><asp:Label ID="Label2" runat="server" CssClass="form-control" Text='<%#Eval("GuestName")%>' Style="text-align: center;"></asp:Label></h5>
                                                            </div>
                                                        </div>


                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </asp:Panel>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
						
						</div>
					</div>
					<!-- END PORTLET-->
				</div>
				
			</div>
			
			<!-- END PAGE CONTENT INNER -->
		</div>
		
	</div>
	<!-- END PAGE CONTENT -->
</div>
<!-- END PAGE CONTAINER -->
    </form>
</asp:Content>
