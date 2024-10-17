using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Loantype : System.Web.UI.Page
{
    whitelable Whitelable = new whitelable();
    LoanMaster journeyMaster = new LoanMaster();
    whitelabelHelper whitelabelHelper = new whitelabelHelper();
    DataTable datatable = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            BindGrid();
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        string message = string.Empty;
        var journeyMaster = new LoanMaster();

        if (btnsave.Text == "Update")
        {
            journeyMaster.Type = "U";
            journeyMaster.loan_Id = int.Parse(hdn_Id.Value);
            message = "Record Is Updated";
        }
        else
        {
            journeyMaster.Type = "I";
            message = "Record Is Inserted";
        }

        journeyMaster.loan_Type = textName.Text.Trim();
        journeyMaster.Loan_Code = txtcompany.Text.Trim();
  
        int Id = whitelabelHelper.InsertUpdateDel_LoanType(journeyMaster);
        if (Id > 0)
        {
            BindGrid();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "customScript", "<script>alert('" + message + "');</script>", false);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "customScript", "<script>alert('Destination code already exists.');</script>", false);
        }
        Clear();
    }


    private void BindGrid()
    {
        DataTable dtAllData = new DataTable();
        journeyMaster.Type = "S";
        journeyMaster.loan_Id = int.Parse(hdn_Id.Value);
        dtAllData = whitelabelHelper.GetLoanData(journeyMaster);
        if (!object.Equals(dtAllData, null))
        {
            if (dtAllData.Rows.Count > 0)
            {
                lblMsg.Visible = false;
                GridApplyCoupon.Visible = true;
                ViewState["datatable"] = dtAllData;
                GridApplyCoupon.DataSource = dtAllData;
                GridApplyCoupon.DataBind();
            }
            else
            {
                lblMsg.Visible = true;
                GridApplyCoupon.Visible = false;
                lblMsg.Text = "No Records !!";
            }
        }

    }
    public void Clear()
    {
        textName.Text = "";
        txtcompany.Text = "";
        btnsave.Text = "Save";
    }

    protected void GridApplyCoupon_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Delete"))
        {
            DataTable dt = new DataTable();
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            Label lblId = (Label)row.FindControl("lblId");
            journeyMaster.Type = "D";
            journeyMaster.loan_Id = Convert.ToInt32(lblId.Text);
            dt = whitelabelHelper.DeleteLoanType(journeyMaster);
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", "alert('Record  Deleted successfully. !!');", true);
            BindGrid();
           
        }
        else if (e.CommandName.Equals("Edit"))
        {
            DataTable dtfeatureFlight = new DataTable();
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            Label lblId = (Label)row.FindControl("lblId");
            journeyMaster.Type = "E";
            journeyMaster.loan_Id = Convert.ToInt32(lblId.Text);
            DataTable dtres = whitelabelHelper.Editloandata(journeyMaster);
            if (dtres.Rows.Count > 0)
            {
                hdn_Id.Value = lblId.Text;
                textName.Text = dtres.Rows[0]["loan_Type"].ToString();
                txtcompany.Text = dtres.Rows[0]["Loan_Code"].ToString();


                btnsave.Text = "Update";
            }
            else
            {
                GridApplyCoupon.Visible = false;
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", "alert('No Record !!');", true);
            }
        }
    }

    protected void GridApplyCoupon_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void GridApplyCoupon_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void GridApplyCoupon_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
}