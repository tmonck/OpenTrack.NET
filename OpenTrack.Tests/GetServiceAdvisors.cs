using System;
using System.Linq;
using Xunit;

namespace OpenTrack.Tests
{
    public class GetServiceAdvisors
    {
        [Fact]
        public void Test_Get_Service_Advisors()
        {
            var api = Credentials.GetAPI();

            var result = api.GetServiceAdvisors(new Requests.ServiceWritersTableRequest(Credentials.EnterpriseCode, Credentials.DealerCode, Credentials.ServerName)
            {
            });

            Assert.True(result.Any());

            foreach (var advisor in result)
            {
                Assert.False(String.IsNullOrWhiteSpace(advisor.Name));
            }
        }
    }
}