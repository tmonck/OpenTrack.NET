using OpenTrack.Requests;
using System;
using System.Linq;
using Xunit;

namespace OpenTrack.Tests
{
    public class AddRepairOrder
    {
        [Fact]
        public void Test_Add_Repair_Order()
        {
            var api = Credentials.GetAPI();

            api.AddRepairOrder(new Requests.AddRepairOrderRequest(Credentials.EnterpriseCode, Credentials.DealerCode, Credentials.ServerName)
            {
                RO = new Requests.RepairOrder()
                {
                    CustomerNumber = "",
                    OdometerIn = "",
                    PromisedDateTime = "",
                    ServiceWriterID = "",
                    TagNumber = "",
                    VIN = "",
                    LineItems = new[]
                    {
                        new LineItem()
                        {

                        }
                    }.ToList()
                }
            });

            // Get the open repair orders and check that this one was added.

        }
    }
}