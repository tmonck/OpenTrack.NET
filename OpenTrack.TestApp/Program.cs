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

            var api = new OpenTrackAPI(url, username, password);

            var result = api.FindOpenRepairOrders(new Requests.OpenRepairOrderLookup("ZE", "ZE7", "arkonap.arkona.com"));

            foreach (var r in result)
            {
                Console.WriteLine(r.CustomerName);
            }

            Console.ReadKey();
        }
    }
}