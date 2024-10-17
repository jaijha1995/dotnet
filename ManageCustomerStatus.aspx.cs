using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManageCustomerStatus : System.Web.UI.Page
{
    whitelable Whitelable = new whitelable();
    whitelabelHelper WhitelabelHelper = new whitelabelHelper();
    ManageStatus leadsData = new ManageStatus();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (object.Equals(Session["UserId"], null))
        {
            Response.Redirect("Login.aspx");
        }

        if (!object.Equals(HttpContext.Current.Session["UserId"], null))
        {


        }

        if (!IsPostBack)
        {
            BindBankName();
            BindGrid();

        }
    }


    private void BindGrid()
    {
        if (Session["roleType"].ToString() == "U")
        {
            DataTable dtAllData = new DataTable();
            leadsData.Type = "G";
            leadsData.LeadID = int.Parse(hdn_Id.Value);
            leadsData.CreateUser = Session["UserId"].ToString();
            leadsData.RoleType = Session["roleType"].ToString();
            dtAllData = WhitelabelHelper.GetApplyCustomerStatus(leadsData);
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
            leadsData.Type = "G";
            leadsData.LeadID = int.Parse(hdn_Id.Value);
            leadsData.RoleType = Session["roleType"].ToString();
            dtAllData = WhitelabelHelper.GetApplyCustomerStatusAdmin(leadsData);
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


    }


    protected void GridCreateUser_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Delete"))
        {
            DataTable dt = new DataTable();
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            Label lblId = (Label)row.FindControl("lblId");
            leadsData.Type = "D";
            leadsData.Id = Convert.ToInt32(lblId.Text);
            //Whitelable.websiteId = Session["websiteId"].ToString();
            dt = WhitelabelHelper.InsertCustomerStatus(leadsData);
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", "alert('Record  Deleted successfully. !!');", true);
            BindGrid();
        }
        else if (e.CommandName.Equals("Edit"))
        {

            DataTable dt = new DataTable();
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            Label lblId = (Label)row.FindControl("lblId");
            leadsData.Type = "V";
            leadsData.LeadID = Convert.ToInt32(lblId.Text);
            dt = WhitelabelHelper.EditCustomerStatus(leadsData);
            if (dt.Rows.Count > 0)
            {
                hdn_Id.Value = lblId.Text;
                txtname.Text = dt.Rows[0]["CustomerName"].ToString();
                txtloantype.Text = dt.Rows[0]["LoanType"].ToString();
                txtcontactno.Text = dt.Rows[0]["ContactNo"].ToString();
                txtcity.Text = dt.Rows[0]["City"].ToString();
                txtstate.Text = dt.Rows[0]["State"].ToString();
                txtApplication.Text = dt.Rows[0]["ApplicationType"].ToString();
                txtloanAmt.Text = dt.Rows[0]["LoanAmt"].ToString();
                txtloandetail.Text = dt.Rows[0]["LoanDetails"].ToString();
                //ddlAirline.Text = dt.Rows[0]["BankName"].ToString();
                Response.Redirect("CustomerStatusIndex.aspx?LeadID=" + leadsData.LeadID);
                btnsave.Text = "Submit";
                //BindGrid();
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
        GridCreateUser.PageIndex = e.NewPageIndex;
        BindGrid();

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

    private void BindBankName()
    {
        try
        {
            DataTable dt = WhitelabelHelper.GetBankName();

            if (dt != null && dt.Rows.Count > 0)
            {
                dt.Columns.Add("BankDisplay", typeof(string), "BankName + ' (' + BankCode + ')'");
                ddlAirline.DataSource = dt;
                ddlAirline.DataTextField = "BankDisplay";
                ddlAirline.DataValueField = "Bankcode";
                ddlAirline.DataBind();
                ddlAirline.Items.Insert(0, "--Select Bank Name--");

            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "An error occurred: " + ex.Message;
            lblMsg.Visible = true;
        }
    }


    protected void GridCreateUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void ddl_accountno_SelectedIndexChanged(object sender, EventArgs e)
    {
        //BindGrid();
        //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "callmulty();", true);
    }
}