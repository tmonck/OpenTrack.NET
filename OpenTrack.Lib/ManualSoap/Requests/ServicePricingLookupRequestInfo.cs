using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OpenTrack.ManualSoap.Requests
{
    [Serializable]
    public class ServicePricingLookupRequestInfo
    {
        [XmlElement]
        public string CustomerKey { get; set; }

        [XmlArray(ElementName = "Labors")]
        [XmlArrayItem(ElementName = "Labor")]
        public List<ServicePricingLookupLabor> ServicePricingLookupLabors { get; set; }
    }
}