using OpenTrack.Requests;
using System;
using System.Linq;
using Xunit;

namespace OpenTrack.Tests
{
    public class CustomerSearch
    {
        [Fact]
        public void Test_Search_For_Customer()
        {
            var api = Credentials.GetAPI();

            var result = api.FindCustomers(new CustomerSearchRequest(Credentials.EnterpriseCode, Credentials.DealerCode, Credentials.ServerName)
            {
                LastName = "Smith"
            });

            foreach (var customer in result.CustomerSearchResult)
            {
                Assert.Equal("Smith", customer.LastName);
            }
        }
    }
}