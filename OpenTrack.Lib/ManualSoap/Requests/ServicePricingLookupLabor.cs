using System;
using System.Xml.Serialization;

namespace OpenTrack.ManualSoap.Requests
{
    [Serializable]
    public class ServicePricingLookupLabor
    {
        [XmlElement]
        public string LaborOpCode { get; set; }

        [XmlElement]
        public string ServiceType { get; set; }

        [XmlElement]
        public string PaymentMethod { get; set; }

        [XmlElement(ElementName = "ServiceContractCompanyID")]
        public decimal ServiceContractCompanyId { get; set; }

        [XmlElement]
        public decimal LaborHours { get; set; }

        [XmlElement]
        public string Manufacturer { get; set; }

        [XmlElement]
        public string LaborRateLevel { get; set; }

        [XmlElement]
        public string ServiceAdvisor { get; set; }
    }
}