using System;
using System.Configuration;
using System.Threading.Tasks;

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

            IOpenTrackAPI api = new OpenTrackAPI(url, username, password);

            var numbers = new[] { "5HS56EGJAI", "5HS57EDAAJ", "12605566", "1231", "9021", "1234" };

            var sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            Parallel.ForEach(numbers, n =>
                {
                    var response = api.GetPartsInventory(new Requests.PartsInventoryRequest(enterpriseCode, dealerCode, serverName)
                    {
                        PartNumber = n
                    });

                    foreach (var r in response)
                    {
                        Console.WriteLine("{0} {1} {2}", r.PartNumber, r.StockCode, r.Status);
                    }
                });

            Console.WriteLine("Elapsed: {0}", sw.Elapsed);

            Console.ReadKey();
        }
    }
}