using System;
using System.Xml.Linq;

namespace OpenTrack.Requests
{
    public class GetClosedRepairOrderRequest : IRequest<ClosedRepairOrders>
    {
        public String RepairOrderNumber { get; set; }

        public String VIN { get; set; }

        public String CustomerNumber { get; set; }

        /// <summary>
        /// When you use the daily request search parm you will get all of the closed repair orders on a specified day.
        /// The parm accepts zero or a positive integer. 0 will return today’s closed repair orders on inventory vehicles,
        /// 1 will return yesterdays, 2 will return current date – 2 days, etc.
        /// </summary>
        public String DailyRequest { get; set; }

        /// <summary>
        /// YYYY-MM-DDTHH:MM:SSZ
        /// </summary>
        public String CreatedDateTimeStart { get; set; }

        /// <summary>
        /// YYYY-MM-DDTHH:MM:SSZ
        /// </summary>
        public String CreatedDateTimeEnd { get; set; }

        /// <summary>
        /// YYYY-MM-DDTHH:MM:SSZ
        /// </summary>
        public String FinalCloseDateStart { get; set; }

        /// <summary>
        /// YYYY-MM-DDTHH:MM:SSZ
        /// </summary>
        public String FinalCloseDateEnd { get; set; }

        internal override XElement XML
        {
            get
            {
                return new XElement("GetClosedRepairOrder",
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