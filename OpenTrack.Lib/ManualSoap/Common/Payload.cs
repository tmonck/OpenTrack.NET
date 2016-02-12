using System;
using System.Xml.Serialization;

namespace OpenTrack.ManualSoap.Common
{
    [Serializable]
    public class Payload<T> where T : Content
    {
        [XmlElement(ElementName = "content")]
        public T Content { get; set; }
    }
}