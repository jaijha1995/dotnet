using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManageJourneyMaster : System.Web.UI.Page
{
    whitelable Whitelable = new whitelable();
    SpecialJourneyMaster journeyMaster = new SpecialJourneyMaster();
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
        var journeyMaster = new SpecialJourneyMaster();

        if (btnsave.Text == "Update")
        {
            journeyMaster.Type = "U";
            journeyMaster.ProfileId = int.Parse(hdn_Id.Value);
            message = "Record Is Updated";
        }
        else
        {
            journeyMaster.Type = "I";
            message = "Record Is Inserted";
        }

        journeyMaster.ProfileName = textName.Text.Trim().ToUpper();
        journeyMaster.CompanyName = txtcompany.Text.Trim();
        journeyMaster.ContactNo = txtcontactNo.Text.Trim();
        journeyMaster.Address = txtAddress.Text.Trim();
        journeyMaster.City = txtcity.Text.Trim();
        journeyMaster.State = txtstate.Text.Trim();


        if (Uploadpancard.HasFile)
        {
            string panCardPath = SaveFile(Uploadpancard, "PanCard");
            journeyMaster.PanCard = panCardPath;
        }
        else if (!string.IsNullOrEmpty(lblPanCard.Text))
        {
            journeyMaster.PanCard = lblPanCard.Text;
        }


        if (UploadAdharcaard.HasFile)
        {
            string aadharCardPath = SaveFile(UploadAdharcaard, "AddharCard");
            journeyMaster.AddharCard = aadharCardPath;
        }
        else if (!string.IsNullOrEmpty(lblAadharCard.Text))
        {
            journeyMaster.AddharCard = lblAadharCard.Text;
        }

        if (UploadGst.HasFile)
        {
            string gstPath = SaveFile(UploadGst, "Gst");
            journeyMaster.Gst = gstPath;
        }
        else if (!string.IsNullOrEmpty(lblGST.Text))
        {
            journeyMaster.Gst = lblGST.Text;
        }
        int Id = whitelabelHelper.Insert_SpecialProfile(journeyMaster);
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


    private string SaveFile(FileUpload fileUpload, string fileType)
    {
        string folderPath = Server.MapPath("~/Uploads/" + fileType + "/");
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        string fileName = Path.GetFileName(fileUpload.PostedFile.FileName);
        string filePath = folderPath + fileName;
        fileUpload.SaveAs(filePath);

        return filePath;
    }

    private void BindGrid()
    {
        DataTable dtAllData = new DataTable();
        journeyMaster.Type = "S";
        journeyMaster.ProfileId = int.Parse(hdn_Id.Value);
        dtAllData = whitelabelHelper.GetApplyManageprofile(journeyMaster);
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

    protected void DownloadFile(object sender, EventArgs e)
    {
        string filePath = (sender as LinkButton).CommandArgument; // Get the file path from the CommandArgument
        if (!string.IsNullOrEmpty(filePath))
        {
            // Since filePath is already a physical path, no need to use Server.MapPath
            if (File.Exists(filePath))
            {
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.TransmitFile(filePath);
                Response.End();
            }
        }
    }

    protected void DownloadAddharcard(object sender, EventArgs e)
    {
        string filePath = (sender as LinkButton).CommandArgument; // Get the file path from the CommandArgument
        if (!string.IsNullOrEmpty(filePath))
        {
            // Since filePath is already a physical path, no need to use Server.MapPath
            if (File.Exists(filePath))
            {
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.TransmitFile(filePath);
                Response.End();
            }
        }
    }

    protected void DownloadGst(object sender, EventArgs e)
    {
        string filePath = (sender as LinkButton).CommandArgument; // Get the file path from the CommandArgument
        if (!string.IsNullOrEmpty(filePath))
        {
            // Since filePath is already a physical path, no need to use Server.MapPath
            if (File.Exists(filePath))
            {
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.TransmitFile(filePath);
                Response.End();
            }
        }
    }

    public void Clear()
    {
        textName.Text = "";
        txtcompany.Text = "";
        txtcontactNo.Text = "";
        txtAddress.Text = "";
        txtcity.Text = "";
        txtstate.Text = "";
        lblPanCard.Text = "";
        lblAadharCard.Text = "";
        lblGST.Text = "";
        btnsave.Text = "Save";
    }

    protected void GridApplyCoupon_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Delete"))
        {
            DataTable dtfeatureFlight = new DataTable();
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            Label lblId = (Label)row.FindControl("lblId");
            journeyMaster.Type = "D";
            journeyMaster.ProfileId = Convert.ToInt32(lblId.Text);
            int res = whitelabelHelper.Delete_ProfileMaster(journeyMaster);
            if (res > 0)
            {

                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", "alert('Deleted Successfuly !!');", true);
                BindGrid();
            }
            else
            {
                GridApplyCoupon.Visible = false;
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", "alert('No Record !!');", true);
            }
        }
        else if (e.CommandName.Equals("Edit"))
        {
            DataTable dtfeatureFlight = new DataTable();
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            Label lblId = (Label)row.FindControl("lblId");
            journeyMaster.Type = "E";
            journeyMaster.ProfileId = Convert.ToInt32(lblId.Text);
            DataTable dtres = whitelabelHelper.EditprofileData(journeyMaster);
            if (dtres.Rows.Count > 0)
            {
                hdn_Id.Value = lblId.Text;
                textName.Text = dtres.Rows[0]["ProfileName"].ToString();
                txtcompany.Text = dtres.Rows[0]["CompanyName"].ToString();
                txtcontactNo.Text = dtres.Rows[0]["ContactNo"].ToString();
                txtAddress.Text = dtres.Rows[0]["Address"].ToString();
                txtcity.Text = dtres.Rows[0]["City"].ToString();
                txtstate.Text = dtres.Rows[0]["State"].ToString();
                if (!string.IsNullOrEmpty(dtres.Rows[0]["PanCard"].ToString()))
                {
                    lblPanCard.Text = dtres.Rows[0]["PanCard"].ToString();
                }
                if (!string.IsNullOrEmpty(dtres.Rows[0]["AddharCard"].ToString()))
                {
                    lblAadharCard.Text = dtres.Rows[0]["AddharCard"].ToString();
                }
                if (!string.IsNullOrEmpty(dtres.Rows[0]["GST"].ToString()))
                {
                    lblGST.Text = dtres.Rows[0]["GST"].ToString();
                }

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