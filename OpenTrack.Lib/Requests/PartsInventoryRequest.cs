using System;
using System.Xml.Linq;

namespace OpenTrack.Requests
{
    public class PartsInventoryRequest : IRequest<OpenTrack.Responses.PartsInventoryResponse>
    {
        public PartsInventoryRequest(String EnterpriseCode, String DealerCode, String ServerName)
            : base(EnterpriseCode, DealerCode, ServerName)
        {
        }

        public String StockingGroup { get; set; }

        public String Manufacturer { get; set; }

        public String PartNumber { get; set; }

        /// <summary>
        /// YYYY-MM-DDTHH:MM:SS0Z format
        /// </summary>
        public DateTime? DateInInventoryStart { get; set; }

        /// <summary>
        /// YYYY-MM-DDTHH:MM:SS0Z format
        /// </summary>
        public DateTime? DateInInventoryEnd { get; set; }

        /// <summary>
        /// YYYY-MM-DDTHH:MM:SS0Z format
        /// </summary>
        public DateTime? LastSoldDateStart { get; set; }

        /// <summary>
        /// YYYY-MM-DDTHH:MM:SS0Z format
        /// </summary>
        public DateTime? LastSoldDateEnd { get; set; }

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
                        new XElement("DateInInventoryStart", this.DateInInventoryStart.HasValue ? this.DateInInventoryStart.Value.ToString(DateTimeBracketFormat) : null),
                        new XElement("DateInInventoryEnd", this.DateInInventoryEnd.HasValue ? this.DateInInventoryEnd.Value.ToString(DateTimeBracketFormat) : null),
                        new XElement("LastSoldDateStart", this.LastSoldDateStart.HasValue ? this.LastSoldDateStart.Value.ToString(DateTimeBracketFormat) : null),
                        new XElement("LastSoldDateEnd", this.LastSoldDateEnd.HasValue ? this.LastSoldDateEnd.Value.ToString(DateTimeBracketFormat) : null)
                        )
                    );
            }
        }
    }
}