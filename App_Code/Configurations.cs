using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

public static partial  class Configurations
{
    #region Key related to connection string
    
    public static string ConnectionStringServer
    {
        get
        {
            return ConfigurationManager.AppSettings["ConnectionStringServer"];
        }
    }

    public static string ConnectionStringUserId
    {
        get
        {
            return ConfigurationManager.AppSettings["ConnectionStringUID"];
        }
    }

    public static string ConnectionStringPassword
    {
        get
        {
            return ConfigurationManager.AppSettings["ConnectionStringPWD"];
        }
    }

    public static string ConnectionStringDatabase
    {
        get
        {
            return ConfigurationManager.AppSettings["ConnectionStringDatabase"];
        }
    }

    public static string EncryptionKey
    {
        get
        {
            return ConfigurationManager.AppSettings["EncryptionKey"];
        }
    }
    #endregion

    #region Key related to application config.

    public static string CompanyName
    {
        get
        {
            return ConfigurationManager.AppSettings["CompanyName"];
        }
    }
    public static string WebMasterEmailID
    {
        get
        {
            return ConfigurationManager.AppSettings["WebMasterEmailID"];
        }
    }
    public static string NewsLetterEmailID
    {
        get
        {
            return ConfigurationManager.AppSettings["NewsLetterEmailID"];
        }
    }
    public static string ContactUsEmailID
    {
        get
        {
            return ConfigurationManager.AppSettings["ContactUsEmailID"];
        }
    }
    public static string ContactAddress
    {
        get
        {
            return ConfigurationManager.AppSettings["ContactAddress"];
        }
    }
    public static string ContactPersonName
    {
        get
        {
            return ConfigurationManager.AppSettings["ContactPersonName"];
        }
    }
    public static string AdvertiserEmailID
    {
        get
        {
            return ConfigurationManager.AppSettings["AdvertiserEmailID"];
        }
    }
    public static string SalesAndMarketEmailID
    {
        get
        {
            return ConfigurationManager.AppSettings["SalesAndMarketEmailID"];
        }
    }
    public static string BrokenLinkEmailID
    {
        get
        {
            return ConfigurationManager.AppSettings["BrokenLinkEmailID"];
        }
    }
    public static string WebSiteErrorEmailID
    {
        get
        {
            return ConfigurationManager.AppSettings["WebSiteErrorEmailID"];
        }
    }
    public static string MemberServicesEmailID
    {
        get
        {
            return ConfigurationManager.AppSettings["MemberServicesEmailID"];
        }
    }
    public static string SupportEmailID
    {
        get
        {
            return ConfigurationManager.AppSettings["SupportEmailID"];
        }
    }

    public static string HomePageURL
    {
        get
        {
            return ConfigurationManager.AppSettings["HomePageURL"];
        }
    }
    public static string HomeURL
    {
        get
        {
            return ConfigurationManager.AppSettings["HomeURL"];
        }
    }
    public static string RegisterUrl
    {
        get
        {
            return ConfigurationManager.AppSettings["RegisterUrl"];
        }
    }
    public static string LoginCheckReturnUrl
    {
        get
        {
            return ConfigurationManager.AppSettings["LoginCheckReturnUrl"];
        }
    }
    public static string EditRegistrationUrl
    {
        get
        {
            return ConfigurationManager.AppSettings["EditRegistrationUrl"];
        }
    }
    public static string ForgotUserNameUrl
    {
        get
        {
            return ConfigurationManager.AppSettings["ForgotUserNameUrl"];
        }
    }
    public static string LoginCheckUrl
    {
        get
        {
            return ConfigurationManager.AppSettings["LoginCheckUrl"];
        }
    }
    public static string WhyRegisterUrl
    {
        get
        {
            return ConfigurationManager.AppSettings["WhyRegisterUrl"];
        }
    }
    public static string ContactUrl
    {
        get
        {
            return ConfigurationManager.AppSettings["ContactUrl"];
        }
    }
    public static string HelpUrl
    {
        get
        {
            return ConfigurationManager.AppSettings["HelpUrl"];
        }
    }
    public static string HostedBy
    {
        get
        {
            return ConfigurationManager.AppSettings["HostedBy"];
        }
    }
    public static string BrokenLink
    {
        get
        {
            return ConfigurationManager.AppSettings["BrokenLink"];
        }
    }
    public static string ContactUs
    {
        get
        {
            return ConfigurationManager.AppSettings["ContactUs"];
        }
    }
    public static string TermsConditions
    {
        get
        {
            return ConfigurationManager.AppSettings["TermsConditions"];
        }
    }
    public static string PrivacyPolicy
    {
        get
        {
            return ConfigurationManager.AppSettings["PrivacyPolicy"];
        }
    }
    public static string AdvertiseWithUs
    {
        get
        {
            return ConfigurationManager.AppSettings["AdvertiseWithUs"];
        }
    }
    public static string SiteMap
    {
        get
        {
            return ConfigurationManager.AppSettings["SiteMap"];
        }
    }
    public static string DefaultPageSize
    {
        get
        {
            return ConfigurationManager.AppSettings["DefaultPageSize"];
        }
    }
    public static string PageSize
    {
        get
        {
            return ConfigurationManager.AppSettings["PageSize"];
        }
    }
    public static string UploadFilePath
    {
        get
        {
            return ConfigurationManager.AppSettings["TextFileFolderPath"];
        }
    }
    public static string IsMailOn
    {
        get
        {
            return ConfigurationManager.AppSettings["IsMailOn"];
        }
    }
public static string HeaderLogoImage
    {
        get
        {
            return ConfigurationManager.AppSettings["Logo"].ToString();
        }
    }
    public static string HeaderLogoSideImage
    {
        get
        {
            return ConfigurationManager.AppSettings["LogoSideImage"].ToString();
        }
    }
    public static string HeaderLogoSideImage1
    {
        get
        {
            return ConfigurationManager.AppSettings["LogoSideImage1"].ToString();
        }
    }

    public static string HomePageURL1
    {
        get
        {
            return ConfigurationManager.AppSettings["HomePageURL"].ToString();
        }
    }

    public static string Copyright
    {
        get
        {
            return ConfigurationManager.AppSettings["Copyright"].ToString();
        }
    } 
    #endregion

    public static bool RethrowError
    {
        get
        {
            return bool.Parse(ConfigurationManager.AppSettings["RethrowError"].ToString());
        }
    }
}
