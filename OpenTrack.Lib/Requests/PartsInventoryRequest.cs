using System;
using System.Xml.Linq;

namespace OpenTrack.Requests
{
    public class PartsInventoryRequest : IRequest<PartsInventoryResponse>
    {
        public PartsInventoryRequest(String EnterpriseCode, String DealerCode, String ServerName)
            : base(EnterpriseCode, DealerCode, ServerName)
        {
        }

        public String StockingGroup { get; set; }

        public String Manufacturer { get; set; }

        public String PartNumber { get; set; }

        public String DateInInventoryStart { get; set; }

        public String DateInInventoryEnd { get; set; }

        public String LastSoldDateStart { get; set; }

        public String LastSoldDateEnd { get; set; }

        internal override XElement Elements
        {
            get
            {
                return new XElement("PartsInventory",
                    this.Dealer,
                    new XElement("InventoryParms",
                        new XElement("StockingGroup", this.StockingGroup),
                        new XElement("Manufacturer", this.Manufacturer),
                        new XElement("PartNumber", this.PartNumber),
                        new XElement("DateInInventoryStart", this.DateInInventoryStart),
                        new XElement("DateInInventoryEnd", this.DateInInventoryEnd),
                        new XElement("LastSoldDateStart", this.LastSoldDateStart),
                        new XElement("LastSoldDateEnd", this.LastSoldDateEnd)
                        )
                    );
            }
        }
    }
}