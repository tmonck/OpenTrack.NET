using System;
using System.Xml.Serialization;
using OpenTrack.ManualSoap.Common;

namespace OpenTrack.ManualSoap.Responses
{
    [Serializable]
    public class PartAddResponseContent : Content
    {
        [XmlElement(Namespace = "")]
        public PartAddResponse PartAddResponse { get; set; }
    }
}