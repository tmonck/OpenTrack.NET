using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using OpenTrack.ManualSoap.Common;

namespace OpenTrack.ManualSoap.Responses
{
    [Serializable]
    public class PartAddResponse
    {
        [XmlElement(ElementName = "Error")]
        public List<Error> Errors { get; set; }

        [XmlElement]
        public Success Success { get; set; }
    }
}