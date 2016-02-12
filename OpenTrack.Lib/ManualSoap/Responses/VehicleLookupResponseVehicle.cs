using System;
using System.Xml.Serialization;

namespace OpenTrack.ManualSoap.Responses
{
    [Serializable]
    public class VehicleLookupResponseVehicle
    {
        [XmlElement]
        public string CompanyNumber { get; set; }

        [XmlElement(ElementName = "VIN")]
        public string Vin { get; set; }

        [XmlElement]
        public string StockNumber { get; set; }

        [XmlElement]
        public string DocumentNumber { get; set; }

        [XmlElement]
        public string Status { get; set; }

        [XmlElement(ElementName = "GLApplied")]
        public string GlApplied { get; set; }

    }
}