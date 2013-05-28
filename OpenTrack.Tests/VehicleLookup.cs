using OpenTrack.Requests;
using Xunit;

namespace OpenTrack.Tests
{
    public class VehicleLookup
    {
        [Fact]
        public void Test_Vehicle_Lookup()
        {
            var api = Credentials.GetAPI();

            var result = api.GetVehicle(new VehicleLookupRequest(Credentials.EnterpriseCode, Credentials.DealerCode, Credentials.ServerName)
            {
                VIN = "SALSF2D48CA739995"
            });

            Assert.NotNull(result);

            Assert.Equal("SALSF2D48CA739995", result.VIN);
        }
    }
}