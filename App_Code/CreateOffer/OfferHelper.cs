using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using log4net;
using System.Data.SqlClient;

/// <summary>
/// Summary description for OfferHelper
/// </summary>
public class OfferHelper
{
    public OfferHelper()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private DatabaseOffline dataBase;
    private DataTable datatable;
    private DatabaseOffline GetDatabaseObject()
    {
        if (object.Equals(dataBase, null))
        {
            dataBase = new DatabaseOffline();
        }
        return dataBase;
    }

    private static readonly ILog logger = LogManager.GetLogger(typeof(OfferHelper));
    private SqlParameter[] param;
    private DataSet dataSet;
    int Id;


    //public DataTable CreateEditOffer(Offer offer)
    //{
    //    try
    //    {
    //        GetDatabaseObject();

    //        param = new SqlParameter[15];
    //        param[0] = dataBase.MakeInParameter("@Destinationcitycode", SqlDbType.Char, 3, offer.DestinationCityCode);
    //        param[1] = dataBase.MakeInParameter("@Destinationcountrycode", SqlDbType.Char, 3, offer.DestinationCountryCode);
    //        param[2] = dataBase.MakeInParameter("@Generalinformation", SqlDbType.NVarChar, 4000, offer.GeneralInformation);
    //        param[3] = dataBase.MakeInParameter("@Airlinecode", SqlDbType.Char, 2, offer.AirlineCode);
    //        param[4] = dataBase.MakeInParameter("@Origin", SqlDbType.Char, 3, offer.OriginCode);

    //        if (offer.DepartDate == DateTime.Parse("1/1/0001 12:00:00 AM"))
    //            param[5] = dataBase.MakeInParameter("@Departdate", SqlDbType.DateTime, 12, DBNull.Value);
    //        else
    //            param[5] = dataBase.MakeInParameter("@Departdate", SqlDbType.DateTime, 12, offer.DepartDate);

    //        if (offer.ReturnDate == DateTime.Parse("1/1/0001 12:00:00 AM"))
    //            param[6] = dataBase.MakeInParameter("@Returndate", SqlDbType.DateTime, 12, DBNull.Value);
    //        else
    //            param[6] = dataBase.MakeInParameter("@Returndate", SqlDbType.DateTime, 12, offer.ReturnDate);

    //        param[7] = dataBase.MakeInParameter("@Destinationcountryname", SqlDbType.NVarChar, 50, offer.DestinationCountryName);
    //        param[8] = dataBase.MakeInParameter("@Cabinclass", SqlDbType.Char, 1, offer.CabinClass);
    //        param[9] = dataBase.MakeInParameter("@Price", SqlDbType.Decimal, 18, offer.Price);
    //        param[10] = dataBase.MakeInParameter("@Query", SqlDbType.NVarChar, 1000, offer.Query);
    //        param[11] = dataBase.MakeInParameter("@id", SqlDbType.Int, 4, offer.ID);
    //        param[12] = dataBase.MakeInParameter("@Type", SqlDbType.Char, 1, offer.Type);
    //        param[13] = dataBase.MakeInParameter("@isFeatured", SqlDbType.Char, 1, offer.isFeatured);
    //        param[14] = dataBase.MakeInParameter("@DestinationName", SqlDbType.NVarChar, 50, offer.DestinationName);
    //        dataBase.RunProcedure("SP_CreateOffer", param, out datatable);

    //    }
    //    catch (Exception exp)
    //    {
    //        logger.Error(exp.ToString());
    //    }
    //    finally
    //    {
    //        Reset();
    //    }
    //    return datatable;
    //}

    //Insert Offline fares
    public DataTable Insert_OfferFare(Offer offer)
    {
        try
        {
            GetDatabaseObject();
            param = new SqlParameter[16];
            param[0] = dataBase.MakeInParameter("@Depart", SqlDbType.NVarChar, 50, offer.OriginCode);
            param[1] = dataBase.MakeInParameter("@Destination", SqlDbType.NVarChar, 50, offer.DestinationCityCode);
            param[2] = dataBase.MakeInParameter("@viaPoint", SqlDbType.NVarChar, 50, offer.ViaPoint);
            param[3] = dataBase.MakeInParameter("@AirlineCode", SqlDbType.NVarChar, 50, offer.AirlineCode);
            param[4] = dataBase.MakeInParameter("@CabinClass", SqlDbType.NVarChar, 50, offer.CabinClass);
            param[5] = dataBase.MakeInParameter("@adtFare", SqlDbType.Decimal, 18, offer.AdtFare);
            param[6] = dataBase.MakeInParameter("@chdFare", SqlDbType.Decimal, 18, offer.ChdFare);
            param[7] = dataBase.MakeInParameter("@infFare", SqlDbType.Decimal, 18, offer.InfFare);

            if (offer.DepartDate == DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                param[8] = dataBase.MakeInParameter("@departDate", SqlDbType.DateTime, 12, DBNull.Value);
            }
            else
                param[8] = dataBase.MakeInParameter("@departDate", SqlDbType.DateTime, 25, offer.DepartDate);

            if (offer.ReturnDate == DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                param[9] = dataBase.MakeInParameter("@arrivalDate", SqlDbType.DateTime, 12, DBNull.Value);
            }
            else
                param[9] = dataBase.MakeInParameter("@arrivalDate", SqlDbType.DateTime, 25, offer.ReturnDate);

            param[10] = dataBase.MakeInParameter("@baggage", SqlDbType.NVarChar, 50, offer.Baggage);
            param[11] = dataBase.MakeInParameter("@type", SqlDbType.Char, 1, offer.Type);
            param[12] = dataBase.MakeInParameter("@offerId", SqlDbType.Int, 4, offer.OfferId);
            param[13] = dataBase.MakeInParameter("@query", SqlDbType.NVarChar, 5000, offer.Query);
            param[14] = dataBase.MakeInParameter("@AccountNo", SqlDbType.VarChar, 50, offer.AccountNo);
            param[15] = dataBase.MakeInParameter("@jType", SqlDbType.Char, 1, offer.jType);
            dataBase.RunProcedure("offers_InsertbyAdmin", param, out datatable);
        }
        catch (Exception exp)
        {
            //  ExceptionHandler.WriteError("**********  DB Error **************\n" + exp.StackTrace);
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


}