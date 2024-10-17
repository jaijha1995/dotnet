using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OtpPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnResetPassword_Click(object sender, EventArgs e)
    {
        string enteredOTP = txtforgotpassword.Text.Trim();
        string sessionOTP = Session["OTP"] != null ? Session["OTP"].ToString() : "";
        if (enteredOTP == sessionOTP)
        {
            Response.Redirect("ChangePassword.aspx");
        }
        else
        {
            lblMsg.Text = "OTP is incorrect. Please try again.";
            lblMsg.Visible = true;
        }
    }
}