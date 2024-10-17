<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SideMenu.ascx.cs" Inherits="UserControl_SideMenu" %>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">
<script type="text/javascript">

    $(document).ready(function () {

        $('.cl-vnavigation li a').click(function () {

            var liId = $(this).attr('id');
            localStorage.setItem('thisLink', liId);

        });

        var url = window.location.pathname;

        url = url.substring(url.lastIndexOf('/') + 1);
        var id = url.split('.')[0];

        var thisLink = localStorage.getItem('thisLink');
        // alert(thisLink);
        // $('#' + thisLink).removeClass('but_class1');
        $('#' + thisLink).parents().addClass('active');


        $('.cl-vnavigation li a').on("click", function (e) {
            $(this).next('ul').toggle();
            e.stopPropagation();
            //e.preventDefault();
        });

    });

</script>
<style>
    .sub-menu-two {
        padding-left: 15px !important;
    }
</style>
<style>
    /* width */
    ::-webkit-scrollbar {
        width: 5px;
    }

    /* Track */
    ::-webkit-scrollbar-track {
        background: #f1f1f1;
    }

    /* Handle */
    ::-webkit-scrollbar-thumb {
        background: #2494F2;
    }

        /* Handle on hover */
        ::-webkit-scrollbar-thumb:hover {
            background: #555;
        }
</style>
<div class="cl-sidebar" data-position="right" data-step="1" data-intro="<strong>Fixed Sidebar</strong> <br/> It adjust to your needs.">
    <div class="cl-toggle"><i class="fa fa-bars"></i></div>
    <div class="cl-navblock">
        <div class="menu-space" style="position:fixed!important;height: 320px">
             <div class="content" style="right: -21px; float: left; height: 100%; overflow-y: auto;">
                <div class="side-user">
                    <div class="avatar">
                        <img src="../images/wincapital_logo1.png" />
                        <%--<img src="images/avatar1_50.jpg" alt="Avatar" />--%>
                    </div>
                    <div class="info">
                        <a href="#">
                            <asp:Label runat="server" ID="lblUserName"></asp:Label></a>
                        <img src="images/state_online.png" alt="Status" />
                        <span>Online</span>
                    </div>
                </div>
                <ul class="cl-vnavigation">
                    <li><a href="default.aspx"><i class="fa fa-home"></i><span>Dashboard</span></a>
                    </li>
                    <li id="liCreateUser" runat="server">
                        <a href="CreateUser.aspx"><i class="fa fa-user" aria-hidden="true"></i><span>Create User</span></a>
                    </li>

                    <li id="limanageprofile" runat="server">
                        <a href="ManageProfile.aspx"><i class="fa fa-check-circle" aria-hidden="true"></i><span>Manage Profile</span></a>
                    </li>

                    <li id="liCreateCustomerID" runat="server">
                        <a href="ManageCustomerID.aspx"><i class="fa fa-id-badge" aria-hidden="true"></i><span>Manage CustomerID</span></a>
                    </li>

                    <li id="liloantype" runat="server">
                        <a href="Loantype.aspx"><i class="fa fa-clipboard-list" aria-hidden="true"></i><span>Manages Loan Type</span></a>
                    </li>

                    <li id="Linankname" runat="server">
                        <a href="ManageBankMaster.aspx"><i class="fa fa-clipboard-list" aria-hidden="true"></i><span>Manage Bank Name</span></a>
                    </li>
                    <li id="lileads" runat="server">
                        <a href="ManagesLeads.aspx"><i class="fa fa-file-invoice-dollar" aria-hidden="true"></i><span>Manage Leads Data</span></a>
                    </li>

                    <li id="customerstausAdmin" runat="server">
                        <a href="ManageCustomerStatus.aspx"><i class="fa fa-user-check" aria-hidden="true"></i><span>Customer Status</span></a>
                    </li>
                    <li id="CustomerstausUser" runat="server">
                        <a href="FinancialInstitution.aspx"><i class="fa fa-building" aria-hidden="true"></i><span>Financial Institution Payout</span></a>
                    </li>

                    <li id="Liservicecharges" runat="server">
                        <a href="ServicesCharges.aspx"><i class="fa fa-dollar-sign" aria-hidden="true"></i><span>Manage Service Charges </span></a>
                    </li>

                    <li id="uploadRotlist" runat="server">
                        <a href="UploadRouteList.aspx"><i class="fa fa-file-invoice" aria-hidden="true"></i><span>Upload Invoices Financial</span></a>
                    </li>

                    <li id="Li2" runat="server">
                        <a href="UploadFileServices.aspx"><i class="fa fa-clipboard-list" aria-hidden="true"></i><span>Upload Invoices Services</span></a>
                    </li>
                </ul>
            </div>
        </div>
        <div class="text-right collapse-button">

            <button type="button" id="sidebar-collapse" class="btn btn-default" style=""><i style="color: #fff;" class="fa fa-angle-left"></i></button>
        </div>
    </div>
</div>

