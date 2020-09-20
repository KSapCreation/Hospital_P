<%@ Page Title="" Language="C#" MasterPageFile="~/Management/Management.Master" AutoEventWireup="true" CodeBehind="HotelMaster.aspx.cs" Inherits="HotelManagement.Management.HotelMaster" %>
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
                                        <i class="icon-home font-green-sharp"></i>
                                        <span class="caption-subject font-green-sharp bold uppercase">Hotel Master </span>
                                    </div>
                                    <div class="actions btn-set">
                                        <asp:button class="btn btn-default btn-circle " id="btnReset" runat="server" onclick="Reset" text="Reset"></asp:button>
                                        <asp:button class="btn green-haze btn-circle" runat="server" id="btnSave" Text="Save" OnClick="Save"></asp:button>                                       

                                    </div>
                                </div>
                                <div class="portlet-body">		
                                    <div class="tab-content">
									<div class="tab-pane active">
										<div class="row">
											<div class="col-md-12 col-sm-12">
												<div class="portlet yellow-crusta box">
													<div class="portlet-title">
														<div class="caption">
															<i class="fa fa-cogs"></i>Basic Information
														</div>													
													</div>
													<div class="portlet-body">												
														<div class="row static-info">
															<div class="col-md-2 name">
																 Hotel Name:
															</div>
															<div class="col-md-4 value">
																 <asp:TextBox ID="txtHotelName" runat="server" CssClass="form-control"></asp:TextBox>
															</div>
                                                            <div class="col-md-2 name">
																 Publish Date:
															</div>
                                                            <div class="col-md-4 value">
																 <asp:TextBox ID="txtHotelCreatedDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
															</div>
														</div>
                                                         <div class="row static-info">
                                                              <div class="col-md-2 name">
																 Complete Address:
															</div>
                                                            <div class="col-md-10 value">
																 <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
															</div>
                                                             </div>
                                                        <div class="row static-info">
                                                            <div class="col-md-3 value">
                                                                	<asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" OnSelectedIndexChanged="BindCity" AutoPostBack="true">
                                                                        </asp:DropDownList>                                                             
                                                            </div>
                                                            <div class="col-md-3 value">
                                                              <asp:DropDownList ID="ddlcity" runat="server" CssClass="form-control">
                                                                        </asp:DropDownList>
                                                            </div>
                                                            <div class="col-md-3 value">
                                                                <asp:TextBox ID="txtZip" runat="server" CssClass="form-control" placeholder="Zip"></asp:TextBox>
                                                            </div>
                                                              <div class="col-md-3 value">
                                                                  <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Value="1" Text="India"></asp:ListItem>
																</asp:DropDownList>
                                                                  </div>
                                                            	
                                                        </div>
														<div class="row static-info">
															<div class="col-md-2 name">
																 WebSite:
															</div>
															<div class="col-md-4 value">
															 <asp:TextBox ID="txtWebSite" runat="server" CssClass="form-control" placeholder="WebSite"></asp:TextBox>
															</div>
                                                            <div class="col-md-2 name">
																 Email ID:
															</div>
															<div class="col-md-4 value">
															 <asp:TextBox ID="txtEmailID" runat="server" CssClass="form-control" placeholder="Email ID"></asp:TextBox>
															</div>
														</div>		
                                                        		<div class="row static-info">
															<div class="col-md-2 name">
																 Phone 1:
															</div>
															<div class="col-md-4 value">
															 <asp:TextBox ID="txtPhone1" runat="server" CssClass="form-control" placeholder="Phone 1" TextMode="Phone"></asp:TextBox>
															</div>
                                                            <div class="col-md-2 name">
																 Phone 2:
															</div>
															<div class="col-md-4 value">
															 <asp:TextBox ID="txtPhone2" runat="server" CssClass="form-control" placeholder="Phone 1" TextMode="Phone"></asp:TextBox>
															</div>
														</div>		
                                                        <div class="row static-info">
															<div class="col-md-2 name">
																 Mobile No:
															</div>
															<div class="col-md-4 value">
															 <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" placeholder="Mobile No" MaxLength="10"></asp:TextBox>
															</div>
                                                            <div class="col-md-2 name">
																 Tan No:
															</div>
															<div class="col-md-4 value">
															 <asp:TextBox ID="txtTanNo" runat="server" CssClass="form-control" placeholder="Tan No"></asp:TextBox>
															</div>
														</div>	
                                                        	   <div class="row static-info">
															<div class="col-md-2 name">
																 Pan No:
															</div>
															<div class="col-md-4 value">
															 <asp:TextBox ID="txtPanNo" runat="server" CssClass="form-control" placeholder="Pan No"></asp:TextBox>
															</div>
                                                            <div class="col-md-2 name">
																 GSTIN No:
															</div>
															<div class="col-md-4 value">
															 <asp:TextBox ID="txtGSTIN" runat="server" CssClass="form-control" placeholder="GSTIN"></asp:TextBox>
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
                                        <asp:GridView ID="GrdHotelList" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" AllowPaging="true" PageSize="10">
                                                    <Columns>
                                                          <asp:TemplateField HeaderText="SrNo">
                                                            <ItemTemplate>
                                                                      <asp:Label ID="lblLine" runat="server" Text='<%#Eval("RowNo")%>'></asp:Label>                                                                                                     <asp:Label ID="lblProgramsID" runat="server" Text='<%#Eval("HotelID")%>' Visible="false"></asp:Label>     
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Hotel Name">
                                                            <ItemTemplate>
                                                                      <asp:Label ID="lblGuest" runat="server" Text='<%#Eval("HotelName")%>'></asp:Label>
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
                                                             <asp:TemplateField HeaderText="GSTIN No" ItemStyle-Width="30">
                                                            <ItemTemplate>
                                                                      <asp:Label ID="lblRoomNo" runat="server" Text='<%#Eval("GSTIN")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="WebSite">
                                                            <ItemTemplate>
                                                                      <asp:Label ID="lblArrival" runat="server" Text='<%#Eval("WebSite")%>'></asp:Label>
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
