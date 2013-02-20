using System;
using System.Xml.Linq;

namespace OpenTrack.Requests
{
    public class GetRepairOrderDetail : IRequest<GetClosedRepairOrderDetailResponse>
    {
        public String RepairOrderNumber { get; set; }

        internal override XElement XML
        {
            get
            {
                return new XElement("GetRepairOrderDetail",
                    this.Dealer,
                    new XElement("RepairOrderNumber", this.RepairOrderNumber)
                    );
            }
        }
    }
}