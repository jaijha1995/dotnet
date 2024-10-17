<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateUser.aspx.cs" Inherits="CreateUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link href="css/calender.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link href="css/sumoselect.min.css" rel="stylesheet" />
    <%--<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery.sumoselect/3.1.6/sumoselect.min.css">--%>
    <link href='https://unpkg.com/boxicons@2.0.9/css/boxicons.min.css' rel='stylesheet'>
    <style>
        .btn-group .dropdown-toggle {
            width: 100% !important;
        }

        .btn-group {
            width: 100% !important;
            margin-right: 0px;
            margin-left: 0px;
        }

        .open > .dropdown-menu {
            margin-bottom: 20px;
        }

        .btn {
            padding: 6px 30px !important;
        }

        .multiselect-search {
            width: 235px !important;
        }

        .input-group-btn {
            display: none;
        }

        tr, .table > thead > tr > th {
            text-align: center;
        }

        .input-group-text {
            cursor: pointer;
            padding-left: 10px;
            padding-right: 10px;
            border: 1px solid #ced4da;
            background-color: white;
        }

        .form-control {
            border-right: none;
        }
    </style>
    <script type="text/javascript">  
        function ScrollTop() {
            window.location.href = "#scrolltop_";
        }
        function changeNumber() {
            var characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
            var randomNum = '';

            for (var i = 0; i < 6; i++) { // Change 8 to the desired length of the string
                var randomIndex = Math.floor(Math.random() * characters.length);
                randomNum += characters.charAt(randomIndex);
            }
            document.getElementById("ctl00_ContentPlaceHolder1_txtpassword").value = randomNum;
        }
    </script>
    <script type="text/javascript">
        function validateTextBox() {
            var textuseridValue = $('#<%=txtuserid.ClientID%>').val();
            var textpasswordValue = $('#<%=txtpassword.ClientID%>').val();
            var textemailValue = $('#<%=txtemail.ClientID%>').val();

            if (textuseridValue.trim() === "") {
                $("#validid").show().text("Please enter userid !");
                $("#iconid").hide();
                $("#ctl00_ContentPlaceHolder1_txtuserid").css("border", "1px solid red");
                return false;
            }
            else {
                $("#validid").hide();
                $("#ctl00_ContentPlaceHolder1_txtuserid").css("border", "");
            }
            if (textpasswordValue.trim() === "") {
                $("#validpass").show().text("Please enter password !");
                $("#iconpass").hide();
                $("#ctl00_ContentPlaceHolder1_txtpassword").css("border", "1px solid red");
                return false;
            }
            else {
                $("#validpass").hide();
                $("#ctl00_ContentPlaceHolder1_txtpassword").css("border", "");
            }
            if (textemailValue.trim() === "") {
                $("#validmail").show().text("Please enter email !");
                $("#iconemail").hide();
                $("#ctl00_ContentPlaceHolder1_txtemail").css("border", "1px solid red");
                return false;
            }
            else {
                $("#validmail").hide();
                $("#ctl00_ContentPlaceHolder1_txtemail").css("border", "");
            }
            return true;
        }
        function checkmail() {
            debugger
            LastName = "";
            var EmailID = $("#ctl00_ContentPlaceHolder1_txtemail").val();
            var emailReg = /^[a-zA-Z0-9._]+[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z]{2,4}$/;
            LastName = $("#ctl00_ContentPlaceHolder1_txtemail").val();
            if ($("#ctl00_ContentPlaceHolder1_txtemail").val() == "") {
                $("#validmail").show().text("Please enter email !");
                $("#iconemail").hide();
                $("#ctl00_ContentPlaceHolder1_txtemail").css("border", "1px solid red");
            }
            else if (!emailReg.test(EmailID)) {
                $("#validmail").show().text("Please enter valid email id.");
                $("#iconemail").hide();
                $("#ctl00_ContentPlaceHolder1_txtemail").css("border", "1px solid red");
            }
            else {
                $("#validmail").hide();
                $("#iconemail").show();
                $("#ctl00_ContentPlaceHolder1_txtemail").css("border", "");
            }
        }

        function togglePasswordVisibility() {
        // Use '<%= txtpassword.ClientID %>' to get the correct ID from ASP.NET
            var passwordInput = document.getElementById("<%= txtpassword.ClientID %>");
            var eyeIcon = document.getElementById("eyeIcon");

            if (passwordInput.type === "password") {
                passwordInput.type = "text";
                eyeIcon.classList.remove("bx-hide");
                eyeIcon.classList.add("bx-show");
            } else {
                passwordInput.type = "password";
                eyeIcon.classList.remove("bx-show");
                eyeIcon.classList.add("bx-hide");
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        th {
            text-align: center;
        }
    </style>
    <div class="container-fluid" id="pcont">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:HiddenField runat="server" ID="hdn_Id" Value="0" />
                <div class="page-head" id="scrolltop_">
                    <h2>Create User</h2>
                </div>
                <div class="cl-mcont">
                    <div class="row">
                        <div class="col-sm-12 col-md-12">
                            <div class="blockflat_d">
                                <div class="block-flat  row" style="margin-bottom: 0px">
                                    <div class="form-group">
                                        <label class="col-sm-4 control-label">UserId<span id="Span1" runat="server" class="spanStar" style="color: Red; font-size: 14px;">*<span id="iconid" style="display: none">&#x2705;</span></span></label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtuserid" runat="server" placeholder="Enter User id" CssClass="form-control"></asp:TextBox>
                                            <span class="text-danger" style="color: red" id="validid"></span>
                                        </div>
                                    </div>
                                    <div style="clear: both; height: 10px">
                                    </div>
                                    <div class="form-group" style="display: flex; align-items: center;">
                                        <label class="col-sm-4 control-label">Role type<span id="Span3" runat="server" class="spanStar" style="color: Red; font-size: 14px;">*</span></label>
                                        <div class="col-sm-4">
                                            <asp:RadioButton GroupName="admin" ID="Rndcheckuser" Text="User" runat="server" />
                                            <asp:RadioButton GroupName="admin" ID="Rndcheckadmin" Text="Admin" runat="server" />
                                        </div>
                                    </div>
                                    <div style="clear: both; height: 10px">
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-4 control-label">Password<span id="Span2" runat="server" class="spanStar" style="color: Red; font-size: 14px;">*<span id="iconpass" style="display: none">&#x2705;</span></span></label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtpassword" type="password" runat="server" placeholder="Enter User Password" CssClass="form-control"></asp:TextBox>
                                            <div id="iconpassword" runat="server">
                                                <span class="input-group-text cursor-pointer" onclick="togglePasswordVisibility()">
                                                    <i id="eyeIcon" class="bx bx-hide"></i>
                                                </span>
                                            </div>

                                        </div>
                                        <div class="col-sm-4">
                                            <button id="btnrandom" class="btn btn-success" onclick="changeNumber(); return false;">Create Random Password</button>
                                            <span class="text-danger" style="color: red" id="validpass"></span>
                                        </div>
                                    </div>
                                    <div style="clear: both; height: 10px">
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-4 control-label">Email<span id="EmailStart" runat="server" class="spanStar" style="color: Red; font-size: 14px;">*<span id="iconemail" style="display: none">&#x2705;</span></span></label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtemail" onkeyup="checkmail()" placeholder="Enter User email" runat="server" CssClass="form-control"></asp:TextBox>
                                            <span class="text-danger" style="color: red" id="validmail"></span>
                                        </div>
                                    </div>
                                    <div style="clear: both; height: 10px">
                                    </div>

                                    <div class="form-group">
                                        <div class="col-sm-4 col-sm-10"></div>
                                        <div class="col-sm-4 col-sm-10">
                                            <asp:Button ID="btnSave" Text="Submit" runat="server" CssClass="btn btn-primary" OnClientClick="return validateTextBox();" OnClick="btnSave_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <div class="col-sm-12 col-md-12">
            <div class="block-flat">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                        <asp:GridView ID="GridCreateUser" runat="server" GridLines="None" ShowFooter="false"
                            RowStyle-VerticalAlign="Middle" OnPageIndexChanging="GridCreateUser_PageIndexChanging" AutoGenerateColumns="false" OnRowDeleting="GridCreateUser_RowDeleting" OnRowEditing="GridCreateUser_RowEditing" OnRowCommand="GridCreateUser_RowCommand" CssClass="table table-striped table-hover fill-head"
                            Width="100%" ShowHeader="true" PageSize="30"
                            PagerStyle-CssClass="paging">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <thead>
                                            <th></th>
                                            <th>User Id
                                            </th>
                                            <th></th>
                                            <th>Email Id
                                            </th>
                                            <th>Roll
                                            </th>
                                            <th colspan="2">Action
                                            </th>
                                        </thead>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Id")%>'></asp:Label>
                                        <td>
                                            <asp:Label ID="lblDepartDate" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("UserId").ToString()) ? "-" : Eval("UserId"))%>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblReturnDate" Visible="false" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("Password").ToString()) ? "-" : Eval("Password"))%>'></asp:Label>

                                        </td>
                                        <td>
                                            <asp:Label ID="lblAirlineCode" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("ContactEmailAdd").ToString()) ? "-" : Eval("ContactEmailAdd"))%>'></asp:Label>
                                        </td>

                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("Role_Type").ToString()) ? "-" : Eval("Role_Type"))%>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="lnkbnEdit" CommandName="Edit" OnClientClick="ScrollTop()" CommandArgument='<%# Eval("Id") %>'
                                                runat="server" CssClass="btn btn-primary">Edit</asp:LinkButton>

                                            <asp:LinkButton ID="lnkbnDelete" CommandArgument='<%# Eval("Id") %>' CommandName="Delete"
                                                CssClass="btn btn-danger" runat="server">Delete</asp:LinkButton>
                                            <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender12" runat="server" TargetControlID="lnkbnDelete"
                                                ConfirmText="Are you sure? you want to delete" />
                                            <asp:Label ID="lblOfferId" runat="server" Visible="false" Text='<%# Eval("Id") %>'></asp:Label>
                                        </td>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
