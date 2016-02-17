using System;
using System.Xml.Serialization;

namespace OpenTrack.ManualSoap.Requests
{
    [Serializable]
    [XmlRoot(Namespace = "opentrack.dealertrack.com")]
    public class ServicePricingLookupRequestBody
    {
        [XmlElement(ElementName = "dealer")]
        public Dealer Dealer { get; set; }

        [XmlElement(ElementName = "request")]
        public ServicePricingLookupRequest ServicePricingLookupRequest { get; set; }
    }
}