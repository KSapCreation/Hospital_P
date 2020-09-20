<%@ Page Title="" Language="C#" MasterPageFile="~/Management/Management.Master" AutoEventWireup="true" CodeBehind="ReservationList.aspx.cs" Inherits="HotelManagement.Management.ReservationList" %>
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
    <form runat="server" id="form1">
        <div class="page-content">
            <div class="container">

                <!-- BEGIN PAGE CONTENT INNER -->
                <div class="row">
                    <div class="col-md-12">
                        
                            <div class="portlet light">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="icon-home"></i>
                                        <span class="caption-subject font-green-sharp bold uppercase">Reservation List </span>
                                    </div>                                
                                </div>
                                

                                <asp:Panel ID="pnl" runat="server" ScrollBars="Auto">
                                        <asp:GridView ID="GrdReservationList" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" AllowPaging="true" PageSize="10">
                                                    <Columns>
                                                          <asp:TemplateField HeaderText="SrNo">
                                                            <ItemTemplate>
                                                                      <asp:Label ID="lblLine" runat="server" Text='<%#Eval("RowNo")%>'></asp:Label>                                                                                                     <asp:Label ID="lblProgramsID" runat="server" Text='<%#Eval("VisitorID")%>' Visible="false"></asp:Label>     
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Guest Name">
                                                            <ItemTemplate>
                                                                      <asp:Label ID="lblGuest" runat="server" Text='<%#Eval("GuestName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                       
                                                          <asp:TemplateField HeaderText="Email ID">
                                                            <ItemTemplate>
                                                                     <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("EmailID")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="Mobile No">
                                                            <ItemTemplate>
                                                                      <asp:Label ID="lblMobileNo" runat="server" Text='<%#Eval("MobileNo")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="Address">
                                                            <ItemTemplate>
                                                                      <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>                                                        
                                                             <asp:TemplateField HeaderText="Room No" ItemStyle-Width="30">
                                                            <ItemTemplate>
                                                                      <asp:Label ID="lblRoomNo" runat="server" Text='<%#Eval("RoomNo")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="Arrival Date">
                                                            <ItemTemplate>
                                                                      <asp:Label ID="lblArrival" runat="server" Text='<%#Eval("ArrivalDate")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="Departure Date">
                                                            <ItemTemplate>
                                                                      <asp:Label ID="lblDeparture" runat="server" Text='<%#Eval("DepartureDate")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="No of Guest" ItemStyle-Width="30">
                                                            <ItemTemplate>
                                                                      <asp:Label ID="lblAdults" runat="server" Text='<%#Eval("Adults")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="Room Price">
                                                            <ItemTemplate>
                                                                   <asp:Label ID="lblRoomPrice" runat="server" Text='<%#Eval("RoomPrice")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="Status" ItemStyle-Width="80">
                                                            <ItemTemplate>
                                                                   <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>                                                         
                                                         <asp:TemplateField HeaderText="Action">
                                                            <ItemTemplate>
                                                                  <asp:LinkButton ID="lnkEdit" runat="server">
                                                                      <img src="admin/layout3/img/edit.png" width="20" />
                                                                  </asp:LinkButton>                                                              
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
    </form>
</asp:Content>
