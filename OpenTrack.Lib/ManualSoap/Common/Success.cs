using System;
using System.Xml.Serialization;

namespace OpenTrack.ManualSoap.Common
{
    [Serializable]
    public class Success
    {
        [XmlElement]
        public string Message { get; set; }
    }
}