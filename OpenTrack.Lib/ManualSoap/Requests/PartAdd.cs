using System;
using System.Xml.Serialization;

namespace OpenTrack.ManualSoap.Requests
{
    [Serializable]
    public class PartAdd
    {
        [XmlElement]
        public Dealer Dealer { get; set; }

        [XmlElement]
        public PartAddPart Part { get; set; }
    }
}