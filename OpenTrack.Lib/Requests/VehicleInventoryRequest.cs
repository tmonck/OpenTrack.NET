using System;
using System.Xml.Linq;

namespace OpenTrack.Requests
{
    public class VehicleInventoryRequest : IRequest<OpenTrack.Responses.VehicleInventoryResponse>
    {
        public VehicleInventoryRequest(String EnterpriseCode, String DealerCode)
            : base(EnterpriseCode, DealerCode)
        {
        }

        public String Type { get; set; }

        public String FromDateInInventory { get; set; }

        public String ToDateInInventory { get; set; }

        internal override XElement Elements
        {
            get
            {
                return new XElement("VehicleInventory",
                    this.Dealer,
                    new XElement("LookupParms",
                        new XElement("Type", this.Type),
                        new XElement("FromDateInInventory", this.FromDateInInventory),
                        new XElement("ToDateInInventory", this.ToDateInInventory)
                    ));
            }
        }
    }
}