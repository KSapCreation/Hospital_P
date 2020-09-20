<%@ Page Title="" Language="C#" MasterPageFile="~/Management/Management.Master" AutoEventWireup="true" CodeBehind="ServiceDeskInvoice.aspx.cs" Inherits="HotelManagement.Management.ServiceDeskInvoice" %>
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
    <script>
        function doPrint() {
            var prtContent = document.getElementById('<%= GrdServiceDesk.ClientID %>');
            prtContent.border = 0; //set no border here
            var WinPrint = window.open('', '', 'left=100,top=100,width=1000,height=1000,toolbar=0,scrollbars=1,status=0,resizable=1');
            WinPrint.document.write(prtContent.outerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
        }
</script>
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
                                        <i class="icon-like"></i>
                                        <span class="caption-subject font-green-sharp bold uppercase">Invoice(s) </span>
                                    </div>
                                    <div class="actions btn-set">                                       
                                         <asp:Button ID="btnPrint" class="btn btn-circle btn-warning" runat="server" Text="Print" OnClientClick="doPrint()"></asp:Button>
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
															<div class="col-md-1 name">
																 From Date:
															</div>														
                                                            <div class="col-md-3 value">
                                                                <asp:TextBox ID="txtfromdate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>                                                                
                                                            </div>
                                                              <div class="col-md-1 name">
                                                               To Date:
                                                            </div>
                                                               <div class="col-md-3 value">
                                                                <asp:TextBox ID="txttodate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>                                                                   
                                                            </div>
                                                             <div class="col-md-1 name">
                                                               Guest Name:
                                                            </div>
                                                            <div class="col-md-3 value">
                                                                <asp:DropDownList ID="ddlGuestName" runat="server" class="chzn-select" Width="100%" ></asp:DropDownList>
                                                            </div>
                                                            		
														</div>
                                                        <div class="actions btn-set">
                                                                <asp:Button ID="btnReset" runat="server" Text="Clear" class="btn btn-default btn-circle" OnClick="Reset"></asp:Button>
                                                                <asp:Button ID="btnSave" class="btn green-haze btn-circle" runat="server" Text="Search" OnClick="Serach"></asp:Button>

                                                            </div>
                                                       
                                                        <h4><asp:Label ID="lblMsg" runat="server"></asp:Label></h4>
                                                        <asp:Panel ID="pnl" runat="server" ScrollBars="Auto">
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
                                                                        <asp:TemplateField HeaderText="Quantity">
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
                                            </asp:Panel>

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
