using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using OpenTrack.ManualSoap.Common;

namespace OpenTrack.ManualSoap.Responses
{
    [Serializable]
    public class ServicePricingLookupResult
    {
        [XmlArray(ElementName = "Labors")]
        [XmlArrayItem(ElementName = "Labor")]
        public List<ServicePricingLookupResultLabor> ServicePricingLookupResultLabors { get; set; }

        [XmlArray(ElementName = "Errors")]
        [XmlArrayItem(ElementName = "Error")]
        public List<Error> Errors { get; set; } 
    }
}