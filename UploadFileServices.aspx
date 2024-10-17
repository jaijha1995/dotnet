<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UploadFileServices.aspx.cs" Inherits="UploadFileServices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        @media (min-width: 768px) {
            .col-sm-offset-3 {
                margin-left: 15%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid" id="pcont">
        <div class="page-head">
            <h2>Upload Services List</h2>
        </div>
        <div class="cl-mcont">
            <%--class="cl-mcont"--%>
            <div class="row">
                <div class="col-sm-12 col-md-12">
                    <div class="blockflat_d">
                        <div class="block-flat">
                            <%--class="block-flat"--%>
                            <div class="content">
                                <div class="form-group" style="text-align:right">
                                     <asp:Button ID="btndownload" Text="DownLoad Latest File" runat="server" CssClass="btn btn-primary" OnClick="btndownload_Click" />   <%--  OnClick="btndownload_Click" --%>
                                </div>
                              <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                  <div class="form-group">
                                            <label class="col-sm-2 control-label">
                                              Services Id
                                            </label>
                                            <div class="col-sm-4">

                                                <asp:DropDownList ID="txtuserid" AutoPostBack="true" runat="server" CssClass="form-control" >
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                <div style="clear: both; height: 5px;">
                                </div>
                                <div class="form-group">
                                    <div>
                                        <label for="inputEmail3" class="col-sm-2 control-label">
                                            Upload Excel File <span class="redmark">*</span></label>
                                        <div class="col-sm-4">
                                            <asp:FileUpload ID="fileuploadExcel" class="col-sm-2 control-label" ClientIDMode="Static" CssClass="flying_txt"
                                                Font-Size="13px" runat="server" />
                                            <asp:RequiredFieldValidator ID="RFVExcelFile" runat="server" ErrorMessage="*" ControlToValidate="fileuploadExcel"
                                                ValidationGroup="Excel"></asp:RequiredFieldValidator>
                                         
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-offset-3 col-sm-10">
                                        <div class="col-sm-1">
                                            <asp:Button ID="btnUploadOffer" Text="Add" runat="server" CssClass="btn btn-primary" OnClick="btnUploadOffer_OnClick"/>   <%-- OnClick="btnUploadOffer_OnClick"--%>
                                            <asp:ValidationSummary ID="ValidationSummary12" runat="server" ShowMessageBox="true"
                                                ShowSummary="false" ValidationGroup="Excel" />
                                        </div>                                  
                                    </div>
                                    <div class="col-sm-offset-4 col-sm-10">

                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true"
                                            ShowSummary="false" ValidationGroup="Excel" />
                                    </div>
                                </div>
                            </div>
                            <div style="clear: both;">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
