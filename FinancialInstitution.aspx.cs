using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FinancialInstitution : System.Web.UI.Page
{
    whitelable Whitelable = new whitelable();
    whitelabelHelper WhitelabelHelper = new whitelabelHelper();
    SFinancialMaster financialdata = new SFinancialMaster();
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
            financialdata.LeadID = Convert.ToInt32(ddlleadId.Text);
            financialdata.CustomerID = Convert.ToInt32(txtuserid.Text);
            financialdata.CustomerName = txtname.Text.Trim();
            financialdata.ContactNo = txtcontactno.Text.Trim();
            financialdata.City = txtcity.Text.Trim();
            financialdata.State = txtstate.Text.Trim();
            financialdata.BankName = txtbankname.Text.Trim();
            decimal transactionAmt;
            decimal pfPercent;
            decimal pfAmt;
            decimal lpPercent;
            decimal lenderPayoutAmt;
            decimal cpPercent;
            decimal cpAmount;
            decimal recovery;
            decimal fpAmt;
            decimal tds;
            decimal gst;
            decimal totalPayout;
            decimal.TryParse(txttranAmt.Text.Trim(), out transactionAmt);
            decimal.TryParse(txtPF.Text.Trim(), out pfPercent);

            decimal.TryParse(hdnPfAmt.Value, out pfAmt);
            decimal.TryParse(txtlenderpf.Text.Trim(), out lpPercent);
            decimal.TryParse(hdnlenderAmt.Value, out lenderPayoutAmt);
            decimal.TryParse(txtchannelpay.Text.Trim(), out cpPercent);
            decimal.TryParse(hdnCpAmt.Value, out cpAmount);
            decimal.TryParse(txtrecovery.Text.Trim(), out recovery);
            decimal.TryParse(hdnfinalamt.Value, out fpAmt);
            decimal.TryParse(txttds.Text.Trim(), out tds);
            decimal.TryParse(txtgst.Text.Trim(), out gst);
            decimal.TryParse(hdntotalamt.Value, out totalPayout);
            financialdata.TransactionAmt = transactionAmt;
            financialdata.PFPercen = pfPercent;
            financialdata.PFAmt = pfAmt;
            financialdata.LPPercent = lpPercent;
            financialdata.LenderPayoutAmt = lenderPayoutAmt;
            financialdata.CPPercent = cpPercent;
            financialdata.CPAmount = cpAmount;
            financialdata.Recovery = recovery;
            financialdata.FPAmt = fpAmt;
            financialdata.TDS = tds;
            financialdata.Gst = gst;
            financialdata.TotalPayout = totalPayout;
            financialdata.CreateUser = txtcreateuser.Text.Trim();
            financialdata.RoleType = txtroltype.Text.Trim();

            if (btnsave.Text == "Submit")
            {
                financialdata.Type = "I";
                dt = WhitelabelHelper.InsertFinancialData(financialdata);

                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", "alert('Data Saved Successfully !!');", true);
            }
            else if (btnsave.Text == "Update")
            {
                financialdata.Type = "U";
                financialdata.Id = Convert.ToInt32(hdn_Id.Value);
                dt = WhitelabelHelper.InsertFinancialData(financialdata);
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
            txtPF.Text = "";
            txtpfAmt.Text = "";
            txtlenderpf.Text = "";
            txtlenPayAmt.Text = "";
            txtchannelpay.Text = "";
            txtcppay.Text = "";
            txtrecovery.Text = "";
            txtfinalpayamt.Text = "";
            txtgst.Text = "";
            txttotal.Text = "";
            txtcreateuser.Text = "";
            txtroltype.Text = "";
            txttds.Text = "";


        }
        catch (Exception ex)
        {

        }
    }


    private void BindGrid()
    {

        if (Session["roleType"].ToString() == "U")
        {
            DataTable dtAllData = new DataTable();
            financialdata.Type = "S";
            financialdata.Id = int.Parse(hdn_Id.Value);
            financialdata.CreateUser = Session["UserId"].ToString();
            financialdata.RoleType = Session["roleType"].ToString();
            dtAllData = WhitelabelHelper.GetFinancialAmt(financialdata);
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
            financialdata.Type = "S";
            financialdata.Id = int.Parse(hdn_Id.Value);
            financialdata.RoleType = Session["roleType"].ToString();
            dtAllData = WhitelabelHelper.GetFinancialAmt(financialdata);
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



    //private void BindCustomerId()
    //{
    //    try
    //    {
    //        if (Session["roleType"].ToString() == "U")
    //        {
    //            Whitelable.Type = "S";
    //            Whitelable.CreateUser = Session["UserId"].ToString();
    //            Whitelable.RoleType = Session["roleType"].ToString();
    //            DataTable dt = WhitelabelHelper.GetApplyCustomerID(Whitelable);

    //            if (dt != null && dt.Rows.Count > 0)
    //            {
    //                dt.Columns.Add("DisplayName", typeof(string));
    //                foreach (DataRow row in dt.Rows)
    //                {
    //                    row["DisplayName"] = row["CustomerName"] + " (" + row["CustomerID"] + ")";
    //                }

    //                txtuserid.DataSource = dt;
    //                txtuserid.DataTextField = "DisplayName";
    //                txtuserid.DataValueField = "CustomerID";
    //                txtuserid.DataBind();
    //            }
    //        }
    //        else if (Session["roleType"].ToString() == "A")
    //        {
    //            Whitelable.Type = "S";
    //            Whitelable.CreateUser = Session["UserId"].ToString();
    //            Whitelable.RoleType = Session["roleType"].ToString();
    //            DataTable dt = WhitelabelHelper.GetApplyCustomerID(Whitelable);

    //            if (dt != null && dt.Rows.Count > 0)
    //            {
    //                dt.Columns.Add("DisplayName", typeof(string));
    //                foreach (DataRow row in dt.Rows)
    //                {
    //                    row["DisplayName"] = row["CustomerName"] + " (" + row["CustomerID"] + ")";
    //                }

    //                txtuserid.DataSource = dt;
    //                txtuserid.DataTextField = "DisplayName";
    //                txtuserid.DataValueField = "CustomerID";
    //                txtuserid.DataBind();
    //            }

    //        }



    //    }
    //    catch (Exception ex)
    //    {
    //        lblMsg.Text = "An error occurred: " + ex.Message;
    //        lblMsg.Visible = true;
    //    }
    //}


    //private void BindBankName()
    //{
    //    try
    //    {
    //        DataTable dt = WhitelabelHelper.GetBankName();

    //        if (dt != null && dt.Rows.Count > 0)
    //        {
    //            dt.Columns.Add("BankDisplay", typeof(string), "BankName + ' (' + BankCode + ')'");
    //            txtbankname.DataSource = dt;
    //            txtbankname.DataTextField = "BankDisplay";
    //            txtbankname.DataValueField = "BankName";
    //            txtbankname.DataBind();
    //            txtbankname.Items.Insert(0, "--Select Bank Name--");

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblMsg.Text = "An error occurred: " + ex.Message;
    //        lblMsg.Visible = true;
    //    }
    //}

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
                // Clear the labels if no details are found
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
            //Whitelable.CreateUser = Session["UserId"].ToString();
            //Whitelable.RoleType = Session["roleType"].ToString();
            DataTable dt = WhitelabelHelper.GetLeadID(Whitelable);

            if (dt != null && dt.Rows.Count > 0)
            {
                //dt.Columns.Add("DisplayName", typeof(string));
                //foreach (DataRow row in dt.Rows)
                //{
                //    row["DisplayName"] = row["CustomerName"] + " (" + row["CustomerID"] + ")";
                //}

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

    protected void GridCreateUser_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Delete"))
        {
            DataTable dt = new DataTable();
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            Label lblId = (Label)row.FindControl("lblId");
            financialdata.Type = "D";
            financialdata.Id = Convert.ToInt32(lblId.Text);
            //Whitelable.websiteId = Session["websiteId"].ToString();
            dt = WhitelabelHelper.InsertFinancialData(financialdata);
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", "alert('Record  Deleted successfully. !!');", true);
            BindGrid();
        }
        else if (e.CommandName.Equals("Edit"))
        {

            DataTable dt = new DataTable();


            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            Label lblId = (Label)row.FindControl("lblId");
            financialdata.Type = "E";
            financialdata.Id = Convert.ToInt32(lblId.Text);
            dt = WhitelabelHelper.EditFinancialData(financialdata);
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
                txtPF.Text = dt.Rows[0]["PFPercent"].ToString();
                txtpfAmt.Text = dt.Rows[0]["PFAmt"].ToString();
                txtlenderpf.Text = dt.Rows[0]["LPPercent"].ToString();
                txtlenPayAmt.Text = dt.Rows[0]["LenderPayoutAmt"].ToString();
                txtchannelpay.Text = dt.Rows[0]["CPPercent"].ToString();
                txtcppay.Text = dt.Rows[0]["CPAmount"].ToString();
                txtrecovery.Text = dt.Rows[0]["Recovery"].ToString();
                txtfinalpayamt.Text = dt.Rows[0]["FPAmt"].ToString();
                txttds.Text = dt.Rows[0]["TDS"].ToString();
                txtgst.Text = dt.Rows[0]["Gst"].ToString();
                txttotal.Text = dt.Rows[0]["TotalPayout"].ToString();
                txtcreateuser.Text = dt.Rows[0]["CreateUser"].ToString();
                txtroltype.Text = dt.Rows[0]["RoalType"].ToString();

                hdnPfAmt.Value = dt.Rows[0]["PFAmt"].ToString();
                hdnlenderAmt.Value = dt.Rows[0]["LenderPayoutAmt"].ToString();
                hdnCpAmt.Value = dt.Rows[0]["CPAmount"].ToString();
                hdnfinalamt.Value = dt.Rows[0]["FPAmt"].ToString();
                hdntotalamt.Value = dt.Rows[0]["TotalPayout"].ToString();

                btnsave.Text = "Update";
                hdn_Id.Value = lblId.Text;
                // BindGrid();
            }
            else
            {
                GridCreateUser.Visible = false;
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", "alert('No Record !!');", true);
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

    //protected void btnConfirm_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        MailMessage mail = new MailMessage();
    //        SmtpClient SmtpServer = new SmtpClient("mail27.skylabstech.com");
    //        mail.From = new MailAddress("jai@skylabstech.com");
    //        mail.To.Add("nisha@ecordon.net");

    //        mail.Subject = "Loan Confirmation";
    //        mail.Body = "My loan has been confirmed.";
    //        SmtpServer.Port = 587;
    //        SmtpServer.Credentials = new System.Net.NetworkCredential("jai@skylabstech.com", "Hello@12345");
    //        SmtpServer.EnableSsl = true;
    //        SmtpServer.Send(mail);
    //        Response.Write("<script>alert('Email Sent Successfully');</script>");
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
    //    }
    //}


    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        try
        {
            string userEmail = txtEmail.Text.Trim();
            DataTable dtAllData = new DataTable();
            financialdata.Type = "S";
            financialdata.CreateUser = Session["UserId"].ToString();
            financialdata.RoleType = Session["roleType"].ToString();
            dtAllData = WhitelabelHelper.GetFinancialAmt(financialdata);

            if (dtAllData != null && dtAllData.Rows.Count > 0)
            {
                string Roletype = dtAllData.Rows[0]["RoalType"].ToString(); 
                string createUser = dtAllData.Rows[0]["CreateUser"].ToString();
                string bankname = dtAllData.Rows[0]["BankName"].ToString();
                string leadID = dtAllData.Rows[0]["LeadID"].ToString();
                string servicesId = dtAllData.Rows[0]["Id"].ToString();
                string name = dtAllData.Rows[0]["CustomerName"].ToString();
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("mail27.skylabstech.com");
                mail.From = new MailAddress("jai@skylabstech.com");
                mail.To.Add(userEmail);
                mail.CC.Add("Finance1.wincapital@gmail.com"); 
                mail.Subject = "Loan Confirmation for Loan ID: " + leadID;
                mail.Body = String.Format("Dear {0},\n\nYour lead with ID {1} has been confirmed with an Roaltype of {2}.\n\nBest regards,\nYour BankName{3}.\n\n loan with Id{4}.\n\n Financial Customer name{0}.\n\nMy loan is confirmed", name, leadID, Roletype, bankname, servicesId);
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("jai@skylabstech.com", "Hello@12345");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                txtEmail.Text = string.Empty;
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
            string userEmail = txtEmail.Text.Trim();
            DataTable dtAllData = new DataTable();
            financialdata.Type = "S";
            financialdata.CreateUser = Session["UserId"].ToString();
            financialdata.RoleType = Session["roleType"].ToString();
            dtAllData = WhitelabelHelper.GetFinancialAmt(financialdata);

            if (dtAllData != null && dtAllData.Rows.Count > 0)
            {
                string Roletype = dtAllData.Rows[0]["RoalType"].ToString();
                string createUser = dtAllData.Rows[0]["CreateUser"].ToString();
                string bankname = dtAllData.Rows[0]["BankName"].ToString();
                string leadID = dtAllData.Rows[0]["LeadID"].ToString();
                string servicesId = dtAllData.Rows[0]["Id"].ToString();
                string name = dtAllData.Rows[0]["CustomerName"].ToString();
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("mail27.skylabstech.com");
                mail.From = new MailAddress("jai@skylabstech.com");
                mail.To.Add(userEmail);
                mail.CC.Add("Finance1.wincapital@gmail.com");
                mail.Subject = "Query regarding to loan for lead ID: " + leadID;
                mail.Body = String.Format("Dear {0},\n\nYour lead with ID {1} has been confirmed with an Roaltype of {2}.\n\nBest regards,\nYour BankName{3}.\n\n loan with Id{4}.\n\n Financial Customer name{0}.\n\n Query regarding to loan", name,  leadID, Roletype, bankname, servicesId);
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("jai@skylabstech.com", "Hello@12345");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                txtEmail.Text = string.Empty;
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