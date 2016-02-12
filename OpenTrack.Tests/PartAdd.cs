using OpenTrack.ManualSoap.Requests;
using Xunit;

namespace OpenTrack.Tests
{
    public class PartAdd
    {
        [Fact]
        public void Verify_call_works()
        {
            // arrange
            var openTrackApi = Credentials.GetAPI();
            var partAdd = new OpenTrack.ManualSoap.Requests.PartAdd
            {
                Dealer = new Dealer
                {
                    EnterpriseCode = Credentials.EnterpriseCode,
                    CompanyNumber = Credentials.DealerNumber
                },
                Part = new PartAddPart
                {
                    Manufacturer = "GM",
                    PartNumber = "10000569",
                    PartDescription = "Test Description",
                    StockingGroup = "GM",
                    Status = "A",
                    BinLocation = "4",
                    Cost = 600,
                    Cps = "OTV"
                }
            };

            // act
            var response = openTrackApi.AddPart(partAdd);

            // assert
            Assert.NotNull(response);
        }
    }
}