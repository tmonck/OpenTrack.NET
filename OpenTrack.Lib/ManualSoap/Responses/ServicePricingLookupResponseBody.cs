using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using OpenTrack.ManualSoap.Common;

namespace OpenTrack.ManualSoap.Responses
{
    [Serializable]
    [XmlRoot(Namespace = "opentrack.dealertrack.com")]
    public class ServicePricingLookupResponseBody
    {
        [XmlElement]
        public ServicePricingLookupResult ServicePricingLookupResult { get; set; }
    }

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

    [Serializable]
    public class ServicePricingLookupResultLabor
    {
        [XmlElement(ElementName = "Success", Namespace = "ServicePricingResponse")]
        public ServicePricingLookupResultSuccess Success { get; set; }

        [XmlElement(ElementName = "Error", Namespace = "ServicePricingResponse")]
        public ServicePricingLookupResultError Error { get; set; }
    }

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

    [Serializable]
    public class ServicePricingLookupResultSuccess
    {
        [XmlElement]
        public string LaborOpCode { get; set; }

        [XmlElement]
        public decimal LaborAmount { get; set; }

        [XmlElement]
        public int LaborHours { get; set; }
    }
}