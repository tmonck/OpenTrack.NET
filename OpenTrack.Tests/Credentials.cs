using System;
using System.Configuration;

namespace OpenTrack.Tests
{
    public class Credentials
    {
        public const String EnterpriseCode = "ZE";
        public const String DealerCode = "ZE7";
        public const String ServerName = "arkonap.arkona.com";

        public const String Url = ConfigurationManager.AppSettings["Url"];
        public const String Username = ConfigurationManager.AppSettings["Username"];
        public const String Password = ConfigurationManager.AppSettings["Password"];

        public static IOpenTrackAPI GetAPI()
        {
            return new OpenTrackAPI(Url, Username, Password);
        }
    }
}