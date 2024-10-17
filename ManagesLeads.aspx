<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManagesLeads.aspx.cs" Inherits="ManagesLeads" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/calender.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />

    <!-- Include jQuery -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.13/css/select2.min.css" rel="stylesheet" />

    <link href="css/sumoselect.min.css" rel="stylesheet" />

    <!-- Include jQuery (required by Select2) -->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

    <!-- Include Select2 JS -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.13/js/select2.min.js"></script>

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

        .scrollable-cell {
            max-height: 50px;
            overflow-y: auto;
            overflow-x: hidden;
            border: 1px solid #ddd;
        }
    </style>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="content" id="pcont">

            <ContentTemplate>
                <asp:HiddenField runat="server" ID="hdn_Id" Value="0" />
                <div class="page-head">
                    <h3>Manage Lead Data</h3>
                </div>
                <div class="cl-mcont">
                    <div class="row">
                        <div class="col-sm-12 col-md-12">
                            <div class="blockflat_d">
                                <div class="block-flat" style="margin-bottom: 0px">
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
                                        <label class="col-sm-4 control-label">Customer ID<span id="Span1" runat="server" class="spanStar" style="color: Red; font-size: 14px;">*<span id="iconid" style="display: none">&#x2705;</span></span></label>
                                        <div class="col-sm-4">

                                            <asp:DropDownList ID="txtuserid" AutoPostBack="true" runat="server" CssClass="form-control select2" OnSelectedIndexChanged="txtuserid_SelectedIndexChanged">
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div style="clear: both; height: 10px">
                                    </div>


                                    <div class="form-group" style="display: flex; align-items: center;">
                                        <label class="col-sm-4 control-label">Customer Name</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtname" runat="server" placeholder="Enter Loan Amt" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtloantype" InitialValue="0" ErrorMessage="Please select Loan Type" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>


                                        </div>
                                    </div>
                                    <div style="clear: both; height: 10px">
                                    </div>

                                    <div class="form-group" style="display: flex; align-items: center;">
                                        <label class="col-sm-4 control-label">Loan type</label>
                                        <div class="col-sm-4">
                                            <asp:DropDownList ID="txtloantype" AutoPostBack="true" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvLoanType" runat="server" ControlToValidate="txtloantype" InitialValue="0" ErrorMessage="Please select Loan Type" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>


                                        </div>
                                    </div>
                                    <div style="clear: both; height: 10px">
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-4 control-label">Loan Amount<span id="Span2" runat="server" class="spanStar1" style="color: Red; font-size: 14px;">*<span id="iconid" style="display: none">&#x2705;</span></span></label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtloanammount" runat="server" placeholder="Enter Loan Amt" CssClass="form-control"></asp:TextBox>
                                            <span class="text-danger" style="color: red" id="validpass"></span>
                                            

                                        </div>
                                    </div>
                                    <div style="clear: both; height: 10px">
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-4 control-label">Loan Details<span id="Span4" runat="server" class="spanStar" style="color: Red; font-size: 14px;"></span></label>
                                        <div class="col-sm-4">
                                            <asp:DropDownList ID="ddlloandetails" AutoPostBack="true" runat="server" CssClass="form-control">
                                                <asp:ListItem Text="--Select loan Details---" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="New Loan" Value="New Loan"></asp:ListItem>
                                                <asp:ListItem Text="Balance Transfer" Value="Balance Transfer"></asp:ListItem>
                                                <asp:ListItem Text="Top Up Only" Value="Top Up Only"></asp:ListItem>
                                                <asp:ListItem Text="BT + Top Up" Value="BT + Top Up"></asp:ListItem>
                                            </asp:DropDownList>


                                        </div>
                                    </div>
                                    <div style="clear: both; height: 10px">
                                    </div>

                                    <%-- <div class="form-group" style="display:none">
                                    <label for="inputEmail3" class="col-sm-4 control-label">
                                        Bank Name 
                                    </label>
                                    <div class="col-sm-4">
                                        <asp:ListBox ID="ddlAirline" runat="server" SelectionMode="Multiple" CssClass=" form-control select2" Style="width: 331px;" />
                                    
                                        <asp:HiddenField ID="hfSelectedAirlines" runat="server" />
                                     
                                    </div>
                                </div>
                                       
                                <div style="clear: both; height: 10px">
                                </div>--%>


                                    <div class="form-group">
                                        <div class="col-sm-4 col-sm-10"></div>
                                        <div class="col-sm-4 col-sm-10">
                                            <asp:Button ID="btnSave" Text="Submit" runat="server" ValidationGroup="insert" CssClass="btn btn-primary" OnClientClick="return validateTextBox();" OnClick="btnSave_Click" />

                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>

                    </div>
                </div>

            </ContentTemplate>

        <div class="col-sm-12 col-md-12">
            <div class="block-flat">

                <contenttemplate>
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
                                        <th>Lead ID
                                        </th>
                                        <th>Customer ID
                                        </th>
                                        <th>Customer Name</th>
                                        <th>Loan Type
                                        </th>
                                        <th>Loan Amount
                                        </th>
                                        <th>Loan Details
                                        </th>
                                        <%--  <th>Bankcode
                                        </th>--%>
                                        <th>Create By
                                        </th>
                                        <th colspan="2">Action
                                        </th>
                                    </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblId" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"LeadID")%>'></asp:Label>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("LeadID").ToString()) ? "-" : Eval("LeadID"))%>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDepartDate" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("CustomerID").ToString()) ? "-" : Eval("CustomerID"))%>'></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("CustomerName ").ToString()) ? "-" : Eval("CustomerName "))%>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblReturnDate" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("LoanType").ToString()) ? "-" : Eval("LoanType"))%>'></asp:Label>

                                    </td>
                                    <td>
                                        <asp:Label ID="lblAirlineCode" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("LoanAmt").ToString()) ? "-" : Eval("LoanAmt"))%>'></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("LoanDetails").ToString()) ? "-" : Eval("LoanDetails"))%>'></asp:Label>
                                    </td>
                                    <%-- <td class="scrollable-cell">
                                        <asp:Label ID="Label3" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("BankName").ToString()) ? "-" : Eval("BankName"))%>'></asp:Label>
                                    </td>--%>

                                    <td class="scrollable-cell">
                                        <asp:Label ID="Label4" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("RoleType").ToString()) ? "-" : Eval("RoleType"))%>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lnkbnEdit" CommandName="Edit" OnClientClick="ScrollTop()" CommandArgument='<%# Eval("LeadID") %>'
                                            runat="server" CssClass="btn btn-primary">Edit</asp:LinkButton>

                                        <asp:LinkButton ID="lnkbnDelete" CommandArgument='<%# Eval("LeadID") %>' CommandName="Delete"
                                            CssClass="btn btn-danger" runat="server">Delete</asp:LinkButton>
                                        <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender12" runat="server" TargetControlID="lnkbnDelete"
                                            ConfirmText="Are you sure? you want to delete" />
                                        <asp:Label ID="lblOfferId" runat="server" Visible="false" Text='<%# Eval("LeadID") %>'></asp:Label>
                                    </td>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </contenttemplate>

            </div>
        </div>

    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <%--<script src="http://code.jquery.com/jquery-1.9.1.js" type="text/javascript"></script>--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.0/jquery.min.js" type="text/javascript"></script>
    <script src="https://code.jquery.com/ui/1.10.3/jquery-ui.js" type="text/javascript"></script>
    <%--    <script src="js/jquery.sumoselect.min.js" type="text/javascript"></script>--%>
    <script src="lib/jquery.sumoselect/jquery.sumoselect.min.js"></script>

    <script type="text/javascript" src="https://davidstutz.github.io/bootstrap-multiselect/dist/js/bootstrap-multiselect.js"></script>

    <script type="text/javascript">

        function checkNum(evt) {
            var carCode = (evt.which) ? evt.which : event.keyCode
            if (carCode > 31 && (carCode < 48) || (carCode > 57)) {
                return false;
            }
        }
        function checkKeyPress() {
            return false;
        }
    </script>

    <script type="text/javascript">
        function validateTextBox() {
            var loanAmount = document.getElementById('<%= txtloanammount.ClientID %>').value;
            if (loanAmount.trim() === "") {
                alert("Loan amount is required.");
                return false;
            }
        }
    </script>


</asp:Content>
