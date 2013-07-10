using OpenTrack.Requests;
using System;
using Xunit;

namespace OpenTrack.Tests
{
    public class PartsManufacturersTable
    {
        [Fact]
        public void Get_Parts_Manfacturers()
        {
            var api = Credentials.GetAPI();

            var result = api.GetPartManufacturers(new PartsManufacturersTableRequest(Credentials.EnterpriseCode, Credentials.DealerNumber));

            foreach (var man in result)
            {
                Assert.False(String.IsNullOrWhiteSpace(man.Manufacturer));
            }
        }
    }
}