using OpenTrack.Requests;
using System;
using System.Linq;
using Xunit;

namespace OpenTrack.Tests
{
    public class FindClosedRepairOrders
    {
        private readonly TimeSpan RangeToPull = TimeSpan.FromHours(-2);

        [Fact]
        public void Test_Find_Closed_ROs()
        {
            var api = Credentials.GetAPI();

            var result = api.FindClosedRepairOrders(new Requests.GetClosedRepairOrderRequest(Credentials.EnterpriseCode, Credentials.DealerNumber)
            {
                FinalCloseDateStart = DateTime.UtcNow.Add(RangeToPull),
                FinalCloseDateEnd = DateTime.UtcNow
            });

            Assert.True(result.Any());

            foreach (var ro in result)
            {
                Assert.False(String.IsNullOrWhiteSpace(ro.RepairOrderNumber));
            }
        }
    }
}