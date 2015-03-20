using OpenTrack.Requests;
using Xunit;

namespace OpenTrack.Tests
{
    public class PartsStockingGroupTable
    {
        [Fact]
        public void Get_Parts_Stocking_Groups()
        {
            var api = Credentials.GetAPI();

            var results =
                api.GetPartsStockingGroups(new PartsStockingGroupsTableRequest(Credentials.EnterpriseCode,
                    Credentials.DealerNumber));

            foreach (var stockingGroup in results)
            {
                Assert.False(string.IsNullOrWhiteSpace(stockingGroup.Manufacturer));
            }
        }
    }
}