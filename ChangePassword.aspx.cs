using Core.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core.InterfaceLayer;
using log4net;

public partial class ChangePassword : System.Web.UI.Page
{

    whitelable Whitelable = new whitelable();
    whitelabelHelper WhitelabelHelper = new whitelabelHelper();
    Core.InterfaceLayer.Login login = new Core.InterfaceLayer.Login();

    DataTable datatable = new DataTable();
    private Database dataBase;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnResetPassword_Click(object sender, EventArgs e)
    {
        string newPassword = txtnew.Text;
        string confirmNewPassword = txtconfirm.Text;

        if (newPassword != confirmNewPassword)
        {
            lblMsg.Text = "Passwords do not match.";
            lblMsg.Visible = true;
            return;
        }

        string currentUserId = Session["UserId"].ToString();
        Encrypt encrypt = new Encrypt();
        string encryptedNewPassword = encrypt.Encrypting(newPassword, ConfigurationManager.AppSettings["encryptKey"].ToString());

        // Update the password in the database
        bool isUpdated = UpdatePasswordInDatabase(currentUserId, encryptedNewPassword);

        if (isUpdated)
        {
            lblMsg.Text = "Password updated successfully!";
            lblMsg.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            lblMsg.Text = "Password update failed.";
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
        lblMsg.Visible = true;
    }


    private Database GetDatabaseObject()
    {
        if (object.Equals(dataBase, null))
        {
            dataBase = new Database();
        }
        return dataBase;
    }
    private static readonly ILog logger = LogManager.GetLogger(typeof(LoginHelper));
    private SqlParameter[] param;

    private bool UpdatePasswordInDatabase(string userId, string newPassword)
    {
        try
        {
            dataBase = GetDatabaseObject();
            SqlParameter[] param = new SqlParameter[3]; 
            param[0] = new SqlParameter("@UserId", userId);
            param[1] = new SqlParameter("@NewPassword", newPassword);
            param[2] = new SqlParameter("@ReturnValue", SqlDbType.Int);
            param[2].Direction = ParameterDirection.Output;

            dataBase.RunProcedure("UpdatePassword", param);

            int returnValue = (int)param[2].Value; 

            return returnValue == 1;

        }
        catch (Exception ex)
        {
            logger.Error("Error updating password.", ex);
            return false;
        }
    }

}