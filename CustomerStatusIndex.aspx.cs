using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerStatusIndex : System.Web.UI.Page
{
    whitelable Whitelable = new whitelable();
    whitelabelHelper WhitelabelHelper = new whitelabelHelper();
    ManageStatus leadsData = new ManageStatus();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            BindGrid();
            BindBankName();
            if (Session["roleType"].ToString() == "A")
            {
                FormPanel.Style["display"] = "block";
            }
            else
            {
                FormPanel.Style["display"] = "none";

            }

        }

        if (!IsPostBack)
        {
            if (Request.QueryString["LeadID"] != null)
            {
                int leadID = Convert.ToInt32(Request.QueryString["LeadID"]);
                leadsData.Type = "V";
                leadsData.LeadID = leadID;
                DataTable dt = WhitelabelHelper.EditCustomerStatus(leadsData);

                if (dt.Rows.Count > 0)
                {
                    hdn_Id.Value = leadID.ToString();
                    txtleadId.Text = dt.Rows[0]["LeadID"].ToString();
                    txtcustomerId.Text = dt.Rows[0]["CustomerID"].ToString();
                    txtname.Text = dt.Rows[0]["CustomerName"].ToString();
                    txtloantype.Text = dt.Rows[0]["LoanType"].ToString();
                    txtcontactno.Text = dt.Rows[0]["ContactNo"].ToString();
                    txtcity.Text = dt.Rows[0]["City"].ToString();
                    txtstate.Text = dt.Rows[0]["State"].ToString();
                    txtApplication.Text = dt.Rows[0]["ApplicationType"].ToString();
                    txtloanAmt.Text = dt.Rows[0]["LoanAmt"].ToString();
                    txtloandetail.Text = dt.Rows[0]["LoanDetails"].ToString();
                    //ddlAirline.Text = dt.Rows[0]["BankName"].ToString();
                    //txtCreate.Text = dt.Rows[0]["CreateUser"].ToString();
                    //txtroltype.Text = dt.Rows[0]["RoleType"].ToString();

                    if (dt.Rows[0]["Status"] != DBNull.Value && !string.IsNullOrEmpty(dt.Rows[0]["Status"].ToString()))
                    {
                        string[] airlineStr = dt.Rows[0]["BankName"].ToString().Split(',');

                        List<string> lstAirline = new List<string>();
                        for (int i = 0; i < airlineStr.Length; i++)
                        {
                            string fwd = airlineStr[i];
                            lstAirline.Add(fwd);
                        }
                        foreach (ListItem item in ddlAirline.Items)
                        {
                            if (lstAirline.Contains(item.Value))
                            {
                                item.Selected = true;
                            }
                        }
                        ddlbankstatus.Text = dt.Rows[0]["BankStatus"].ToString();
                        txtEndDate.Text = dt.Rows[0]["TenareDate"].ToString();
                        txtrate.Text = dt.Rows[0]["Rate"].ToString();
                        txtforecharges.Text = dt.Rows[0]["ForeCharge"].ToString();
                        ddlstatus.SelectedValue = dt.Rows[0]["Status"].ToString();
                        txtReason.Text = dt.Rows[0]["Reason"].ToString();
                        btnsave.Text = "Update";

                    }
                    else
                    {
                        btnsave.Text = "Submit";
                    }

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


    string airlineCode;
    protected void btnSave_Click(object sender, EventArgs e)
    {

        try
        {
            string selectedAirlines = hfSelectedAirlines.Value;
            string[] selectedAirlinesArray = selectedAirlines.Split(',');
            DataTable dt = new DataTable();
            leadsData.LeadID = Convert.ToInt32(txtleadId.Text);
            leadsData.CustomerID = Convert.ToInt32(txtcustomerId.Text);
            leadsData.LoanType = txtloantype.Text.Trim();
            leadsData.LoanAmt = txtloanAmt.Text.Trim();
            leadsData.LoanDetail = txtloandetail.Text.Trim();
            leadsData.BankName = selectedAirlines;
            leadsData.CustomerName = txtname.Text.Trim();
            leadsData.ContactNo = txtcontactno.Text.Trim();
            leadsData.City = txtcity.Text.Trim();
            leadsData.State = txtstate.Text.Trim();
            leadsData.TenareDate = txtEndDate.Text.Trim();
            leadsData.applicationType = txtApplication.Text.Trim();
            leadsData.Bankstatus = ddlbankstatus.Text.Trim();
            //if (!string.IsNullOrEmpty(txtEndDate.Text.Trim()))
            //{
            //    DateTime tenareDate;
            //    if (DateTime.TryParseExact(txtEndDate.Text.Trim(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out tenareDate))
            //    {
            //        leadsData.TenareDate = tenareDate;
            //    }
            //    else
            //    {
            //        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", "alert('Invalid Date Format. Please enter the date in MM/dd/yyyy format.');", true);
            //    }
            //}

            leadsData.Rate = txtrate.Text.Trim();
            leadsData.ForeCharge = txtforecharges.Text.Trim();
            leadsData.Status = ddlstatus.Text.Trim();
            if (leadsData.Status == "Pending" || string.IsNullOrEmpty(txtReason.Text.Trim())|| leadsData.Status == "Complete" || leadsData.Status == "Bank Meeting" || leadsData.Status == "Sanctioned")
            {
                leadsData.Reason = null;
            }
            else
            {
                leadsData.Reason = txtReason.Text.Trim(); 
            }
            if (btnsave.Text == "Submit")
            {
                leadsData.Type = "I";
                dt = WhitelabelHelper.InsertCustomerStatus(leadsData);

                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", "alert('Data Saved Successfully !!');", true);
            }
            else if (btnsave.Text == "Update")
            {
                leadsData.Type = "U";
                leadsData.Id = Convert.ToInt32(hdn_Id.Value);
                dt = WhitelabelHelper.InsertCustomerStatus(leadsData);
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", "alert('Data Updated Successfully. !!');", true);
                hdn_Id.Value = "0";
            }
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ScrollTop();", true);
            //BindGrid();

            txtroltype.Text = "";
            txtCreate.Text = "";
            txtleadId.Text = "";
            txtcustomerId.Text = "";
            txtloantype.Text = "";
            txtloanAmt.Text = "";
            txtloandetail.Text = "";
            //ddlAirline.Text = "";
            txtname.Text = "";
            txtcontactno.Text = "";
            txtcity.Text = "";
            txtstate.Text = "";
            txtApplication.Text = "";
            txtEndDate.Text = "";
            txtrate.Text = "";
            txtforecharges.Text = "";
            ddlstatus.SelectedValue = "0";
            Response.Redirect("ManageCustomerStatus.aspx");

        }
        catch (Exception ex)
        {

        }
    }


    private void BindGrid()
    {
        DataTable dtAllData = new DataTable();
        leadsData.Type = "S";
        //leadsData.Id = int.Parse(hdn_Id.Value);
        dtAllData = WhitelabelHelper.GetApplyCustomerStatusIndex(leadsData);
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


    protected void GridCreateUser_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Delete"))
        {
            DataTable dt = new DataTable();
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            Label lblId = (Label)row.FindControl("lblId");
            leadsData.Type = "D";
            leadsData.Id = Convert.ToInt32(lblId.Text);
            dt = WhitelabelHelper.DeleteCustomerStatus(leadsData);
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", "alert('Record  Deleted successfully. !!');", true);
            BindGrid();
        }
        else if (e.CommandName.Equals("Edit"))
        {

            DataTable dt = new DataTable();
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            Label lblId = (Label)row.FindControl("lblId");
            leadsData.Type = "E";
            leadsData.Id = Convert.ToInt32(lblId.Text);
            dt = WhitelabelHelper.EditCustomerStatusIndex(leadsData);
            if (dt.Rows.Count > 0)
            {
                hdn_Id.Value = lblId.Text;
                txtleadId.Text = dt.Rows[0]["LeadID"].ToString();
                txtcustomerId.Text = dt.Rows[0]["CustomerID"].ToString();
                txtname.Text = dt.Rows[0]["CustomerName"].ToString();
                txtloantype.Text = dt.Rows[0]["LoanType"].ToString();
                txtcontactno.Text = dt.Rows[0]["ContactNo"].ToString();
                txtcity.Text = dt.Rows[0]["City"].ToString();
                txtstate.Text = dt.Rows[0]["State"].ToString();
                txtApplication.Text = dt.Rows[0]["ApplicationType"].ToString();
                txtloanAmt.Text = dt.Rows[0]["LoanAmt"].ToString();
                txtloandetail.Text = dt.Rows[0]["LoanDetail"].ToString();
                //ddlAirline.Text = dt.Rows[0]["BankName"].ToString();
                string[] airlineStr = dt.Rows[0]["BankName"].ToString().Split(',');

                List<string> lstAirline = new List<string>();
                for (int i = 0; i < airlineStr.Length; i++)
                {
                    string fwd = airlineStr[i];
                    lstAirline.Add(fwd);
                }
                foreach (ListItem item in ddlAirline.Items)
                {
                    if (lstAirline.Contains(item.Value))
                    {
                        item.Selected = true;
                    }
                }
                txtEndDate.Text = dt.Rows[0]["TenareDate"].ToString();
                txtrate.Text = dt.Rows[0]["Rate"].ToString();
                txtforecharges.Text = dt.Rows[0]["ForeCharge"].ToString();
                ddlstatus.SelectedValue = dt.Rows[0]["Status"].ToString();
                txtReason.Text = dt.Rows[0]["Reason"].ToString();
                ddlbankstatus.Text = dt.Rows[0]["BankStatus"].ToString();
                btnsave.Text = "Update";
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

    protected void GridCreateUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void ddl_accountno_SelectedIndexChanged(object sender, EventArgs e)
    {
        //BindGrid();
        //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "callmulty();", true);
    }
}