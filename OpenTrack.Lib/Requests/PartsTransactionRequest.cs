using System;
using System.Xml.Linq;

namespace OpenTrack.Requests
{
    public class PartsTransactionsRequest : IRequest<OpenTrack.Responses.PartsInventoryResponse>
    {
        public PartsTransactionsRequest(String EnterpriseCode, String DealerCode)
            : base(EnterpriseCode, DealerCode)
        {
        }

        public String TransactionType { get; set; }

        public String Manufacturer { get; set; }

        public String PartNumber { get; set; }

        /// <summary>
        /// YYYY-MM-DDTHH:MM:SS0Z format
        /// </summary>
        public DateTime? TransDateStart { get; set; }

        /// <summary>
        /// YYYY-MM-DDTHH:MM:SS0Z format
        /// </summary>
        public DateTime? TransDateEnd { get; set; }

        internal override XElement Elements
        {
            get
            {
                return new XElement("PartsTransactions",
                    this.Dealer,
                    new XElement("SearchParms",
                        new XElement("TransDateStart", this.TransDateStart.HasValue ? this.TransDateStart.Value.ToString(DateTimeBracketFormat) : null),
                        new XElement("TransDateEnd", this.TransDateEnd.HasValue ? this.TransDateEnd.Value.ToString(DateTimeBracketFormat) : null),
                        new XElement("Manufacturer", this.Manufacturer),
                        new XElement("PartNumber", this.PartNumber),
                        new XElement("TransactionType",  this.TransactionType)
                        )
                    );
            }
        }
    }
}