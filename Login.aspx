<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="shortcut icon" href="images/favicon.png">
    <title>Clean Zone</title>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,400italic,700,800'
        rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Raleway:300,200,100' rel='stylesheet'
        type='text/css'>
    <link href="js/bootstrap/dist/css/bootstrap.css" rel="stylesheet">
    <link rel="stylesheet" href="fonts/font-awesome-4/css/font-awesome.min.css">
    <link href="css/style.css" rel="stylesheet" />
</head>
<body class="texture">
    <form id="form1" runat="server" style="margin-bottom: 0px !important;" class="form-horizontal"
        defaultbutton="lnkbtnLogin">
        <div id="cl-wrapper" class="login-container">
            <div class="middle-login">
                <div class="block-flat">
                    <div class="header">
                        <h3 class="text-center" style="font-size: 35px!important">
                        <img src="images/wincapital_logo1.png" alt="logo"/>Wincapital</h3>
                    </div>
                    <div>
                        <div class="content">
                            <h4 class="title">Login Access</h4>
                            <div class="form-group">
                                <div class="col-sm-12">
                                    <div class="input-group">
                                        <span class="input-group-addon"><i class="fa fa-user"></i></span>
                                        <asp:TextBox ID="txtUserId" runat="server" class="form-control" placeholder="Username"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-12">
                                    <div class="input-group">
                                        <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                                        <asp:TextBox ID="txtPassword" runat="server" class="form-control" placeholder="Password"
                                            TextMode="Password"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="foot">
                            <asp:LinkButton ID="lnkbtnLogin" runat="server" CssClass="btn btn-primary" Text="Log me in"
                                ValidationGroup="login" OnClick="lnkbtnLoginClick" data-dismiss="modal"></asp:LinkButton>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUserId"
                                Display="None" ErrorMessage="Please enter user id" SetFocusOnError="true" ValidationGroup="login"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword"
                                Display="None" ErrorMessage="Please enter password" SetFocusOnError="true" ValidationGroup="login"></asp:RequiredFieldValidator>
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true"
                                ShowSummary="false" ValidationGroup="login" />
                            
                            <asp:HyperLink ID="hplForgotPassword" NavigateUrl="ForgatePassword.aspx" runat="server"
                                Text="Forgot Password" CssClass="btn btn-default"></asp:HyperLink>

                         <%--     <asp:HyperLink ID="HyperRegistration" NavigateUrl="CreateUser.aspx" runat="server"
                                Text="Registration" CssClass="btn btn-default"></asp:HyperLink>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script src="js/jquery.js"></script>
        <script type="text/javascript" src="js/general.js"></script>
    </form>
</body>
</html>
