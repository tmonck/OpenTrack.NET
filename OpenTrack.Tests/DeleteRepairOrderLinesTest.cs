using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTrack.Requests;
using OpenTrack.ServiceAPI;
using Xunit;
using DeleteRepairOrderLinesRequest = OpenTrack.Requests.DeleteRepairOrderLinesRequest;

namespace OpenTrack.Tests
{
    public class DeleteRepairOrderLinesTest
    {

        [Fact]//(Skip = "This should not be automated since it will actually update a Repair Order.")]
        public void Test_Delete_RepairOrder_Line()
        {
            var api = Credentials.GetAPI();
            api.DeleteRepairOrderLines(
                new DeleteRepairOrderLinesRequest(Credentials.EnterpriseCode, Credentials.DealerNumber)
                {
                    LineItems = new List<UpdateLineItem>()
                    {
                        new UpdateLineItem()
                        {
                            ServiceLineNumber = 2
                        }
                    }
                }
                );
        }
    }
}
