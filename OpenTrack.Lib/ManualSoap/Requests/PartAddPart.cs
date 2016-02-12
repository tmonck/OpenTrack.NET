using System;
using System.Xml.Serialization;

namespace OpenTrack.ManualSoap.Requests
{
    [Serializable]
    public class PartAddPart
    {
        [XmlElement]
        public string PartNumber { get; set; }

        [XmlElement]
        public string Manufacturer { get; set; }

        [XmlElement]
        public string PartDescription { get; set; }

        [XmlElement]
        public string StockingGroup { get; set; }

        [XmlElement]
        public string Status { get; set; }

        [XmlElement]
        public string BinLocation { get; set; }

        [XmlElement]
        public string ShelfLocation { get; set; }

        [XmlElement]
        public decimal Cost { get; set; }

        [XmlElement]
        public decimal ListPrice { get; set; }

        [XmlElement]
        public decimal TradePrice { get; set; }

        [XmlElement(ElementName = "CPS")]
        public string Cps { get; set; }
    }
}