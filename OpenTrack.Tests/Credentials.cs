using System;
using System.Configuration;

namespace OpenTrack.Tests
{
    public class Credentials
    {
        public const String EnterpriseCode = "POMO";
        public const String DealerNumber = "PO3";

        public static readonly String Url = ConfigurationManager.AppSettings["Url"];
        public static readonly String Username = ConfigurationManager.AppSettings["Username"];
        public static readonly String Password = ConfigurationManager.AppSettings["Password"];

        public static IOpenTrackAPI GetAPI()
        {
            return new OpenTrackAPI(Url, Username, Password) { DebugMode = true };
        }
    }
}