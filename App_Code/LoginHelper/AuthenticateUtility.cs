using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Collections;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Core.InterfaceLayer;
using Core.Common;

using System.Xml;
using System.IO;

/// <summary>
/// Summary description for AuthenticateUtility
/// </summary>
public class AuthenticateUtility
{
    public static int AuthenticateUser(string UID, string PWD)
    {
        Encrypt l_Encrypt = new Encrypt();
        Core.InterfaceLayer.Login login = new Core.InterfaceLayer.Login();
        LoginHelper loginHelper = new LoginHelper();
        login.UserID = UID;
        login.TextPassword = PWD;
        login.PWD = l_Encrypt.Encrypting(PWD, ConfigurationManager.AppSettings["encryptKey"].ToString());
        loginHelper.ValidateUser(login);
        if (login.Status)
        {
            HttpContext.Current.Session["UserId"] = login.UserID;
            HttpContext.Current.Session["PWD"] = login.PWD;
            HttpContext.Current.Session["SubAgencyName"] = login.UserName;
            HttpContext.Current.Session["UserFname"] = login.FName;
            HttpContext.Current.Session["UserProfileImg"] = login.ProfileImg;
            HttpContext.Current.Response.Cookies["UID"].Value = UID;
            HttpContext.Current.Response.Cookies["PWD"].Value = PWD;
            HttpContext.Current.Session["AgentId"] = login.AgentId;
            HttpContext.Current.Session["roleType"] = login.RoleType;
            return 1;
        }
        else
            return 0;
    }
}