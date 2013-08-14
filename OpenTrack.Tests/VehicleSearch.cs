using OpenTrack.Requests;
using Xunit;

namespace OpenTrack.Tests
{
    public class VehicleSearch
    {
        [Fact]
        public void Vehicle_Search()
        {
            var api = Credentials.GetAPI();

            var result = api.FindVehicles(new VehicleSearchRequest(Credentials.EnterpriseCode, Credentials.DealerNumber)
            {
                Make = "FORD",
                ModelYear = "2013"
            });

            foreach (var vehicle in result)
            {
                Assert.Equal("FORD", vehicle.Make);
                Assert.Equal("2013", vehicle.ModelYear);
            }
        }
    }
}