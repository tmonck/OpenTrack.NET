using System.Collections.Generic;
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

        [Fact(Skip = "Integration Test, Be Careful")]
        public void Add_Repair_Order_With_Service_Contracts()
        {
            var api = Credentials.GetAPI();

            var ro = new RepairOrder
            {
                CustomerNumber = "4232734",
                VIN = "JTHFF2C20B2515555",
                ServiceWriterID = "999",
                OdometerIn = "40602",
                LineItems = new List<LineItem> {
                    new LineItem {
                        LaborOpCode = "*",
                        ServiceLineNumber = "1",
                        LineType = "A",
                        TransCode = "SC",
                        Comments = "Test",
                        ServiceType = "MR",
                        ServiceDepartmentKey = "6",
                        ServiceContractSequenceNumber = "1"
                    }
                },
                TagNumber = string.Empty
            };

            var addRoResponse =
                api.AddRepairOrder(new AddRepairOrderRequest("CRMT", "BH1")
                {
                    RO = ro
                });
        }

        [Fact(Skip = "Integration test for INS-7344.")]
        public void Cause_response_with_multiple_errors()
        {
            var threwException = false;
            var api = Credentials.GetAPI();

            var ro = new RepairOrder
            {
                CustomerNumber = "4232734",
                VIN = "JTHFF2C20B251555x", // RO2: VIN not found in DMS; RO22: Customer must own vehicle.
                ServiceWriterID = "nope", // RO5: Invalid or missing ServiceWriterID.
                OdometerIn = "-1", // invalid, but not checked due to above vehicle errors
                LineItems = new List<LineItem> {
                    new LineItem {
                        LaborOpCode = "nope", // RO10: LineItem 1 has an invalid LaborOpCode.
                        ServiceLineNumber = "1",
                        LineType = "A",
                        TransCode = "CP",
                        ServiceType = "MR"
                    },
                    new LineItem {
                        LaborOpCode = "*",
                        ServiceLineNumber = "-1", // RO21: LineItem 2's ServiceLineNumber is invalid or missing.
                        LineType = "A",
                        TransCode = "CP",
                        ServiceType = "MR"
                    },
                },
            };

            try
            {
                var addRoResponse =
                    api.AddRepairOrder(new AddRepairOrderRequest("CRMT", "BH1")
                    {
                        RO = ro
                    });
            }
            catch (Exception ex)
            {
                threwException = true;
                var otex = ex as OpenTrackException;
                Assert.True(otex != null, "The exception should have been an OpenTrackException.");
                Assert.True(otex.ErrorItems != null, "The ErrorItems list should not be null.");
                Assert.True(otex.ErrorItems.Count > 1, "The ErrorItems list should contain multiple items.");
                Assert.True(otex.ErrorItems.Count(e => string.IsNullOrWhiteSpace(e.ErrorCode)) == 0, "The ErrorItems should all have an ErrorCode.");
                Assert.True(otex.ErrorItems.Count(e => string.IsNullOrWhiteSpace(e.ErrorMessage)) == 0, "The ErrorItems should all have an ErrorMessage.");
            }

            Assert.True(threwException, "This RO was supposed to cause an exception.");
        }
    }
}