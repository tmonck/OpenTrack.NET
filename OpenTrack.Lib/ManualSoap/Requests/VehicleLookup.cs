using System;
using System.Xml.Serialization;

namespace OpenTrack.ManualSoap.Requests
{
    [Serializable]
    public class VehicleLookup
    {
        [XmlElement]
        public Dealer Dealer { get; set; }

        [XmlElement(ElementName = "VIN")]
        public string Vin { get; set; }

        [XmlElement]
        public string StockNumber { get; set; }
    }
}