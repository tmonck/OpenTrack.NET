using System;
using System.Xml.Serialization;

namespace OpenTrack.ManualSoap.Requests
{
    [Serializable]
    public class ServicePricingLookup
    {
        [XmlElement(ElementName = "dealer")]
        public Dealer Dealer { get; set; }

        [XmlElement(ElementName = "request")]
        public ServicePricingLookupRequestInfo RequestInfo { get; set; }
    }
}