using System;
using System.Xml.Serialization;
using OpenTrack.ManualSoap.Common;

namespace OpenTrack.ManualSoap.Requests
{
    [Serializable]
    public class PartAddContent : Content
    {
        [XmlElement(Namespace = "")]
        public PartAdd PartAdd { get; set; } 
    }
}