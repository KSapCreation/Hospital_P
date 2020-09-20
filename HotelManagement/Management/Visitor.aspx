<%@ Page Title="" Language="C#" MasterPageFile="~/Management/Management.Master" AutoEventWireup="true" CodeBehind="Visitor.aspx.cs" Inherits="HotelManagement.Management.Visitor" %>
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
                                        <i class="icon-basket font-green-sharp"></i>
                                        <span class="caption-subject font-green-sharp bold uppercase">Visitor (Check-In) </span>
                                    </div>
                                    <div class="actions btn-set">
                                        <button class="btn btn-default btn-circle "><i class="fa fa-reply"></i>Reset</button>
                                        <asp:button class="btn green-haze btn-circle" runat="server" OnClick="Save" id="btnSave" Text="Save"></asp:button>             

                                    </div>
                                </div>
                                <div class="portlet-body">		
                                    <div class="tab-content">
									<div class="tab-pane active">
										<div class="row">
											<div class="col-md-6 col-sm-12">
												<div class="portlet yellow-crusta box">
													<div class="portlet-title">
														<div class="caption">
															<i class="fa fa-cogs"></i>Guest Information
														</div>													
													</div>
													<div class="portlet-body">
														<div class="row static-info">
                                                            <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>
															<div class="col-md-3 name">
																 Guest Name:
															</div>
															<div class="col-md-3 value">
                                                                <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Value="1" Text="Mr."></asp:ListItem>
                                                                    <asp:ListItem Value="2" Text="Mrs."></asp:ListItem>
                                                                    <asp:ListItem Value="3" Text="Ms."></asp:ListItem>
                                                                </asp:DropDownList>
                                                                </div>
                                                                <div class="col-md-6 value">
															<asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
															</div>
														</div>
														<div class="row static-info">
															<div class="col-md-3 name">
																 Address:
															</div>
															<div class="col-md-9 value">
																 <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
															</div>
														</div>
                                                        <div class="row static-info">
                                                            <div class="col-md-3 name">
																 State:
															</div>
                                                            <div class="col-md-4 value">
                                                                	<asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" OnSelectedIndexChanged="BindCity" AutoPostBack="true">
                                                                        </asp:DropDownList>                                                             
                                                            </div>
                                                            </div>
                                                             <div class="row static-info">
                                                            <div class="col-md-3 name">
																 City:
															</div>
                                                            <div class="col-md-4 value">
                                                              <asp:DropDownList ID="ddlcity" runat="server" CssClass="form-control">
                                                                        </asp:DropDownList>
                                                            </div>
                                                                 </div>
                                                                   <div class="row static-info">
                                                                        <div class="col-md-3 name">
																Zip Code:
															</div>
                                                            <div class="col-md-4 value">
                                                                <asp:TextBox ID="txtZip" runat="server" CssClass="form-control" placeholder="Zip"></asp:TextBox>
                                                            </div>
                                                        </div>
														<div class="row static-info">
															<div class="col-md-3 name">
																 Country:
															</div>
															<div class="col-md-9 value">
																<asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Value="1" Text="India"></asp:ListItem>
																</asp:DropDownList>
															</div>
														</div>													
													</div>
												</div>
											</div>
											<div class="col-md-6 col-sm-12">
												<div class="portlet blue-hoki box">
													<div class="portlet-title">
														<div class="caption">
															<i class="fa fa-cogs"></i>Stay Information
														</div>														
													</div>
													<div class="portlet-body">
														<div class="row static-info">
															<div class="col-md-4 name">
																 Room(s):
															</div>
															<div class="col-md-4 value">
																 <asp:DropDownList ID="ddlRoomlist" runat="server" CssClass="form-control" OnSelectedIndexChanged="BindRoomNo" AutoPostBack="true"></asp:DropDownList>
															</div>
                                                            	<div class="col-md-4 value">
																 <asp:DropDownList ID="ddlRoomNo" runat="server" CssClass="form-control"></asp:DropDownList>
                                                                    <asp:Label ID="lblRoomNo" runat="server" Visible="false"></asp:Label>
															</div>
														</div>
														<div class="row static-info">
															<div class="col-md-4 name">
																 Arrival:
															</div>
															<div class="col-md-4 value">
																 <asp:TextBox ID="txtArrival" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
															</div>
                                                            <div class="col-md-4 value">
																 <asp:TextBox ID="txtArrivalTime" runat="server" TextMode="Time" CssClass="form-control"></asp:TextBox>
															</div>
														</div>
                                                        <div class="row static-info">
															<div class="col-md-4 name">
																 Departure:
															</div>
															<div class="col-md-4 value">
																 <asp:TextBox ID="txtDeparture" runat="server" TextMode="Date" CssClass="form-control" OnTextChanged="CalculateDays" AutoPostBack="true"></asp:TextBox>
															</div>
                                                            <div class="col-md-4 value">
																 <asp:TextBox ID="txtDepartureTime" runat="server" TextMode="Time" CssClass="form-control"></asp:TextBox>
															</div>
														</div>
														<div class="row static-info">
															<div class="col-md-4 name">
																 Day(s):
															</div>
															<div class="col-md-3 value">
																 <asp:TextBox ID="txtDays" runat="server" CssClass="form-control" TextMode="Number" ReadOnly="true"></asp:TextBox>
															</div>
														</div>
														<div class="row static-info">
															<div class="col-md-4 name">
																 Adult:
															</div>
															<div class="col-md-2 value">
															 <asp:DropDownList ID="ddlAdult" runat="server" CssClass="form-control">
                                                                 <asp:ListItem Value="0" Text="0"></asp:ListItem>
                                                                 <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                                                 <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                                                    <asp:ListItem Value="3" Text="3"></asp:ListItem>
															 </asp:DropDownList>
															</div>
                                                            <div class="col-md-2 name">
																 Child:
															</div>
															<div class="col-md-2 value">
																 <asp:DropDownList ID="ddlChild" runat="server" CssClass="form-control">
                                                                 <asp:ListItem Value="0" Text="0"></asp:ListItem>
                                                                 <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                                                 <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                                                 <asp:ListItem Value="3" Text="3"></asp:ListItem>
															 </asp:DropDownList>
															</div>
														</div>
                                                        	<div class="row static-info">
															<div class="col-md-4 name">
																Reservation Type:
															</div>
															<div class="col-md-6 value">
																<asp:DropDownList ID="ddlReservationType" runat="server" CssClass="form-control">
                                                                 <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                 <asp:ListItem Value="1" Text="Confrom Booking"></asp:ListItem>
                                                                 <asp:ListItem Value="2" Text="Hold Confrom Boooking"></asp:ListItem>
                                                                 <asp:ListItem Value="3" Text="Online Failed Booking"></asp:ListItem>
                                                                    <asp:ListItem Value="4" Text="Released"></asp:ListItem>
															 </asp:DropDownList>
															</div>
														</div>
													</div>
												</div>
											</div>
                                         
										</div>
										<div class="row">
                                               <div class="col-md-4 col-sm-12">
												<div class="portlet green-meadow box">
													<div class="portlet-title">
														<div class="caption">
															<i class="fa fa-cogs"></i>Contact Information
														</div>													
													</div>
													<div class="portlet-body">
														<div class="row static-info">
															<div class="col-md-4 name">
																 Email:
															</div>
															<div class="col-md-8 value">
																 <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
															</div>
														</div>
                                                        <div class="row static-info">
															<div class="col-md-4 name">
																 Phone:
															</div>
															<div class="col-md-8 value">
																 <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" TextMode="Phone"></asp:TextBox>
															</div>
														</div>
                                                        <div class="row static-info">
															<div class="col-md-4 name">
																 Mobile No:
															</div>
															<div class="col-md-8 value">
																 <asp:TextBox ID="txtMobileno" runat="server" CssClass="form-control" TextMode="Phone" MaxLength="10"></asp:TextBox>
															</div>
														</div>
                                                        <div class="row static-info">
															<div class="col-md-4 name">
																 Fax:
															</div>
															<div class="col-md-8 value">
																 <asp:TextBox ID="txtFax" runat="server" CssClass="form-control"></asp:TextBox>
															</div>
														</div>
													</div>
												</div>
											</div>
											<div class="col-md-4 col-sm-12">
												<div class="portlet yellow-crusta box">
													<div class="portlet-title">
														<div class="caption">
															<i class="fa fa-cogs"></i>Other Information
														</div>													
													</div>
													<div class="portlet-body" style="height: 194px;">
														<div class="row static-info">
															<div class="col-md-4 name">
																 Identity
															</div>
															<div class="col-md-8 value">
																<asp:DropDownList ID="ddlIdentity" runat="server" CssClass="form-control">
                                                                 <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                 <asp:ListItem Value="1" Text="Aadhar Card"></asp:ListItem>
                                                                 <asp:ListItem Value="2" Text="Driving license"></asp:ListItem>
                                                                 <asp:ListItem Value="3" Text="Passport"></asp:ListItem>                                                          
															 </asp:DropDownList>
															</div>                                                           
														</div>
                                                         <div class="row static-info">
                                                                <div class="col-md-12">
                                                                    <asp:TextBox ID="txtAadharNo" runat="server" TextMode="Number" CssClass="form-control" placeholder="Aadhar Card number"></asp:TextBox>
                                                                </div>
                                                            </div>
														<div class="row static-info">
															<div class="col-md-4 name">
																Gender:
															</div>
															<div class="col-md-8 value">
																 <asp:RadioButtonList ID="rbtnGender" runat="server" RepeatDirection="Horizontal">
                                                                     <asp:ListItem Value="1" Text="Male" Selected="True"></asp:ListItem>
                                                                     <asp:ListItem Value="2" Text="Female"></asp:ListItem>
																 </asp:RadioButtonList>
															</div>
														</div>														
													</div>
												</div>
											</div>
                                            <div class="col-md-4 col-sm-12">
												<div class="portlet blue-hoki box">
													<div class="portlet-title">
														<div class="caption">
															<i class="fa fa-cogs"></i>Billing Information
														</div>														
													</div>
													<div class="portlet-body">
														<div class="row static-info">
															<div class="col-md-4 name">
																 Bill To:
															</div>
															<div class="col-md-8 value">
																 	<asp:DropDownList ID="ddlBillTo" runat="server" CssClass="form-control">
                                                                 <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                 <asp:ListItem Value="1" Text="Company"></asp:ListItem>
                                                                 <asp:ListItem Value="2" Text="Guest"></asp:ListItem>                                                     
															 </asp:DropDownList>
															</div>
														</div>
														<div class="row static-info">
															<div class="col-md-4 name">
																 Payement Mode:
															</div>
															<div class="col-md-4 value">
																 <asp:RadioButtonList ID="rbtnPaymentMode" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table">
                                                                     <asp:ListItem Value="1" Text="Cash" Selected="True"></asp:ListItem>
                                                                     <asp:ListItem Value="2" Text="Credit"></asp:ListItem>
																 </asp:RadioButtonList>
															</div>
                                                            <div class="col-md-4 name">
                                                                <asp:DropDownList ID="ddlPaymentType" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                    <asp:ListItem Value="1" Text="Cash"></asp:ListItem>
                                                                    <asp:ListItem Value="2" Text="Credit Card"></asp:ListItem>
                                                                    <asp:ListItem Value="3" Text="Debit Card"></asp:ListItem>
                                                                </asp:DropDownList>
															</div>
														</div>
														<div class="row static-info">
															<div class="col-md-4 name">
																 Discount(%):
															</div>
															<div class="col-md-8 value">
																   <asp:TextBox ID="txtdescount" runat="server" TextMode="Number" CssClass="form-control" OnTextChanged="txtDiscountCalculate" AutoPostBack="true"></asp:TextBox>
															</div>
                                                           
														</div>
														
													</div>
												</div>
											</div>
                                            </div>
                                          
								<%--		<div class="row">
											<div class="col-md-12 col-sm-12">
												<div class="portlet grey-cascade box">
													<div class="portlet-title">
														<div class="caption">
															<i class="fa fa-cogs"></i>Shopping Cart
														</div>
														<div class="actions">
															<a href="javascript:;" class="btn btn-default btn-sm">
															<i class="fa fa-pencil"></i> Edit </a>
														</div>
													</div>
													<div class="portlet-body">
														<div class="table-responsive">
															<table class="table table-hover table-bordered table-striped">
															<thead>
															<tr>
																<th>
																	 Product
																</th>
																<th>
																	 Item Status
																</th>
																<th>
																	 Original Price
																</th>
																<th>
																	 Price
																</th>
																<th>
																	 Quantity
																</th>
																<th>
																	 Tax Amount
																</th>
																<th>
																	 Tax Percent
																</th>
																<th>
																	 Discount Amount
																</th>
																<th>
																	 Total
																</th>
															</tr>
															</thead>
															<tbody>
															<tr>
																<td>
																	<a href="javascript:;">
																	Product 1 </a>
																</td>
																<td>
																	<span class="label label-sm label-success">
																	Available
																</td>
																<td>
																	 345.50$
																</td>
																<td>
																	 345.50$
																</td>
																<td>
																	 2
																</td>
																<td>
																	 2.00$
																</td>
																<td>
																	 4%
																</td>
																<td>
																	 0.00$
																</td>
																<td>
																	 691.00$
																</td>
															</tr>
															<tr>
																<td>
																	<a href="javascript:;">
																	Product 1 </a>
																</td>
																<td>
																	<span class="label label-sm label-success">
																	Available
																</td>
																<td>
																	 345.50$
																</td>
																<td>
																	 345.50$
																</td>
																<td>
																	 2
																</td>
																<td>
																	 2.00$
																</td>
																<td>
																	 4%
																</td>
																<td>
																	 0.00$
																</td>
																<td>
																	 691.00$
																</td>
															</tr>
															<tr>
																<td>
																	<a href="javascript:;">
																	Product 1 </a>
																</td>
																<td>
																	<span class="label label-sm label-success">
																	Available
																</td>
																<td>
																	 345.50$
																</td>
																<td>
																	 345.50$
																</td>
																<td>
																	 2
																</td>
																<td>
																	 2.00$
																</td>
																<td>
																	 4%
																</td>
																<td>
																	 0.00$
																</td>
																<td>
																	 691.00$
																</td>
															</tr>
															<tr>
																<td>
																	<a href="javascript:;">
																	Product 1 </a>
																</td>
																<td>
																	<span class="label label-sm label-success">
																	Available
																</td>
																<td>
																	 345.50$
																</td>
																<td>
																	 345.50$
																</td>
																<td>
																	 2
																</td>
																<td>
																	 2.00$
																</td>
																<td>
																	 4%
																</td>
																<td>
																	 0.00$
																</td>
																<td>
																	 691.00$
																</td>
															</tr>
															</tbody>
															</table>
														</div>
													</div>
												</div>
											</div>
										</div>
										<div class="row">
											<div class="col-md-6">
											</div>
											<div class="col-md-6">
												<div class="well">
													<div class="row static-info align-reverse">
														<div class="col-md-8 name">
															 Sub Total:
														</div>
														<div class="col-md-3 value">
															 $1,124.50
														</div>
													</div>
													<div class="row static-info align-reverse">
														<div class="col-md-8 name">
															 Shipping:
														</div>
														<div class="col-md-3 value">
															 $40.50
														</div>
													</div>
													<div class="row static-info align-reverse">
														<div class="col-md-8 name">
															 Grand Total:
														</div>
														<div class="col-md-3 value">
															 $1,260.00
														</div>
													</div>
													<div class="row static-info align-reverse">
														<div class="col-md-8 name">
															 Total Paid:
														</div>
														<div class="col-md-3 value">
															 $1,260.00
														</div>
													</div>
													<div class="row static-info align-reverse">
														<div class="col-md-8 name">
															 Total Refunded:
														</div>
														<div class="col-md-3 value">
															 $0.00
														</div>
													</div>
													<div class="row static-info align-reverse">
														<div class="col-md-8 name">
															 Total Due:
														</div>
														<div class="col-md-3 value">
															 $1,124.50
														</div>
													</div>
												</div>
											</div>
										</div>--%>
									</div>
									
								</div>
							</div>
						
                                <div class="row">
                                    <div class="col-md-6">

                                    </div>
                            <div class="col-md-6">
                                <div class="well">
                                    <div class="row">
                                        <div class="row static-info align-reverse">
                                            <div class="col-md-6 name">
                                                 Basic Amount:
                                            </div>
                                            <div class="col-md-5 value">
                                                 <asp:Label ID="lblRoomAmount" runat="server"></asp:Label>
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
                                          Discount(%)
                                            </div>
                                            <div class="col-md-5 value">
                                                 <asp:Label ID="lblDiscount" runat="server"></asp:Label>
                                                <asp:Label ID="Label3" runat="server" Text="(%) Amount:"></asp:Label>
                                            <asp:Label ID="lblDiscountAmt" runat="server"></asp:Label>
                                       
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
                <!-- END PAGE CONTENT INNER -->
            </div>
        </div>
        <!-- END PAGE CONTENT -->
    </form>
</asp:Content>
