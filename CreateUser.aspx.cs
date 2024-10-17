using AjaxControlToolkit.HTMLEditor.ToolbarButton;
using Core.Common;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class CreateUser : System.Web.UI.Page
{
    SearchEngine searchEngineCls = new SearchEngine();
    SearchEngineHelper searchEngineHelperCls = new SearchEngineHelper();
    Encrypt l_Encrypt = new Encrypt();
    whitelable Whitelable = new whitelable();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (object.Equals(Session["UserId"], null))
        {
            Response.Redirect("Login.aspx");
        }

        if (!IsPostBack)
        {
            Rndcheckuser.Checked = true;
            BindGrid();
            if (Session["roleType"].ToString() == "A")
            {
                Rndcheckadmin.Enabled = true;
                Rndcheckuser.Enabled = true;
            }
            else
            {
                Rndcheckadmin.Enabled = false;
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
 
            DataTable dt = new DataTable();
            searchEngineCls.EmailId = txtemail.Text;
            searchEngineCls.UserId = txtuserid.Text;
            searchEngineCls.Password = l_Encrypt.Encrypting(txtpassword.Text, ConfigurationManager.AppSettings["encryptKey"].ToString());
            if (Rndcheckadmin.Checked == true)
            {
                searchEngineCls.Rolltype = "A";
            }
            else
            {
                searchEngineCls.Rolltype = "U";
            }
            if (btnSave.Text == "Submit")
            {
                searchEngineCls.Type = "I";
                dt = searchEngineHelperCls.InsertCreateUser(searchEngineCls);
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", "alert('Data Saved Successfuly !!');", true);
                SendMail();
            }
            else if (btnSave.Text == "Update")
            {
                searchEngineCls.Type = "U";
                searchEngineCls.Id = Convert.ToInt32(hdn_Id.Value);
                dt = searchEngineHelperCls.InsertCreateUser(searchEngineCls);
                SendMail();
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", "alert('Data Update Successfully. !!');", true);
                hdn_Id.Value = "0";
            }
            hdn_Id.Value = "0";
            txtuserid.Text = "";
            txtpassword.Text = "";
            txtemail.Text = "";
            // txturl.Text = "";
            btnSave.Text = "Submit";
            Rndcheckuser.Checked = true;
            BindGrid();
            if (searchEngineCls.Rolltype == "A") // Admin
            {
                Rndcheckadmin.Enabled = true;
                Rndcheckuser.Enabled = true;
            }
            else if (searchEngineCls.Rolltype == "U")
            {
                Rndcheckadmin.Enabled = false;
                Rndcheckuser.Checked = true;
            }
        }
        catch { };
    }

  



    private void BindGrid()
    {
        try
        {
            if (Session["roleType"].ToString() == "U")
            {
                DataTable dt = new DataTable();
                Whitelable.Type = "S";
                Whitelable.UserId = Session["UserId"].ToString();
                Whitelable.RoleType = Session["roleType"].ToString();
                dt = searchEngineHelperCls.GetCreateuser(Whitelable);
                if (!object.Equals(dt, null))
                {
                    if (dt.Rows.Count > 0)
                    {
                        lblMsg.Visible = false;
                        GridCreateUser.DataSource = dt;
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
                DataTable dt = new DataTable();
                Whitelable.Type = "S";
                Whitelable.RoleType = Session["roleType"].ToString();
                dt = searchEngineHelperCls.GetCreateuser(Whitelable);
                if (!object.Equals(dt, null))
                {
                    if (dt.Rows.Count > 0)
                    {
                        lblMsg.Visible = false;
                        GridCreateUser.DataSource = dt;
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


        }
        catch
        { }
    }
    protected void GridCreateUser_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Delete"))
        {
            DataTable dt = new DataTable();
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            Label lblId = (Label)row.FindControl("lblId");
            searchEngineCls.Type = "D";
            searchEngineCls.Id = Convert.ToInt32(lblId.Text);
            dt = searchEngineHelperCls.InsertCreateUser(searchEngineCls);
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", "alert('Record  Deleted successfully. !!');", true);
            BindGrid();
        }
        else if (e.CommandName.Equals("Edit"))
        {
            string rolltype = string.Empty;
            DataTable dt = new DataTable();
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            Label lblId = (Label)row.FindControl("lblId");
            searchEngineCls.Type = "E";
            searchEngineCls.Id = Convert.ToInt32(lblId.Text);
            dt = searchEngineHelperCls.InsertCreateUser(searchEngineCls);
            if (dt.Rows.Count > 0)
            {
                txtuserid.Text = dt.Rows[0]["UserId"].ToString();
                txtpassword.Text = l_Encrypt.Decrypting(dt.Rows[0]["Password"].ToString(), ConfigurationManager.AppSettings["encryptKey"].ToString());
                txtemail.Text = dt.Rows[0]["ContactEmailAdd"].ToString();
                rolltype = dt.Rows[0]["Role_Type"].ToString();
                if (rolltype == "A")
                {
                    Rndcheckadmin.Checked = true;
                    Rndcheckuser.Checked = false;


                }
                else
                {
                    Rndcheckuser.Checked = true;
                    Rndcheckadmin.Checked = false;

                }
                if (Session["roleType"].ToString() == "A")
                {
                    Rndcheckadmin.Enabled = true;
                    Rndcheckuser.Enabled = true;

                }
                else
                {
                    Rndcheckadmin.Enabled = false;
                    //txtpassword.Enabled = false;
                   
                }
                btnSave.Text = "Update";
                hdn_Id.Value = lblId.Text;
                BindGrid();
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
    protected void SendMail()
    {
        try
        {
            string url = Request.Url.ToString();
            Uri uri = new Uri(url);
            string host = uri.Host;
            string _subject = "", _toEmail = "";

            _subject = "Login Detail";
            _toEmail = txtemail.Text;
            MailMessage mailMessage = new MailMessage();
            MailAddress from = new MailAddress("nm774385@gmail.com");
            MailAddress to = new MailAddress(_toEmail);
            mailMessage.To.Add(to);
            mailMessage.From = from;
            mailMessage.Subject = _subject;
            mailMessage.IsBodyHtml = false;
            StringBuilder body = new StringBuilder();

            body.Append("");
            body.Append("============================================================");
            body.Append('\n');
            body.Append('\n');
            body.Append("Login Details");
            body.Append('\n');
            body.Append('\n');
            body.Append("Userid : " + txtuserid.Text);
            body.Append('\n');
            body.Append("password : " + txtpassword.Text);
            body.Append('\n');
            body.Append("Email Id : " + txtemail.Text);
            body.Append('\n');
            body.Append("Url : " + host);
            body.Append('\n');
            body.Append('\n');
            body.Append("============================================================");

            mailMessage.Body = body.ToString();

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.EnableSsl = true;

            smtpClient.Send(mailMessage);
        }
        catch (Exception ex)
        { }
    }
    protected void GridCreateUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}