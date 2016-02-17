using System;
using System.Xml.Serialization;

namespace OpenTrack.ManualSoap.Common
{
    [Serializable]
    public class Header
    {
        [XmlElement(Namespace = "http://www.starstandards.org/webservices/2005/10/transport")]
        public PayloadManifest PayloadManifest { get; set; }

        [XmlElement(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd")]
        public SecurityHeader Security { get; set; }
    }
}