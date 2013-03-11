using System;
using System.Xml.Linq;

namespace OpenTrack.Requests
{
    public class OpenRepairOrderLookup : IRequest<OpenRepairOrderLookupResponse>
    {
        public OpenRepairOrderLookup(String EnterpriseCode, String DealerCode, String ServerName)
            : base(EnterpriseCode, DealerCode, ServerName)
        {
        }

        public String RepairOrderNumber { get; set; }

        public String VIN { get; set; }

        public String StockNumber { get; set; }

        public String CustomerNumber { get; set; }

        public String CustomerName { get; set; }

        public String TagNumber { get; set; }

        public Boolean InternalOnly { get; set; }

        internal override XElement XML
        {
            get
            {
                return new XElement("OpenRepairOrderLookup",
                    this.Dealer,
                    new XElement("LookupParms",
                        new XElement("RepairOrderNumber", this.RepairOrderNumber),
                        new XElement("VIN", this.VIN),
                        new XElement("StockNumber", this.StockNumber),
                        new XElement("CustomerNumber", this.CustomerNumber),
                        new XElement("CustomerName", this.CustomerName),
                        new XElement("TagNumber", this.TagNumber),
                        new XElement("InternalOnly", this.InternalOnly)
                        )
                    );
            }
        }
    }
}