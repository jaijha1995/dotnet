using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using log4net;
using System;
using System.IO;
using System.Text;
using System.Net.Mail;
using Core.Common;

/// <summary>
/// Summary description for whiltelabelHelper
/// </summary>
public class whitelabelHelper
{

    private DatabaseWhiteLabelCrm dataBase;

    private DataTable datatable;
    private DataSet dataset;
    private static readonly ILog logger = LogManager.GetLogger(typeof(whitelabelHelper));

    SearchEngine searchEngineCls = new SearchEngine();
    private DatabaseWhiteLabelCrm GetDatabaseObject()
    {
        if (object.Equals(dataBase, null))
        {
            dataBase = new DatabaseWhiteLabelCrm();
        }
        return dataBase;
    }

    private SqlParameter[] param;
    int Id;

    int insStatus = 0;
    public DataTable InsertLogBaggageUser(whitelable whitelable)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new DatabaseWhiteLabelCrm();
            }
            param = new SqlParameter[9];


            param[0] = dataBase.MakeInParameter("@type", SqlDbType.Char, 1, whitelable.Type);
            param[1] = dataBase.MakeInParameter("@CustomerName ", SqlDbType.VarChar, 20, whitelable.CustomerName);
            param[2] = dataBase.MakeInParameter("@ContactNo ", SqlDbType.NVarChar, 15, whitelable.ContactNo);
            param[3] = dataBase.MakeInParameter("@City", SqlDbType.NVarChar, 50, whitelable.City);
            param[4] = dataBase.MakeInParameter("@State", SqlDbType.NVarChar, 100, whitelable.State);
            param[5] = dataBase.MakeInParameter("@applicationType", SqlDbType.Char, 2, whitelable.applicationType);
            param[6] = dataBase.MakeInParameter("@CustomerID", SqlDbType.Int, 4, whitelable.CustomerID);
            param[7] = dataBase.MakeInParameter("@CreateUser", SqlDbType.NVarChar, 50, whitelable.CreateUser);
            param[8] = dataBase.MakeInParameter("@RoleType", SqlDbType.NVarChar, 1, whitelable.RoleType);
            dataBase.RunProcedure("intsert_del_upd", param, out datatable);
            insStatus = 1;
        }
        catch (Exception exp)
        {
            insStatus = 0;
            logger.Error(exp.ToString());
        }
        finally
        {
            Reset();
        }
        return datatable;
    }



 

    public DataTable GetCreateuser(whitelable whitelable)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new DatabaseWhiteLabelCrm();
            }
            param = new SqlParameter[3];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.Char, 1, whitelable.Type);
            param[1] = dataBase.MakeInParameter("@CreateUser", SqlDbType.NVarChar, 50, whitelable.CreateUser);
            param[2] = dataBase.MakeInParameter("@RoleType", SqlDbType.NVarChar, 50, whitelable.RoleType);
            dataBase.RunProcedure("intsert_del_upd", param, out datatable);
        }
        catch (Exception exp)
        {
            logger.Error(exp.ToString());
        }
        finally
        {
            Reset();
        }
        return datatable;
    }


    public DataTable GetCreateuserAdmin(whitelable whitelable)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new DatabaseWhiteLabelCrm();
            }
            param = new SqlParameter[2];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.Char, 1, whitelable.Type);
            param[1] = dataBase.MakeInParameter("@RoleType", SqlDbType.NVarChar, 50, whitelable.RoleType);
            dataBase.RunProcedure("intsert_del_upd", param, out datatable);
        }
        catch (Exception exp)
        {
            logger.Error(exp.ToString());
        }
        finally
        {
            Reset();
        }
        return datatable;
    }


    public DataTable getAirline(whitelable whitelable)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new DatabaseWhiteLabelCrm();
            }
            dataBase = GetDatabaseObject();

            param = new SqlParameter[1];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.Char, 2, whitelable.Type);
            //dataBase.RunProcedure("SelectItemDetail_Select", param, out datatable);
            dataBase.RunProcedure("SelectAll_Airline", param, out datatable);

        }
        catch (Exception exp)
        {
            logger.Error(exp.ToString());
        }
        finally
        {
            Reset();
        }
        return datatable;
    }


    private void Reset()
    {
        param = null;
        //dataBase = null;
    }


    public DataTable SelectAllSaAccountNo(whitelable Whitelable)
    {
        try
        {
            dataBase = GetDatabaseObject();
            param = new SqlParameter[1];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.Char, 2, Whitelable.Type);
            dataBase.RunProcedure("SelectInsert_SaAccountNo", param, out datatable);

        }
        catch (Exception ex)
        {
            logger.Error(ex.ToString());
        }
        finally
        {
            Reset();
        }
        return datatable;
    }

    int Status = 0;



    public int Delete_ProfileMaster(SpecialJourneyMaster journeyMaster)
    {
        try
        {

            dataBase = GetDatabaseObject();
            param = new SqlParameter[12];

            param[0] = dataBase.MakeInParameter("@ProfileId", SqlDbType.Int, 4, journeyMaster.ProfileId);
            param[1] = dataBase.MakeInParameter("@ProfileName", SqlDbType.NVarChar, 20, journeyMaster.ProfileName);
            param[2] = dataBase.MakeInParameter("@CompanyName", SqlDbType.NVarChar, 50, journeyMaster.CompanyName);
            param[3] = dataBase.MakeInParameter("@ContactNo", SqlDbType.NVarChar, 20, journeyMaster.ContactNo);
            param[4] = dataBase.MakeInParameter("@Address", SqlDbType.NVarChar, 50, journeyMaster.Address);
            param[5] = dataBase.MakeInParameter("@City", SqlDbType.NVarChar, 20, journeyMaster.City);
            param[6] = dataBase.MakeInParameter("@State", SqlDbType.NVarChar, 20, journeyMaster.State);
            param[7] = dataBase.MakeInParameter("@PanCard", SqlDbType.NVarChar, 100, journeyMaster.PanCard); // Fixed name (removed space)
            param[8] = dataBase.MakeInParameter("@AddharCard", SqlDbType.NVarChar, 100, journeyMaster.AddharCard); // Fixed name (removed space)
            param[9] = dataBase.MakeInParameter("@Gst", SqlDbType.NVarChar, 100, journeyMaster.Gst); // Fixed name (removed space)
            param[10] = dataBase.MakeInParameter("@Type", SqlDbType.Char, 1, journeyMaster.Type); // Type at the end as per procedure
            param[11] = dataBase.MakeOutParameter("@iresult", SqlDbType.Int, 5);
            dataBase.RunProcedure("InsertUpdateDelProfile", param, out datatable);
            Id = int.Parse(param[11].Value.ToString()); // Assuming ProfileId is being returned after insert/update

        }
        catch (Exception ex)
        {
            logger.Error(ex.ToString());
        }
        finally
        {
            Reset();
        }
        return Id;
    }




    public DataTable GetApplyManageprofile(SpecialJourneyMaster journeyMaster)
    {
        try
        {
            dataBase = GetDatabaseObject();
            param = new SqlParameter[2];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.VarChar, 1, journeyMaster.Type);
            param[1] = dataBase.MakeInParameter("@ProfileId", SqlDbType.Int, 4, journeyMaster.ProfileId);
            dataBase.RunProcedure("InsertUpdateDelProfile", param, out datatable);
        }
        catch (Exception ex)
        {

        }
        finally
        {
            Reset();
        }
        return datatable;
    }


    public DataTable EditprofileData(SpecialJourneyMaster journeyMaster)
    {
        try
        {
            dataBase = GetDatabaseObject();
            param = new SqlParameter[2];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.VarChar, 2, journeyMaster.Type);
            param[1] = dataBase.MakeInParameter("@ProfileId", SqlDbType.Int, 10, journeyMaster.ProfileId);
            dataBase.RunProcedure("InsertUpdateDelProfile", param, out datatable);
            //Id = (int)param[4].Value;
        }
        catch (Exception ex)
        {

        }
        finally
        {
            Reset();
        }
        return datatable;
    }



    public DataTable InserUpdateDeleteBlockBaggageMaster(whitelable wl)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = GetDatabaseObject();
            }
            param = new SqlParameter[2];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.Char, 1, wl.Type);
            param[1] = dataBase.MakeInParameter("@CustomerID", SqlDbType.Int, 8, wl.CustomerID);
            dataBase.RunProcedure("intsert_del_upd", param, out datatable);
        }
        catch (Exception exp)
        {
            logger.Error(exp.ToString());
        }
        finally
        {
            Reset();
        }
        return datatable;
    }

    public int Insert_SpecialProfile(SpecialJourneyMaster journeyMaster)
    {
        try
        {

            dataBase = GetDatabaseObject();
            param = new SqlParameter[12]; 

            param[0] = dataBase.MakeInParameter("@ProfileId", SqlDbType.Int, 4, journeyMaster.ProfileId);
            param[1] = dataBase.MakeInParameter("@ProfileName", SqlDbType.NVarChar, 20, journeyMaster.ProfileName);
            param[2] = dataBase.MakeInParameter("@CompanyName", SqlDbType.NVarChar, 50, journeyMaster.CompanyName);
            param[3] = dataBase.MakeInParameter("@ContactNo", SqlDbType.NVarChar, 20, journeyMaster.ContactNo);
            param[4] = dataBase.MakeInParameter("@Address", SqlDbType.NVarChar, 50, journeyMaster.Address);
            param[5] = dataBase.MakeInParameter("@City", SqlDbType.NVarChar, 20, journeyMaster.City);
            param[6] = dataBase.MakeInParameter("@State", SqlDbType.NVarChar, 20, journeyMaster.State);
            param[7] = dataBase.MakeInParameter("@PanCard", SqlDbType.NVarChar, 100, journeyMaster.PanCard); // Fixed name (removed space)
            param[8] = dataBase.MakeInParameter("@AddharCard", SqlDbType.NVarChar, 100, journeyMaster.AddharCard); // Fixed name (removed space)
            param[9] = dataBase.MakeInParameter("@Gst", SqlDbType.NVarChar, 100, journeyMaster.Gst); // Fixed name (removed space)
            param[10] = dataBase.MakeInParameter("@Type", SqlDbType.Char, 1, journeyMaster.Type); // Type at the end as per procedure
            param[11] = dataBase.MakeOutParameter("@iresult", SqlDbType.Int, 5);
            dataBase.RunProcedure("InsertUpdateDelProfile", param, out datatable);
            Id = int.Parse(param[11].Value.ToString()); // Assuming ProfileId is being returned after insert/update

        }
        catch (Exception ex)
        {
            logger.Error(ex.ToString());
        }
        finally
        {
            Reset();
        }
        return Id;
    }


    public whitelabelHelper()
    {
        string connStr = ConfigurationManager.AppSettings["conWhiteLabel"];
        connection = new SqlConnection(connStr);
    }

    private SqlConnection connection = null;
    public bool CityCodeExists(string CityCode)
    {
        bool exists = false;
        string query = "SELECT COUNT(*) FROM st_City WHERE CityCode = @CityCode";

        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@CityCode", CityCode);
            connection.Open();
            try
            {
                int count = (int)command.ExecuteScalar();
                exists = count > 0;
            }
            finally
            {
                connection.Close();
            }
        }
        return exists;
    }



 

    public int InsertUpdateDel_LoanType(LoanMaster journeyMaster)
    {
        try
        {

            dataBase = GetDatabaseObject();
            param = new SqlParameter[5];

            param[0] = dataBase.MakeInParameter("@loan_Id", SqlDbType.Int, 4, journeyMaster.loan_Id);
            param[1] = dataBase.MakeInParameter("@loan_Type", SqlDbType.NVarChar, 100, journeyMaster.loan_Type);
            param[2] = dataBase.MakeInParameter("@Loan_Code", SqlDbType.NVarChar, 20, journeyMaster.Loan_Code);
            param[3] = dataBase.MakeInParameter("@Type", SqlDbType.Char, 1, journeyMaster.Type);
            param[4] = dataBase.MakeOutParameter("@iresult", SqlDbType.Int, 5);
            dataBase.RunProcedure("intsertUpdateDel_LoanMaster", param, out datatable);
            Id = int.Parse(param[4].Value.ToString()); 

        }
        catch (Exception ex)
        {
            logger.Error(ex.ToString());
        }
        finally
        {
            Reset();
        }
        return Id;
    }



    public int InsertUpdateDel_BankData(Bankname bankdata)
    {
        try
        {

            dataBase = GetDatabaseObject();
            param = new SqlParameter[5];

            param[0] = dataBase.MakeInParameter("@BankId", SqlDbType.Int, 4, bankdata.BankId);
            param[1] = dataBase.MakeInParameter("@BankName", SqlDbType.NVarChar, 50, bankdata.BankName);
            param[2] = dataBase.MakeInParameter("@Bankcode", SqlDbType.NVarChar, 20, bankdata.Bankcode);
            param[3] = dataBase.MakeInParameter("@Type", SqlDbType.Char, 1, bankdata.Type);
            param[4] = dataBase.MakeOutParameter("@iresult", SqlDbType.Int, 5);
            dataBase.RunProcedure("BindBank_Details", param, out datatable);
            Id = int.Parse(param[4].Value.ToString());

        }
        catch (Exception ex)
        {
            logger.Error(ex.ToString());
        }
        finally
        {
            Reset();
        }
        return Id;
    }


    public DataTable DeleteLoanType(LoanMaster journeyMaster)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new DatabaseWhiteLabelCrm();
            }
            param = new SqlParameter[2];
            param[0] = dataBase.MakeInParameter("@type", SqlDbType.Char, 1, journeyMaster.Type);
            param[1] = dataBase.MakeInParameter("@loan_Id", SqlDbType.Int, 4, journeyMaster.loan_Id);
            dataBase.RunProcedure("intsertUpdateDel_LoanMaster", param, out datatable);
            insStatus = 1;
        }
        catch (Exception exp)
        {
            insStatus = 0;
            logger.Error(exp.ToString());
        }
        finally
        {
            Reset();
        }
        return datatable;
    }

    public DataTable DeletebankData(Bankname bankdata)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new DatabaseWhiteLabelCrm();
            }
            param = new SqlParameter[2];
            param[0] = dataBase.MakeInParameter("@type", SqlDbType.Char, 1, bankdata.Type);
            param[1] = dataBase.MakeInParameter("@BankId", SqlDbType.Int, 4, bankdata.BankId);
            dataBase.RunProcedure("BindBank_Details", param, out datatable);
            insStatus = 1;
        }
        catch (Exception exp)
        {
            insStatus = 0;
            logger.Error(exp.ToString());
        }
        finally
        {
            Reset();
        }
        return datatable;
    }

    public DataTable GetLoanData(LoanMaster journeyMaster)
    {
        try
        {
            dataBase = GetDatabaseObject();
            param = new SqlParameter[2];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.VarChar, 1, journeyMaster.Type);
            param[1] = dataBase.MakeInParameter("@loan_Id", SqlDbType.Int, 4, journeyMaster.loan_Id);
            dataBase.RunProcedure("intsertUpdateDel_LoanMaster", param, out datatable);
        }
        catch (Exception ex)
        {

        }
        finally
        {
            Reset();
        }
        return datatable;
    }

    public DataTable GetBankData(Bankname bankdata)
    {
        try
        {
            dataBase = GetDatabaseObject();
            param = new SqlParameter[2];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.VarChar, 1, bankdata.Type);
            param[1] = dataBase.MakeInParameter("@BankId", SqlDbType.Int, 4, bankdata.BankId);
            dataBase.RunProcedure("BindBank_Details", param, out datatable);
        }
        catch (Exception ex)
        {

        }
        finally
        {
            Reset();
        }
        return datatable;
    }

    public DataTable Editloandata(LoanMaster journeyMaster)
    {
        try
        {
            dataBase = GetDatabaseObject();
            param = new SqlParameter[2];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.VarChar, 2, journeyMaster.Type);
            param[1] = dataBase.MakeInParameter("@loan_Id", SqlDbType.Int, 10, journeyMaster.loan_Id);
            dataBase.RunProcedure("intsertUpdateDel_LoanMaster", param, out datatable);
            //Id = (int)param[4].Value;
        }
        catch (Exception ex)
        {

        }
        finally
        {
            Reset();
        }
        return datatable;
    }

    public DataTable Editbankdata(Bankname bankdata)
    {
        try
        {
            dataBase = GetDatabaseObject();
            param = new SqlParameter[2];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.VarChar, 2, bankdata.Type);
            param[1] = dataBase.MakeInParameter("@BankId", SqlDbType.Int, 4, bankdata.BankId);
            dataBase.RunProcedure("BindBank_Details", param, out datatable);
            //Id = (int)param[4].Value;
        }
        catch (Exception ex)
        {

        }
        finally
        {
            Reset();
        }
        return datatable;
    }

    public DataTable GetApplyLoanType()
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new DatabaseWhiteLabelCrm();
            }
            param = new SqlParameter[1];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.Char, 1, "B");
            dataBase.RunProcedure("intsertUpdateDel_LoanMaster", param, out datatable);
        }
        catch (Exception exp)
        {
            logger.Error(exp.ToString());
        }
        finally
        {
            Reset();
        }
        return datatable;
    }



    public DataTable GetBankName()
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new DatabaseWhiteLabelCrm();
            }
            param = new SqlParameter[1];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.Char, 1, "B");
            dataBase.RunProcedure("BindBank_Details", param, out datatable);
        }
        catch (Exception exp)
        {
            logger.Error(exp.ToString());
        }
        finally
        {
            Reset();
        }
        return datatable;
    }

    public DataTable GetApplyCustomerID(whitelable Whitelable)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new DatabaseWhiteLabelCrm();
            }
            param = new SqlParameter[3];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.Char, 1, Whitelable.Type);
            param[1] = dataBase.MakeInParameter("@CreateUser", SqlDbType.NVarChar, 50, Whitelable.CreateUser);
            param[2] = dataBase.MakeInParameter("@RoleType", SqlDbType.NVarChar, 1, Whitelable.RoleType);
            dataBase.RunProcedure("intsert_del_upd", param, out datatable);
        }
        catch (Exception exp)
        {
            logger.Error(exp.ToString());
        }
        finally
        {
            Reset();
        }
        return datatable;
    }


    public DataTable GetFinancialId(whitelable Whitelable)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new DatabaseWhiteLabelCrm();
            }
            param = new SqlParameter[3];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.Char, 1, Whitelable.Type);
            param[1] = dataBase.MakeInParameter("@CreateUser", SqlDbType.NVarChar, 100, Whitelable.CreateUser);
            param[2] = dataBase.MakeInParameter("@RoleType", SqlDbType.NVarChar, 50, Whitelable.RoleType);
            dataBase.RunProcedure("intsert_FinancialData", param, out datatable);
        }
        catch (Exception exp)
        {
            logger.Error(exp.ToString());
        }
        finally
        {
            Reset();
        }
        return datatable;
    }


    public DataTable GetLeadID(whitelable Whitelable)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new DatabaseWhiteLabelCrm();
            }
            param = new SqlParameter[1];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.Char, 1, Whitelable.Type);

            dataBase.RunProcedure("intsertUpdateDel_LeadMaster", param, out datatable);
        }
        catch (Exception exp)
        {
            logger.Error(exp.ToString());
        }
        finally
        {
            Reset();
        }
        return datatable;
    }


    public DataTable GetCustomerDetailsByleadId(ManageLeadsData leadsData)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new DatabaseWhiteLabelCrm();
            }
            param = new SqlParameter[2];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.Char, 1, leadsData.Type);
            param[1] = dataBase.MakeInParameter("@LeadID", SqlDbType.Char, 1, leadsData.LeadID);
            dataBase.RunProcedure("intsertUpdateDel_LeadMaster", param, out datatable);
        }
        catch (Exception exp)
        {
            logger.Error(exp.ToString());
        }
        finally
        {
            Reset();
        }
        return datatable;
    }

    public DataTable GetCustomername(ManageLeadsData leadsData)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new DatabaseWhiteLabelCrm();
            }
            param = new SqlParameter[2];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.Char, 1, leadsData.Type);
            param[1] = dataBase.MakeInParameter("@CustomerID", SqlDbType.Char, 1, leadsData.CustomerID);
            dataBase.RunProcedure("intsertUpdateDel_LeadMaster", param, out datatable);
        }
        catch (Exception exp)
        {
            logger.Error(exp.ToString());
        }
        finally
        {
            Reset();
        }
        return datatable;
    }

    public DataTable GetApplyManageprofile(ManageLeadsData leadsData)
    {
        try
        {
            dataBase = GetDatabaseObject();
            param = new SqlParameter[3];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.VarChar, 1, leadsData.Type);
            param[1] = dataBase.MakeInParameter("@CreateUser", SqlDbType.NVarChar, 50, leadsData.CreateUser);
            param[2] = dataBase.MakeInParameter("@RoleType", SqlDbType.NVarChar, 20, leadsData.RoleType);
            dataBase.RunProcedure("intsertUpdateDel_LeadMaster", param, out datatable);
        }
        catch (Exception ex)
        {

        }
        finally
        {
            Reset();
        }
        return datatable;
    }


    public DataTable GetFinancialAmt(SFinancialMaster financialdata)
    {
        try
        {
            dataBase = GetDatabaseObject();
            param = new SqlParameter[3];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.VarChar, 1, financialdata.Type);
            param[1] = dataBase.MakeInParameter("@CreateUser", SqlDbType.NVarChar, 50, financialdata.CreateUser);
            param[2] = dataBase.MakeInParameter("@RoleType", SqlDbType.NVarChar, 20, financialdata.RoleType);
            dataBase.RunProcedure("intsert_FinancialData", param, out datatable);
        }
        catch (Exception ex)
        {

        }
        finally
        {
            Reset();
        }
        return datatable;
    }


    public DataTable GetServicesAmt(ServicesMaster servicescharges)
    {
        try
        {
            dataBase = GetDatabaseObject();
            param = new SqlParameter[3];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.VarChar, 1, servicescharges.Type);
            param[1] = dataBase.MakeInParameter("@CreateUser", SqlDbType.NVarChar, 50, servicescharges.CreateUser);
            param[2] = dataBase.MakeInParameter("@RoleType", SqlDbType.NVarChar, 20, servicescharges.RoleType);
            dataBase.RunProcedure("sp_ManageServicesMaster", param, out datatable);
        }
        catch (Exception ex)
        {

        }
        finally
        {
            Reset();
        }
        return datatable;
    }


    public DataTable GetApplyCustomerStatus(ManageStatus leadsData)
    {
        try
        {
            dataBase = GetDatabaseObject();
            param = new SqlParameter[3];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.VarChar, 1, leadsData.Type);
            param[1] = dataBase.MakeInParameter("@CreateUser", SqlDbType.NVarChar, 20, leadsData.CreateUser);
            param[2] = dataBase.MakeInParameter("@RoleType", SqlDbType.NVarChar, 20, leadsData.RoleType);
            dataBase.RunProcedure("intsertUpdateDel_LeadMaster", param, out datatable);
        }
        catch (Exception ex)
        {

        }
        finally
        {
            Reset();
        }
        return datatable;
    }



    public DataTable GetApplyCustomerStatusAdmin(ManageStatus leadsData)
    {
        try
        {
            dataBase = GetDatabaseObject();
            param = new SqlParameter[2];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.VarChar, 1, leadsData.Type);
            param[1] = dataBase.MakeInParameter("@RoleType", SqlDbType.NVarChar, 20, leadsData.RoleType);
            dataBase.RunProcedure("intsertUpdateDel_LeadMaster", param, out datatable);
        }
        catch (Exception ex)
        {

        }
        finally
        {
            Reset();
        }
        return datatable;
    }



    public DataTable GetApplyCustomerStatusIndex(ManageStatus leadsData)
    {
        try
        {
            dataBase = GetDatabaseObject();
            param = new SqlParameter[1];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.VarChar, 1, leadsData.Type);
            dataBase.RunProcedure("intsertdelUpdate_CustomerStatus", param, out datatable);
        }
        catch (Exception ex)
        {

        }
        finally
        {
            Reset();
        }
        return datatable;
    }



    public DataTable InsertLeadData(ManageLeadsData leadsData)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new DatabaseWhiteLabelCrm();
            }
            param = new SqlParameter[9];


            param[0] = dataBase.MakeInParameter("@type", SqlDbType.Char, 1, leadsData.Type);
            param[1] = dataBase.MakeInParameter("@CustomerID", SqlDbType.Int, 4, leadsData.CustomerID);
            param[2] = dataBase.MakeInParameter("@LoanType ", SqlDbType.NVarChar, 50, leadsData.LoanType);
            param[3] = dataBase.MakeInParameter("@LoanAmt", SqlDbType.NVarChar, 50, leadsData.LoanAmt);
            param[4] = dataBase.MakeInParameter("@LoanDetails", SqlDbType.NVarChar, 50, leadsData.LoanDetails);
            //param[5] = dataBase.MakeInParameter("@BankName", SqlDbType.NVarChar, -1, leadsData.BankName);
            param[5] = dataBase.MakeInParameter("@LeadID", SqlDbType.Int, 4, leadsData.LeadID);
            param[6] = dataBase.MakeInParameter("@CreateUser", SqlDbType.NVarChar, 50, leadsData.CreateUser);
            param[7] = dataBase.MakeInParameter("@RoleType", SqlDbType.NVarChar, 1, leadsData.RoleType);
            param[8] = dataBase.MakeInParameter("@CustomerName ", SqlDbType.NVarChar, 100, leadsData.CustomerName);
            dataBase.RunProcedure("intsertUpdateDel_LeadMaster", param, out datatable);
            insStatus = 1;
        }
        catch (Exception exp)
        {
            insStatus = 0;
            logger.Error(exp.ToString());
        }
        finally
        {
            Reset();
        }
        return datatable;
    }


    public DataTable InsertCustomerStatus(ManageStatus leadsData)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new DatabaseWhiteLabelCrm();
            }
            param = new SqlParameter[19];
            param[0] = dataBase.MakeInParameter("@type", SqlDbType.Char, 1, leadsData.Type);
            param[1] = dataBase.MakeInParameter("@Id", SqlDbType.Int, 4, leadsData.Id);
            param[2] = dataBase.MakeInParameter("@LoanType", SqlDbType.NVarChar, 50, leadsData.LoanType);
            param[3] = dataBase.MakeInParameter("@LoanAmt", SqlDbType.NVarChar, 20, leadsData.LoanAmt);
            param[4] = dataBase.MakeInParameter("@LoanDetail", SqlDbType.NVarChar, 50, leadsData.LoanDetail);
            param[5] = dataBase.MakeInParameter("@BankName", SqlDbType.NVarChar, -1, leadsData.BankName);
            param[6] = dataBase.MakeInParameter("@CustomerName", SqlDbType.NVarChar, 100, leadsData.CustomerName); 
            param[7] = dataBase.MakeInParameter("@ContactNo", SqlDbType.NVarChar, 20, leadsData.ContactNo);
            param[8] = dataBase.MakeInParameter("@City", SqlDbType.NVarChar, 20, leadsData.City);
            param[9] = dataBase.MakeInParameter("@State", SqlDbType.NVarChar, 20, leadsData.State);
            param[10] = dataBase.MakeInParameter("@applicationType", SqlDbType.NVarChar, 20, leadsData.applicationType);
            param[11] = dataBase.MakeInParameter("@Status", SqlDbType.NVarChar, 20, leadsData.Status);
            param[12] = dataBase.MakeInParameter("@TenareDate", SqlDbType.NVarChar, 100, leadsData.TenareDate);
            param[13] = dataBase.MakeInParameter("@Rate", SqlDbType.NVarChar, 20, leadsData.Rate);
            param[14] = dataBase.MakeInParameter("@ForeCharge", SqlDbType.NVarChar, 20, leadsData.ForeCharge);
            param[15] = dataBase.MakeInParameter("@LeadID", SqlDbType.Int, 4, leadsData.LeadID);
            param[16] = dataBase.MakeInParameter("@CustomerID", SqlDbType.Int, 4, leadsData.CustomerID);
            param[17] = dataBase.MakeInParameter("@Reason", SqlDbType.NVarChar, -1, leadsData.Reason);
            param[18] = dataBase.MakeInParameter("@BankStatus", SqlDbType.NVarChar, 100, leadsData.Bankstatus);

            dataBase.RunProcedure("intsertdelUpdate_CustomerStatus", param, out datatable);
            insStatus = 1;
        }
        catch (Exception exp)
        {
            insStatus = 0;
            logger.Error(exp.ToString());
        }
        finally
        {
            Reset();
        }
        return datatable;
    }



    public DataTable InsertFinancialData(SFinancialMaster financialdata)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new DatabaseWhiteLabelCrm();
            }
            param = new SqlParameter[23];
            param[0] = dataBase.MakeInParameter("@type", SqlDbType.Char, 1, financialdata.Type);
            param[1] = dataBase.MakeInParameter("@Id", SqlDbType.Int, 4, financialdata.Id);
            param[2] = dataBase.MakeInParameter("@CustomerID", SqlDbType.Int, 4, financialdata.CustomerID);
            param[3] = dataBase.MakeInParameter("@LeadID", SqlDbType.Int, 4, financialdata.LeadID);
            param[4] = dataBase.MakeInParameter("@CustomerName", SqlDbType.NVarChar, 50, financialdata.CustomerName);
            param[5] = dataBase.MakeInParameter("@City", SqlDbType.NVarChar, 50, financialdata.City);
            param[6] = dataBase.MakeInParameter("@State", SqlDbType.NVarChar, -1, financialdata.State);
            param[7] = dataBase.MakeInParameter("@BankName", SqlDbType.NVarChar, 50, financialdata.BankName);
            param[8] = dataBase.MakeInParameter("@TransactionAmt", SqlDbType.Decimal, 18, financialdata.TransactionAmt);
            param[9] = dataBase.MakeInParameter("@ContactNo", SqlDbType.Decimal, 18, financialdata.ContactNo);
            param[10] = dataBase.MakeInParameter("@PFPercent", SqlDbType.Decimal, 18, financialdata.PFPercen);
            param[11] = dataBase.MakeInParameter("@PFAmt", SqlDbType.Decimal, 18, financialdata.PFAmt);
            param[12] = dataBase.MakeInParameter("@LPPercent", SqlDbType.Decimal, 18, financialdata.LPPercent);
            param[13] = dataBase.MakeInParameter("@LenderPayoutAmt", SqlDbType.Decimal, 18, financialdata.LenderPayoutAmt);
            param[14] = dataBase.MakeInParameter("@CPAmount", SqlDbType.Decimal, 18, financialdata.CPAmount);
            param[15] = dataBase.MakeInParameter("@CPPercent", SqlDbType.Decimal, 18, financialdata.CPPercent);
            param[16] = dataBase.MakeInParameter("@Recovery", SqlDbType.Decimal, 18, financialdata.Recovery);
            param[17] = dataBase.MakeInParameter("@FPAmt", SqlDbType.Decimal, 18, financialdata.FPAmt);
            param[18] = dataBase.MakeInParameter("@TDS", SqlDbType.Decimal, 18, financialdata.TDS);
            param[19] = dataBase.MakeInParameter("@Gst", SqlDbType.Decimal, 18, financialdata.Gst);
            param[20] = dataBase.MakeInParameter("@TotalPayout", SqlDbType.Decimal, 18, financialdata.TotalPayout);
            param[21] = dataBase.MakeInParameter("@CreateUser", SqlDbType.NVarChar, 50, financialdata.CreateUser);
            param[22] = dataBase.MakeInParameter("@RoleType", SqlDbType.NVarChar, 20, financialdata.RoleType);
            dataBase.RunProcedure("intsert_FinancialData", param, out datatable);
            insStatus = 1;
        }
        catch (Exception exp)
        {
            insStatus = 0;
            logger.Error(exp.ToString());
        }
        finally
        {
            Reset();
        }
        return datatable;
    }


    public DataTable InsertServiceMaster(ServicesMaster servicescharges)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new DatabaseWhiteLabelCrm();
            }
            param = new SqlParameter[20];
            param[0] = dataBase.MakeInParameter("@type", SqlDbType.Char, 1, servicescharges.Type);
            param[1] = dataBase.MakeInParameter("@Id", SqlDbType.Int, 4, servicescharges.Id);
            param[2] = dataBase.MakeInParameter("@CustomerID", SqlDbType.Int, 4, servicescharges.CustomerID);
            param[3] = dataBase.MakeInParameter("@LeadID", SqlDbType.Int, 4, servicescharges.LeadID);
            param[4] = dataBase.MakeInParameter("@CustomerName", SqlDbType.NVarChar, 50, servicescharges.CustomerName);
            param[5] = dataBase.MakeInParameter("@City", SqlDbType.NVarChar, 50, servicescharges.City);
            param[6] = dataBase.MakeInParameter("@State", SqlDbType.NVarChar, 20, servicescharges.State);
            param[7] = dataBase.MakeInParameter("@BankName", SqlDbType.NVarChar, -1, servicescharges.BankName);
            param[8] = dataBase.MakeInParameter("@TransactionAmt", SqlDbType.Decimal, 18, servicescharges.TransactionAmt);
            param[9] = dataBase.MakeInParameter("@ContactNo", SqlDbType.Decimal, 18, servicescharges.ContactNo);
            param[10] = dataBase.MakeInParameter("@ServiceChargesAmt", SqlDbType.Decimal, 18, servicescharges.ServiceChargesAmt);
            param[11] = dataBase.MakeInParameter("@CPSharePer", SqlDbType.Decimal, 18, servicescharges.CPSharePer);
            param[12] = dataBase.MakeInParameter("@CPShareAmt", SqlDbType.Decimal, 18, servicescharges.CPShareAmt);
            param[13] = dataBase.MakeInParameter("@Recovery", SqlDbType.Decimal, 18, servicescharges.Recovery);
            param[14] = dataBase.MakeInParameter("@FinalCPShareAmt", SqlDbType.Decimal, 18, servicescharges.FinalCPShareAmt);
            param[15] = dataBase.MakeInParameter("@TDS", SqlDbType.Decimal, 18, servicescharges.TDS);
            param[16] = dataBase.MakeInParameter("@Gst", SqlDbType.Decimal, 18, servicescharges.Gst);
            param[17] = dataBase.MakeInParameter("@NetCPShareAmt", SqlDbType.Decimal, 18, servicescharges.NetCPShareAmt);
            param[18] = dataBase.MakeInParameter("@CreateUser", SqlDbType.NVarChar, 50, servicescharges.CreateUser);
            param[19] = dataBase.MakeInParameter("@RoleType", SqlDbType.NVarChar, 20, servicescharges.RoleType);
            dataBase.RunProcedure("sp_ManageServicesMaster", param, out datatable);
            insStatus = 1;
        }
        catch (Exception exp)
        {
            insStatus = 0;
            logger.Error(exp.ToString());
        }
        finally
        {
            Reset();
        }
        return datatable;
    }


    public DataTable DeleteCustomerStatus(ManageStatus leadsData)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new DatabaseWhiteLabelCrm();
            }
            param = new SqlParameter[2];
            param[0] = dataBase.MakeInParameter("@type", SqlDbType.Char, 1, leadsData.Type);
            param[1] = dataBase.MakeInParameter("@Id", SqlDbType.Int, 4, leadsData.Id);
            dataBase.RunProcedure("intsertdelUpdate_CustomerStatus", param, out datatable);
            insStatus = 1;
        }
        catch (Exception exp)
        {
            insStatus = 0;
            logger.Error(exp.ToString());
        }
        finally
        {
            Reset();
        }
        return datatable;
    }


    public DataTable EditleadData(ManageLeadsData leadsData)
    {
        try
        {
            dataBase = GetDatabaseObject();
            param = new SqlParameter[2];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.VarChar, 2, leadsData.Type);
            param[1] = dataBase.MakeInParameter("@LeadID", SqlDbType.Int, 10, leadsData.LeadID);
            dataBase.RunProcedure("intsertUpdateDel_LeadMaster", param, out datatable);
            //Id = (int)param[4].Value;
        }
        catch (Exception ex)
        {

        }
        finally
        {
            Reset();
        }
        return datatable;
    }


    public DataTable EditFinancialData(SFinancialMaster financialdata)
    {
        try
        {
            dataBase = GetDatabaseObject();
            param = new SqlParameter[2];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.VarChar, 2, financialdata.Type);
            param[1] = dataBase.MakeInParameter("@Id", SqlDbType.Int, 10, financialdata.Id);
            dataBase.RunProcedure("intsert_FinancialData", param, out datatable);
            //Id = (int)param[4].Value;
        }
        catch (Exception ex)
        {

        }
        finally
        {
            Reset();
        }
        return datatable;
    }


    public DataTable EditServiceData(ServicesMaster servicescharges)
    {
        try
        {
            dataBase = GetDatabaseObject();
            param = new SqlParameter[2];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.VarChar, 2, servicescharges.Type);
            param[1] = dataBase.MakeInParameter("@Id", SqlDbType.Int, 10, servicescharges.Id);
            dataBase.RunProcedure("sp_ManageServicesMaster", param, out datatable);
            //Id = (int)param[4].Value;
        }
        catch (Exception ex)
        {

        }
        finally
        {
            Reset();
        }
        return datatable;
    }

    public DataTable EditCustomerStatus(ManageStatus leadsData)
    {
        try
        {
            dataBase = GetDatabaseObject();
            param = new SqlParameter[2];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.VarChar, 2, leadsData.Type);
            param[1] = dataBase.MakeInParameter("@LeadID", SqlDbType.Int, 4, leadsData.LeadID);
            dataBase.RunProcedure("intsertUpdateDel_LeadMaster", param, out datatable);
            //Id = (int)param[4].Value;
        }
        catch (Exception ex)
        {

        }
        finally
        {
            Reset();
        }
        return datatable;
    }

    public DataTable EditCustomerStatusIndex(ManageStatus leadsData)
    {
        try
        {
            dataBase = GetDatabaseObject();
            param = new SqlParameter[2];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.VarChar, 2, leadsData.Type);
            param[1] = dataBase.MakeInParameter("@Id", SqlDbType.Int, 4, leadsData.Id);
            dataBase.RunProcedure("intsertdelUpdate_CustomerStatus", param, out datatable);
            //Id = (int)param[4].Value;
        }
        catch (Exception ex)
        {

        }
        finally
        {
            Reset();
        }
        return datatable;
    }


    public DataTable Getsitedata(SearchEngine searchEngineCls)
    {
        try
        {
            dataBase = GetDatabaseObject();
            param = new SqlParameter[1];
            param[0] = dataBase.MakeInParameter("@userId", SqlDbType.NVarChar, 50, searchEngineCls.UserId);
            dataBase.RunProcedure("SubAgent_BindData", param, out datatable);
        }
        catch (Exception ex)
        {

        }
        finally
        {
            Reset();
        }
        return datatable;
    }

    //private DataTable ChangePassword(whitelable Whitelable)
    //{
    //    Encrypt l_Encrypt = new Encrypt();
    //    string encryptedPassword = l_Encrypt.Encrypting(newPassword, ConfigurationManager.AppSettings["encryptKey"].ToString());

    //    try
    //    {
    //        SqlParameter[] param = new SqlParameter[3];
    //        param[0] = new SqlParameter("@userId", SqlDbType.NVarChar, 100) { Value = userId };
    //        param[1] = new SqlParameter("@newPassword", SqlDbType.NVarChar, 100) { Value = encryptedPassword };
    //        param[2] = new SqlParameter("@Return_Value", SqlDbType.Int) { Direction = ParameterDirection.Output };

    //        dataBase = GetDatabaseObject();
    //        dataBase.RunProcedure("SubAgent_ChangePassword", param);

    //        int returnValue = (int)param[2].Value;
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //    finally
    //    {
    //        Reset();
    //    }
    //    return datatable;
    //}


}