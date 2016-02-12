using System;
using System.Xml.Serialization;
using OpenTrack.ManualSoap.Common;

namespace OpenTrack.ManualSoap.Responses
{
    [Serializable]
    public class ProcessMessageResponse<TContent> where TContent : Content
    {
        [XmlElement(ElementName = "payload")]
        public Payload<TContent> Payload { get; set; }
    }
}