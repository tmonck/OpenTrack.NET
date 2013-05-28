using OpenTrack.Requests;
using Xunit;

namespace OpenTrack.Tests
{
    public class VehicleSearch
    {
        [Fact]
        public void Test_Search_For_Vehicle()
        {
            var api = Credentials.GetAPI();

            var result = api.FindVehicles(new VehicleSearchRequest(Credentials.EnterpriseCode, Credentials.DealerCode, Credentials.ServerName)
            {
                VIN = "SALSF2D48CA739995"
            });

            foreach (var vehicle in result)
            {
                Assert.Equal("SALSF2D48CA739995", vehicle.VIN);
            }
        }
    }
}