using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for SearchEngine
/// </summary>
public class SearchEngine
{
    #region

    //private string baseCurrency;
    //private string selectedCurrency;

    private string fname;
    private string lname;
    private string country;
    private string mobileno;
    private string emailid;
    private string postcode;
    private string street;
    private string phone;
    private string fax;
    private string city;
    private string state;
    private string password;
     private string type;
    private int clientid;
    private string url;
    //private decimal Curr_value;

    private string username;
    private string accountno;

    private int bookingref;
    private string pnr;
    private string query;
    private string userid;
    private string agencyname;
    private int id;
    private int takecontrol;
    private string profileimg;
    public string actionflag;
    private int countryid;

    public string skintheme;
    public string navtheme;
    public string sidetheme;
    public string newpassword;
 
    #endregion

    #region



    //public string BaseCurrency
    //{
    //    get { return baseCurrency; }
    //    set { baseCurrency = value; }
    //}

    //public string SelectedCurrency
    //{
    //    get { return selectedCurrency; }
    //    set { selectedCurrency = value; }
    //}
     public string Url
    {
        get { return url; }
        set { url = value; }
    }
    public string FirstName
    {
        get { return fname; }
        set { fname = value; }
    }
    public string LastName
    {
        get { return lname; }
        set { lname = value; }
    }
    public string Country
    {
        get { return country; }
        set { country = value; }
    }
    public string MobileNo
    {
        get { return mobileno; }
        set { mobileno = value; }
    }
    public string EmailId
    {
        get { return emailid; }
        set { emailid = value; }
    }
    public string PostCode
    {
        get { return postcode; }
        set { postcode = value; }
    }


    public string Street
    {
        get { return street; }
        set { street = value; }
    }
    public string Phone
    {
        get { return phone; }
        set { phone = value; }
    }
   
    public string Fax
    {
        get { return fax; }
        set { fax = value; }
    }
    public string City
    {
        get { return city; }
        set { city = value; }
    }
    public string State
    {
        get { return state; }
        set { state = value; }
    }
    public string Password
    {
        get { return password; }
        set { password = value; }
    }
    public string NewPassword
    {
        get { return newpassword; }
        set { newpassword = value; }
    }
    public string Type
    {
        get { return type; }
        set { type = value; }
    }

    public int ClientId
    {
        get { return clientid; }
        set { clientid = value; }
    }

    //public decimal Curr_Value
    //{
    //    get { return Curr_value; }
    //    set { Curr_value = value; }
    //}

    public string UserName
    {
        get { return username; }
        set { username = value; }
    }
    public string AccountNo
    {
        get { return accountno; }
        set { accountno = value; }
    }
    public int Booking_Ref
    {
        get { return bookingref; }
        set { bookingref = value; }
    }
    public string Pnr_No
    {
        get { return pnr; }
        set { pnr = value; }
    }
    public string Query
    {
        get { return query; }
        set { query = value; }
    }
    public string UserId
    {
        get { return userid; }
        set { userid = value; }
    }
    public string AgencyName
    {
        get { return agencyname; }
        set { agencyname = value; }
    }
    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    public int TakeControl
    {
        get { return takecontrol; }
        set { takecontrol = value; }
    }
    public string ProfileImg
    {
        get { return profileimg; }
        set { profileimg = value; }
    }
    public string ActionFlag
    {
        get { return actionflag; }
        set { actionflag = value; }
    }
    public int CountryId
    {
        get { return countryid; }
        set { countryid = value; }
    }

    public string SkinTheme
    {
        get { return skintheme; }
        set { skintheme = value; }
    }
    public string NavTheme
    {
        get { return navtheme; }
        set { navtheme = value; }
    }
    public string SideTheme
    {
        get { return sidetheme; }
        set { sidetheme = value; }
    }

    public int InvoiceId
    { get; set; }
    public bool IsPaid
    { get; set; }

    public long BookingRef
    { get; set; }

    public string sales_Channel
    { get; set; }
    public string TransID
    { get; set; }

    public decimal TotAmt
    { get; set; }

    public int AgentId { get; set; }
    public string BookingDateFrom { get; set; }
    public string BookingDateTo { get; set; }
    public string Provider { get; set; }
    public string Destination { get; set; }
    public string Status { get; set; }

    public string DepartDate { get; set; }
    public string ReturnDate { get; set; }
    public string AirlineCode { get; set; }
    public string Priority { get; set; }
    public string WebSiteId { get; set; }
    public string Rolltype { get; set; }

    #endregion
}