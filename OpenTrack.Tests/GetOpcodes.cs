using System;
using System.Linq;
using Xunit;

namespace OpenTrack.Tests
{
    public class GetOpcodes
    {
        [Fact]
        public void Test_Get_Op_Codes()
        {
            var api = Credentials.GetAPI();

            var result = api.GetOpcodes(new Requests.ServiceLaborOpcodesTableRequest(Credentials.EnterpriseCode, Credentials.DealerNumber));

            Assert.True(result.Any());

            foreach (var code in result)
            {
                Assert.False(String.IsNullOrWhiteSpace(code.OperationCode));
            }
        }
    }
}