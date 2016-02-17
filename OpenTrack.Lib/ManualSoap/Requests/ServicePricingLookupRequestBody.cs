using System;
using System.Xml.Serialization;

namespace OpenTrack.ManualSoap.Requests
{
    [Serializable]
    [XmlRoot(Namespace = "opentrack.dealertrack.com")]
    public class ServicePricingLookupRequestBody
    {
        [XmlElement]
        public ServicePricingLookup ServicePricingLookup { get; set; }
    }
}