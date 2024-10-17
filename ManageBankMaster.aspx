<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageBankMaster.aspx.cs" Inherits="ManageBankMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid" id="pcont">
        <div class="page-head">
            <h2>Manage Bank Name</h2>
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
                                            Bank Name<span class="redmark">*</span></label>
                                        <div class="col-sm-4">
                                            <asp:TextBox runat="server" ID="textName" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="textName"
                                                Display="Dynamic" ErrorMessage="Please enter the Bank Name" ValidationGroup="insert"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label">
                                            Bank Code 
                                       <span class="redmark">*</span></label>
                                        <div class="col-sm-4">
                                            <asp:HiddenField runat="server" ID="hdn_Id" Value="0" />
                                            <asp:TextBox runat="server" ID="txtcompany" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtcompany"
                                                Display="Dynamic" ErrorMessage="Please enter the Bank Code" ValidationGroup="insert"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                </div>

                                <div class="row">
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
                                                RowStyle-VerticalAlign="Middle" AutoGenerateColumns="false" CssClass="table table-striped table-hover fill-head"
                                                Width="100%" ShowHeader="true" PageSize="30" OnRowDeleting="GridApplyCoupon_RowDeleting"
                                                OnRowEditing="GridApplyCoupon_RowEditing" OnRowDataBound="GridApplyCoupon_RowDataBound"
                                                OnRowCommand="GridApplyCoupon_RowCommand"
                                                PagerStyle-CssClass="paging">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <thead>
                                                                <th></th>

                                                                <th>Bank Name
                                                                </th>
                                                                <th>Bank Code
                                                                </th>
                                                                <th colspan="2">Action
                                                                </th>
                                                            </thead>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblId" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"BankId")%>'></asp:Label>
                                                            <td>
                                                                <asp:Label ID="lblprofilename" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"BankName")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Labelcompanyname" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Bankcode")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="lnkbnEdit" CommandName="Edit" CommandArgument='<%# Eval("BankId")%>'
                                                                    runat="server" CssClass="btn btn-primary">Edit</asp:LinkButton>
                                                                <asp:LinkButton ID="lnkbnDelete" CommandArgument='<%# Eval("BankId") %>' CommandName="Delete"
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
