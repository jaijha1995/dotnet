using System;
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

/// <summary>
/// Summary description for SearchEngineHelper
/// </summary>
public class SearchEngineHelper
{
    private Database dataBase;
   
    private DataTable datatable;
    private Database GetDatabaseObject()
    {
        if (object.Equals(dataBase, null))
        {
            dataBase = new Database();
        }
        return dataBase;
    }

    
    private static readonly ILog logger = LogManager.GetLogger(typeof(SearchEngineHelper));
    private SqlParameter[] param;
    private DataSet dataSet;
    int Id;

    


    public DataTable GetClientDetailInsert(SearchEngine searchEngine)
    {
        param = new SqlParameter[9];

        if (object.Equals(dataBase, null))
        {
            dataBase = new Database();
        }
        try
        {
            param[0] = dataBase.MakeInParameter("@FirstName", SqlDbType.NVarChar, 50, searchEngine.FirstName);
            param[1] = dataBase.MakeInParameter("@LastName", SqlDbType.NVarChar, 50, searchEngine.LastName);
            param[2] = dataBase.MakeInParameter("@Mobile", SqlDbType.NVarChar, 20, searchEngine.MobileNo);
            param[3] = dataBase.MakeInParameter("@EmailAddress", SqlDbType.VarChar, 50, searchEngine.EmailId);
            param[4] = dataBase.MakeInParameter("@PostCode", SqlDbType.NVarChar, 50, searchEngine.PostCode);
            param[5] = dataBase.MakeInParameter("@CountryName", SqlDbType.VarChar, 50, searchEngine.Country);
            param[6] = dataBase.MakeInParameter("@Password", SqlDbType.VarChar, 20, searchEngine.Password);
            param[7] = dataBase.MakeInParameter("@Type", SqlDbType.Char, 1, searchEngine.Type);
            param[8] = dataBase.MakeInParameter("@Client_ID", SqlDbType.Int, 4, searchEngine.ClientId);
            dataBase.RunProcedure("ClientMaster_Signup_Insert", param, out datatable);

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

    

    public DataTable GetClientDetail(SearchEngine searchEngine)
    {
        param = new SqlParameter[2];
        // dataBase = GetdataBaseObject();
        if (object.Equals(dataBase, null))
        {
            dataBase = new Database();
        }
        try
        {
            param[0] = dataBase.MakeInParameter("@Client_ID", SqlDbType.Int, 4, searchEngine.ClientId);
            param[1] = dataBase.MakeInParameter("@Type", SqlDbType.Char, 1, searchEngine.Type);
            dataBase.RunProcedure("ClientMaster_Signup_Insert", param, out datatable);
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

    public DataTable GetBookingDetail(SearchEngine searchEngine)
    {
        param = new SqlParameter[2];
        // dataBase = GetdataBaseObject();
        if (object.Equals(dataBase, null))
        {
            dataBase = new Database();
        }
        try
        {
            param[0] = dataBase.MakeInParameter("@Email_Id", SqlDbType.NVarChar, 50, searchEngine.EmailId);
            param[1] = dataBase.MakeInParameter("@Type", SqlDbType.Char, 1, searchEngine.Type);
            dataBase.RunProcedure("BookingMaster_SelectBooking", param, out datatable);
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



    /// <summary>
  
    /// </summary>
    /// <param name="searchEngine"></param>
    /// <returns></returns>
    public DataTable GetBookingResultByAccount(SearchEngine searchEngine)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new Database();
            }
            param = new SqlParameter[7];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.Char, 2, searchEngine.Type);
            param[1] = dataBase.MakeInParameter("@AccountNo", SqlDbType.VarChar, 50, searchEngine.AccountNo);
            param[2] = dataBase.MakeInParameter("@ActionFlag", SqlDbType.Char, 1, searchEngine.ActionFlag);
            param[3] = dataBase.MakeInParameter("@LastName", SqlDbType.VarChar, 50, searchEngine.LastName);
            param[4] = dataBase.MakeInParameter("@PNR", SqlDbType.VarChar, 50, searchEngine.Pnr_No);
            param[5] = dataBase.MakeInParameter("@Booking_ref", SqlDbType.BigInt, 8, searchEngine.Booking_Ref);
            param[6] = dataBase.MakeInParameter("@agentId", SqlDbType.Int, 4, searchEngine.AgentId);
            dataBase.RunProcedure("BookingMaster_SelectByAccount", param, out datatable);
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


    public DataSet GetBookingDetails(SearchEngine searchEngine)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new Database();
            }
            param = new SqlParameter[1];
            param[0] = dataBase.MakeInParameter("@Booking_Ref", SqlDbType.BigInt, 8, searchEngine.Booking_Ref);

            dataBase.RunProcedure("BookingDetail_Select", param, out dataSet);
        }
        catch (Exception exp)
        {
            logger.Error(exp.ToString());
        }
        finally
        {
            Reset();
        }
        return dataSet;
    }

    public DataSet GetPaxTypeCount(SearchEngine searchEngine)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new Database();
            }
            param = new SqlParameter[1];
            param[0] = dataBase.MakeInParameter("@Booking_Ref", SqlDbType.BigInt, 8, searchEngine.Booking_Ref);
           // param[1] = dataBase.MakeInParameter("@Pnr_no", SqlDbType.NChar, 10, searchEngine.Pnr_No);

            dataBase.RunProcedure("PasssengerDetails_SelectPaxType", param, out dataSet);
        }
        catch (Exception exp)
        {
            logger.Error(exp.ToString());
        }
        finally
        {
            Reset();
        }
        return dataSet;
    }

    public DataTable GetBookingResultByAnyOne(SearchEngine searchEngine)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new Database();
            }
            param = new SqlParameter[3];

            param[0] = dataBase.MakeInParameter("@Query", SqlDbType.NVarChar, 500, searchEngine.Query);
            param[1] = dataBase.MakeInParameter("@Type", SqlDbType.Char, 2, searchEngine.Type);
            param[2] = dataBase.MakeInParameter("@agentId", SqlDbType.Int, 4, searchEngine.AgentId);
            dataBase.RunProcedure("BookingMaster_SelectByAccount", param, out datatable);
            return datatable;
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

    public DataTable LoginCheck(SearchEngine searchEngine)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new Database();
            }
            param = new SqlParameter[2];
            param[0] = dataBase.MakeInParameter("@UserId", SqlDbType.NVarChar, 50, searchEngine.UserId);
            param[1] = dataBase.MakeInParameter("@Password", SqlDbType.NVarChar, 50, searchEngine.Password);
           // param[2] = dataBase.MakeInParameter("@Company_Id", SqlDbType.NVarChar, 50, searchEngine.CompanyCode);

            dataBase.RunProcedure("Login_Select", param, out datatable);

            return datatable;
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

    public void SetTakeControl(SearchEngine searchEngine)
    {
        param = new SqlParameter[3];
        if (object.Equals(dataBase, null))
        {
            dataBase = new Database();
        }
        try
        {
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.Char, 2, searchEngine.Type);
            param[1] = dataBase.MakeInParameter("@Booking_Ref", SqlDbType.BigInt, 8, searchEngine.Booking_Ref);
            param[2] = dataBase.MakeInParameter("@agentId", SqlDbType.Int, 4, searchEngine.UserId);
            dataBase.RunProcedure("BookingMaster_SelectByAccount", param);

        }
        catch (Exception exp)
        {
            logger.Error(exp.ToString());
        }
        finally
        {
            Reset();
        }

    }

    public DataTable GetProfileLoginDetail(SearchEngine searchEngine)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new Database();
            }
            param = new SqlParameter[3];
            param[0] = dataBase.MakeInParameter("@UserId", SqlDbType.NVarChar, 20, searchEngine.UserId);
            param[1] = dataBase.MakeInParameter("@Password", SqlDbType.NVarChar, 100, searchEngine.Password);
            param[2] = dataBase.MakeInParameter("@Type", SqlDbType.Char, 2, searchEngine.Type);

            dataBase.RunProcedure("SubAgentMaster_SelectProfile", param, out datatable);

            return datatable;
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

    public DataTable UpdateProfileDetail(SearchEngine searchEngine)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new Database();
            }
            param = new SqlParameter[15];
            param[0] = dataBase.MakeInParameter("@FirstName", SqlDbType.NVarChar, 20, searchEngine.FirstName);
            param[1] = dataBase.MakeInParameter("@LastName", SqlDbType.NVarChar, 100, searchEngine.LastName);
            param[2] = dataBase.MakeInParameter("@Type", SqlDbType.Char, 2, searchEngine.Type);
            param[3] = dataBase.MakeInParameter("@EmailId", SqlDbType.NVarChar, 50, searchEngine.EmailId);
            param[4] = dataBase.MakeInParameter("@Mobile", SqlDbType.NVarChar, 20, searchEngine.MobileNo);
            param[5] = dataBase.MakeInParameter("@Phone", SqlDbType.NVarChar, 20, searchEngine.Phone);
            param[6] = dataBase.MakeInParameter("@Street", SqlDbType.NVarChar, 150, searchEngine.Street);
            param[7] = dataBase.MakeInParameter("@City", SqlDbType.NVarChar, 50, searchEngine.City);
            param[8] = dataBase.MakeInParameter("@State", SqlDbType.NVarChar, 50, searchEngine.State);
            param[9] = dataBase.MakeInParameter("@AgencyName", SqlDbType.NVarChar, 50, searchEngine.AgencyName);
            param[10] = dataBase.MakeInParameter("@Fax", SqlDbType.NVarChar, 20, searchEngine.Fax);
            param[11] = dataBase.MakeInParameter("@PostCode", SqlDbType.NVarChar, 20, searchEngine.PostCode);
            param[12] = dataBase.MakeInParameter("@ProfileImg", SqlDbType.NVarChar, 50, searchEngine.ProfileImg);
            param[13] = dataBase.MakeInParameter("@Id", SqlDbType.Int, 4, searchEngine.Id);
            param[14] = dataBase.MakeInParameter("@CountryId", SqlDbType.Int, 4, searchEngine.CountryId);

            dataBase.RunProcedure("SubAgentMaster_SelectProfile", param, out datatable);

           
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

    public DataTable GetCountry(SearchEngine searchEngine)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new Database();
            }
            param = new SqlParameter[0];

            dataBase.RunProcedure("Country_Select", param, out datatable);

            return datatable;
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

    public void UpdateThemeSetting(SearchEngine searchEngine)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new Database();
            }
            param = new SqlParameter[6];
            param[0] = dataBase.MakeInParameter("@SkinTheme", SqlDbType.NVarChar, 20, searchEngine.SkinTheme);
            param[1] = dataBase.MakeInParameter("@NavTheme", SqlDbType.NVarChar, 20, searchEngine.NavTheme);
            param[2] = dataBase.MakeInParameter("@Type", SqlDbType.Char, 2, searchEngine.Type);
            param[3] = dataBase.MakeInParameter("@SideTheme", SqlDbType.NVarChar, 20, searchEngine.SideTheme);
            param[4] = dataBase.MakeInParameter("@UserId", SqlDbType.NVarChar, 20, searchEngine.UserId);
            param[5] = dataBase.MakeInParameter("@Password", SqlDbType.NVarChar, 100, searchEngine.Password);

            dataBase.RunProcedure("SubAgentMaster_SelectProfile", param);


        }
        catch (Exception exp)
        {
            logger.Error(exp.ToString());
        }
        finally
        {
            Reset();
        }

    }


    ///////////////////////////

    public DataTable SubAgent_ForgotPassword(SearchEngine searchEngine)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new Database();
            }
            param = new SqlParameter[2];

            param[0] = dataBase.MakeInParameter("@Email", SqlDbType.NVarChar, 50, searchEngine.EmailId);
            param[1] = dataBase.MakeInParameter("@UserId", SqlDbType.NVarChar, 20, searchEngine.UserId);
            dataBase.RunProcedure("SubAgent_ForgotPassword", param, out datatable);

            return datatable;
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


    /////
    public DataTable GetpaymentRequest_Select_updateById(SearchEngine searchEngine)
    {
        param = new SqlParameter[10];
        // dataBaseReservation = GetDatabaseReservationObject();
        if (object.Equals(dataBase, null))
        {
            dataBase = new Database();
        }
        try
        {
            param[0] = dataBase.MakeInParameter("@invoiceId", SqlDbType.Int, 4, searchEngine.InvoiceId);
            param[1] = dataBase.MakeInParameter("@lastName", SqlDbType.NVarChar, 50, searchEngine.LastName);
            param[2] = dataBase.MakeInParameter("@type", SqlDbType.Char, 1, searchEngine.Type);
            param[3] = dataBase.MakeInParameter("@isPaid", SqlDbType.Bit, 1, searchEngine.IsPaid);
            param[4] = dataBase.MakeInParameter("@firstName", SqlDbType.NVarChar, 50, searchEngine.FirstName);
            param[5] = dataBase.MakeInParameter("@sales_Channel", SqlDbType.NVarChar, 20, searchEngine.sales_Channel);
            param[6] = dataBase.MakeInParameter("@transId", SqlDbType.NVarChar, 50, searchEngine.TransID);
            param[7] = dataBase.MakeInParameter("@bookingRef", SqlDbType.BigInt, 8, searchEngine.BookingRef);
            param[8] = dataBase.MakeInParameter("@netAmt", SqlDbType.Decimal, 18, searchEngine.TotAmt);
            param[9] = dataBase.MakeInParameter("@email", SqlDbType.NVarChar, 50, searchEngine.EmailId);
            dataBase.RunProcedure("paymentRequest_Select_updateById", param, out datatable);
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

    int resetPwdFlag = 0;
    public int SubAgent_ResetPassword(SearchEngine searchEngine)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new Database();
            }
            param = new SqlParameter[5];

            param[0] = dataBase.MakeInParameter("@EmailId", SqlDbType.NVarChar, 50, searchEngine.EmailId);
            param[1] = dataBase.MakeInParameter("@UserId", SqlDbType.NVarChar, 20, searchEngine.UserId);
            param[2] = dataBase.MakeInParameter("@Password", SqlDbType.NVarChar, 100, searchEngine.Password);
            param[3] = dataBase.MakeInParameter("@NewPassword", SqlDbType.NVarChar, 100, searchEngine.NewPassword);
            param[4] = dataBase.MakeOutParameter("@Success", SqlDbType.Int, 4);

            dataBase.RunProcedure("SubAgent_ResetPassword", param);
            resetPwdFlag = (int)param[4].Value;

        }
        catch (Exception exp)
        {
            logger.Error(exp.ToString());
        }
        finally
        {
            Reset();
        }
        return resetPwdFlag;
    }

    ///////////////////////   Booking Details select by Ticketdeadline

    public DataTable GetBookingDetail_SelectByTicketDeadline(SearchEngine searchEngine)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new Database();
            }
            param = new SqlParameter[3];
            param[0] = dataBase.MakeInParameter("@type", SqlDbType.Char, 1, searchEngine.Type);
            param[1] = dataBase.MakeInParameter("@AccountNo", SqlDbType.VarChar, 50, searchEngine.AccountNo);
            param[2] = dataBase.MakeInParameter("@ActionFlag", SqlDbType.Char, 1, searchEngine.ActionFlag);
            dataBase.RunProcedure("BookingMaster_SelectbyTicketDate", param, out datatable);
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

    public DataTable GetBookingDetail_SelectByPaymentDueDate(SearchEngine searchEngine)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new Database();
            }
            param = new SqlParameter[3];
            param[0] = dataBase.MakeInParameter("@type", SqlDbType.Char, 1, searchEngine.Type);
            param[1] = dataBase.MakeInParameter("@AccountNo", SqlDbType.VarChar, 50, searchEngine.AccountNo);
            param[2] = dataBase.MakeInParameter("@ActionFlag", SqlDbType.Char, 1, searchEngine.ActionFlag);
            dataBase.RunProcedure("BookingMaster_SelectbyPaymentDueDate", param, out datatable);
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

    public DataTable GetGDSDetail(SearchEngine searchEngine)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new Database();
            }
            param = new SqlParameter[1];
            param[0] = dataBase.MakeInParameter("@type", SqlDbType.Char, 2, searchEngine.Type);
            dataBase.RunProcedure("gdsMaster_Select", param, out datatable);
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



    //Booking Detail

    public DataTable GetBookingDetailByBookingRef(SearchEngine searchEngine)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new Database();
            }
            param = new SqlParameter[3];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.Char, 2, searchEngine.Type);
            param[1] = dataBase.MakeInParameter("@Booking_Ref", SqlDbType.BigInt, 8, searchEngine.Booking_Ref);
            param[2] = dataBase.MakeInParameter("@SAgentId", SqlDbType.Int, 4, searchEngine.UserId);
            dataBase.RunProcedure("BookingMaster_SelectByBookingRef", param, out datatable);
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


    //Booking report
    public DataTable GetBookingReport(SearchEngine searchEngine)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new Database();
            }
            param = new SqlParameter[11];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.Char, 2, searchEngine.Type);
            param[1] = dataBase.MakeInParameter("@Booking_Ref", SqlDbType.Int, 8, searchEngine.Booking_Ref);
            param[2] = dataBase.MakeInParameter("@Pnr_no", SqlDbType.NVarChar, 50, searchEngine.Pnr_No);
            param[3] = dataBase.MakeInParameter("@DateOfBookingfrom", SqlDbType.NVarChar, 50, searchEngine.BookingDateFrom);
            param[4] = dataBase.MakeInParameter("@DateOfBookingTo", SqlDbType.NVarChar, 50, searchEngine.BookingDateTo);
            param[5] = dataBase.MakeInParameter("@Provider", SqlDbType.NVarChar, 50, searchEngine.Provider);
            param[6] = dataBase.MakeInParameter("@destination", SqlDbType.NVarChar, 50, searchEngine.Destination);
            param[7] = dataBase.MakeInParameter("@first_name", SqlDbType.NVarChar, 50, searchEngine.FirstName);
            param[8] = dataBase.MakeInParameter("@last_name", SqlDbType.NVarChar, 50, searchEngine.LastName);
            param[9] = dataBase.MakeInParameter("@SourceMedia", SqlDbType.NVarChar, 50, searchEngine.AccountNo);
            param[10] = dataBase.MakeInParameter("@PaymentStatus", SqlDbType.NVarChar, 50, searchEngine.Status);
            dataBase.RunProcedure("BookingMaster_Report", param, out datatable);
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

    // mayank //
    int createStatus = 0;
    public DataTable InsertCreateUser(SearchEngine searchEngine)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new Database();
            }
            param = new SqlParameter[6];

            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.Char, 2, searchEngine.Type);
            param[1] = dataBase.MakeInParameter("@Id ", SqlDbType.Int, 4, searchEngine.Id);
            param[2] = dataBase.MakeInParameter("@userId ", SqlDbType.NVarChar, 50, searchEngine.UserId);
            param[3] = dataBase.MakeInParameter("@Password", SqlDbType.NVarChar, 100, searchEngine.Password);
            param[4] = dataBase.MakeInParameter("@EmailAddress", SqlDbType.NVarChar, 200, searchEngine.EmailId);
            param[5] = dataBase.MakeInParameter("@Roletype ", SqlDbType.NVarChar, 10, searchEngine.Rolltype);
            dataBase.RunProcedure("InsertUpdateDelCreateUser", param, out datatable);
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
    public DataTable GetCreateuser(whitelable Whitelable)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new Database();
            }
            param = new SqlParameter[3];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.Char, 2, Whitelable.Type);
            param[1] = dataBase.MakeInParameter("@UserId", SqlDbType.NVarChar, 50, Whitelable.UserId);
            param[2] = dataBase.MakeInParameter("@RoleType", SqlDbType.NVarChar, 10, Whitelable.RoleType);
            dataBase.RunProcedure("InsertUpdateDelCreateUser", param, out datatable);
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

 
    // mayank //

    //preferred Airline
    int insStatus = 0;
    public int InsertPreferredAirline(SearchEngine searchEngine)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new Database();
            }
            param = new SqlParameter[9];

            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.Char, 2, searchEngine.Type);
            param[1] = dataBase.MakeInParameter("@Destination", SqlDbType.Char,3, searchEngine.Destination);
            param[2] = dataBase.MakeInParameter("@DepartDate", SqlDbType.NVarChar, 50, searchEngine.DepartDate);
            param[3] = dataBase.MakeInParameter("@ReturnDate", SqlDbType.NVarChar, 50, searchEngine.ReturnDate);
            param[4] = dataBase.MakeInParameter("@AirlineCode", SqlDbType.NVarChar, 100, searchEngine.AirlineCode);
            param[5] = dataBase.MakeInParameter("@Id", SqlDbType.Int, 4, searchEngine.Id);
            param[6] = dataBase.MakeInParameter("@Priority", SqlDbType.Int, 8, searchEngine.Priority);
            param[7] = dataBase.MakeInParameter("@AirType", SqlDbType.Char, 3,"PA");
            param[8] = dataBase.MakeInParameter("@WebSiteId", SqlDbType.NVarChar, 50, searchEngine.WebSiteId);

            dataBase.RunProcedure("Preferred_Airline_InsertSelectUpdateDelete", param);
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
        return insStatus;
    }
    public int InsertPreferredAirlineMessage(SearchEngine searchEngine)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new Database();
            }
            param = new SqlParameter[9];

            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.Char, 2, searchEngine.Type);
            param[1] = dataBase.MakeInParameter("@Destination", SqlDbType.Char, 3, searchEngine.Destination);
            param[2] = dataBase.MakeInParameter("@DepartDate", SqlDbType.NVarChar, 50, searchEngine.DepartDate==""?null: searchEngine.DepartDate);
            param[3] = dataBase.MakeInParameter("@ReturnDate", SqlDbType.NVarChar, 50, searchEngine.ReturnDate == "" ? null : searchEngine.ReturnDate);
            param[4] = dataBase.MakeInParameter("@AirlineCode", SqlDbType.NVarChar, 100, searchEngine.AirlineCode);
            param[5] = dataBase.MakeInParameter("@Id", SqlDbType.Int, 4, searchEngine.Id);
            param[6] = dataBase.MakeInParameter("@Priority", SqlDbType.Int, 8, searchEngine.Priority);
            param[7] = dataBase.MakeInParameter("@AirType", SqlDbType.Char, 3, "PAM");
            param[8] = dataBase.MakeInParameter("@WebSiteId", SqlDbType.NVarChar, 50, searchEngine.WebSiteId);

            dataBase.RunProcedure("Preferred_Airline_Message_InsertSelectUpdateDelete", param);
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
        return insStatus;
    }

    public DataTable GetPreferredAirline(SearchEngine searchEngine)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new Database();
            }
            param = new SqlParameter[3];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.Char, 2, searchEngine.Type);
            param[1] = dataBase.MakeInParameter("@Id", SqlDbType.Int, 8, searchEngine.Id);
            param[2] = dataBase.MakeInParameter("@WebSiteId", SqlDbType.NVarChar, 50, searchEngine.WebSiteId);
            dataBase.RunProcedure("Preferred_Airline_InsertSelectUpdateDelete", param, out datatable);
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

    public DataTable GetPreferredAirlineMessage(SearchEngine searchEngine)
    {
        try
        {
            if (object.Equals(dataBase, null))
            {
                dataBase = new Database();
            }
            param = new SqlParameter[3];
            param[0] = dataBase.MakeInParameter("@Type", SqlDbType.Char, 2, searchEngine.Type);
            param[1] = dataBase.MakeInParameter("@Id", SqlDbType.Int, 8, searchEngine.Id);
            param[2] = dataBase.MakeInParameter("@WebSiteId", SqlDbType.NVarChar, 50, searchEngine.WebSiteId);
            dataBase.RunProcedure("Preferred_Airline_Message_InsertSelectUpdateDelete", param, out datatable);
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



}