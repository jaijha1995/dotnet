using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_TopMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!object.Equals(Session["UserFname"], null))
            {
                lblUserName.Text = Session["UserFname"].ToString();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

        }
       
    }

}