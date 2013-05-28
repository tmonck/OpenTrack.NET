using System;
using System.Linq;
using Xunit;

namespace OpenTrack.Tests
{
    public class FindClosedRepairOrders
    {
        [Fact]
        public void Test_Find_Closed_ROs()
        {
            var api = Credentials.GetAPI();

            var result = api.FindClosedRepairOrders(new Requests.GetClosedRepairOrderRequest(Credentials.EnterpriseCode, Credentials.DealerCode, Credentials.ServerName)
            {
                VIN = "SALSF2D48CA739995"
            });

            Assert.True(result.Any());

            foreach (var ro in result)
            {
                Assert.False(String.IsNullOrWhiteSpace(ro.RepairOrderNumber));

                Assert.Equal("SALSF2D48CA739995", ro.VIN);
            }
        }
    }
}