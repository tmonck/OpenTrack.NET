using System;
using System.Xml.Serialization;

namespace OpenTrack.ManualSoap.Responses
{
    [Serializable]
    [XmlRoot(Namespace = "opentrack.dealertrack.com")]
    public class ServicePricingLookupResponseBody
    {
        [XmlElement]
        public ServicePricingLookupResult ServicePricingLookupResult { get; set; }
    }
}