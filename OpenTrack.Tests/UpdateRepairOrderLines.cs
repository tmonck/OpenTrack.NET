using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using OpenTrack.Requests;
using OpenTrack.ServiceAPI;
using Xunit;
using UpdateRepairOrderLinesRequest = OpenTrack.Requests.UpdateRepairOrderLinesRequest;

namespace OpenTrack.Tests
{
    public class UpdateRepairOrderLines
    {
        [Fact(Skip = "Integration that adds repair orders, DO NOT EXECUTE ON PRODUCTION URI")]
        public void Update_Repair_Order_Lines()
        {
            // arrange
            var api = Credentials.GetAPI();

            var customer =
                api.FindCustomers(new CustomerSearchRequest(Credentials.EnterpriseCode, Credentials.DealerNumber) { LastName = "Smith" })
                    .CustomerSearchResult.First(c => c.Vehicles != null && c.Vehicles.Any());
            var vehicleVin = customer.Vehicles.First();

            var advisor =
                api.GetServiceAdvisors(new ServiceWritersTableRequest(Credentials.EnterpriseCode,
                    Credentials.DealerNumber)).First();

            var ro = new RepairOrder
            {
                CustomerNumber = customer.CustomerNumber,
                VIN = vehicleVin.Value,
                ServiceWriterID = advisor.ID,
                OdometerIn = "1",
                LineItems = new List<LineItem> { new LineItem { LaborOpCode = "*", ServiceLineNumber = "1", LineType = "A", TransCode = "CP", Comments = "Test", ServiceType = "MR" }},
                TagNumber = string.Empty
            };

            var addRoResponse =
                api.AddRepairOrder(new AddRepairOrderRequest(Credentials.EnterpriseCode, Credentials.DealerNumber)
                {
                    RO = ro
                });
            var roNumber = addRoResponse.RepairOrderNumber;

            var retreivedRo =
                api.FindOpenRepairOrders(new OpenRepairOrderLookup(Credentials.EnterpriseCode, Credentials.DealerNumber)
                {
                    RepairOrderNumber = roNumber
                }).First();
            // we need the op code line
            var detail = retreivedRo.Details.First(r => r.LineType == "A");

            // act
            var updateLineItemsRequest = new UpdateRepairOrderLinesRequest(Credentials.EnterpriseCode,
                Credentials.DealerNumber) { RepairOrderNumber = roNumber };
            var updateLineItem = new UpdateLineItem
            {
                ServiceLineNumber = Convert.ToInt32(detail.ServiceLineNumber),
                CauseStatement = "Test Cause"
            };
            updateLineItemsRequest.LineItems.Add(updateLineItem);
            var updateLineItemsResponse = api.UpdateRepairOrderLines(updateLineItemsRequest);

            // assert
            Assert.NotNull(updateLineItemsResponse);
            Assert.NotNull(updateLineItemsResponse.Success);
        }
    }
}