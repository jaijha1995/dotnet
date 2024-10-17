<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TopMenu.ascx.cs" Inherits="UserControl_TopMenu" %>
<%--<%@ OutputCache Duration="86400" VaryByParam="none" %>--%>
<!-- Fixed navbar -->
<div id="head-nav" class="navbar navbar-default navbar-fixed-top">
    <div class="container-fluid">
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                <span class="fa fa-gear"></span>
            </button>
            <a class="navbar-brand" href="#">
                <asp:Label ID="lblCpmpanyName" runat="server"></asp:Label></></a>
        </div>
        <div class="navbar-collapse collapse">

            <ul class="nav navbar-nav navbar-right user-nav">
                <li class="dropdown profile_menu">
                    <a id="sign_out" href="#" class="dropdown-toggle avatar " data-toggle="dropdown">
                        <img src="../images/wincapital_logo1.png" />
                          <%--  <img alt="Avatar" src="images/logo-2.jpg" />--%>
                        <span><asp:Label runat="server" ID="lblUserName"></asp:Label></span> <b class="caret"></b></a>
                    <ul id="sn" class="dropdown-menu">
                        <li><a href="logOut.aspx">Sign Out</a></li>
                    </ul>
                </li>
            </ul>

        </div>
        <!--/.nav-collapse animate-collapse -->
    </div>
</div>

<style>
    .sign_out_txt {
        display: block;
    }
</style>

<script src="../js/jquery.js"></script>

<script>
    $(document).ready(function () {
        $('#sign_out').click(function () {
            $('#sn').toggle();
        });
    });
</script>
