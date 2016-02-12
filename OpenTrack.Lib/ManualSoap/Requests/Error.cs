using System;
using System.Xml.Serialization;

namespace OpenTrack.ManualSoap.Requests
{
    [Serializable]
    public class Error
    {
        [XmlElement]
        public string Code { get; set; }

        [XmlElement]
        public string Message { get; set; }
    }
}