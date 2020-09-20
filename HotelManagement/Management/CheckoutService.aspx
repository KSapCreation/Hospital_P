<%@ Page Title="" Language="C#" MasterPageFile="~/Management/Management.Master" AutoEventWireup="true" CodeBehind="CheckoutService.aspx.cs" Inherits="HotelManagement.Management.CheckoutService" %>
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
        <div class="page-content">
            <div class="container">

                <!-- BEGIN PAGE CONTENT INNER  test purpose only-->
                <div class="row">
                    <div class="col-md-12">
                        
                            <div class="portlet light">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="icon-home"></i>
                                        <span class="caption-subject font-green-sharp bold uppercase">CheckOut Service </span>
                                    </div>
                                    <div class="actions btn-set">
                                        <asp:Button ID="btnReset" runat="server" Text="Clear" class="btn btn-default btn-circle" OnClick="Clear"></asp:Button>
                                        <asp:Button ID="btnSave" class="btn green-haze btn-circle" runat="server" OnClick="Save" Text="Save"></asp:Button>

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
                                                               <h4> Guest Details</h4>
                                                            </div>
                                                        </div>
                                                        <div class="row static-info" id="DivGuestDetail" runat="server" visible="false">
                                                            <div class="col-md-8 name">
                                                                <asp:GridView ID="GrdGuestList" runat="server" CssClass="table table-hover table-bordered table-striped" AutoGenerateColumns="false" AllowPaging="true" PageSize="10">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Mobile No">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblLine" runat="server" Text='<%#Eval("MobileNo")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Email ID">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblRoomName" runat="server" Text='<%#Eval("EmailID")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Basic Amount">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblRoomPrice" runat="server" Text='<%#Eval("RoomPrice")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>                                                                            

                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>		
                                                         <div class="row static-info" id="divCaptionServiceDesk" runat="server" visible="false">
                                                            <div class="col-md-2 name">
                                                               <h4> Service Desk Details</h4>
                                                            </div>
                                                        </div>
                                                        <div class="row static-info" id="DivServiceDesk" runat="server" visible="false">
                                                            <div class="col-md-8 name">
                                                                <asp:GridView ID="GrdServiceDesk" runat="server" CssClass="table table-hover table-bordered table-striped" AutoGenerateColumns="false" AllowPaging="true" PageSize="10">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Mobile No" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblItemID" runat="server" Text='<%#Eval("ItemID")%>'></asp:Label>
                                                                                <asp:Label ID="lblServiceDeskID" runat="server" Text='<%#Eval("ServiceID")%>' Visible="false"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                          <asp:TemplateField HeaderText="SrNo">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblRowNo" runat="server" Text='<%#Eval("RowNo")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Item Name">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblItemName" runat="server" Text='<%#Eval("ItemName")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Category">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblItemType" runat="server" Text='<%#Eval("ItemType")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                          <asp:TemplateField HeaderText="Price">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblItemPrice" runat="server" Text='<%#Eval("ItemPrice")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>		
                                                        <div class="row" id="divTotalCheckOutPrice" runat="server" visible="false">
                                                            <div class="col-md-6">
                                                            </div>
                                                            <div class="col-md-6">
                                                                <div class="well">
                                                                    <div class="row static-info align-reverse">
                                                                        <div class="col-md-6 name">
                                                                            Basic Price:
                                                                        </div>
                                                                        <div class="col-md-5 value">
                                                                            <asp:Label ID="lblRoomPrice1" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row static-info align-reverse">
                                                                        <div class="col-md-6 name">
                                                                            <asp:Label ID="lblTaxName1" runat="server"></asp:Label>
                                                                        </div>
                                                                        <div class="col-md-5 value">
                                                                            <asp:Label ID="lblTaxRate1" runat="server"></asp:Label>
                                                                            <asp:Label ID="Label1" runat="server" Text="(%) Amount:"></asp:Label>
                                                                            <asp:Label ID="lbltaxAmt1" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row static-info align-reverse">
                                                                        <div class="col-md-6 name">
                                                                            <asp:Label ID="lblTaxName2" runat="server"></asp:Label>
                                                                        </div>
                                                                        <div class="col-md-5 value">
                                                                            <asp:Label ID="lblTaxRate2" runat="server"></asp:Label>
                                                                            <asp:Label ID="Label2" runat="server" Text="(%) Amount:"></asp:Label>
                                                                            <asp:Label ID="lbltaxAmt2" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row static-info align-reverse">
                                                                        <div class="col-md-6 name">
                                                                            <asp:Label ID="lblTaxName3" runat="server"></asp:Label>
                                                                        </div>
                                                                        <div class="col-md-5 value">
                                                                            <asp:Label ID="lblTaxRate3" runat="server"></asp:Label>
                                                                            <asp:Label ID="lbltaxAmt3" runat="server"></asp:Label>

                                                                        </div>
                                                                    </div>
                                                                    <div class="row static-info align-reverse">
                                                                        <div class="col-md-6 name">
                                                                            Taxable Amount
                                                                        </div>
                                                                        <div class="col-md-5 value">
                                                                            <asp:Label ID="lbltaxableamt" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row static-info align-reverse">
                                                                        <div class="col-md-6 name">
                                                                            Service Desk Total:
                                                                        </div>
                                                                        <div class="col-md-5 value">
                                                                            <asp:Label ID="lblServiceDeskAmt" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row static-info align-reverse">
                                                                        <div class="col-md-6 name">
                                                                            Total Amount:
                                                                        </div>
                                                                        <div class="col-md-5 value">
                                                                            <asp:Label ID="lblTotalAmount" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row static-info align-reverse">
                                                                        <div class="col-md-6 name">
                                                                            Discount (%):
                                                                        </div>
                                                                        <div class="col-md-5 value">
                                                                            <asp:Label ID="lblDiscountPer" runat="server"></asp:Label><br />
                                                                            Amount:
                                                                            <asp:Label ID="lblDisocuntAmt" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row static-info align-reverse">
                                                                        <div class="col-md-6 name">
                                                                            Grand Total:
                                                                        </div>
                                                                        <div class="col-md-5 value">
                                                                            <asp:Label ID="lblGrandTotal" runat="server"></asp:Label>

                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>					
													</div>
												</div>
											</div>
											
                                         
										</div>
										                                         
								
									</div>
									
								</div>
							</div>
                                                               
						
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
