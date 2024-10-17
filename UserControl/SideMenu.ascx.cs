using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class UserControl_SideMenu : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!object.Equals(Session["UserFname"], null))
            {
                lblUserName.Text = Session["UserFname"].ToString();
                if (Session["roleType"].ToString() == "A")
                {
                    liCreateUser.Visible = true;
                    liloantype.Visible = true;
                    Linankname.Visible = true;


                }
                else
                {
                    liloantype.Visible = false;
                    Linankname.Visible = false;
                }
                
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
       
    }
}