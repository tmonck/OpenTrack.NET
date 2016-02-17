using System;
using System.Xml.Serialization;

namespace OpenTrack.ManualSoap.Responses
{
    [Serializable]
    public class ServicePricingLookupResponse
    {
        [XmlElement]
        public ServicePricingLookupResult ServicePricingLookupResult { get; set; }
    }
}