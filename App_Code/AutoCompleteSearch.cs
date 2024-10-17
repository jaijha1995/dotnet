using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Web.Script.Services;

/// <summary>
/// Summary description for Search
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class AutoCompleteSearch : System.Web.Services.WebService
{
    static string _firstRecord;
    //public Search()
    //{
    //}

    public string GetFirstRecord()
    {
        return _firstRecord;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string[] GetCompletionList(string prefixText, int count)
    {
        if (count == 0)
            count = 10;
        string preChar = prefixText.Substring(0, 1).Trim().ToUpper();
        XElement destination =
         XElement.Load(HttpContext.Current.Server.MapPath("xmlfiles/Destination/" + preChar + ".xml"));

        var res1 = from x in destination.Elements("Destination")
                   where
                   x.Element("code").Value.ToUpper().StartsWith(prefixText.ToUpper())
                   select x.Element("DestinationStr").Value;

        var res2 = from x in destination.Elements("Destination")
                   where
                   x.Element("DestinationName").Value.ToUpper().Contains(prefixText.ToUpper())
                   select x.Element("DestinationStr").Value;

        var finalResult = res1.Concat(res2);

        if (finalResult.Any())
        {
        }
        else
        {
            prefixText = "NORESULT";
            finalResult = from noRes in destination.Elements("Destination")
                          where
                          noRes.Element("code").Value.ToUpper().StartsWith(prefixText.ToUpper())
                          select noRes.Element("DestinationStr").Value;
        }

        _firstRecord = finalResult.FirstOrDefault().ToString(); // Get first record

        var final = finalResult;

        return final.Distinct().ToArray<string>();
    }


}
