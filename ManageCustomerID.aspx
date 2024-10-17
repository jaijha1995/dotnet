<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageCustomerID.aspx.cs" Inherits="LogBaggages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link href="css/calender.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link href="css/sumoselect.min.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
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
    </style>
    <script type="text/javascript">  
        function ScrollTop() {
            window.location.href = "#scrolltop_";
        }
    </script>

    <script type="text/javascript">
        function validateTextBox() {
            var txtnameValue = $('#<%=txtname.ClientID%>').val();

            var txtcontactnoValue = $('#<%=txtcontactno.ClientID%>').val();
            var txtcityValue = $('#<%=txtcity.ClientID%>').val();
            var txtstateValue = $('#<%=txtstate.ClientID%>').val();
            var ddlAplicationtypeValue = $('#<%=ddlAplicationtype.ClientID%>').val();

            // Validate Name
            if (txtnameValue.trim() === "") {
                $("#validname").show().text("Please enter your name!");
                $("#ctl00_ContentPlaceHolder1_txtname").css("border", "1px solid red");
                return false;
            } else {
                $("#validname").hide();
                $("#ctl00_ContentPlaceHolder1_txtname").css("border", "");
            }

            // Validate Contact Number
            if (txtcontactnoValue.trim() === "") {
                $("#validcontactno").show().text("Please enter your contact number!");
                $("#ctl00_ContentPlaceHolder1_txtcontactno").css("border", "1px solid red");
                return false;
            } else {
                $("#validcontactno").hide();
                $("#ctl00_ContentPlaceHolder1_txtcontactno").css("border", "");
            }

            // Validate City
            if (txtcityValue.trim() === "") {
                $("#validcity").show().text("Please enter your city!");
                $("#ctl00_ContentPlaceHolder1_txtcity").css("border", "1px solid red");
                return false;
            } else {
                $("#validcity").hide();
                $("#ctl00_ContentPlaceHolder1_txtcity").css("border", "");
            }

            // Validate State
            if (txtstateValue.trim() === "") {
                $("#validstate").show().text("Please enter your state!");
                $("#ctl00_ContentPlaceHolder1_txtstate").css("border", "1px solid red");
                return false;
            } else {
                $("#validstate").hide();
                $("#ctl00_ContentPlaceHolder1_txtstate").css("border", "");
            }

            // Validate Application Type Dropdown
            if (ddlAplicationtypeValue.trim() === "") {
                $("#validApplicationType").show().text("Please select an application type!");
                $("#ctl00_ContentPlaceHolder1_ddlAplicationtype").css("border", "1px solid red");
                return false;
            } else {
                $("#validApplicationType").hide();
                $("#ctl00_ContentPlaceHolder1_ddlAplicationtype").css("border", "");
            }

            return true;
        }
    </script>
    <script>
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            // Allow only numbers (0-9)
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                evt.preventDefault();
                return false;
            }
            return true;
        }

        function validateLength(input) {
            if (input.value.length > 10) {
                input.value = input.value.slice(0, 10); // Limit to 10 digits
                document.getElementById('validDest').innerText = "Maximum 10 digits allowed.";
            } else {
                document.getElementById('validDest').innerText = ""; // Clear the message
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
                    <h2>Manage Customer ID</h2>
                </div>
                <div class="cl-mcont">
                    <div class="row">
                        <div class="col-sm-12 col-md-12">
                            <div class="blockflat_d">
                                <div class="block-flat  row" style="margin-bottom: 0px">
                                    <div class="form-group" style="display: none">
                                        <label class="col-sm-4 control-label" style="display: none">User Id</label>
                                        <div class="col-sm-4" style="display: none">
                                            <asp:DropDownList ID="ddl_Site" runat="server" CssClass="form-control" AutoPostBack="true" Enabled="false">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div style="clear: both; height: 10px">
                                    </div>

                                    <div class="form-group" style="display: none">
                                        <label class="col-sm-4 control-label" style="display: none">Roal Type</label>
                                        <div class="col-sm-4" style="display: none">
                                            <asp:DropDownList ID="ddl_roltype" runat="server" CssClass="form-control" AutoPostBack="true" Enabled="false">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div style="clear: both; height: 10px">
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-4 control-label">Name</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtname" runat="server" placeholder="Enter the Name" CssClass="form-control"></asp:TextBox>
                                            <span class="text-danger" style="color: red" id="validorigin"></span>
                                        </div>
                                    </div>
                                    <div style="clear: both; height: 10px">
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-4 control-label">Contact No</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtcontactno" runat="server" placeholder="Enter the Contact" CssClass="form-control"
                                                OnKeyPress="return isNumberKey(event)" OnInput="validateLength(this)" MaxLength="10"></asp:TextBox>
                                            <span class="text-danger" style="color: red" id="validDest"></span>
                                        </div>
                                    </div>
                                    <div style="clear: both; height: 10px">
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-4 control-label">City</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtcity" runat="server" placeholder="Enter the City" CssClass="form-control"></asp:TextBox>
                                            <span class="text-danger" style="color: red" id="validairline"></span>
                                        </div>
                                    </div>
                                    <div style="clear: both; height: 10px">
                                    </div>

                                    <div style="clear: both; height: 10px">
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-4 control-label">State</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtstate" placeholder="Enter the state" runat="server" CssClass="form-control"></asp:TextBox>
                                            <span class="text-danger" style="color: red" id="validbooking"></span>
                                        </div>
                                    </div>
                                    <div style="clear: both; height: 10px">
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-4 control-label">Application Type</label>
                                        <div class="col-sm-4">
                                            <asp:DropDownList ID="ddlAplicationtype" AutoPostBack="true" runat="server" CssClass="form-control">
                                                <asp:ListItem Text="--Select---" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Salary Individual" Value="SI"></asp:ListItem>
                                                <asp:ListItem Text="Self Employed Individual" Value="SE"></asp:ListItem>
                                                <asp:ListItem Text="Entity" Value="EN"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div style="clear: both; height: 10px">
                                    </div>


                                    <div class="form-group">
                                        <div class="col-sm-4 col-sm-10"></div>
                                        <div class="col-sm-4 col-sm-10">
                                            <asp:Button ID="btnSave" Text="Submit" runat="server" CssClass="btn btn-primary" OnClientClick="return validateTextBox();" OnClick="btnSave_Click" />
                                            <%--OnClientClick="return validateTextBox();" OnClick="btnSave_Click"--%>
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
                                            <th>Customer ID
                                            </th>
                                            <th>Customer Name
                                            </th>
                                            <th>Contact No
                                            </th>
                                            <th>City
                                            </th>
                                            <th>State 
                                            </th>
                                            <th>Application Type
                                            </th>

                                            <th>Create User
                                            </th>

                                            <th colspan="2">Action
                                            </th>
                                        </thead>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CustomerID")%>'></asp:Label>

                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text='<%#(Eval("CustomerID"))%>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDepartDate" runat="server" Text='<%#(Eval("CustomerName"))%>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblReturnDate" runat="server" Text='<%#(Eval("ContactNo"))%>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblAirlineCode" runat="server" Text='<%#( Eval("City"))%>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="LabelBookingCode" runat="server" Text='<%#(Eval("State"))%>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text='<%#(Eval("applicationType"))%>'></asp:Label>
                                        </td>


                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text='<%#(Eval("CreateUser"))%>'></asp:Label>
                                        </td>

                                        <td>
                                            <asp:LinkButton ID="lnkbnEdit" CommandName="Edit" OnClientClick="ScrollTop()" CommandArgument='<%# Eval("CustomerID") %>'
                                                runat="server" CssClass="btn btn-primary">Edit</asp:LinkButton>

                                            <asp:LinkButton ID="lnkbnDelete" CommandArgument='<%# Eval("CustomerID") %>' CommandName="Delete"
                                                CssClass="btn btn-danger" runat="server">Delete</asp:LinkButton>
                                            <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender12" runat="server" TargetControlID="lnkbnDelete"
                                                ConfirmText="Are you sure? you want to delete" />
                                            <asp:Label ID="lblOfferId" runat="server" Visible="false" Text='<%# Eval("CustomerID") %>'></asp:Label>
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

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/jquery.dataTables.min.js"></script>

    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.11.5/css/jquery.dataTables.min.css">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#ctl00_ContentPlaceHolder1_GridCreateUser').DataTable({
                paging: true, // Enable pagination
                searching: true, // Enable searching
                columnDefs: [
                    { targets: '_all', defaultContent: "" }
                ]
            });
        });
    </script>

</asp:Content>
