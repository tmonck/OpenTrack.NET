using System;

namespace OpenTrack.Requests
{
    /// <summary>
    /// Use this request to get the details on one Closed Repair Order.
    /// </summary>
    public class GetClosedRepairOrderDetailsRequest : IRequest
    {
        public GetClosedRepairOrderDetailsRequest(String EnterpriseCode, String DealerCode)
            : base(EnterpriseCode, DealerCode)
        {
        }

        public int RepairOrderNumber { get; set; }

        internal virtual References.GetClosedRepairOrderDetailRequest Request
        {
            get
            {
                return new References.GetClosedRepairOrderDetailRequest { RepairOrderNumber = this.RepairOrderNumber };
            }
        }
    }
}