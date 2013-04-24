using System;
using System.Linq;
using Xunit;

namespace OpenTrack.Tests
{
    public class GetPartsInventory
    {
        [Fact]
        public void Test_Get_PartsInfo()
        {
            var api = Credentials.GetAPI();

            var result = api.GetPartsInventory(new Requests.PartsInventoryRequest(Credentials.EnterpriseCode, Credentials.DealerCode, Credentials.ServerName));

            Assert.True(result.Any());

            foreach (var part in result)
            {
                Assert.False(String.IsNullOrWhiteSpace(part.PartNumber));
            }
        }
    }
}