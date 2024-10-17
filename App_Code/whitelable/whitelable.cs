using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for whitelable
/// </summary>
public class whitelable
{
    #region

    private string type;
    private string airline;
    private string cabinClass;
    private string bookingClass;
    private string fareBasis;
    private string from;
    private string destination;
    private string fromCity;
    private string toCity;
    private string fare;
    private string paxType;


    private string sUserID;
    private string sPWD;
    private int id;

    public string InboundCabinCode { get; set; }
    public int RetunrDays { get; set; }
    public string OutboundCabinCode { get; set; }

    #endregion


    #region
    public string origin { get; set; }

    public string JType { get; set; }

    public string CityGroupType { get; set; }

    public string CityCode { get; set; }
    public string DepartAirline { get; set; }
    public string ReturnAirline { get; set; }
    #endregion



    public string Type { get; set; }

    public string ContactNo
    {
        get { return destination; }
        set { destination = value; }

    }
    public string CustomerName
    {
        get { return origin; }
        set { origin = value; }

    }
    public string City { get; set; }
    public string State { get; set; }
    public string applicationType { get; set; }

    public string ComputedCustomerID { get; set; }
    public int CustomerID
    {
        get { return id; }
        set { id = value; }
    }


    //public int CustomerID { get; set; }
    public string CreateUser { get; set; }

    public string UserId { get; set; }
    public string RoleType { get; set; }

}
public class ManageLeadsData
{
    public int LeadID { get; set; }
    public int CustomerID { get; set; }
    public string ComputedCustomerID { get; set; }
    public string LoanType { get; set; }
    public string Type { get; set; }
    public string LoanAmt { get; set; }
    public string LoanDetails { get; set; }
    public string BankName { get; set; }
    public string Bankcode { get; set; }
    public string CreateUser { get; set; }
    public string RoleType { get; set; }
    public string CustomerName { get; set; }

}

public class SpecialJourneyMaster
{
    public int ProfileId { get; set; }
    public string Type { get; set; }
    public string ProfileName { get; set; }
    public string CompanyName { get; set; }
    public string ContactNo { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PanCard { get; set; }
    public string AddharCard { get; set; }
    public string Gst { get; set; }
}

public class LoanMaster
{
    public int loan_Id { get; set; }
    public string Type { get; set; }
    public string loan_Type { get; set; }
    public string Loan_Code { get; set; }
}


public class Bankname
{
    public int BankId { get; set; }
    public string Type { get; set; }
    public string Bankcode { get; set; }
    public string BankName { get; set; }
}


public class ManageStatus
{
    public int Id { get; set; }
    public int LeadID { get; set; }
    public int CustomerID { get; set; }
    public string LoanType { get; set; }
    public string Type { get; set; }
    public string LoanAmt { get; set; }
    public string LoanDetail { get; set; }
    public string BankName { get; set; }
    public string CustomerName { get; set; }
    public string ContactNo { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string applicationType { get; set; }
    public string TenareDate { get; set; }
    public string Rate { get; set; }
    public string ForeCharge { get; set; }
    public string Status { get; set; }
    public string Bankstatus { get; set; }
    public string Reason { get; set; }
    public string CreateUser { get; set; }
    public string RoleType { get; set; }

}


public class SFinancialMaster
{
    public int Id { get; set; }
    public int CustomerID { get; set; }
    public int LeadID { get; set; }
    public string Type { get; set; }
    public string CustomerName { get; set; }
    public string ContactNo { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string BankName { get; set; }
    public Decimal TransactionAmt { get; set; }
    public Decimal PFPercen { get; set; }
    public Decimal PFAmt { get; set; }
    public Decimal LPPercent { get; set; }
    public Decimal LenderPayoutAmt { get; set; }
    public Decimal CPPercent { get; set; }
    public Decimal CPAmount { get; set; }
    public Decimal Recovery { get; set; }
    public Decimal FPAmt { get; set; }
    public Decimal TDS { get; set; }
    public Decimal Gst { get; set; }
    public Decimal TotalPayout { get; set; }
    public string CreateUser { get; set; }
    public string RoleType { get; set; }
}

public class ServicesMaster
{
    public int Id { get; set; }
    public int LeadID { get; set; }
    public int CustomerID { get; set; }
    public string CustomerName { get; set; }
    public string ContactNo { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string BankName { get; set; }
    public decimal TransactionAmt { get; set; }
    public decimal ServiceChargesAmt { get; set; }
    public decimal CPSharePer { get; set; }
    public decimal CPShareAmt { get; set; } 
    public decimal Recovery { get; set; }
    public decimal FinalCPShareAmt { get; set; }
    public decimal TDS { get; set; }
    public decimal Gst { get; set; }
    public decimal NetCPShareAmt { get; set; } 
    public string CreateUser { get; set; }
    public string RoleType { get; set; }
    public string Type { get; set; } 
}

public class Confirmationbtn
{
    public int ConfID { get; set; }
    public int LeadID { get; set; }
    public string Type { get; set; }
    public string ConfirmBtn { get; set; }
    public string QueryBtn { get; set; }
    public string CreateUser { get; set; }
    public string RoleType { get; set; }
}


