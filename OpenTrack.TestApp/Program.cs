using System;
using System.Configuration;
using System.Linq;

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

            var response = api.FindCustomers(new Requests.CustomerSearchRequest(enterpriseCode, dealerCode, serverName)
            {
                State = "FL"
            });

            foreach (var r in response)
            {
                Console.WriteLine("{0} {1}", r.LastName, r.Email1);
            }

            Console.ReadKey();
        }
    }
}