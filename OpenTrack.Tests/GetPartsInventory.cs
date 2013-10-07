using System;
using Xunit;

namespace OpenTrack.Tests
{
    public class GetPartsInventory
    {
        [Fact]
        public void Parts_Inventory_Per_Manufacturer()
        {
            var api = Credentials.GetAPI();

            foreach (var manufacturer in api.GetPartManufacturers(new Requests.PartsManufacturersTableRequest(Credentials.EnterpriseCode, Credentials.DealerNumber)))
            {
                foreach (var part in api.GetPartsInventory(new Requests.PartsInventoryRequest(Credentials.EnterpriseCode, Credentials.DealerNumber) { Manufacturer = manufacturer.Manufacturer }))
                {
                    Assert.False(String.IsNullOrWhiteSpace(part.PartNumber));
                }
            }
        }

        [Fact]
        public void Parts_Inventory_Recently_Sold()
        {
            var api = Credentials.GetAPI();

            foreach (var part in api.GetPartsInventory(new Requests.PartsInventoryRequest(Credentials.EnterpriseCode, Credentials.DealerNumber) { LastSoldDateStart = DateTime.Today.AddDays(-1), LastSoldDateEnd = DateTime.Today.AddDays(1) }))
            {
                Assert.False(String.IsNullOrWhiteSpace(part.PartNumber));
            }
        }

        [Fact]
        public void Parts_Inventory_Recently_By_Part()
        {
            var api = Credentials.GetAPI();

            foreach (var part in api.GetPartsInventory(new Requests.PartsInventoryRequest(Credentials.EnterpriseCode, Credentials.DealerNumber) { PartNumber = "Q8400764" }))
            {
                Assert.False(String.IsNullOrWhiteSpace(part.PartNumber));
            }
        }
    }
}