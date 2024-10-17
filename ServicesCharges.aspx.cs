using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ServicesCharges : System.Web.UI.Page
{
    whitelable Whitelable = new whitelable();
    whitelabelHelper WhitelabelHelper = new whitelabelHelper();
    ServicesMaster servicescharges = new ServicesMaster();
    ManageLeadsData leadsData = new ManageLeadsData();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (object.Equals(Session["UserId"], null))
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            BindGrid();
            Bindleadid();
           // BindBankName();
            //BindCustomerId();
            if (Session["roleType"].ToString() == "A")
            {
                FormPanel.Style["display"] = "block";
            }
            else
            {
                FormPanel.Style["display"] = "none";

            }


            if (Session["roleType"].ToString() == "A")
            {
                formpanal.Style["display"] = "none";
            }
            else
            {
                formpanal.Style["display"] = "block";

            }
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {

        try
        {
            DataTable dt = new DataTable();
            servicescharges.LeadID = Convert.ToInt32(ddlleadId.Text);
            servicescharges.CustomerID = Convert.ToInt32(txtuserid.Text);
            servicescharges.CustomerName = txtname.Text.Trim();
            servicescharges.ContactNo = txtcontactno.Text.Trim();
            servicescharges.City = txtcity.Text.Trim();
            servicescharges.State = txtstate.Text.Trim();
            servicescharges.BankName = txtbankname.Text.Trim();
            decimal transactionAmt;
            decimal ServicsAmt;
            decimal Cpshareamt;
            decimal Cpshareper;
            decimal recovery;
            decimal fpAmt;
            decimal tds;
            decimal gst;
            decimal totalPayout;
            decimal.TryParse(txttranAmt.Text.Trim(), out transactionAmt);
            decimal.TryParse(txtservicesCharges.Text.Trim(), out ServicsAmt);
    
            decimal.TryParse(txtCPshareper.Text.Trim(), out Cpshareper);
            decimal.TryParse(hdnCpshareAmt.Value, out Cpshareamt);
            decimal.TryParse(txtrecovery.Text.Trim(), out recovery);
            decimal.TryParse(hdnfinalcpamt.Value, out fpAmt);
            decimal.TryParse(txttds.Text.Trim(), out tds);
            decimal.TryParse(txtgst.Text.Trim(), out gst);
            decimal.TryParse(hdntotalcpamt.Value, out totalPayout);
            servicescharges.TransactionAmt = transactionAmt;
            servicescharges.ServiceChargesAmt = ServicsAmt;
            servicescharges.CPSharePer = Cpshareper;
            servicescharges.CPShareAmt = Cpshareamt;
            servicescharges.Recovery = recovery;
            servicescharges.FinalCPShareAmt = fpAmt;
            servicescharges.TDS = tds;
            servicescharges.Gst = gst;
            servicescharges.NetCPShareAmt = totalPayout;
            servicescharges.CreateUser = txtcreateuser.Text.Trim();
            servicescharges.RoleType = txtroltype.Text.Trim();

            if (btnsave.Text == "Submit")
            {
                servicescharges.Type = "I";
                dt = WhitelabelHelper.InsertServiceMaster(servicescharges);

                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", "alert('Data Saved Successfully !!');", true);
            }
            else if (btnsave.Text == "Update")
            {
                servicescharges.Type = "U";
                servicescharges.Id = Convert.ToInt32(hdn_Id.Value);
                dt = WhitelabelHelper.InsertServiceMaster(servicescharges);
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", "alert('Data Updated Successfully. !!');", true);
                hdn_Id.Value = "0";
            }
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ScrollTop();", true);
            BindGrid();
            txtuserid.Text = "";
            txtname.Text = "";
            txtcontactno.Text = "";
            txtcity.Text = "";
            txtstate.Text = "";
            txttranAmt.Text = "";
            txtservicesCharges.Text = "";
            txtCPshareper.Text = "";
            txtcpshareAmt.Text = "";
            txtrecovery.Text = "";
            txtfinalcpamt.Text = "";
            txtgst.Text = "";
            txttotalCpAmt.Text = "";
            txtcreateuser.Text = "";
            txtroltype.Text = "";
            txttds.Text = "";

        }
        catch (Exception ex)
        {

        }
    }



    protected void txtuserid_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            leadsData.Type = "M";
            leadsData.LeadID = Convert.ToInt32(ddlleadId.SelectedValue);
            DataTable dtCustomerDetails = WhitelabelHelper.GetCustomerDetailsByleadId(leadsData);

            if (dtCustomerDetails != null && dtCustomerDetails.Rows.Count > 0)
            {
                txtuserid.Text = dtCustomerDetails.Rows[0]["CustomerID"].ToString();
                txtname.Text = dtCustomerDetails.Rows[0]["CustomerName"].ToString();
                txtstate.Text = dtCustomerDetails.Rows[0]["State"].ToString();
                txtcity.Text = dtCustomerDetails.Rows[0]["City"].ToString();
                txtcontactno.Text = dtCustomerDetails.Rows[0]["ContactNo"].ToString();
                txtbankname.Text = dtCustomerDetails.Rows[0]["BankName"].ToString();
                txtcreateuser.Text = dtCustomerDetails.Rows[0]["CreateUser"].ToString();
                txtroltype.Text = dtCustomerDetails.Rows[0]["RoleType"].ToString();
            }
            else
            {
                txtname.Text = string.Empty;
                txtcity.Text = string.Empty;
                txtcontactno.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "An error occurred: " + ex.Message;
            lblMsg.Visible = true;
        }
    }

    private void Bindleadid()
    {
        try
        {
            Whitelable.Type = "L";
            DataTable dt = WhitelabelHelper.GetLeadID(Whitelable);

            if (dt != null && dt.Rows.Count > 0)
            {
  

                ddlleadId.DataSource = dt;
                ddlleadId.DataTextField = "LeadID";
                ddlleadId.DataValueField = "LeadID";
                ddlleadId.DataBind();
                ddlleadId.Items.Insert(0, "--Select Lead Id--");
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "An error occurred: " + ex.Message;
            lblMsg.Visible = true;
        }
    }


    private void BindGrid()
    {

        if (Session["roleType"].ToString() == "U")
        {
            DataTable dtAllData = new DataTable();
            servicescharges.Type = "S";
            servicescharges.Id = int.Parse(hdn_Id.Value);
            servicescharges.CreateUser = Session["UserId"].ToString();
            servicescharges.RoleType = Session["roleType"].ToString();
            dtAllData = WhitelabelHelper.GetServicesAmt(servicescharges);
            if (!object.Equals(dtAllData, null))
            {
                if (dtAllData.Rows.Count > 0)
                {
                    lblMsg.Visible = false;
                    GridCreateUser.Visible = true;
                    GridCreateUser.DataSource = dtAllData;
                    GridCreateUser.DataBind();
                }
                else
                {
                    lblMsg.Visible = true;
                    GridCreateUser.Visible = false;
                    lblMsg.Text = "No Records !!";
                }
            }
        }
        else if (Session["roleType"].ToString() == "A")
        {
            DataTable dtAllData = new DataTable();
            servicescharges.Type = "S";
            servicescharges.Id = int.Parse(hdn_Id.Value);
            servicescharges.RoleType = Session["roleType"].ToString();
            dtAllData = WhitelabelHelper.GetServicesAmt(servicescharges);
            if (!object.Equals(dtAllData, null))
            {
                if (dtAllData.Rows.Count > 0)
                {
                    lblMsg1.Visible = false;
                    GridCreateUser.Visible = true;
                    GridCreateUser.DataSource = dtAllData;
                    GridCreateUser.DataBind();
                }
                else
                {
                    lblMsg1.Visible = true;
                    GridCreateUser.Visible = false;
                    lblMsg1.Text = "No Records !!";
                }
            }

        }



    }

    protected void GridCreateUser_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Delete"))
        {
            DataTable dt = new DataTable();
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            Label lblId = (Label)row.FindControl("lblId");
            servicescharges.Type = "D";
            servicescharges.Id = Convert.ToInt32(lblId.Text);
            //Whitelable.websiteId = Session["websiteId"].ToString();
            dt = WhitelabelHelper.InsertServiceMaster(servicescharges);
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", "alert('Record  Deleted successfully. !!');", true);
            BindGrid();
        }
        else if (e.CommandName.Equals("Edit"))
        {

            DataTable dt = new DataTable();


            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            Label lblId = (Label)row.FindControl("lblId");
            servicescharges.Type = "E";
            servicescharges.Id = Convert.ToInt32(lblId.Text);
            dt = WhitelabelHelper.EditServiceData(servicescharges);
            if (dt.Rows.Count > 0)
            {

                ddlleadId.SelectedValue = dt.Rows[0]["LeadID"].ToString();
                txtuserid.Text = dt.Rows[0]["CustomerID"].ToString();
                txtname.Text = dt.Rows[0]["CustomerName"].ToString();
                txtcontactno.Text = dt.Rows[0]["ContactNo"].ToString();
                txtcity.Text = dt.Rows[0]["City"].ToString();
                txtstate.Text = dt.Rows[0]["State"].ToString();
                txtbankname.Text = dt.Rows[0]["BankName"].ToString();
                txttranAmt.Text = dt.Rows[0]["TransactionAmt"].ToString();
                txtservicesCharges.Text = dt.Rows[0]["ServiceChargesAmt"].ToString();
                txtCPshareper.Text = dt.Rows[0]["CPSharePer"].ToString();
                txtcpshareAmt.Text = dt.Rows[0]["CPShareAmt"].ToString();
                txtrecovery.Text = dt.Rows[0]["Recovery"].ToString();
                txtfinalcpamt.Text = dt.Rows[0]["FinalCPShareAmt"].ToString();
                txttds.Text = dt.Rows[0]["TDS"].ToString();
                txtgst.Text = dt.Rows[0]["Gst"].ToString();
                txttotalCpAmt.Text = dt.Rows[0]["NetCPShareAmt"].ToString();
                txtcreateuser.Text = dt.Rows[0]["CreateUser"].ToString();
                txtroltype.Text = dt.Rows[0]["RoleType"].ToString();

                hdnCpshareAmt.Value = dt.Rows[0]["CPShareAmt"].ToString();
                hdnfinalcpamt.Value = dt.Rows[0]["FinalCPShareAmt"].ToString();
                hdntotalcpamt.Value = dt.Rows[0]["NetCPShareAmt"].ToString();

                btnsave.Text = "Update";
                hdn_Id.Value = lblId.Text;

            }
            else
            {
                GridCreateUser.Visible = false;
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", "alert('No Record !!');", true);
            }
        }

    }


    protected void GridCreateUser_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkbnEdit = (LinkButton)e.Row.FindControl("lnkbnEdit");
            LinkButton lnkbnDelete = (LinkButton)e.Row.FindControl("lnkbnDelete");
            if (Session["roleType"] != null)
            {
                string roleType = Session["roleType"].ToString();
                if (roleType == "U")
                {
                    lnkbnEdit.Visible = false;
                    lnkbnDelete.Visible = false;

                }
                else if (roleType == "A")
                {
                    lnkbnEdit.Visible = true;
                    lnkbnDelete.Visible = true;
                }
            }
        }
    }

    protected void GridCreateUser_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void GridCreateUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void GridCreateUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void ddl_accountno_SelectedIndexChanged(object sender, EventArgs e)
    {
        //BindGrid();
        //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "callmulty();", true);
    }


    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtAllData = new DataTable();
            servicescharges.Type = "S";
            servicescharges.CreateUser = Session["UserId"].ToString();
            servicescharges.RoleType = Session["roleType"].ToString();
            dtAllData = WhitelabelHelper.GetServicesAmt(servicescharges);

            if (dtAllData != null && dtAllData.Rows.Count > 0)
            {
                string Roletype = dtAllData.Rows[0]["RoleType"].ToString();
                string createUser = dtAllData.Rows[0]["CreateUser"].ToString();
                string bankname = dtAllData.Rows[0]["BankName"].ToString();
                string leadID = dtAllData.Rows[0]["LeadID"].ToString();
                string servicesId = dtAllData.Rows[0]["Id"].ToString();
                string name = dtAllData.Rows[0]["CustomerName"].ToString();
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("mail27.skylabstech.com");
                mail.From = new MailAddress("jai@skylabstech.com");
                mail.To.Add("Finance1.wincapital@gmail.com");
                mail.Subject = "Loan Confirmation for service lead ID: " + leadID;
                mail.Body = String.Format("Dear {0},\n\nYour lead with ID {1} has been confirmed with an Roaltype of {2}.\n\nBest regards,\nYour BankName{3}.\n\n loan with Id{4}.\n\n service Customer name{0}.\n\nMy loan is confirmed", name,  leadID, Roletype, bankname, servicesId);
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("jai@skylabstech.com", "Hello@12345");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                Response.Write("<script>alert('Email Sent Successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('No Records Found to Send Email');</script>");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
        }
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtAllData = new DataTable();
            servicescharges.Type = "S";
            servicescharges.CreateUser = Session["UserId"].ToString();
            servicescharges.RoleType = Session["roleType"].ToString();
            dtAllData = WhitelabelHelper.GetServicesAmt(servicescharges);

            if (dtAllData != null && dtAllData.Rows.Count > 0)
            {
                string Roletype = dtAllData.Rows[0]["RoleType"].ToString();
                string createUser = dtAllData.Rows[0]["CreateUser"].ToString();
                string bankname = dtAllData.Rows[0]["BankName"].ToString();
                string leadID = dtAllData.Rows[0]["LeadID"].ToString();
                string servicesId = dtAllData.Rows[0]["Id"].ToString();
                string name = dtAllData.Rows[0]["CustomerName"].ToString();
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("mail27.skylabstech.com");
                mail.From = new MailAddress("jai@skylabstech.com");
                mail.To.Add("Finance1.wincapital@gmail.com");
                mail.Subject = "Query regarding to loan for lead ID: " + leadID;
                mail.Body = String.Format("Dear {0},\n\nYour lead with ID {1} has been confirmed with an Roaltype of {2}.\n\nBest regards,\nYour BankName{3}.\n\n loan with Id{4}.\n\n service Customer name{0}.\n\n Query regarding to loan", name, leadID, Roletype, bankname, servicesId);
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("jai@skylabstech.com", "Hello@12345");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                Response.Write("<script>alert('Email Sent Successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('No Records Found to Send Email');</script>");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
        }
    }
}