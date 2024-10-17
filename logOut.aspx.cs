using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class logOut : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.RemoveAll();
        Response.Write(@"<script language='javascript'> localStorage.removeItem('thisLink');document.location.href='Login.aspx'; </script>");

    }
}