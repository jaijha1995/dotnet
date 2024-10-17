<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ServicesCharges.aspx.cs" Inherits="ServicesCharges" %>


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
            <h2>Manage Services Charges</h2>
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
                                                <asp:TextBox runat="server" ID="txtuserid" CssClass="form-control"></asp:TextBox>

                                            </div>
                                        </div>

                                    </div>

                                    <div class="row">

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">
                                                Customer Name
                                            </label>
                                            <div class="col-sm-4">

                                                <asp:TextBox runat="server" ID="txtname" ClientIDMode="Static" CssClass="form-control" ></asp:TextBox>
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
                                           <%--     <asp:DropDownList ID="txtbankname" AutoPostBack="true" runat="server" CssClass="form-control" OnSelectedIndexChanged="txtuserid_SelectedIndexChanged">
                                                </asp:DropDownList>--%>

                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="CanbinCode">
                                                Transaction Amount<span class="redmark">*</span>
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:TextBox runat="server" ID="txttranAmt" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txttranAmt"
                                                    Display="Dynamic" ErrorMessage="Please enter the transaction Amt " ValidationGroup="insert"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="CanbinCode">
                                                Service Charges Amount<span class="redmark">*</span>
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:TextBox runat="server" ID="txtservicesCharges" CssClass="form-control" oninput="calculatePFAmount()"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtservicesCharges"
                                                    Display="Dynamic" ErrorMessage="Please enter the Services Charges Amt " ValidationGroup="insert"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="CanbinCode">
                                                CP Share (%)<span class="redmark">*</span>
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:TextBox runat="server" ID="txtCPshareper" CssClass="form-control" oninput="calculatePFAmount()"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtservicesCharges"
                                                    Display="Dynamic" ErrorMessage="Please enter the Services Charges Amt " ValidationGroup="insert"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="row">
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="ddlDeparture">
                                                CP Share Amount
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:HiddenField runat="server" ID="hdnCpshareAmt"  EnableViewState="true"/>
                                                <asp:TextBox runat="server" ID="txtcpshareAmt" CssClass="form-control" ReadOnly="true"></asp:TextBox>

                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="txtDestination">
                                                Recovery
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:TextBox ID="txtrecovery" runat="server" CssClass="form-control" oninput="calculatePFAmount()"></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="row">
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="ddlDeparture">
                                                Final CP Share Amount
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:HiddenField runat="server" ID="hdnfinalcpamt" />
                                                <asp:TextBox runat="server" ID="txtfinalcpamt" CssClass="form-control" ReadOnly="true"></asp:TextBox>

                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="ddlDeparture">
                                                TDS
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:TextBox ID="txttds" runat="server" CssClass="form-control" oninput="calculateGst()"></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="row">


                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="ddlDeparture">
                                                GST<span class="redmark">*</span>
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:TextBox ID="txtgst" runat="server" CssClass="form-control" oninput="calculatePFAmount()"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtgst"
                                                    Display="Dynamic" ErrorMessage="Please enter the gst" ValidationGroup="insert"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="ddlDeparture">
                                                Net CP Share Amount<span class="redmark">*</span>
                                            </label>
                                            <div class="col-sm-4">
                                                <asp:HiddenField runat="server" ID="hdntotalcpamt" />
                                                <asp:TextBox ID="txttotalCpAmt" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>



                                    <div class="form-group">
                                        <div class="col-sm-4 col-sm-10"></div>
                                        <div class="col-sm-4 col-sm-10">
                                            <asp:Button ID="btnsave" runat="server" ValidationGroup="insert" CssClass="btn btn-primary" Text="Submit" OnClick="btnSave_Click" />
                                            <%--   <asp:Button ID="btnSave" Text="Submit" runat="server" CssClass="btn btn-primary" />--%>
                                        </div>
                                    </div>

                                </asp:Panel>

                                <asp:Panel ID="formpanal" runat="server">
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-4 col-sm-10"></div>
                                            <div class="col-sm-4 col-sm-10">
                                                <asp:Button ID="btnconfirm" runat="server" CssClass="btn btn-primary" Text="Confirm" OnClick="btnConfirm_Click" />
                                                <%-- OnClick="btnConfirm_Click"--%>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <div class="col-sm-4 col-sm-10"></div>
                                            <div class="col-sm-4 col-sm-10">
                                                <asp:Button ID="btnQuery" runat="server" CssClass="btn btn-primary" Text="Query" OnClick="btnQuery_Click" />
                                                <%--  OnClick="btnQuery_Click"--%>
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
                                                                <th>Bank Name</th>
                                                                <th>Transaction Amt
                                                                </th>
                                                                <th>Service Charges Amt
                                                                </th>
                                                                <th>CP Share(%)</th>
                                                                <th>CP Share Amt
                                                                </th>
                                                                <th>Recovery</th>
                                                                <th>FinalCP Share Amt
                                                                </th>
                                                                <th>TDS</th>
                                                                <th>Gst</th>
                                                                <th>Net Amt</th>

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
                                                                <asp:Label ID="Label9" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("ServiceChargesAmt").ToString()) ? "-" : Eval("ServiceChargesAmt"))%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label10" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("CPSharePer").ToString()) ? "-" : Eval("CPSharePer"))%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label11" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("CPShareAmt ").ToString()) ? "-" : Eval("CPShareAmt "))%>'></asp:Label>
                                                            </td>

                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("Recovery").ToString()) ? "-" : Eval("Recovery"))%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label5" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("FinalCPShareAmt ").ToString()) ? "-" : Eval("FinalCPShareAmt "))%>'></asp:Label>
                                                            </td>

                                                            <td>
                                                                <asp:Label ID="Label12" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("TDS ").ToString()) ? "-" : Eval("TDS"))%>'></asp:Label>
                                                            </td>

                                                            <td>
                                                                <asp:Label ID="Label13" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("Gst").ToString()) ? "-" : Eval("Gst"))%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label14" runat="server" Text='<%#(String.IsNullOrEmpty(Eval("NetCPShareAmt ").ToString()) ? "-" : Eval("NetCPShareAmt "))%>'></asp:Label>
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
            var serviceschargeAmt = parseFloat(document.getElementById('<%= txtservicesCharges.ClientID %>').value) || 0;
            var CPPercent = parseFloat(document.getElementById('<%= txtCPshareper.ClientID %>').value) || 0;
            var CPShareAmt = (serviceschargeAmt * CPPercent) / 100;
            document.getElementById('<%= txtcpshareAmt.ClientID %>').value = CPShareAmt.toFixed(2);
            document.getElementById('<%= hdnCpshareAmt.ClientID %>').value = CPShareAmt.toFixed(2);

            var CPShareAmt = parseFloat(document.getElementById('<%= txtcpshareAmt.ClientID %>').value) || 0;
            var Recovery = parseFloat(document.getElementById('<%= txtrecovery.ClientID %>').value) || 0;
            var finalCpSharAmt = (CPShareAmt - Recovery);
            document.getElementById('<%= txtfinalcpamt.ClientID %>').value = finalCpSharAmt.toFixed(2);
            document.getElementById('<%= hdnfinalcpamt.ClientID %>').value = finalCpSharAmt.toFixed(2);

            var finalCpSharAmt = parseFloat(document.getElementById('<%= txtfinalcpamt.ClientID %>').value) || 0;
            var tdsamt = parseFloat(document.getElementById('<%= txttds.ClientID %>').value) || 0;
            var tdsAmttoal = (finalCpSharAmt * tdsamt) / 100;
            //document.getElementById('<%= txttds.ClientID %>').value = tdsAmttoal.toFixed(2);

            var finalCpSharAmt = parseFloat(document.getElementById('<%= txtfinalcpamt.ClientID %>').value) || 0;
            var Gstamt = parseFloat(document.getElementById('<%= txtgst.ClientID %>').value) || 0;
            var totalgst = (finalCpSharAmt * Gstamt) / 100;
           // document.getElementById('<%= txtgst.ClientID %>').value = totalgst.toFixed(2);

            var finalCpSharAmt = parseFloat(document.getElementById('<%= txtfinalcpamt.ClientID %>').value) || 0;
            //var tdsamt1 = parseFloat(document.getElementById('<%= txttds.ClientID %>').value = tdsAmttoal.toFixed(2)) || 0;
            //var totalgst1 = parseFloat(document.getElementById('<%= txttds.ClientID %>').value = totalgst.toFixed(2)) || 0;
            var TotalAmt = (finalCpSharAmt - tdsAmttoal + totalgst);
            document.getElementById('<%= txttotalCpAmt.ClientID %>').value = TotalAmt.toFixed(2);
            document.getElementById('<%= hdntotalcpamt.ClientID %>').value = TotalAmt.toFixed(2);

        }

        function calculateGst() {
            var finalCpSharAmt = parseFloat(document.getElementById('<%= txtfinalcpamt.ClientID %>').value) || 0;
            var tdsamt = parseFloat(document.getElementById('<%= txttds.ClientID %>').value) || 0;
            var tdsAmttoal = (finalCpSharAmt * tdsamt) / 100;
            //document.getElementById('<%= txttds.ClientID %>').value = tdsAmttoal.toFixed(2);

            var finalCpSharAmt = parseFloat(document.getElementById('<%= txtfinalcpamt.ClientID %>').value) || 0;
            var Gstamt = parseFloat(document.getElementById('<%= txtgst.ClientID %>').value) || 0;
            var totalgst = (finalCpSharAmt * Gstamt) / 100;
           // document.getElementById('<%= txtgst.ClientID %>').value = totalgst.toFixed(2);

            var finalCpSharAmt = parseFloat(document.getElementById('<%= txtfinalcpamt.ClientID %>').value) || 0;
            //var tdsamt1 = parseFloat(document.getElementById('<%= txttds.ClientID %>').value = tdsAmttoal.toFixed(2)) || 0;
            //var totalgst1 = parseFloat(document.getElementById('<%= txttds.ClientID %>').value = totalgst.toFixed(2)) || 0;
            var TotalAmt = (finalCpSharAmt - tdsAmttoal + totalgst);
            document.getElementById('<%= txttotalCpAmt.ClientID %>').value = TotalAmt.toFixed(2);
            document.getElementById('<%= hdntotalcpamt.ClientID %>').value = TotalAmt.toFixed(2);
        }
</script>
</asp:Content>






