using System;
using System.Configuration;
using System.IO;

namespace OpenTrack.Tests
{
    public class Credentials
    {
        public const String EnterpriseCode = "ZE";
        public const String DealerNumber = "ZE7";

        public static readonly String Url = ConfigurationManager.AppSettings["Url"];
        public static readonly String Username = ConfigurationManager.AppSettings["Username"];
        public static readonly String Password = ConfigurationManager.AppSettings["Password"];

        public static IOpenTrackAPI GetAPI()
        {
            var request_id = Guid.NewGuid();

            return new OpenTrackAPI(Url, Username, Password)
            {
                OnSend = (msg) =>
                    {
                        var filename = String.Format("Request.{0}.xml", request_id);

                        using (var writer = new StreamWriter(filename))
                        {
                            writer.Write(msg.ToString());
                        }
                    },
                OnReceive = (msg) =>
                    {
                        var filename = String.Format("Response.{0}.xml", request_id);

                        using (var writer = new StreamWriter(filename))
                        {
                            writer.Write(msg.ToString());
                        }
                    },
                OnManualSoapSend = (msg) => Console.WriteLine(msg),
                OnManualSoapReceive = (msg) => Console.WriteLine(msg)
            };
        }
    }
}