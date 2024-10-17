<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FinancialInstitution.aspx.cs" Inherits="FinancialInstitution" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.11.5/css/jquery.dataTables.min.css">
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
            padding: 6px 12px !important;
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
            // Allow only numbers (charCode 48-57) and control keys like backspace (charCode 8)
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid" id="pcont">
        <div class="page-head">
            <h2>Manage Payout from Financial Institution Payout</h2>
        </div>
        <div class="cl-mcont">
            <div class="row">
                <div class="col-sm-12 col-md-12">
                    <div class="blockflat_d">
                        <div class="block-flat-offer">
                            <div class="content">
                                <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                <asp:HiddenField runat="server" ID="hdn_Id" Value="0" />
                                <asp:Panel ID="FormPanel" runat="server">

                                    <div class="row" style="display: none">
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">
                                                Create User
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:TextBox runat="server" ID="txtcreateuser" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="CanbinCode">
                                                Role Type
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:TextBox runat="server" ID="txtroltype" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">
                                                Lead Id
                                            </label>
                                            <div class="col-sm-4">

                                                <asp:DropDownList ID="ddlleadId" AutoPostBack="true" runat="server" CssClass="form-control" OnSelectedIndexChanged="txtuserid_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>


                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="CanbinCode">
                                                Customer Id
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:TextBox runat="server" ID="txtuserid" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">
                                                Customer Name<span class="redmark">*</span>
                                            </label>
                                            <div class="col-sm-4">

                                                <asp:TextBox runat="server" ID="txtname" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtname"
                                                    Display="Dynamic" ErrorMessage="Please enter the Customer Name " ValidationGroup="insert"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="txtDestination">
                                                Contact No 
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:TextBox ID="txtcontactno" runat="server" CssClass="form-control" OnKeyPress="return isNumberKey(event)" MaxLength="10"></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row">

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

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="ddlDeparture">
                                                State<span class="redmark">*</span>
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:TextBox runat="server" ID="txtstate" CssClass="form-control"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="ddlDeparture">
                                                Bank Name<span class="redmark">*</span>
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:TextBox runat="server" ID="txtbankname" CssClass="form-control"></asp:TextBox>
                                                <%-- <asp:DropDownList ID="txtbankname" AutoPostBack="true" runat="server" CssClass="form-control" OnSelectedIndexChanged="txtuserid_SelectedIndexChanged">
                                                </asp:DropDownList>--%>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtbankname"
                                                    Display="Dynamic" ErrorMessage="Please Select the bank name " ValidationGroup="insert"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="CanbinCode">
                                                Transaction Amount<span class="redmark">*</span>
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:TextBox runat="server" ID="txttranAmt" CssClass="form-control" oninput="calculatePFAmount()"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txttranAmt"
                                                    Display="Dynamic" ErrorMessage="Please Enter the transaction Amt" ValidationGroup="insert"></asp:RequiredFieldValidator>

                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="CanbinCode">
                                                PF(%)<span class="redmark">*</span>
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:TextBox runat="server" ID="txtPF" CssClass="form-control" oninput="calculatePFAmount()"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPF"
                                                    Display="Dynamic" ErrorMessage="Please Enter the PF(%)" ValidationGroup="insert"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="CanbinCode">
                                                PF Amount
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:TextBox runat="server" ID="txtpfAmt" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                <asp:HiddenField runat="server" ID="hdnPfAmt" />
                                            </div>
                                        </div>

                                    </div>

                                    <div class="row">
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="ddlDeparture">
                                                Lender Payout (On PF)(%)<span class="redmark">*</span>
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:TextBox runat="server" ID="txtlenderpf" CssClass="form-control" oninput="calculatePFAmount()"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtlenderpf"
                                                    Display="Dynamic" ErrorMessage="Please Enter the Lender Payout(%)" ValidationGroup="insert"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="txtDestination">
                                                Lender Payout Amount
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:TextBox ID="txtlenPayAmt" runat="server" CssClass="form-control" ReadOnly="true" oninput="calculatePFAmount()"></asp:TextBox>
                                                <asp:HiddenField runat="server" ID="hdnlenderAmt" />
                                            </div>
                                        </div>

                                    </div>

                                    <div class="row">
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="ddlDeparture">
                                                Channel Partner Payout (%)<span class="redmark">*</span>
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:TextBox runat="server" ID="txtchannelpay" CssClass="form-control" oninput="calculatePFAmount()"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtchannelpay"
                                                    Display="Dynamic" ErrorMessage="Please Enter the Channel Partner Payout(%)" ValidationGroup="insert"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="txtDestination">
                                                CP Payout Amount
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:TextBox ID="txtcppay" runat="server" CssClass="form-control" ReadOnly="true" oninput="calculatePFAmount()"></asp:TextBox>
                                                <asp:HiddenField runat="server" ID="hdnCpAmt" />
                                            </div>
                                        </div>

                                    </div>

                                    <div class="row">
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="ddlDeparture">
                                                Recovery<span class="redmark">*</span>
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:TextBox ID="txtrecovery" runat="server" CssClass="form-control" oninput="calculatePFAmount()"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="ddlDeparture">
                                                Final Payout Amount
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:HiddenField runat="server" ID="hdnfinalamt" />
                                                <asp:TextBox ID="txtfinalpayamt" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="ddlDeparture">
                                                TDS<span class="redmark">*</span>
                                            </label>
                                            <div class="col-sm-4">

                                                <asp:TextBox ID="txttds" runat="server" CssClass="form-control" oninput="calculateGst()"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="ddlDeparture">
                                                GST<span class="redmark">*</span>
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:TextBox ID="txtgst" runat="server" CssClass="form-control" oninput="calculatePFAmount()"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtgst"
                                                    Display="Dynamic" ErrorMessage="Please Enter the Gst" ValidationGroup="insert"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="ddlDeparture">
                                                Total Payout
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:HiddenField runat="server" ID="hdntotalamt" />
                                                <asp:TextBox ID="txttotal" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>



                                    <div class="form-group">
                                        <div class="col-sm-4 col-sm-10"></div>
                                        <div class="col-sm-4 col-sm-10">
                                            <asp:Button ID="btnsave" runat="server" ValidationGroup="insert" CssClass="btn btn-primary" Text="Submit" OnClick="btnSave_Click" />
                                        </div>
                                    </div>
                                </asp:Panel>


                                <asp:Panel ID="formpanal" runat="server">
                                    <%--    <div class="row">
                                         <div class="form-group">
                                        <label class="col-sm-4 control-label">Email<span id="EmailStart" runat="server" class="spanStar" style="color: Red; font-size: 14px;">*<span id="iconemail" style="display: none">&#x2705;</span></span></label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtemail" placeholder="Enter User email" runat="server" CssClass="form-control"></asp:TextBox>
                                            <span class="text-danger" style="color: red" id="validmail"></span>
                                        </div>
                                    </div>
                                    </div>
                                    --%>
                                    <div class="row">
                                        <!-- Email Input Field -->
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="txtEmail">Email</label>
                                            <div class="col-sm-4 col-sm-10">
                                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="Enter your email"></asp:TextBox>
                                            </div>
                                        </div>

                                        <!-- Confirm Button -->
                                        <div class="form-group">
                                            <div class="col-sm-1 col-sm-10"></div>
                                            <div class="col-sm-2 col-sm-10">
                                                <asp:Button ID="btnconfirm" runat="server" CssClass="btn btn-primary" Text="Confirm" OnClick="btnConfirm_Click" CausesValidation="false" />
                                            </div>
                                        </div>

                                        <!-- Query Button -->
                                        <div class="form-group">
                                            <div class="col-sm-1 col-sm-10"></div>
                                            <div class="col-sm-2 col-sm-10">
                                                <asp:Button ID="btnQuery" runat="server" CssClass="btn btn-primary" Text="Query" OnClick="btnQuery_Click" />
                                            </div>
                                        </div>
                                    </div>

                                </asp:Panel>

                                <div class="col-sm-12 col-md-12">
                                    <div class="block-flat1">
                                        <contenttemplate>
                                            <asp:Label ID="lblMsg1" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                            <asp:GridView ID="GridCreateUser" runat="server" GridLines="None" ShowFooter="false"
                                                RowStyle-VerticalAlign="Middle" OnPageIndexChanging="GridCreateUser_PageIndexChanging" AutoGenerateColumns="false" OnRowDeleting="GridCreateUser_RowDeleting" OnRowEditing="GridCreateUser_RowEditing" OnRowCommand="GridCreateUser_RowCommand" CssClass="table table-striped table-hover fill-head"
                                                Width="100%" ShowHeader="true" PageSize="30" OnRowDataBound="GridCreateUser_RowDataBound"
                                                PagerStyle-CssClass="paging">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <thead>
                                                                <th></th>
                                                                <th>Lead ID
                                                                </th>
                                                                <th>Customer Name</th>
                                                                <th>City</th>
                                                                <th>Contact No</th>
                                                                <th>State</th>
                                                                <th>Bank Name
                                                                </th>
                                                                <th>Transaction Amount
                                                                </th>
                                                                <th>PF(%)
                                                                </th>
                                                                <th>PF Amount
                                                                </th>
                                                                <th>Lender Payout (On PF)(%)
                                                                </th>
                                                                <th>Lender Payout Amount
                                                                </th>
                                                                <th>Channel Partner Payout (%)
                                                                </th>
                                                                <th>CP Payout Amount
                                                                </th>
                                                                <th>Recovery
                                                                </th>
                                                                <th>Final Payout Amount
                                                                </th>
                                                                <th>TDS
                                                                </th>
                                                                <th>GST
                                                                </th>
                                                                <th>Total Amount
                                                                </th>
                                                                <th colspan="2">Action
                                                                </th>

                                                            </thead>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblId" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Id")%>'></asp:Label>
                                                            <td>
                                                                <asp:Label ID="lblId1" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("LeadID").ToString()) ? "-" : Eval("LeadID"))%>'></asp:Label>
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
                                                                <asp:Label ID="Label6" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("State").ToString()) ? "-" : Eval("State"))%>'></asp:Label>
                                                            </td>

                                                            <td>
                                                                <asp:Label ID="Label7" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("BankName").ToString()) ? "-" : Eval("BankName"))%>'></asp:Label>
                                                            </td>

                                                            <td>
                                                                <asp:Label ID="Label8" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("TransactionAmt").ToString()) ? "-" : Eval("TransactionAmt"))%>'></asp:Label>
                                                            </td>

                                                            <td>
                                                                <asp:Label ID="Label12" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("PFPercent").ToString()) ? "-" : Eval("PFPercent"))%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label9" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("PFAmt").ToString()) ? "-" : Eval("PFAmt"))%>'></asp:Label>
                                                            </td>

                                                            <td>
                                                                <asp:Label ID="Label13" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("LPPercent").ToString()) ? "-" : Eval("LPPercent"))%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label10" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("LenderPayoutAmt").ToString()) ? "-" : Eval("LenderPayoutAmt"))%>'></asp:Label>
                                                            </td>

                                                            <td>
                                                                <asp:Label ID="Label14" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("CPPercent").ToString()) ? "-" : Eval("CPPercent"))%>'></asp:Label>
                                                            </td>

                                                            <td>
                                                                <asp:Label ID="Label11" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("CPAmount").ToString()) ? "-" : Eval("CPAmount"))%>'></asp:Label>
                                                            </td>

                                                            <td>
                                                                <asp:Label ID="Label15" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("Recovery").ToString()) ? "-" : Eval("Recovery"))%>'></asp:Label>
                                                            </td>

                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("FPAmt").ToString()) ? "-" : Eval("FPAmt "))%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label16" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("TDS").ToString()) ? "-" : Eval("TDS"))%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label17" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("Gst").ToString()) ? "-" : Eval("Gst"))%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label5" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("TotalPayout ").ToString()) ? "-" : Eval("TotalPayout "))%>'></asp:Label>
                                                            </td>

                                                            <td>
                                                                <asp:LinkButton ID="lnkbnEdit" CommandName="Edit" OnClientClick="ScrollTop()" CommandArgument='<%# Eval("Id") %>'
                                                                    runat="server" CssClass="btn btn-primary" Style="display: inline-block;">Edit</asp:LinkButton>

                                                                <asp:LinkButton ID="lnkbnDelete" CommandArgument='<%# Eval("Id") %>' CommandName="Delete"
                                                                    CssClass="btn btn-danger" runat="server" Style="display: inline-block;">Delete</asp:LinkButton>

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

    <script type="text/javascript">
        function calculatePFAmount() {
            var transactionAmount = parseFloat(document.getElementById('<%= txttranAmt.ClientID %>').value) || 0;
            var pfPercentage = parseFloat(document.getElementById('<%= txtPF.ClientID %>').value) || 0;
            var pfAmount = (transactionAmount * pfPercentage) / 100;
            document.getElementById('<%= txtpfAmt.ClientID %>').value = pfAmount.toFixed(2);
            document.getElementById('<%= hdnPfAmt.ClientID %>').value = pfAmount.toFixed(2);

            var transactionAmount = parseFloat(document.getElementById('<%= txttranAmt.ClientID %>').value) || 0;
            var lenderpercent = parseFloat(document.getElementById('<%= txtlenderpf.ClientID %>').value) || 0;
            var LenderAmount = (transactionAmount * lenderpercent) / 100;
            document.getElementById('<%= txtlenPayAmt.ClientID %>').value = LenderAmount.toFixed(2);
            document.getElementById('<%= hdnlenderAmt.ClientID %>').value = LenderAmount.toFixed(2);

            var LenderAmount = parseFloat(document.getElementById('<%= txtlenPayAmt.ClientID %>').value) || 0;
            var Channelpercent = parseFloat(document.getElementById('<%= txtchannelpay.ClientID %>').value) || 0;
            var CPPayAmt = (LenderAmount * Channelpercent) / 100;
            document.getElementById('<%= txtcppay.ClientID %>').value = CPPayAmt.toFixed(2);
            document.getElementById('<%= hdnCpAmt.ClientID %>').value = CPPayAmt.toFixed(2);

            var CPPayAmt = parseFloat(document.getElementById('<%= txtcppay.ClientID %>').value) || 0;
            var recoverAmt = parseFloat(document.getElementById('<%= txtrecovery.ClientID %>').value) || 0;
            var finalpayAmt = (CPPayAmt - recoverAmt);
            document.getElementById('<%= txtfinalpayamt.ClientID %>').value = finalpayAmt.toFixed(2);
            document.getElementById('<%= hdnfinalamt.ClientID %>').value = finalpayAmt.toFixed(2);

            var finalpayAmt = parseFloat(document.getElementById('<%= txtfinalpayamt.ClientID %>').value) || 0;
            var tdsamt = parseFloat(document.getElementById('<%= txttds.ClientID %>').value) || 0;
            var tdsAmttoal = (finalpayAmt * tdsamt) / 100;
            //document.getElementById('<%= txttds.ClientID %>').value = tdsAmttoal.toFixed(2);

            var finalpayAmt = parseFloat(document.getElementById('<%= txtfinalpayamt.ClientID %>').value) || 0;
            var Gstamt = parseFloat(document.getElementById('<%= txtgst.ClientID %>').value) || 0;
            var totalgst = (finalpayAmt * Gstamt) / 100;
           // document.getElementById('<%= txtgst.ClientID %>').value = totalgst.toFixed(2);

            var finalpayAmt = parseFloat(document.getElementById('<%= txtfinalpayamt.ClientID %>').value) || 0;
            //var tdsamt1 = parseFloat(document.getElementById('<%= txttds.ClientID %>').value = tdsAmttoal.toFixed(2)) || 0;
            //var totalgst1 = parseFloat(document.getElementById('<%= txttds.ClientID %>').value = totalgst.toFixed(2)) || 0;
            var TotalAmt = (finalpayAmt - tdsAmttoal + totalgst);
            document.getElementById('<%= txttotal.ClientID %>').value = TotalAmt.toFixed(2);
            document.getElementById('<%= hdntotalamt.ClientID %>').value = TotalAmt.toFixed(2);

        }

        function calculateGst() {
            var finalpayAmt = parseFloat(document.getElementById('<%= txtfinalpayamt.ClientID %>').value) || 0;
            var tdsamt = parseFloat(document.getElementById('<%= txttds.ClientID %>').value) || 0;
            var tdsAmttoal = (finalpayAmt * tdsamt) / 100;
            //document.getElementById('<%= txttds.ClientID %>').value = tdsAmttoal.toFixed(2);

            var finalpayAmt = parseFloat(document.getElementById('<%= txtfinalpayamt.ClientID %>').value) || 0;
            var Gstamt = parseFloat(document.getElementById('<%= txtgst.ClientID %>').value) || 0;
            var totalgst = (finalpayAmt * Gstamt) / 100;
           // document.getElementById('<%= txtgst.ClientID %>').value = totalgst.toFixed(2);

            var finalpayAmt = parseFloat(document.getElementById('<%= txtfinalpayamt.ClientID %>').value) || 0;
            //var tdsamt1 = parseFloat(document.getElementById('<%= txttds.ClientID %>').value = tdsAmttoal.toFixed(2)) || 0;
            //var totalgst1 = parseFloat(document.getElementById('<%= txttds.ClientID %>').value = totalgst.toFixed(2)) || 0;
            var TotalAmt = (finalpayAmt - tdsAmttoal + totalgst);
            document.getElementById('<%= txttotal.ClientID %>').value = TotalAmt.toFixed(2);
            document.getElementById('<%= hdntotalamt.ClientID %>').value = TotalAmt.toFixed(2);
        }


</script>
</asp:Content>





