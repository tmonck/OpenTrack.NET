using System;
using System.Xml.Serialization;
using OpenTrack.ManualSoap.Common;

namespace OpenTrack.ManualSoap.Requests
{
    [Serializable]
    public class StarRequestBody<TContent> where TContent : Content
    {
        [XmlElement(Namespace = "http://www.starstandards.org/webservices/2005/10/transport")]
        public ProcessMessage<TContent> ProcessMessage { get; set; }
    }
}