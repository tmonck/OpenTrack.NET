using System;
using System.Xml.Serialization;

namespace OpenTrack.ManualSoap.Responses
{
    [Serializable]
    public class ServicePricingLookupResultSuccess
    {
        [XmlElement]
        public string LaborOpCode { get; set; }

        [XmlElement]
        public decimal LaborAmount { get; set; }

        [XmlElement]
        public decimal LaborHours { get; set; }
    }
}