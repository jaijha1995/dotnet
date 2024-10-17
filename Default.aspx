<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid" id="pcont">
        <div class="cl-mcont">
            <div class="jumbotron text-center">
                <h2 class="display-4">
                    <% if (Session["UserId"] != null)
                        { %>
                        Welcome to this CRM, <%= Session["UserId"].ToString() %>!
                   
                    <% }
                    else
                    { %>
                        Welcome to this CRM!
                   
                    <% } %>
                </h2>
            </div>
        </div>
    </div>
</asp:Content>

