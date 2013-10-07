using System;
using Xunit;

namespace OpenTrack.Tests
{
    public class GetPartsTransactions
    {
        [Fact]
        public void Parts_Transactions_Per_Manufacturer()
        {
            var api = Credentials.GetAPI();

            foreach (var manufacturer in api.GetPartManufacturers(new Requests.PartsManufacturersTableRequest(Credentials.EnterpriseCode, Credentials.DealerNumber)))
            {
                foreach (var part in api.GetPartsTransactions(new Requests.PartsTransactionsRequest(Credentials.EnterpriseCode, Credentials.DealerNumber) { Manufacturer = manufacturer.Manufacturer }))
                {
                    Assert.False(String.IsNullOrWhiteSpace(part.PartNumber));
                }
            }
        }
    }
}