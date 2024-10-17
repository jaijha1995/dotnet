using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for ExceptionHandler
/// </summary>
public class ExceptionHandler
{
	public ExceptionHandler()
	{
		
	}

    //////////////////////////// Exception Funcation


    public void WriteError(string errorMessage)
    {
        try
        {
            string path = "~/Log/" + DateTime.Today.ToString("dd-MM-yy") + ".txt";
            if (!File.Exists(System.Web.HttpContext.Current.Server.MapPath(path)))
            {
                File.Create(System.Web.HttpContext.Current.Server.MapPath(path)).Close();
            }
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath(path)))
            {

                w.WriteLine("\r\nLog Entry : ");
                w.WriteLine("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                w.WriteLine(errorMessage);
                w.WriteLine("__________________________");
                w.Flush();
                w.Close();
            }
            
        }
        catch
        {
          
        }

    }

    public string CreateRandomPassword(int PasswordLength)
    {
        string _allowedChars = "0123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ";
        Random randNum = new Random();
        char[] chars = new char[PasswordLength];
        int allowedCharCount = _allowedChars.Length;
        for (int i = 0; i < PasswordLength; i++)
        {
            chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
        }
        return new string(chars);
    }
    public void WritePNRError(string errorMessage,string sourcePnr)
    {
        try
        {
            string path = "~/Log/" + DateTime.Today.ToString("dd-MM-yy") + ".txt";
            if (!File.Exists(System.Web.HttpContext.Current.Server.MapPath(path)))
            {
                File.Create(System.Web.HttpContext.Current.Server.MapPath(path)).Close();
            }
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath(path)))
            {

                w.WriteLine("\r\nLog Entry : ");
                w.WriteLine("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));

                w.WriteLine("\rPNR : " + sourcePnr);
                w.WriteLine("__________________________");
                w.WriteLine(errorMessage);
                w.WriteLine("__________________________");
                w.Flush();
                w.Close();
            }

        }
        catch
        {

        }

    }
    public void WriteAPIError(string errorMessage)
    {
        try
        {
            string path = "~/Log/" + DateTime.Today.ToString("dd-MM-yy") + ".txt";

            bool IsFolderExists = System.IO.Directory.Exists(HttpContext.Current.Server.MapPath(path));
            if (!IsFolderExists)
            {
                System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(path));
            }
            string filePath = "~/Logs/" + DateTime.Today.ToString("ddMMyy") + "/APIError.txt";
            if (!File.Exists(System.Web.HttpContext.Current.Server.MapPath(filePath)))
            {
                File.Create(System.Web.HttpContext.Current.Server.MapPath(filePath)).Close();
            }
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath(filePath)))
            {

                w.WriteLine("\r\nLog API Error Entry : ");
                w.WriteLine("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                w.WriteLine(errorMessage);
                w.WriteLine("__________________________");
                w.Flush();
                w.Close();
            }

        }
        catch (Exception)
        {
        }

    }
    public void WriteApplicationError(string errorMessage)
    {
        try
        {
            string path = "~/Log/" + DateTime.Today.ToString("dd-MM-yy") + ".txt";

            bool IsFolderExists = System.IO.Directory.Exists(HttpContext.Current.Server.MapPath(path));
            if (!IsFolderExists)
            {
                System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(path));
            }
            string filePath = "~/Logs/" + DateTime.Today.ToString("ddMMyy") + "/ApplicationError.txt";
            if (!File.Exists(System.Web.HttpContext.Current.Server.MapPath(filePath)))
            {
                File.Create(System.Web.HttpContext.Current.Server.MapPath(filePath)).Close();
            }
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath(filePath)))
            {

                w.WriteLine("\r\nLog Application Error Entry : ");
                w.WriteLine("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                w.WriteLine(errorMessage);
                w.WriteLine("__________________________");
                w.Flush();
                w.Close();
            }

        }
        catch (Exception)
        {

        }

    }

}