using Core.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UploadFileServices : System.Web.UI.Page
{
    whitelable Whitelable = new whitelable();
    whitelabelHelper WhitelabelHelper = new whitelabelHelper();
    ManageLeadsData leadsData = new ManageLeadsData();
    Encrypt l_Encrypt = new Encrypt();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (object.Equals(Session["UserId"], null))
            Response.Redirect("Login.aspx");

        if (!IsPostBack)
        {
            BindServicesId();
        }
    }

    private void BindServicesId()
    {
        try
        {
            if (Session["roleType"].ToString() == "U")
            {
                Whitelable.Type = "G";
                Whitelable.CreateUser = Session["UserId"].ToString();
                Whitelable.RoleType = Session["roleType"].ToString();
                DataTable dt = WhitelabelHelper.GetFinancialId(Whitelable);

                if (dt != null && dt.Rows.Count > 0)
                {
                    txtuserid.DataSource = dt;
                    txtuserid.DataTextField = "Id";
                    txtuserid.DataValueField = "Id";
                    txtuserid.DataBind();
                }
            }
            else if (Session["roleType"].ToString() == "A")
            {
                Whitelable.Type = "G";

                Whitelable.RoleType = Session["roleType"].ToString();
                DataTable dt = WhitelabelHelper.GetFinancialId(Whitelable);

                if (dt != null && dt.Rows.Count > 0)
                {
                    txtuserid.DataSource = dt;
                    txtuserid.DataTextField = "Id";
                    txtuserid.DataValueField = "Id";
                    txtuserid.DataBind();
                }
            }


        }
        catch (Exception ex)
        {
            lblMsg.Text = "An error occurred: " + ex.Message;
            lblMsg.Visible = true;
        }
    }


    protected void btndownload_Click(object sender, EventArgs e)
    {
        try
        {
            string xlpath = "~/ServiceExcel/" + txtuserid.SelectedValue.ToString();
            var directory = new DirectoryInfo(Server.MapPath(xlpath));
            if (directory.Exists)
            {
                if (directory.GetFiles().Length > 0)
                {
                    var myfile = directory.GetFiles()
                                .OrderByDescending(f => f.LastWriteTime)
                                .First();
                    Response.Clear();
                    Response.ContentType = "application/octet-stream";
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + myfile.Name);
                    Response.TransmitFile(myfile.FullName);
                    Response.End();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", "alert('No files available for download !!');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", "alert('Directory does not exist !!');", true);
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", "alert('Something went wrong: " + ex.Message + "');", true);
        }
    }


    protected void btnUploadOffer_OnClick(object sender, EventArgs e)
    {
        if (fileuploadExcel.PostedFile.ContentLength > 0)
        {
            try
            {
                string sPath = "~/ServiceExcel/" + txtuserid.SelectedValue.ToString();
                DirectoryInfo dir = new DirectoryInfo(Server.MapPath(sPath));
                if (!dir.Exists)
                {
                    dir.Create();
                }
                string fileExtension = Path.GetExtension(fileuploadExcel.PostedFile.FileName);
                string renameExclFile = System.DateTime.Now.Year + System.DateTime.Now.DayOfYear.ToString() + System.DateTime.Now.Hour + System.DateTime.Now.Millisecond + fileExtension.ToString();
                string FullPath = sPath + "/" + renameExclFile;
                fileuploadExcel.PostedFile.SaveAs(MapPath(FullPath));
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", "alert('File Uploaded Successfully !!');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", "alert('Error: " + ex.Message + "');", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", "alert('Please select a valid file !!');", true);
        }
    }


}