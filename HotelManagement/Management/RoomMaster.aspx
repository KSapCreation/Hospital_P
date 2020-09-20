<%@ Page Title="" Language="C#" MasterPageFile="~/Management/Management.Master" AutoEventWireup="true" CodeBehind="RoomMaster.aspx.cs" Inherits="HotelManagement.Management.RoomMaster" %>
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
    <link href="css/DropDownClass.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/chosen.css" />
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
                                        <span class="caption-subject font-green-sharp bold uppercase">Room Master </span>
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
																 Room Name:
															</div>														
                                                            <div class="col-md-3 value">
                                                                <asp:TextBox ID="txtRoomName" runat="server" CssClass="form-control" required=""></asp:TextBox>
                                                                 <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>
                                                            </div>
                                                              <div class="col-md-2 name">
                                                               Room Number
                                                            </div>
                                                               <div class="col-md-5 value">
                                                                <asp:TextBox ID="txtRoomNo" runat="server" CssClass="form-control" required=""></asp:TextBox>
                                                                   <asp:Label ID="lblNo" runat="server" Text="Room Number enter in Commas"></asp:Label>
                                                            </div>
														</div>
                                                        <div class="row static-info">
                                                            <div class="col-md-2 name">
																 Room Basic Price:
															</div>														
                                                            <div class="col-md-3 value">
                                                                <asp:TextBox ID="txtRoomPrice" runat="server" CssClass="form-control" TextMode="Number" required=""></asp:TextBox>
                                                            </div>
                                                            <div class="col-md-2 name">
																 Active:
															</div>														
                                                            <div class="col-md-3 value">
                                                                <asp:CheckBox ID="chkActive" runat="server"  CssClass="form-control" required="" />
                                                            </div>
                                                            </div>
																  <div class="row static-info">
                                                            <div class="col-md-2 name">
																 Tax Group:
															</div>														
                                                            <div class="col-md-3 value">
                                                                <asp:DropDownList ID="ddlTaxGroup" runat="server" class="chzn-select" Width="100%"></asp:DropDownList>
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
                                        <asp:GridView ID="GrdRoomList" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnPageIndexChanging="GrdRoomList_PageIndexChanging">
                                                    <Columns>
                                                          <asp:TemplateField HeaderText="SrNo">
                                                            <ItemTemplate>
                                                                      <asp:Label ID="lblLine" runat="server" Text='<%#Eval("RowNo")%>'></asp:Label>                                                                                                     <asp:Label ID="lblProgramsID" runat="server" Text='<%#Eval("RoomID")%>' Visible="false"></asp:Label>     
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Room Name">
                                                            <ItemTemplate>
                                                                      <asp:Label ID="lblRoomName" runat="server" Text='<%#Eval("RoomName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                       <%--  <asp:TemplateField HeaderText="Room No">
                                                            <ItemTemplate>
                                                                      <asp:Label ID="lblRoomNo" runat="server" Text='<%#Eval("RoomNo")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                          <asp:TemplateField HeaderText="Room Price">
                                                            <ItemTemplate>
                                                                     <asp:Label ID="lblRoomPrice" runat="server" Text='<%#Eval("RoomPrice")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="Active">
                                                            <ItemTemplate>
                                                                     <asp:Label ID="lblIs_Active" runat="server" Text='<%#Eval("Status")%>' cssclass="label label-success"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Action">
                                                            <ItemTemplate>
                                                                  <asp:LinkButton ID="lnkEdit" runat="server" OnClick="Update">
                                                                      <img src="admin/layout3/img/edit.png" width="20" />
                                                                  </asp:LinkButton>
                                                                  <asp:LinkButton ID="lnkDelete" runat="server" OnClientClick="return confirm('Are you sure you want to delete this record?');" OnClick="Delete">
                                                                      <img src="admin/layout3/img/Delete.png" width="20" />
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
          <script src="Script/jquery.min.js" type="text/javascript"></script>
        <script src="Script/chosen.jquery.js" type="text/javascript"></script>
        <script type="text/javascript"> $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>
    </form>
</asp:Content>
