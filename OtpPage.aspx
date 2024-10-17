<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OtpPage.aspx.cs" Inherits="OtpPage" %>


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
    <form id="forgate" runat="server" style="margin-bottom: 0px !important;" class="form-horizontal" defaultbutton="">
        <div id="cl-wrapper" class="login-container">
            <div class="middle-login">
                <div class="block-flat">
                    <div class="header">
                        <h3 class="text-center" style="font-size: 35px!important">
                            <img src="images/wincapital_logo1.png" alt="logo" />Wincapital</h3>
                    </div>
                    <div>
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                        <div class="content">
                            <h4 class="title">OTP Verification</h4>
                            <div class="form-group">
                                <div class="col-sm-12">
                                    <div class="input-group">
                                        <span class="input-group-addon"><i class="fa fa-user"></i></span>
                                        <asp:TextBox ID="txtforgotpassword" runat="server" class="form-control" placeholder="Enter OTP"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="foot">
                            <asp:Button ID="btnResetPassword" runat="server" Text="Verify" CssClass="btn btn-default" OnClick="btnResetPassword_Click" />
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


