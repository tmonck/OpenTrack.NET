using System;
using System.Configuration;

namespace OpenTrack.TestApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var url = ConfigurationManager.AppSettings["url"];
            var username = ConfigurationManager.AppSettings["username"];
            var password = ConfigurationManager.AppSettings["password"];

            var enterpriseCode = "ZE";
            var dealerCode = "ZE7";
            var serverName = "arkonap.arkona.com";

            var api = new OpenTrackAPI(url, username, password);

            var result = api.GetPartsInventory(new Requests.PartsInventoryRequest(enterpriseCode, dealerCode, serverName));

            foreach (var r in result)
            {
                Console.WriteLine(r.DisplayPartNumber);
            }

            Console.ReadKey();
        }
    }
}