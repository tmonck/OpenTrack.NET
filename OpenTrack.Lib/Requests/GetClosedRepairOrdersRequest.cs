using System;
using System.Xml.Linq;

namespace OpenTrack.Requests
{
    /// <summary>
    /// The GetClosedRepairOrdersRequest request is used to get a single repair order or a set of repair orders by VIN number or customer number.
    /// </summary>
   
    public class GetClosedRepairOrdersRequest : IRequest<OpenTrack.Responses.ClosedRepairOrderLookupResponse>
    {
        public GetClosedRepairOrdersRequest(String EnterpriseCode, String DealerCode)
            : base(EnterpriseCode, DealerCode)
        {
        }

        public String RepairOrderNumber { get; set; }

        public String VIN { get; set; }

        public String CustomerNumber { get; set; }

        /// <summary>
        /// Any one of the search parameters is sufficient to check for repair orders.
        /// </summary>
        public String DailyRequest { get; set; }

        public DateTime? CreatedDateTimeStart { get; set; }

        public DateTime? CreatedDateTimeEnd { get; set; }

        public DateTime? FinalCloseDateStart { get; set; }

        public DateTime? FinalCloseDateEnd { get; set; }

        internal override XElement Elements
        {
            get
            {
                return new XElement("GetClosedRepairOrders",
                    this.Dealer,
                    new XElement("Request",
                        new XElement("RepairOrderNumber", this.RepairOrderNumber),
                        new XElement("VIN", this.VIN),
                        new XElement("CustomerNumber", this.CustomerNumber),
                        new XElement("CreatedDateTimeStart", this.CreatedDateTimeStart.HasValue ? this.CreatedDateTimeStart.Value.ToString(DateTimeBracketFormat) : null),
                        new XElement("CreatedDateTimeEnd", this.CreatedDateTimeEnd.HasValue ? this.CreatedDateTimeEnd.Value.ToString(DateTimeBracketFormat) : null),
                        new XElement("FinalCloseDateStart", this.FinalCloseDateStart.HasValue ? this.FinalCloseDateStart.Value.ToString(DateTimeBracketFormat) : null),
                        new XElement("FinalCloseDateEnd", this.FinalCloseDateEnd.HasValue ? this.FinalCloseDateEnd.Value.ToString(DateTimeBracketFormat) : null)
                        )
                    );
            }
        }
    }
}