using System;
using System.Xml.Linq;

namespace OpenTrack.Requests
{
    public class GetRepairOrderDetail : IRequest<OpenTrack.Responses.GetClosedRepairOrderDetailResponse>
    {
        public GetRepairOrderDetail(String EnterpriseCode, String DealerCode)
            : base(EnterpriseCode, DealerCode)
        {
        }

        /// <summary>
        /// The Repair Order # in the DMS that we want to get the details of.
        /// </summary>
        public String RepairOrderNumber { get; set; }

        internal override XElement Elements
        {
            get
            {
                return new XElement("GetRepairOrderDetail", this.Dealer, new XElement("RepairOrderNumber", this.RepairOrderNumber));
            }
        }
    }
}