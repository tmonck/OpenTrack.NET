using System;
using System.Xml.Serialization;
using OpenTrack.ManualSoap.Common;

namespace OpenTrack.ManualSoap.Requests
{
    [Serializable]
    public class ProcessMessage<TContent> where TContent : Content
    {
        [XmlElement(ElementName = "payload")]
        public Payload<TContent> Payload { get; set; }
    }
}