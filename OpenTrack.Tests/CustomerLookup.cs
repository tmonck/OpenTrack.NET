using Xunit;

namespace OpenTrack.Tests
{
    public class CustomerLookup
    {
        [Fact]
        public void Test_Customer_Lookup()
        {
            var api = Credentials.GetAPI();

            var result = api.GetCustomer(new Requests.CustomerLookupRequest(Credentials.EnterpriseCode, Credentials.DealerCode, Credentials.ServerName)
            {
                CustomerNumber = "1000135"
            });

            Assert.NotNull(result);

            Assert.Equal("1000135", result.CustomerNumber);
        }
    }
}