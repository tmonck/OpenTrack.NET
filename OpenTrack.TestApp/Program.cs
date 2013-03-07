using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTrack.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = ConfigurationManager.AppSettings["url"];
            var username = ConfigurationManager.AppSettings["username"];
            var password = ConfigurationManager.AppSettings["password"];

            var api = new OpenTrackAPI(url, username, password);

            var result = api.FindClosedRepairOrders(new Requests.GetClosedRepairOrderRequest()
                {
                    EnterpriseCode = "ZE",
                    DealerCode = "ZE7",
                    ServerName = "arkonap.arkona.com",
                    RepairOrderNumber = "7004255"
                });

            foreach (var r in result)
            {
                Console.WriteLine(r.CustomerName);
            }

            Console.ReadKey();
        }
    }
}
