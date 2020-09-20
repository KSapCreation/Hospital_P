<%@ Page Title="" Language="C#" MasterPageFile="~/H/Hospital.Master" AutoEventWireup="true" CodeBehind="PatientRegisration.aspx.cs" Inherits="Hospital_P.H.PatientRegisration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta content="width=device-width, initial-scale=1" name="viewport"/>
<meta content="" name="description"/>
<meta content="" name="author"/>
<!-- BEGIN GLOBAL MANDATORY STYLES -->
<link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css"/>
<link href="plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
<link href="plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css"/>
<link href="plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
<link href="plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css"/>
<link href="plugins/bootstrap-switch/css/bootstrap-switch.min.css" rel="stylesheet" type="text/css"/>
<!-- END GLOBAL MANDATORY STYLES -->
<!-- BEGIN PAGE LEVEL PLUGIN STYLES -->
<link href="plugins/bootstrap-daterangepicker/daterangepicker-bs3.css" rel="stylesheet" type="text/css"/>
<link href="plugins/fullcalendar/fullcalendar.min.css" rel="stylesheet" type="text/css"/>
<link href="plugins/jqvmap/jqvmap/jqvmap.css" rel="stylesheet" type="text/css"/>

<!-- END PAGE LEVEL PLUGIN STYLES -->
<!-- BEGIN PAGE STYLES -->
<link href="page/tasks.css" rel="stylesheet" type="text/css"/>
<!-- END PAGE STYLES -->
    
<!-- BEGIN THEME STYLES -->
<!-- DOC: To use 'rounded corners' style just load 'components-rounded.css' stylesheet instead of 'components.css' in the below style tag -->
<link href="css/components-rounded.css" id="style_components" rel="stylesheet" type="text/css"/>
<link href="css/plugins.css" rel="stylesheet" type="text/css"/>
<link href="css/layout/css/layout.css" rel="stylesheet" type="text/css"/>
<link href="css/layout/css/theme/darkblue.css" rel="stylesheet" type="text/css" id="style_color"/>
<link href="css/layout/css/custom.css" rel="stylesheet" type="text/css"/>
    <link rel="shortcut icon" href="css/Layout/img/logo.png">
    <script>
        function OnlyNumbers(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode != 46 && charCode > 31
              && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
        function checkEmail(event) {
            var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            if (!re.test(event.value)) {
                alert("Please enter a valid email address");
                return false;
            }
            return true;
        }

        
    </script>  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <% if (blAccess)
       { %>
     <form id="form1" runat="server">
         
                 <div class="page-content-wrapper">
                     <div class="page-content">
                         <div class="page-bar">
                             <ul class="page-breadcrumb">
                                 <li>
                                     <i class="fa fa-home"></i>
                                     <a href="#">Patient Management</a>
                                     <i class="fa fa-angle-right"></i>
                                 </li>
                                 <li>
                                     <a href="#">In Patient</a>
                                 </li>
                             </ul>
                             <div class="page-toolbar">
                                 <div>
                                     <img src="css/Layout/img/logo.png" class="logo-default" />
                                 </div>
                             </div>
                         </div>
                         <div><br /></div>
                         <div class="page-bar">
                             <table style="width:40%;">
                                 <tr>
                                     <td>
                                         Find:
                                     </td>
                                     <td>
<asp:TextBox ID="txtSerach" runat="server" CssClass="form-control placeholder-no-fix" AutoCompleteType="FirstName" ></asp:TextBox>
                                           <asp:HiddenField ID="hfCustomerId" runat="server" />
                                     </td>
                                     <td>
                                         <asp:Button ID="btnSerach" runat="server" CssClass="btn btn-arrow-link" Text=">>>" OnClick="Search" />
                                     </td>
                                 </tr>
                             </table>
                             
                             
                             
                             </div>
                         <!-- END PAGE HEADER-->
                         <div><br /></div>
                         <div class="row">
                             <div class="col-md-12">
                                 <!-- BEGIN ALERTS PORTLET-->
                                 <div class="portlet yellow box">
                                     <div class="portlet-title">
                                         <div class="caption">
                                             <i class="fa fa-cogs"></i>Admission
                                         </div>
                                         <div class="tools">
                                             <a href="javascript:;" class="collapse"></a>
                                             <a href="javascript:;" class="reload"></a>

                                         </div>
                                     </div>
                                     <div class="portlet-body">
                                         <div class="row">
                                             <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>
                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                            Admission No:
                                      <asp:TextBox ID="txtAppNo" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Patient No" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                            Patient Admission Date:                                      
                                <asp:TextBox ID="txtAdmisionDate" runat="server" CssClass="form-control placeholder-no-fix" TextMode="Date" placeholder="dd/mm/yyyy"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                         <div class="row">
                                             <div class="col-sm-6">
                                                 <div class="form-group">
                                                     First Name:
                                      <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control placeholder-no-fix" placeholder="First Name" AutoCompleteType="Disabled"></asp:TextBox>
                                                 </div>
                                             </div>
                                             <div class="col-sm-6">
                                                 <div class="form-group">
                                                     Last Name                                  
                                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Last Name" AutoCompleteType="Disabled"></asp:TextBox>
                                                 </div>
                                             </div>
                                         </div>
                                         <div class="row">
                                             <div class="col-sm-6">
                                                 <div class="form-group">
                                                     Date of Birth:
                                      <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Date of Birth" TextMode="Date"></asp:TextBox>
                                                 </div>
                                             </div>
                                             <div class="col-sm-6">
                                                 <div class="form-group">
                                                     Gender:                            
                                <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control placeholder-no-fix">
                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Male"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Female"></asp:ListItem>
                                </asp:DropDownList>
                                                 </div>
                                             </div>
                                         </div>
                                         <div class="row">
                                             <div class="col-sm-6">
                                                 <div class="form-group">
                                                     Married Status:                         
                                <asp:DropDownList ID="ddlMarried" runat="server" CssClass="form-control placeholder-no-fix">
                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Single"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Married"></asp:ListItem>
                                </asp:DropDownList>
                                                 </div>
                                             </div>
                                              <div class="col-sm-6">
                                                 <div class="form-group">
                                                     Age:                            
                                <asp:TextBox ID="txtAge" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Age" AutoCompleteType="Disabled"></asp:TextBox>
                                                 </div>
                                             </div>
                                            
                                         </div>
                                         <div class="row">
                                             <div class="col-sm-6">
                                                 <div class="form-group">
                                                     Mobile No:
                                      <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Mobile No" MaxLength="10" onkeypress="return OnlyNumbers(event)"></asp:TextBox>
                                                 </div>
                                             </div> <div class="col-sm-6">
                                                 <div class="form-group">
                                                     Phone No:
                                      <asp:TextBox ID="txtPhoneNo" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Phone No" AutoCompleteType="Disabled"></asp:TextBox>
                                                 </div>
                                             </div>
                                             
                                            
                                         </div>
                                         <div class="row">
                                             <div class="col-sm-6">
                                                 <div class="form-group">
                                                     Email ID:                           
                                <asp:TextBox ID="txtEmailID" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Email ID" AutoCompleteType="Disabled" onblur="checkEmail(this)"></asp:TextBox>
                                                 </div>
                                             </div>
                                              <div class="col-sm-6">
                                                 <div class="form-group">
                                                     Madicine Information:                          
                                <asp:TextBox ID="txtMadicineInfo" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Madicine Information" TextMode="MultiLine"></asp:TextBox>
                                                 </div>
                                             </div>
                                         </div>
                                          <div class="row">
                                             <div class="col-sm-6">
                                                 <div class="form-group">
                                                     Bill Type:                           
                               <asp:DropDownList ID="ddlBillType" runat="server" CssClass="form-control placeholder-no-fix">
                                   <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                   <asp:ListItem Value="1" Text="Bill Now"></asp:ListItem>
                                   <asp:ListItem Value="2" Text="Bill Later"></asp:ListItem>
                               </asp:DropDownList>
                                                 </div>
                                             </div>
                                              <div class="col-sm-6">
                                                 <div class="form-group">
                                                     Department:                          
                               <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-control placeholder-no-fix">                                   
                               </asp:DropDownList>
                                                 </div>
                                             </div>
                                         </div>
                                         <div class="row">
                                             <div class="col-sm-6">
                                                 <div class="form-group">
                                                     Hospital Name:                          
                                <asp:TextBox ID="txtHospital" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Hospital Name" AutoCompleteType="Disabled" ReadOnly="true"></asp:TextBox>
                                                 </div>
                                             </div>
                                              <div class="col-sm-6">
                                                 <div class="form-group">
                                                     Doctor:                          
                                <asp:TextBox ID="txtdoctor" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Doctor" AutoCompleteType="Disabled"></asp:TextBox>
                                                 </div>
                                             </div>
                                         </div>
                                          <div class="row">
                                             <div class="col-sm-6">
                                                 <div class="form-group">
                                                     Bed:                          
                                <asp:DropDownList ID="ddlBedType" runat="server" CssClass="form-control placeholder-no-fix">                                  
                                </asp:DropDownList>
                                                 </div>
                                             </div>
                                              <div class="col-sm-6">
                                                 <div class="form-group">
                                                     Ward:                          
                                 <asp:DropDownList ID="ddlWardType" runat="server" CssClass="form-control placeholder-no-fix">                                    
                                </asp:DropDownList>
                                                 </div>
                                             </div>
                                         </div>
                                           <div class="row">
                                              <div class="col-sm-12">
                                                 <div class="form-group">
                                                     Address
                                <asp:TextBox ID="txtaddress" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Address" TextMode="MultiLine"></asp:TextBox>
                                                 </div>
                                             </div>
                                         </div>
                                          <div class="row">
                                             <div class="col-sm-6">
                                                 <div class="form-group">
                                                     State:                          
                                 <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control placeholder-no-fix" AutoPostBack="true" OnSelectedIndexChanged = "getCity">                                    
                                </asp:DropDownList>
                                                 </div>
                                             </div>
                                              <div class="col-sm-6">
                                                 <div class="form-group">
                                                     City:                          
                                <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control placeholder-no-fix">
                                </asp:DropDownList>
                                                 </div>
                                             </div>
                                         </div>
                                         <div class="row">
                                             <div class="col-sm-6">
                                                 <div class="form-group">
                                                     Charges:                          
                                <asp:TextBox ID="txtCharges" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Charges Per Day" AutoCompleteType="Disabled"></asp:TextBox>
                                                 </div>
                                             </div>
                                              <div class="col-sm-6">
                                                 <div class="form-group">
                                                     Complaint:                          
                                <asp:TextBox ID="txtComplaint" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Complaint" AutoCompleteType="Disabled"></asp:TextBox>
                                                 </div>
                                             </div>
                                         </div>
                                         <div class="form-group">
                                             <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-info" OnClick="btnSaved" OnClientClick="return chkvalidation()"/>
                                             <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-circle" OnClick="btnCleared" />
                                         </div>
                                     </div>
                                 </div>
                                 <!-- END ALERTS PORTLET-->
                             </div>
                         </div>
                         <div class="row">
                                    <div class="col-sm-12">
                                        <asp:Panel ID="pnl" runat="server" ScrollBars="Auto">
                                        <asp:GridView ID="GrdPaitent" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnPageIndexChanging="GrdPaitent_PageIndexChanging">
                                                    <Columns>
                                                          <asp:TemplateField HeaderText="SrNo">
                                                            <ItemTemplate>
                                                                      <asp:Label ID="lblLine" runat="server" Text='<%#Eval("RowNo")%>'></asp:Label>
                                                                  
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Paitent No">
                                                            <ItemTemplate>
                                                                      <asp:Label ID="lblPatientID" runat="server" Text='<%#Eval("Patient_ID")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Paitent Name">
                                                            <ItemTemplate>
                                                                      <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Name")%>'></asp:Label>                                                      
                                                            </ItemTemplate>
                                                        </asp:TemplateField>                                                         
                                                           <asp:TemplateField HeaderText="Admission Date">
                                                            <ItemTemplate>
                                                                     <asp:Label ID="lblAdmissionDate" runat="server" Text='<%#Eval("AdmissionDate")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="Ward">
                                                            <ItemTemplate>
                                                                     <asp:Label ID="lblWard" runat="server" Text='<%#Eval("WardName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Bed">
                                                            <ItemTemplate>
                                                                     <asp:Label ID="lblBed" runat="server" Text='<%#Eval("BedName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                       <asp:TemplateField HeaderText="Doctor">
                                                            <ItemTemplate>
                                                                     <asp:Label ID="lblDoctor" runat="server" Text='<%#Eval("Doctor")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Doctor Fees">
                                                            <ItemTemplate>
                                                                     <asp:Label ID="lblCharges" runat="server" Text='<%#Eval("Charges")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                           <asp:TemplateField HeaderText="Action">
                                                            <ItemTemplate>
                                                                     <asp:LinkButton ID="lnkEdit" runat="server" OnClick="Update"><img src="img/edit.png" alt="" width="20" /></asp:LinkButton>&nbsp;
                                                                <asp:LinkButton ID="lnkDelete" runat="server" OnClientClick="return confirm('Are you sure you want to delete this record?');" OnClick="Delete" ><img src="img/delete.png" alt="" width="20" /></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView> 
                                            </asp:Panel>
                                    </div>
                                </div>
                     </div>
                 </div>
               </form>
   
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
            $("[id$=txtSerach]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("Service.asmx/GetPatientDetail") %>',
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
           
    <%} %>
</asp:Content>
