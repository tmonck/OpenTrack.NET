using System;
using System.Xml.Serialization;
using OpenTrack.ManualSoap.Requests;

namespace OpenTrack.ManualSoap.Common
{
    [Serializable]
    [XmlRoot(Namespace = "http://www.w3.org/2003/05/soap-envelope", ElementName = "Envelope")]
    public class Envelope<TBody>
    {
        [XmlElement(Namespace = "http://www.w3.org/2003/05/soap-envelope")]
        public Header Header { get; set; }

        [XmlElement(Namespace = "http://www.w3.org/2003/05/soap-envelope")]
        public TBody Body { get; set; }
    }
}