using System;
using System.Xml.Serialization;

namespace OpenTrack.ManualSoap.Responses
{
    [Serializable]
    public class ServicePricingLookupResultLabor
    {
        [XmlElement]
        public ServicePricingLookupResultSuccess Success { get; set; }

        [XmlElement]
        public ServicePricingLookupResultError Error { get; set; }
    }
}