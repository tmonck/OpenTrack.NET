using System;
using System.Globalization;
using System.Linq;
using Xunit;

namespace OpenTrack.Tests
{
    public class FindOpenRepairOrders
    {
        [Fact]
        public void Test_Find_All_Open_ROs()
        {
            var api = Credentials.GetAPI();

            var result = api.FindOpenRepairOrders(new Requests.OpenRepairOrderLookup(Credentials.EnterpriseCode, Credentials.DealerNumber)
            {
                CreatedDateTimeStart = DateTime.Today.AddDays(-3),
                CreatedDateTimeEnd = DateTime.Today
            });

            Assert.True(result.Any());

            foreach (var ro in result)
            {
                Assert.False(String.IsNullOrWhiteSpace(ro.RepairOrderNumber));
            }
        }
    }
}