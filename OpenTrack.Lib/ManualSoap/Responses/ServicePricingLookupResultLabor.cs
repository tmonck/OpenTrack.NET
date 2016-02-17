using System;
using System.Xml.Serialization;

namespace OpenTrack.ManualSoap.Responses
{
    [Serializable]
    public class ServicePricingLookupResultLabor
    {
        [XmlElement(ElementName = "Success", Namespace = "ServicePricingResponse")]
        public ServicePricingLookupResultSuccess Success { get; set; }

        [XmlElement(ElementName = "Error", Namespace = "ServicePricingResponse")]
        public ServicePricingLookupResultError Error { get; set; }
    }
}