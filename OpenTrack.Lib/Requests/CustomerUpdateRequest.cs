using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace OpenTrack.Requests
{
    public class CustomerUpdateRequest : IRequest<OpenTrack.Responses.AddRepairOrderResponse>
    {
        public CustomerUpdateRequest(String EnterpriseCode, String DealerCode, String ServerName)
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