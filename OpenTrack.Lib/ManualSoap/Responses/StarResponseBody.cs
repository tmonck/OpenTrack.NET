using System;
using System.Xml.Serialization;
using OpenTrack.ManualSoap.Common;
using OpenTrack.ManualSoap.Requests;

namespace OpenTrack.ManualSoap.Responses
{
    [Serializable]
    public class StarResponseBody<TContent> where TContent : Content
    {
        [XmlElement(Namespace = "http://www.starstandards.org/webservices/2005/10/transport")]
        public ProcessMessage<TContent> ProcessMessageResponse { get; set; }
    }
}