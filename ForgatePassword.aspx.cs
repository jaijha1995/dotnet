using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core.InterfaceLayer;
using System.Data;
using DocumentFormat.OpenXml.Spreadsheet;

public partial class ForgatePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnResetPassword_Click(object sender, EventArgs e)
    {
        string userEmail = txtforgotpassword.Text.Trim();
        LoginHelper loginHelper = new LoginHelper();
        DataTable dt = loginHelper.getUserIdByEmail(userEmail);
        if (dt!=null && dt.Rows.Count>0)
        {
            Session["UserId"] = dt.Rows[0]["UserId"].ToString();
        }
        if (IsValidEmail(userEmail))
        {
            string otp = GenerateOTP();
            Session["OTP"] = otp; 
            bool isEmailSent = SendOTPEmail(userEmail, otp);

            if (isEmailSent)
            {
                Response.Redirect("OtpPage.aspx");
            }
            else
            {
                lblMsg.Text = "Failed to send OTP. Please try again.";
            }
        }
        else
        {
            lblMsg.Text = "Invalid email address.";
        }
    }

    public  void getUserIdByEmail(string Email)
    {
        LoginHelper loginHelper = new LoginHelper();    
        DataTable dt=loginHelper.getUserIdByEmail(Email);
    }
    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    private string GenerateOTP()
    {
        Random random = new Random();
        return random.Next(100000, 999999).ToString();
    }

    private bool SendOTPEmail(string email, string otp)
    {
        try
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("jai@skylabstech.com"); 
            mail.To.Add(email);
            mail.Subject = "Your OTP for Password Reset";
            mail.Body = "Your OTP code is: " + otp;
            SmtpClient smtpClient = new SmtpClient("mail27.skylabstech.com"); 
            smtpClient.Port = 587; 
            smtpClient.Credentials = new NetworkCredential("jai@skylabstech.com", "Hello@12345");
            smtpClient.EnableSsl = true;
            smtpClient.Send(mail);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}