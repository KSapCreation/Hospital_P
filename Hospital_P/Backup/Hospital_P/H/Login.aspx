<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Hospital_P.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="utf-8"/>
<title>:: Login ::</title>
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta content="width=device-width, initial-scale=1.0" name="viewport"/>
<meta http-equiv="Content-type" content="text/html; charset=utf-8">
<meta content="" name="description"/>
<meta content="" name="author"/>
<!-- BEGIN GLOBAL MANDATORY STYLES -->
<link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css"/>
<link href="plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
<link href="plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css"/>
<link href="plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
<link href="plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css"/>
<!-- END GLOBAL MANDATORY STYLES -->
<!-- BEGIN PAGE LEVEL STYLES -->
<link href="plugins/select2/select2.css" rel="stylesheet" type="text/css"/>
    <link href="css/Page/login2.css" rel="stylesheet" type="text/css" />
<!-- END PAGE LEVEL SCRIPTS -->
    
<!-- BEGIN THEME STYLES -->
<link href="css/login/components.css" id="style_components" rel="stylesheet" type="text/css"/>
<link href="css/login/plugins.css" rel="stylesheet" type="text/css"/>
<link href="css/login/layout.css" rel="stylesheet" type="text/css"/>
<link id="style_color" href="css/login/darkblue.css" rel="stylesheet" type="text/css"/>
<link href="css/login/custom.css" rel="stylesheet" type="text/css"/>
<!-- END THEME STYLES -->
<link rel="shortcut icon" href="css/Layout/img/K.ico">
</head>
<body class="login" style="background-image:url('img/Login/login_bg.png'); background-repeat:no-repeat;">
    <form id="form1" runat="server">
<!-- BEGIN SIDEBAR TOGGLER BUTTON -->
<div class="menu-toggler sidebar-toggler">
    
</div>
<!-- END SIDEBAR TOGGLER BUTTON -->
<!-- BEGIN LOGO -->
<div class="logo">
	<a href="#">
	<img src="css/Layout/img/Logo.png" alt=""/>
	</a>
</div>
<!-- END LOGO -->
<!-- BEGIN LOGIN -->
<div class="content">
	<!-- BEGIN LOGIN FORM -->
    <div id="UserLoginDiv" runat="server" visible="true">
        <div class="form-title">
            <span class="form-title">Welcome.</span>
            <span class="form-subtitle">Please login.</span>
        </div>
        <%--<div class="alert alert-danger display-hide">
			<button class="close" data-close="alert"></button>
			<span>
			Enter any username and password. </span>
		</div>--%>
        <div class="form-group">
            <!--ie8, ie9 does not support html5 placeholder, so we just show field title for that-->
            <label class="control-label visible-ie8 visible-ie9">Username</label>
            <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control form-control-solid placeholder-no-fix" placeholder="Username" AutoCompleteType="Disabled"></asp:TextBox>
        </div>
        <div class="form-group">
            <label class="control-label visible-ie8 visible-ie9 visible-chrome">Password</label>
            <asp:TextBox ID="txtpassword" runat="server" CssClass="form-control form-control-solid placeholder-no-fix" placeholder="Password" TextMode="Password"></asp:TextBox>
        </div>
        <div class="form-actions">
            <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary btn-block uppercase" Text="Login" OnClick="btnSave" />
        </div>
        <div class="form-actions">
            <div class="pull-right forget-password-block">
                <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                <asp:LinkButton ID="lnkForget" runat="server" CssClass="forget-password" OnClick="lnkForgotPassword"> Forgot Password</asp:LinkButton>
            </div>
        </div>
    </div>		

	<!-- END LOGIN FORM -->
	<!-- BEGIN FORGOT PASSWORD FORM -->
	<div id="ForgetPwdDiv" runat="server" visible="false">
		<div class="form-title">
			<span class="form-title">Forget Password ?</span>
			<span class="form-subtitle">Enter your e-mail to reset it.</span>
		</div>
		<div class="form-group">
			<input class="form-control placeholder-no-fix" type="text" autocomplete="off" placeholder="Email" name="email"/>
		</div>
		<div class="form-actions">
            <asp:Button ID="btnBacklogin" runat="server" class="btn btn-default" Text="Back" OnClick="btnBackLogin" />			
			<button type="submit" class="btn btn-primary uppercase pull-right">Submit</button>
		</div>
	</div>
	<!-- END FORGOT PASSWORD FORM -->

</div>
<div class="copyright hide">
	 2018 © Sap Creations. Hospital Management System.
</div>
<!-- END LOGIN -->
<!-- BEGIN JAVASCRIPTS(Load javascripts at bottom, this will reduce page load time) -->
<!-- BEGIN CORE PLUGINS -->
<!--[if lt IE 9]>
<script src="../../assets/global/plugins/respond.min.js"></script>
<script src="../../assets/global/plugins/excanvas.min.js"></script> 
<![endif]-->
<script src="plugins/jquery.min.js" type="text/javascript"></script>
<script src="plugins/jquery-migrate.min.js" type="text/javascript"></script>
<script src="plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
<script src="plugins/jquery.blockui.min.js" type="text/javascript"></script>
<script src="plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>
<script src="plugins/jquery.cokie.min.js" type="text/javascript"></script>
<!-- END CORE PLUGINS -->
<!-- BEGIN PAGE LEVEL PLUGINS -->
<script src="plugins/jquery-validation/js/jquery.validate.min.js" type="text/javascript"></script>
<!-- END PAGE LEVEL PLUGINS -->
<!-- BEGIN PAGE LEVEL SCRIPTS -->
<script src="scripts/metronic.js" type="text/javascript"></script>
<script src="css/layout/scripts/layout.js" type="text/javascript"></script>
<script src="css/layout/scripts/demo.js" type="text/javascript"></script>
<script src="css/page/scripts/login.js" type="text/javascript"></script>
<!-- END PAGE LEVEL SCRIPTS -->
<script>
    jQuery(document).ready(function () {
        Metronic.init(); // init metronic core components
        Layout.init(); // init current layout
        Login.init();
        Demo.init();
    });
</script>
<!-- END JAVASCRIPTS -->
        </form>
</body>
</html>
