using Core.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManagesLeads : System.Web.UI.Page
{
    whitelable Whitelable = new whitelable();
    whitelabelHelper WhitelabelHelper = new whitelabelHelper();
    ManageLeadsData leadsData = new ManageLeadsData();
    Encrypt l_Encrypt = new Encrypt();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (object.Equals(Session["UserId"], null))
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            BindCustomerId();
            BindLoanTypes();
            BindGrid();
        }
    }
    string airlineCode;
    protected void btnSave_Click(object sender, EventArgs e)
    {

        try
        {

            DataTable dt = new DataTable();
            leadsData.CreateUser = Session["UserId"].ToString();
            leadsData.RoleType = Session["roleType"].ToString();
            leadsData.CustomerID = Convert.ToInt32(txtuserid.Text);
            leadsData.LoanType = txtloantype.Text.Trim();
            leadsData.LoanAmt = txtloanammount.Text.Trim();
            leadsData.LoanDetails = ddlloandetails.Text.Trim();
            leadsData.CustomerName = txtname.Text.Trim();
           // leadsData.BankName = selectedAirlines;
            if (btnSave.Text == "Submit")
            {
                leadsData.Type = "I";
                dt = WhitelabelHelper.InsertLeadData(leadsData);

                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", "alert('Data Saved Successfully !!');", true);
            }
            else if (btnSave.Text == "Update")
            {
                leadsData.Type = "U";
                leadsData.LeadID = Convert.ToInt32(hdn_Id.Value);
                dt = WhitelabelHelper.InsertLeadData(leadsData);
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", "alert('Data Updated Successfully. !!');", true);
                hdn_Id.Value = "0";
            }
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ScrollTop();", true);
            BindGrid();
            txtuserid.SelectedIndex = 0;
            txtloanammount.Text = "";
            txtloantype.SelectedIndex = 0;
            ddlloandetails.SelectedValue = "0";
            btnSave.Text = "Submit";
          

        }
        catch (Exception ex)
        {

        
        }
    }


  

    private void BindGrid()
    {

        if (Session["roleType"].ToString() == "U")
        {
            DataTable dtAllData = new DataTable();
            leadsData.Type = "S";
            leadsData.LeadID = int.Parse(hdn_Id.Value);
            leadsData.CreateUser = Session["UserId"].ToString();
            leadsData.RoleType = Session["roleType"].ToString();
            dtAllData = WhitelabelHelper.GetApplyManageprofile(leadsData);
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
            leadsData.Type = "S";
            leadsData.LeadID = int.Parse(hdn_Id.Value);
            leadsData.RoleType = Session["roleType"].ToString();
            dtAllData = WhitelabelHelper.GetApplyManageprofile(leadsData);
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


    private void BindLoanTypes()
    {
        try
        {
            DataTable dt = WhitelabelHelper.GetApplyLoanType();

            if (dt != null && dt.Rows.Count > 0)
            {

                txtloantype.DataSource = dt;
                txtloantype.DataTextField = "loan_Type";
                txtloantype.DataValueField = "loan_Type";
                txtloantype.DataBind();
                txtloantype.Items.Insert(0, "--Select Loan Type--");

            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "An error occurred: " + ex.Message;
            lblMsg.Visible = true;
        }
    }


    //private void BindCustomerId()
    //{
    //    try
    //    {
    //        Whitelable.Type = "S";
    //        Whitelable.CreateUser = Session["UserId"].ToString();
    //        Whitelable.RoleType = Session["roleType"].ToString();
    //        DataTable dt = WhitelabelHelper.GetApplyCustomerID(Whitelable);

    //        if (dt != null && dt.Rows.Count > 0)
    //        {

    //            txtuserid.DataSource = dt;
    //            txtuserid.DataTextField = "CustomerID";
    //            txtuserid.DataValueField = "CustomerID";
    //            txtuserid.DataBind();

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblMsg.Text = "An error occurred: " + ex.Message;
    //        lblMsg.Visible = true;
    //    }
    //}



    private void BindCustomerId()
    {
        try
        {
            if (Session["roleType"].ToString() == "U")
            {
                Whitelable.Type = "S";
                Whitelable.CreateUser = Session["UserId"].ToString();
                Whitelable.RoleType = Session["roleType"].ToString();
                DataTable dt = WhitelabelHelper.GetApplyCustomerID(Whitelable);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dt.Columns.Add("DisplayName", typeof(string));
                    foreach (DataRow row in dt.Rows)
                    {
                        row["DisplayName"] = row["CustomerName"] + " (" + row["CustomerID"] + ")";
                    }

                    txtuserid.DataSource = dt;
                    txtuserid.DataTextField = "DisplayName";
                    txtuserid.DataValueField = "CustomerID";
                    txtuserid.DataBind();
                    txtuserid.Items.Insert(0, "--Select Customer Id--");
                }
            }
            else if (Session["roleType"].ToString() == "A")
            {
                Whitelable.Type = "S";
                Whitelable.CreateUser = Session["UserId"].ToString();
                Whitelable.RoleType = Session["roleType"].ToString();
                DataTable dt = WhitelabelHelper.GetApplyCustomerID(Whitelable);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dt.Columns.Add("DisplayName", typeof(string));
                    foreach (DataRow row in dt.Rows)
                    {
                        row["DisplayName"] = row["CustomerName"] + " (" + row["CustomerID"] + ")";
                    }

                    txtuserid.DataSource = dt;
                    txtuserid.DataTextField = "DisplayName";
                    txtuserid.DataValueField = "CustomerID";
                    txtuserid.DataBind();
                    txtuserid.Items.Insert(0, "--Select Customer Id--");
                }

            }



        }
        catch (Exception ex)
        {
            lblMsg.Text = "An error occurred: " + ex.Message;
            lblMsg.Visible = true;
        }
    }


    protected void txtuserid_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            leadsData.Type = "C";
            leadsData.CustomerID = Convert.ToInt32(txtuserid.SelectedValue);
            DataTable dtCustomerDetails = WhitelabelHelper.GetCustomername(leadsData);

            if (dtCustomerDetails != null && dtCustomerDetails.Rows.Count > 0)
            {
                txtname.Text = dtCustomerDetails.Rows[0]["CustomerName"].ToString();
                
            }
            else
            {
                txtname.Text = string.Empty;
            
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "An error occurred: " + ex.Message;
            lblMsg.Visible = true;
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
            leadsData.LeadID = Convert.ToInt32(lblId.Text);
            //Whitelable.websiteId = Session["websiteId"].ToString();
            dt = WhitelabelHelper.InsertLeadData(leadsData);
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", "alert('Record  Deleted successfully. !!');", true);
            BindGrid();
        }
        else if (e.CommandName.Equals("Edit"))
        {

            DataTable dt = new DataTable();


            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            Label lblId = (Label)row.FindControl("lblId");
            leadsData.Type = "E";
            leadsData.LeadID = Convert.ToInt32(lblId.Text);
            dt = WhitelabelHelper.EditleadData(leadsData);
            DataTable alldt = WhitelabelHelper.GetBankName();
            if (dt.Rows.Count > 0)
            {
                txtuserid.Text = dt.Rows[0]["CustomerID"].ToString();
                txtloantype.Text = dt.Rows[0]["LoanType"].ToString();
                txtloanammount.Text = dt.Rows[0]["LoanAmt"].ToString();
                ddlloandetails.SelectedValue = dt.Rows[0]["LoanDetails"].ToString();
                txtname.Text = dt.Rows[0]["CustomerName"].ToString();
                //string[] airlineStr = dt.Rows[0]["BankName"].ToString().Split(',');

                //List<string> lstAirline = new List<string>();
                //for (int i = 0; i < airlineStr.Length; i++)
                //{
                //    string fwd = airlineStr[i];
                //    lstAirline.Add(fwd);
                //}
                //foreach (ListItem item in ddlAirline.Items)
                //{
                //    if (lstAirline.Contains(item.Value))
                //    {
                //        item.Selected = true;
                //    }
                //}

                btnSave.Text = "Update";
                hdn_Id.Value = lblId.Text;
               // BindGrid();
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

    protected void GridCreateUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void ddl_accountno_SelectedIndexChanged(object sender, EventArgs e)
    {
        //BindGrid();
        //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "callmulty();", true);
    }


}