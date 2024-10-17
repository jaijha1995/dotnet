using Core.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LogBaggages : System.Web.UI.Page
{
    whitelable Whitelable = new whitelable();
    whitelabelHelper WhitelabelHelper = new whitelabelHelper();
    Core.InterfaceLayer.Login login = new Core.InterfaceLayer.Login();
    Encrypt l_Encrypt = new Encrypt();
    SearchEngine searchEngineCls = new SearchEngine();
    protected void Page_Load(object sender, EventArgs e)
    {
        //BindSites();
        if (!object.Equals(HttpContext.Current.Session["UserId"], null))
        {

            BindGrid();
        }
        else
        {
            BindGrid();
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        try
        {
            DataTable dt = new DataTable();
            Whitelable.CreateUser = Session["UserId"].ToString();
            Whitelable.RoleType = Session["roleType"].ToString();
            Whitelable.CustomerName = txtname.Text.Trim().ToUpper();
            Whitelable.ContactNo = txtcontactno.Text.Trim();
            Whitelable.City = txtcity.Text.Trim();
            Whitelable.State = txtstate.Text.Trim();
            Whitelable.applicationType = ddlAplicationtype.Text.Trim();

            if (btnSave.Text == "Submit")
            {
                Whitelable.Type = "I";
                dt = WhitelabelHelper.InsertLogBaggageUser(Whitelable);

                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", "alert('Data Saved Successfully !!');", true);
            }
            else if (btnSave.Text == "Update")
            {
                Whitelable.Type = "U";
                Whitelable.CustomerID = Convert.ToInt32(hdn_Id.Value);
                dt = WhitelabelHelper.InsertLogBaggageUser(Whitelable);
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", "alert('Data Updated Successfully. !!');", true);
                hdn_Id.Value = "0";
            }
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ScrollTop();", true);
            BindGrid();
            txtname.Text = "";
            txtcontactno.Text = "";
            txtcity.Text = "";
            txtstate.Text = "";
            ddlAplicationtype.SelectedValue = "0";
            btnSave.Text = "Submit";

        }
        catch (Exception ex)
        {

        }
    }


    //protected void BindSites()
    //{
    //    DataTable datatable = new DataTable();
    //    //searchEngineCls.Rolltype = Session["roleType"].ToString();
    //    //searchEngineCls.Password = Session["PWD"].ToString();
    //    searchEngineCls.UserId = Session["UserId"].ToString();
    //    datatable = WhitelabelHelper.Getsitedata(searchEngineCls);
    //    ddl_Site.DataSource = datatable;

    //    if (datatable != null && datatable.Rows.Count > 0)
    //    {

    //        // Add a new column to concatenate userId and Id
    //        datatable.Columns.Add("DisplayField", typeof(string), "userId + ' - ' + Id");

    //        // Bind the new column to the dropdown
    //        ddl_Site.DataSource = datatable;
    //        ddl_Site.DataTextField = "DisplayField"; // The column containing concatenated values
    //        ddl_Site.DataValueField = "userId"; // Choose which field to use as the value
    //        ddl_Site.DataBind();

    //    }
    //    else
    //    {
    //        ddl_Site.SelectedIndex = 0;
    //        ddl_Site.Enabled = false;
    //    }
    //}

    //private void BindGrid()
    //{
    //    try
    //    {
    //        if (Session["roleType"].ToString() == "A")
    //        {
    //            DataTable dt = new DataTable();
    //            Whitelable.Type = "A";
    //            Whitelable.UserId = Session["UserId"].ToString();
    //            dt = WhitelabelHelper.GetCreateuser(Whitelable);
    //            if (!object.Equals(dt, null))
    //            {


    //                if (dt.Rows.Count > 0)
    //                {
    //                    lblMsg.Visible = false;
    //                    GridCreateUser.DataSource = dt;
    //                    GridCreateUser.DataBind();
    //                }
    //                else
    //                {
    //                    lblMsg.Visible = true;
    //                    GridCreateUser.Visible = false;
    //                    lblMsg.Text = "No Records !!";
    //                }



    //            }
    //        }
    //        else if (Session["roleType"].ToString() == "U" && Session["UserId"].ToString() == ddl_Site.Text)
    //        {
    //            DataTable dt = new DataTable();
    //            Whitelable.Type = "A";
    //            Whitelable.UserId = Session["UserId"].ToString();
    //            dt = WhitelabelHelper.GetCreateuser(Whitelable);
    //            if (!object.Equals(dt, null))
    //            {


    //                if (dt.Rows.Count > 0)
    //                {
    //                    lblMsg.Visible = false;
    //                    GridCreateUser.DataSource = dt;
    //                    GridCreateUser.DataBind();
    //                }
    //                else
    //                {
    //                    lblMsg.Visible = true;
    //                    GridCreateUser.Visible = false;
    //                    lblMsg.Text = "No Records !!";
    //                }
    //            }

    //        }


    //    }
    //    catch (Exception ex)
    //    { }
    //}


    private void BindGrid()
    {
        try
        {
            if(Session["roleType"].ToString()=="U")
            {
                DataTable dt = new DataTable();
                Whitelable.Type = "A";
                Whitelable.CreateUser = Session["UserId"].ToString();
                Whitelable.RoleType = Session["roleType"].ToString();
                dt = WhitelabelHelper.GetCreateuser(Whitelable);
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
                Whitelable.Type = "A";
                Whitelable.RoleType = Session["roleType"].ToString();
                dt = WhitelabelHelper.GetCreateuserAdmin(Whitelable);
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
        catch (Exception ex)
        { }
    }


    protected void GridCreateUser_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void GridCreateUser_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Delete"))
        {
            DataTable dt = new DataTable();
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            Label lblId = (Label)row.FindControl("lblId");
            Whitelable.Type = "D";
            Whitelable.CustomerID = Convert.ToInt32(lblId.Text);
            dt = WhitelabelHelper.InsertLogBaggageUser(Whitelable);
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", "alert('Record  Deleted successfully. !!');", true);
            BindGrid();
        }
        else if (e.CommandName.Equals("Edit"))
        {

            DataTable dt = new DataTable();


            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            Label lblId = (Label)row.FindControl("lblId");
            Whitelable.Type = "E";
            Whitelable.CustomerID = Convert.ToInt32(lblId.Text);
            dt = WhitelabelHelper.InserUpdateDeleteBlockBaggageMaster(Whitelable);
            if (dt.Rows.Count > 0)
            {
                txtname.Text = dt.Rows[0]["CustomerName"].ToString();
                txtcontactno.Text = dt.Rows[0]["ContactNo"].ToString();
                txtcity.Text = dt.Rows[0]["City"].ToString();
                txtstate.Text = dt.Rows[0]["State"].ToString();
                ddlAplicationtype.Text = dt.Rows[0]["applicationType"].ToString();
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

    protected void GridCreateUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void GridCreateUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

}