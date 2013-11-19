using OpenTrack.Requests;
using System;
using System.Linq;
using Xunit;

namespace OpenTrack.Tests
{
    public class AddRepairOrder
    {
        [Fact(Skip = "Integration Test, Be Careful")]
        public void Add_Repair_Order_Line()
        {
            var api = Credentials.GetAPI();

            // Grab RO's from the past two hours
            var ROs = api.FindOpenRepairOrders(new OpenRepairOrderLookup(Credentials.EnterpriseCode, Credentials.DealerNumber)
            {
                CreatedDateTimeStart = DateTime.UtcNow.AddHours(-2),
                CreatedDateTimeEnd = DateTime.UtcNow
            });

            // We're just going to use the first one in the list for this
            var RO = ROs.First();

            // Add a line
            var result = api.AddRepairOrderLines(new AddRepairOrderLinesRequest(Credentials.EnterpriseCode, Credentials.DealerNumber)
            {
                RepairOrderNumber = RO.RepairOrderNumber,
                ServiceWriterID = "485", // One selected randomly, not test-friendly!
                VIN = RO.VIN,
                CustomerNumber = RO.CustomerNumber,
                LineItems = new[]
                {
                    new LineItem()
                    {
                        LaborOpCode = "*", // See ServiceLaborOpcodesTable, * for undefined
                        ServiceLineNumber = "1", // The line # this detail refers to, grouped together by this
                        LineType = "A", // A = Labor Op Code Line Desc
                        TransCode = "CP", // CP IS WS
                        Comments = "This is a test line!", // Optional
                        LineStatus = "", // Optional I = Unassigned C = Complete
                        ServiceType = "MR"
                    }
                }
            });

            // Lame, just check to make sure there are some success codes and no failure codes
            Assert.True(result.Success.Any());
            Assert.False(result.Failure.Any());

            // Pull the RO again and verify additional line

            var RO_Check = api.FindOpenRepairOrders(new OpenRepairOrderLookup(Credentials.EnterpriseCode, Credentials.DealerNumber)
            {
                RepairOrderNumber = RO.RepairOrderNumber
            })
            .First();

            // Assert.True(RO_Check.Details.Any(line => line.LaborOpCode == OpCode));
        }
    }
}