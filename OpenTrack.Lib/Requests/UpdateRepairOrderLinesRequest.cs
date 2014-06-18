using System.Collections.Generic;
using OpenTrack.ServiceAPI;

namespace OpenTrack.Requests
{
    public class UpdateRepairOrderLinesRequest : IRequest
    {
        public UpdateRepairOrderLinesRequest(string EnterpriseCode, string CompanyNumber) : base(EnterpriseCode, CompanyNumber)
        {
            LineItems = new List<UpdateLineItem>();
        }

        public UpdateRepairOrderLinesRequest(string EnterpriseCode, string CompanyNumber, string ServerName) : base(EnterpriseCode, CompanyNumber, ServerName)
        {
            LineItems = new List<UpdateLineItem>();
        }

        public string RepairOrderNumber { get; set; }

        public List<UpdateLineItem> LineItems { get; set; }

        internal virtual ServiceAPI.UpdateRepairOrderLinesRequest Request { get
        {
            return new ServiceAPI.UpdateRepairOrderLinesRequest
            {
                RepairOrderNumber = this.RepairOrderNumber,
                LineItems = this.LineItems == null ? new UpdateLineItem[0] : this.LineItems.ToArray()
            };
        }
        }
    }
}