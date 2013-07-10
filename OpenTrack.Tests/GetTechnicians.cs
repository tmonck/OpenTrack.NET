using System;
using System.Linq;
using Xunit;

namespace OpenTrack.Tests
{
    public class GetTechnicians
    {
        [Fact]
        public void Test_Get_Technicians()
        {
            var api = Credentials.GetAPI();

            var result = api.GetTechnicians(new Requests.ServiceTechsTableRequest(Credentials.EnterpriseCode, Credentials.DealerNumber)
            {
            });

            Assert.True(result.Any());

            foreach (var tech in result)
            {
                Assert.False(String.IsNullOrWhiteSpace(tech.TechnicianId));
            }
        }
    }
}