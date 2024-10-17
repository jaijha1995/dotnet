<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageProfile.aspx.cs" Inherits="ManageJourneyMaster" %>

<%-- Add content controls here --%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <%--    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.11.5/css/jquery.dataTables.min.css">--%>
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
            <h2>Manage Profile</h2>
        </div>
        <asp:HiddenField ID="hdnPanCardPath" runat="server" />
        <asp:HiddenField ID="hdnAadharCardPath" runat="server" />
        <asp:HiddenField ID="hdnGstPath" runat="server" />
        <div class="cl-mcont">
            <div class="row">
                <div class="col-sm-12 col-md-12">
                    <div class="blockflat_d">
                        <div class="block-flat-offer">
                            <div class="content">
                                <div class="row">
                                    <div class="form-group">
                                        <label for="inputEmail3" class="col-sm-2 control-label">
                                            Name <span class="redmark">*</span></label>
                                        <div class="col-sm-4">
                                            <asp:TextBox runat="server" ID="textName" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="textName"
                                                Display="Dynamic" ErrorMessage="Please enter the name in Upper Case" ValidationGroup="insert"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label">
                                            Company Name 
                                        </label>
                                        <div class="col-sm-4">
                                            <asp:HiddenField runat="server" ID="hdn_Id" Value="0" />
                                            <asp:TextBox runat="server" ID="txtcompany" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtcompany"
                                                Display="Dynamic" ErrorMessage="Please enter the Company Name " ValidationGroup="insert"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="txtDestination">
                                            Contact No
                                        </label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtcontactNo" runat="server" CssClass="form-control" OnKeyPress="return isNumberKey(event)" MaxLength="10"></asp:TextBox>
                                            <span id="contactError" style="color: red; display: none;">Contact number must be 10 digits long.</span>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="ddlDeparture">
                                            Address<span class="redmark">*</span>
                                        </label>
                                        <div class="col-sm-4">
                                            <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RvfddlAirlineCode" runat="server" ControlToValidate="txtAddress"
                                                Display="Dynamic" ErrorMessage="Please enter the Address " ValidationGroup="insert"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="ddlDeparture">
                                            City <span class="redmark">*</span>
                                        </label>
                                        <div class="col-sm-4">
                                            <asp:TextBox runat="server" ID="txtcity" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RVFtxtcity" runat="server" ControlToValidate="txtcity"
                                                Display="Dynamic" ErrorMessage="Please enter the City " ValidationGroup="insert"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="CanbinCode">
                                            State
                                        </label>
                                        <div class="col-sm-4">
                                            <asp:TextBox runat="server" ID="txtstate" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtstate"
                                                Display="Dynamic" ErrorMessage="Please enter the State " ValidationGroup="insert"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label " for="CanbinCode">
                                            Upload Pan Card
                                        </label>
                                        <div class="col-sm-4">
                                            <asp:FileUpload ID="Uploadpancard" class="form-control" runat="server" AllowMultiple="True" />
                                            <asp:Label ID="lblPanCard" runat="server" Text="" Visible="true"></asp:Label>
                                            <!-- Existing file info -->
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="CanbinCode">
                                            Upload Adhar Card
                                        </label>
                                        <div class="col-sm-4">
                                            <asp:FileUpload ID="UploadAdharcaard" class="form-control" runat="server" AllowMultiple="True" />
                                            <asp:Label ID="lblAadharCard" runat="server" Text="" Visible="true"></asp:Label>
                                            <!-- Existing file info -->
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="CanbinCode">
                                            Upload GST
                                        </label>
                                        <div class="col-sm-4">
                                            <asp:FileUpload ID="UploadGst" class="form-control" runat="server" AllowMultiple="True" />
                                            <asp:Label ID="lblGST" runat="server" Text="" Visible="true"></asp:Label>
                                            <!-- Existing file info -->
                                        </div>
                                    </div>


                                    <div class="form-group">
                                        <label class="col-sm-2 control-label">
                                        </label>
                                        <div class="col-sm-2" runat="server" id="divSave" visible="true">
                                            <asp:Button ID="btnsave" runat="server" ValidationGroup="insert" CssClass="btn btn-primary" Text="Save" OnClick="btnsave_Click" />
                                            <%-- OnClick="btnsave_Click"--%>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-sm-12 col-md-12">
                                    <div class="block-flat" runat="server" id="divgrid" visible="true">
                                        <contenttemplate>
                                            <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                            <asp:GridView ID="GridApplyCoupon" runat="server" GridLines="None" ShowFooter="false"
                                                RowStyle-VerticalAlign="Middle" AutoGenerateColumns="false" CssClass="table tablesorter table-bordered table-striped table-hover"
                                                Width="100%" ShowHeader="true" OnRowDeleting="GridApplyCoupon_RowDeleting"
                                                OnRowEditing="GridApplyCoupon_RowEditing" OnRowDataBound="GridApplyCoupon_RowDataBound"
                                                OnRowCommand="GridApplyCoupon_RowCommand"
                                                PagerStyle-CssClass="paging">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <thead>
                                                                <th></th>
                                                                <th>Profile Name
                                                                </th>
                                                                <th>Company Name
                                                                </th>
                                                                <th>Contact No
                                                                </th>
                                                                <th>Address
                                                                </th>
                                                                <th>City
                                                                </th>
                                                                <th>State
                                                                </th>
                                                                <th>Pan Card</th>
                                                                <th>Aadhar Card</th>
                                                                <th>GST</th>
                                                                <th colspan="2">Action
                                                                </th>
                                                            </thead>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblId" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ProfileId")%>'></asp:Label>
                                                            <td>
                                                                <asp:Label ID="lblprofilename" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ProfileName")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Labelcompanyname" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CompanyName")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblContactNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ContactNo")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblAddress" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Address")%>'></asp:Label>

                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblcity" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"City")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblstate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"State")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="lnkPanCardDownload" runat="server" CommandArgument='<%# Eval("PanCard") %>'
                                                                    OnClick="DownloadFile" Text="Download Pan Card"></asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                  <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("AddharCard") %>'
                                                                    OnClick="DownloadAddharcard" Text="Download Addhar Card"></asp:LinkButton>

                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("Gst") %>'
                                                                    OnClick="DownloadGst" Text="Download Gst"></asp:LinkButton>
                                                               
                                                            </td>

                                                            <td>
                                                                <asp:LinkButton ID="lnkbnEdit" CommandName="Edit" CommandArgument='<%# Eval("ProfileId")%>'
                                                                    runat="server" CssClass="btn btn-primary">Edit</asp:LinkButton>

                                                                <asp:LinkButton ID="lnkbnDelete" CommandArgument='<%# Eval("ProfileId") %>' CommandName="Delete"
                                                                    CssClass="btn btn-primary" runat="server" OnClientClick="return confirm('Are you sure? you want to delete')">Delete</asp:LinkButton>
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

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/jquery.dataTables.min.js"></script>

    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.11.5/css/jquery.dataTables.min.css">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#ctl00_ContentPlaceHolder1_GridApplyCoupon').DataTable({
                paging: true, // Enable pagination
                searching: true, // Enable searching
                columnDefs: [
                    { targets: '_all', defaultContent: "" }
                ]
            });
        });
    </script>
</asp:Content>



