using System.Collections.Generic;
using OpenTrack.Requests;
using Xunit;

namespace OpenTrack.Tests
{
    public class VehicleAdd
    {
        //[Fact]
        public void Vehicle_Add()
        {
            var api = Credentials.GetAPI();

            var request = new VehicleAddRequest(Credentials.EnterpriseCode, Credentials.DealerNumber);
            request.Vehicle = new Vehicle
            {
                DealerCode = Credentials.DealerNumber,
                VIN = "2FMDK4KC8DBA52504",
                Status = "I",
                TypeNU = "U",
                BusinessOfficeFranchiseCode = "XXX",
                ModelYear = "2014",
                Make = "FORD",
                Model = "MUSTANG",
                OptionalFields =
                    new List<VehicleOptionalField>
                    {
                        new VehicleOptionalField
                        {
                            OptionNumber = 4,
                            Description = "Holdback",
                            FieldType = "B",
                            NumericFieldValue = 0.00m,
                            DateFieldValue = "0",
                            AddToCostFlag = "N"
                        }
                    },
                Options =
                    new List<VehicleOption> {new VehicleOption {OptionCode = "ABS", Description = "AntiLockBreaks"}}
            };

            var response = api.AddVehicle(request);
            Assert.NotNull(response);
        }
    }
}