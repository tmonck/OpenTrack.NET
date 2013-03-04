using System;
using System.Xml.Linq;

namespace OpenTrack.Requests
{
    public class ClosedRepairOrderLookup : IRequest<ClosedRepairOrderLookupResponse>
    {
        public String RepairOrderNumber { get; set; }

        public String VIN { get; set; }

        public String CustomerNumber { get; set; }

        public String DailyRequest { get; set; }

        public String CreatedDateTimeStart { get; set; }

        public String CreatedDateTimeEnd { get; set; }

        public String FinalCloseDateStart { get; set; }

        public String FinalCloseDateEnd { get; set; }

        internal override XElement XML
        {
            get
            {
                return new XElement("ClosedRepairOrderLookup",
                    this.Dealer,
                    new XElement("LookupParms",
                        new XElement("RepairOrderNumber", this.RepairOrderNumber),
                        new XElement("VIN", this.VIN),
                        new XElement("CustomerNumber", this.CustomerNumber),
                        new XElement("DailyRequest", this.DailyRequest),
                        new XElement("CreatedDateTimeStart", this.CreatedDateTimeStart),
                        new XElement("CreatedDateTimeEnd", this.CreatedDateTimeEnd),
                        new XElement("FinalCloseDateStart", this.FinalCloseDateStart),
                        new XElement("FinalCloseDateEnd", this.FinalCloseDateEnd)
                        )
                    );
            }
        }
    }
}