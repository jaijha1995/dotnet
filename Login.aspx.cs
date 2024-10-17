using Core.Common;
using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void lnkbtnLoginClick(object sender, EventArgs e)
    {
        string userName = txtUserId.Text;
        string userPassword = txtPassword.Text.Trim();
        Authenticate(AuthenticateUtility.AuthenticateUser(userName, userPassword));
    }
    private void Authenticate(int stat)
    {
        bool isIpAddress = false;
        if (stat == 1)
        {
            if (Session["roleType"].ToString() == "A")
            {
                isIpAddress = true;
            }
            else
            {
                isIpAddress = true;
            }
            if (isIpAddress == true)
            {
                Response.Redirect(ResolveUrl("~/default.aspx"));
            }
            else
            {
                Session.Abandon();
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "PopupScript", "alert('Invalid ID/Password!');", true);
                return;
            }
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "PopupScript", "alert('Invalid ID/Password!');", true);
            return;
        }
    }
    //private bool checkIpAdress()
    //{
    //    bool flag = false;

    //    DataTable dtsearch;
    //    whitelable whiteLable = new whitelable();
    //    whitelabelHelper whitelabelhelper = new whitelabelHelper();
    //    string IPAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"]; // HttpContext.Current.Request.ServerVariables[33].ToString(); // // for local
       
    //    if (IPAddress == null) 
    //    {
    //        IPAddress = Request.ServerVariables["REMOTE_ADDR"];
    //    }
    
    //    whiteLable.Mode = 'S';
    //    dtsearch = whitelabelhelper.GetIPAddress(whiteLable);
    //    for (int i = 0; i < dtsearch.Rows.Count; i++)
    //    {
    //        if (IPAddress.Equals(dtsearch.Rows[i]["IPAddress"]))
    //        {
    //            flag = true;
    //            break;
    //        }
    //    }

    //    return flag;
    //}
}