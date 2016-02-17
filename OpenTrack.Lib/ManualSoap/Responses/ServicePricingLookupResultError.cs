using System;
using System.Xml.Serialization;

namespace OpenTrack.ManualSoap.Responses
{
    [Serializable]
    public class ServicePricingLookupResultError
    {
        [XmlElement]
        public string Code { get; set; }

        [XmlElement]
        public string Message { get; set; }

        [XmlElement]
        public string LaborOpCode { get; set; }
    }
}