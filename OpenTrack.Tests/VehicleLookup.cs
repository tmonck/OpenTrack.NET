using OpenTrack.Requests;
using Xunit;

namespace OpenTrack.Tests
{
    public class VehicleLookup
    {
        [Fact]
        public void Vehicle_Lookup()
        {
            var api = Credentials.GetAPI();

            var result = api.GetVehicle(new VehicleLookupRequest(Credentials.EnterpriseCode, Credentials.DealerNumber)
            {
                VIN = "2FMDK4KC8DBA52504"
            });

            Assert.NotNull(result);

            Assert.Equal("2FMDK4KC8DBA52504", result.VIN);
            Assert.Equal("FORD", result.Make);
            Assert.Equal("2013", result.ModelYear);
        }
    }
}