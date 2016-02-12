using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using OpenTrack.ManualSoap.Requests;

namespace OpenTrack.ManualSoap.Responses
{
    [Serializable]
    public class VehicleLookupResponse
    {
        [XmlElement(ElementName = "Error")]
        public List<Error> Errors { get; set; }

        [XmlElement]
        public VehicleLookupResponseVehicle Vehicle { get; set; }

        
    }

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