using System;
using System.Linq;
using OpenTrack.Requests;
using Xunit;

namespace OpenTrack.Tests
{
    public class GetClosedRepairOrders
    {
        [Fact]
        public void Get_Closed_ROs_For_Today_New()
        {
            var api = Credentials.GetAPI();

            var result = api.GetClosedRepairOrders(new Requests.GetClosedRepairOrdersRequest(Credentials.EnterpriseCode, Credentials.DealerNumber)
            {
                CloseDate = DateTime.Today
            });

            Assert.True(result.Any());

            var firstRoNumber = result.First().RepairOrderNumber;
            var details =
                api.GetClosedRepairOrderDetails(new GetClosedRepairOrderDetailsRequest(Credentials.EnterpriseCode,
                    Credentials.DealerNumber) { RepairOrderNumber = firstRoNumber });

            Assert.True(details.Details != null);

            foreach (var ro in result)
            {
                Assert.False(String.IsNullOrWhiteSpace(ro.RepairOrderNumber));
            }
        }

        [Fact]
        public void Get_Closed_ROs_For_Range_New()
        {
            var api = Credentials.GetAPI();

            var result = api.GetClosedRepairOrders(new Requests.GetClosedRepairOrdersRequest(Credentials.EnterpriseCode, Credentials.DealerNumber)
            {
                FinalCloseDateStart = DateTime.Today.AddDays(-3),
                FinalCloseDateEnd = DateTime.Today.AddDays(1)
            });

            Assert.True(result.Any());

            foreach (var ro in result)
            {
                Assert.False(String.IsNullOrWhiteSpace(ro.RepairOrderNumber));
            }
        }
    }
}