using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace OpenTrack.Requests
{
    public class CustomerListRequest : IRequest<OpenTrack.Responses.AddRepairOrderResponse>
    {
        public CustomerListRequest(String EnterpriseCode, String DealerCode, String ServerName)
            : base(EnterpriseCode, DealerCode, ServerName)
        {
        }

        public RepairOrder RO { get; set; }

        internal override XElement Elements
        {
            get
            {
                return new XElement("AddRepairOrder",
                    this.Dealer,
                    SerializeToXml<RepairOrder>(this.RO)
                    );
            }
        }
    }
}