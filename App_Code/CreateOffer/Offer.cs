using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Offer
/// </summary>
public class Offer
{
	public Offer()
	{
		//
		// TODO: Add constructor logic here
		//
    }

    #region Private variables

    private string destinationcitycode;
    private string destinationcountrycode;
    private string generalinformation;
    private string airlinecode;

    private string origin;    
    private string destinationcountryname;
    private string cabinclass;
    private DateTime? departdate;
    private DateTime? returndate;
    private decimal price;

    private int Id;
    private string query;
    private string type;
    private string isfeatured;
    private string isactive;



    private string offertsype;
    private string title;
    private string amount;

    private decimal adtfare;
    private decimal chdfare;
    private decimal inffare;
    private string baggage;
    private string viaPoint;
    private int offerid;


    private string destination_name;

    #endregion


    public int OfferId
    {
        get { return offerid; }
        set { offerid = value; }
    }
    public decimal ChdFare
    {
        get { return chdfare; }
        set { chdfare = value; }
    }

    public decimal InfFare
    {
        get { return inffare; }
        set { inffare = value; }
    }
    public decimal AdtFare
    {
        get { return adtfare; }
        set { adtfare = value; }
    }
    public string Baggage
    {
        get { return baggage; }
        set { baggage = value; }
    }

    public string ViaPoint
    {
        get { return viaPoint; }
        set { viaPoint = value; }
    }

    public string DestinationCityCode
    {
        get { return destinationcitycode; }
        set { destinationcitycode = value; }
    }

    public string DestinationCountryCode
    {
        get { return destinationcountrycode; }
        set { destinationcountrycode = value; }
    }

    public string GeneralInformation
    {
        get { return generalinformation; }
        set { generalinformation = value; }
    }

    public string AirlineCode
    {
        get { return airlinecode; }
        set { airlinecode = value; }
    }

    public string OriginCode
    {
        get { return origin; }
        set { origin = value; }
    }

    public string DestinationCountryName
    {
        get { return destinationcountryname; }
        set { destinationcountryname = value; }
    }

    public string CabinClass
    {
        get { return cabinclass; }
        set { cabinclass = value; }
    }

    public DateTime? DepartDate
    {
        get { return departdate; }
        set { departdate = value; }
    }

    public DateTime? ReturnDate
    {
        get { return returndate; }
        set { returndate = value; }
    }

    public decimal Price
    {
        get { return price; }
        set { price = value; }
    }

    public int ID
    {
        get { return Id; }
        set { Id = value; }
    }

    public string Query
    {
        get { return query; }
        set { query = value; }
    }

    public string Type
    {
        get { return type; }
        set { type = value; }
    }
    public string isFeatured
    {
        get { return isfeatured; }
        set { isfeatured = value; }
    }
    public string IsActive
    {
        get { return isactive; }
        set { isactive = value; }
    }
    public string DestinationName
    {
        get { return destination_name; }
        set { destination_name = value; }
    }
    public string OffersType
    {
        get { return offertsype; }
        set { offertsype = value; }
    }
    public string Title
    {
        get { return title; }
        set { title = value; }
    }
    public string Amount
    {
        get { return amount; }
        set { amount = value; }
    }

    public string AccountNo { get; set; }
    public string jType { get; set; }
}