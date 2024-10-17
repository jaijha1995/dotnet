<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CustomerStatusIndex.aspx.cs" Inherits="CustomerStatusIndex" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.11.5/css/jquery.dataTables.min.css">

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.13/css/select2.min.css" rel="stylesheet" />

    <link href="css/sumoselect.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
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
    </style>

    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }
</script>
    <script type="text/javascript">

        $(document).ready(function () {
            $('#<%= ddlAirline.ClientID %>').SumoSelect();
        });
        $(document).ready(function () {
            $('#ctl00_ContentPlaceHolder1_ddlAirline').select2();
        });


        $(document).ready(function () {
            $('#<%= ddlAirline.ClientID %>').select2({
                placeholder: "Select Bank Name",
                allowClear: true
            });
        });

        $(document).ready(function () {
            $('.select2').select2({
                placeholder: "Select Bank Name",
                allowClear: true
            });
        });

        function callmulty() {
            $(<%=ddlAirline.ClientID%>).SumoSelect();
        }


    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid" id="pcont">
        <div class="page-head">
            <h2>Manage Customer Status Index(Only Admin)</h2>
        </div>
        <div class="cl-mcont">
            <div class="row">
                <div class="col-sm-12 col-md-12">
                    <div class="blockflat_d">
                        <div class="block-flat-offer">
                            <div class="content">
                                <asp:HiddenField runat="server" ID="hdn_Id" Value="0" />
                                <asp:Panel ID="FormPanel" runat="server" Style="display: none">
                                    <div class="row" style="display: none">
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">
                                                Lead Id
                                            </label>
                                            <div class="col-sm-4">

                                                <asp:TextBox runat="server" ID="txtleadId" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="CanbinCode">
                                                Customer Id
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:TextBox runat="server" ID="txtcustomerId" CssClass="form-control"></asp:TextBox>

                                            </div>
                                        </div>

                                    </div>

                                    <div class="row" style="display: none">
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">
                                                Create User
                                            </label>
                                            <div class="col-sm-4">

                                                <asp:TextBox runat="server" ID="txtCreate" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="CanbinCode">
                                                Roal type
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:TextBox runat="server" ID="txtroltype" CssClass="form-control"></asp:TextBox>

                                            </div>
                                        </div>

                                    </div>



                                    <div class="row">

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">
                                                Customer Name
                                            </label>
                                            <div class="col-sm-4">

                                                <asp:TextBox runat="server" ID="txtname" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="CanbinCode">
                                                Loan Type
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:TextBox runat="server" ID="txtloantype" CssClass="form-control"></asp:TextBox>
                                                <%--          <asp:DropDownList runat="server" ID="ddlLoantype" CssClass="form-control">
                                                </asp:DropDownList>--%>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="txtDestination">
                                                Contact No 
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:TextBox ID="txtcontactno" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="ddlDeparture">
                                                City<span class="redmark">*</span>
                                            </label>
                                            <div class="col-sm-4">

                                                <asp:TextBox runat="server" ID="txtcity" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RvfddlAirlineCode" runat="server" ControlToValidate="txtcity"
                                                    Display="Dynamic" ErrorMessage="Please enter the city " ValidationGroup="insert"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="ddlDeparture">
                                                State<span class="redmark">*</span>
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:TextBox runat="server" ID="txtstate" CssClass="form-control"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="CanbinCode">
                                                Application Type
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:TextBox runat="server" ID="txtApplication" CssClass="form-control"></asp:TextBox>
                                                <%--<asp:DropDownList runat="server" ID="ddlApplication" CssClass="form-control">
                                                </asp:DropDownList>--%>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="CanbinCode">
                                                Loan Ammmount
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:TextBox runat="server" ID="txtloanAmt" CssClass="form-control"></asp:TextBox>

                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="CanbinCode">
                                                Loan Details
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:TextBox runat="server" ID="txtloandetail" CssClass="form-control"></asp:TextBox>
                                                <%--                                                <asp:DropDownList runat="server" ID="ddlloandetails" CssClass="form-control">
                                                </asp:DropDownList>--%>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="row">
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="ddlDeparture">
                                                Bank Name<span class="redmark">*</span>
                                            </label>
                                            <div class="col-sm-4">
                                                <%-- <asp:TextBox runat="server" ID="txtbankname" CssClass="form-control"></asp:TextBox>--%>
                                                <asp:ListBox ID="ddlAirline" runat="server" SelectionMode="Multiple" CssClass=" form-control select2" Style="width: 331px;" />
                                                <asp:HiddenField ID="hfSelectedAirlines" runat="server" />
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="txtDestination">
                                                Month
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="row">
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="ddlDeparture">
                                                Rate of Interest<span class="redmark">*</span>
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:TextBox runat="server" ID="txtrate" CssClass="form-control"></asp:TextBox>

                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="txtDestination">
                                                Foreclosure Charges
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:TextBox ID="txtforecharges" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="row">
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="ddlDeparture">
                                                Status<span class="redmark">*</span>
                                            </label>
                                            <div class="col-sm-4">
                                                <%-- <asp:TextBox runat="server" ID="txtstatus" CssClass="form-control"></asp:TextBox>--%>
                                                <asp:DropDownList runat="server" ID="ddlstatus" CssClass="form-control" onchange="toggleReasonTextbox()">
                                                    <asp:ListItem Text="--Select Bank Status---" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Docs Pending" Value="Docs Pending"></asp:ListItem>
                                                    <asp:ListItem Text="Docs Complete" Value="Docs Complete"></asp:ListItem>
                                                    <asp:ListItem Text="Log in" Value="Log in"></asp:ListItem>
                                                    <asp:ListItem Text="Bank Meeting" Value="Bank Meeting"></asp:ListItem>
                                                    <asp:ListItem Text="Rejected" Value="Rejected"></asp:ListItem>
                                                    <asp:ListItem Text="Sanctioned" Value="Sanctioned"></asp:ListItem>
                                                    <asp:ListItem Text="Not Availed" Value="Not Availed"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="txtReason">Reason</label>
                                            <div class="col-sm-4">
                                                <asp:TextBox runat="server" ID="txtReason" CssClass="form-control" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="ddlDeparture">
                                             Bank Status<span class="redmark">*</span>
                                            </label>
                                            <div class="col-sm-4">
                                                <%-- <asp:TextBox runat="server" ID="txtstatus" CssClass="form-control"></asp:TextBox>--%>
                                                <asp:DropDownList runat="server" ID="ddlbankstatus" CssClass="form-control" onchange="toggleReasonTextbox()">
                                                    <asp:ListItem Text="--Select Bank Status---" Value="0"></asp:ListItem>
                                                      <asp:ListItem Text="Docs Pending" Value="Docs Pending"></asp:ListItem>
                                                     <asp:ListItem Text="Docs Complete" Value="Docs Complete"></asp:ListItem>
                                                     <asp:ListItem Text="Shared with Bank" Value="Shared with Bank"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <div class="col-sm-4 col-sm-10"></div>
                                            <div class="col-sm-4 col-sm-10">
                                                <asp:Button ID="btnsave" runat="server" ValidationGroup="insert" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" OnClientClick="return validateTextBox();" />
                                                <%--   <asp:Button ID="btnSave" Text="Submit" runat="server" CssClass="btn btn-primary" />--%>
                                            </div>
                                        </div>
                                    </div>



                                </asp:Panel>
                                <div class="col-sm-12 col-md-12">
                                    <div class="block-flat1">

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
                                                                <th>Lead ID</th>
                                                                <th>Customer Name</th>
                                                                <th>City</th>
                                                                <th>Contact No</th>
                                                                <th>Application Type</th>
                                                                <th>State</th>
                                                                <th>Loan Type
                                                                </th>
                                                                <th>Loan Amount
                                                                </th>
                                                                <th>Loan Details
                                                                </th>
                                                                <th>Bank Name
                                                                </th>
                                                                <th>Rate
                                                                </th>
                                                                <th>TenareDate
                                                                </th>
                                                                <th>ForeClosure Charges
                                                                </th>
                                                                <th>Status
                                                                </th>
                                                                <th>Bank Status
                                                                </th>
                                                                <th>Reason
                                                                </th>
                                                                <th colspan="2">Action
                                                                </th>

                                                            </thead>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblId" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Id")%>'></asp:Label>

                                                            <td>
                                                                <asp:Label ID="Label12" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("LeadID").ToString()) ? "-" : Eval("LeadID"))%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("CustomerName").ToString()) ? "-" : Eval("CustomerName"))%>'></asp:Label>
                                                            </td>

                                                            <td>
                                                                <asp:Label ID="Label3" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("City").ToString()) ? "-" : Eval("City"))%>'></asp:Label>
                                                            </td>

                                                            <td>
                                                                <asp:Label ID="Label4" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("ContactNo").ToString()) ? "-" : Eval("ContactNo"))%>'></asp:Label>
                                                            </td>

                                                            <td>
                                                                <asp:Label ID="Label5" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("applicationType").ToString()) ? "-" : Eval("applicationType"))%>'></asp:Label>
                                                            </td>

                                                            <td>
                                                                <asp:Label ID="Label6" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("State").ToString()) ? "-" : Eval("State"))%>'></asp:Label>
                                                            </td>

                                                            <td>
                                                                <asp:Label ID="lblReturnDate" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("LoanType").ToString()) ? "-" : Eval("LoanType"))%>'></asp:Label>

                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblAirlineCode" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("LoanAmt").ToString()) ? "-" : Eval("LoanAmt"))%>'></asp:Label>
                                                            </td>

                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("LoanDetail").ToString()) ? "-" : Eval("LoanDetail"))%>'></asp:Label>
                                                            </td>

                                                            <td>
                                                                <asp:Label ID="Label7" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("BankName").ToString()) ? "-" : Eval("BankName"))%>'></asp:Label>
                                                            </td>

                                                            <td>
                                                                <asp:Label ID="Label8" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("Rate").ToString()) ? "-" : Eval("Rate"))%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label9" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("TenareDate").ToString()) ? "-" : Eval("TenareDate"))%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label10" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("ForeCharge").ToString()) ? "-" : Eval("ForeCharge"))%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label11" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("Status ").ToString()) ? "-" : Eval("Status "))%>'></asp:Label>
                                                            </td>

                                                             <td>
                                                                <asp:Label ID="Label14" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("BankStatus").ToString()) ? "-" : Eval("BankStatus"))%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label13" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("Reason ").ToString()) ? "-" : Eval("Reason "))%>'></asp:Label>
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
                                        </contenttemplate>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
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
        function validateTextBox() {

            var selectedValues = $('#<%= ddlAirline.ClientID %>').val();
            var selectedValuesString = selectedValues.join(',');
            $('#<%= hfSelectedAirlines.ClientID %>').val(selectedValuesString);

            return true;

        }
    </script>
    <script>
        function toggleReasonTextbox() {
            var status = $('#<%= ddlstatus.ClientID %>').val();
            var reasonTextbox = $('#<%= txtReason.ClientID %>');

            if (status === 'Rejected' || status === 'Not Availed') {
                reasonTextbox.prop('disabled', false);
            } else {
                reasonTextbox.prop('disabled', true);
            }
        }
        $(document).ready(function () {
            toggleReasonTextbox();
        });
</script>

</asp:Content>

