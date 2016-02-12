using System;
using System.Xml.Serialization;

namespace OpenTrack.ManualSoap.Common
{
    [Serializable]
    public class UserNameToken
    {
        [XmlAttribute(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd")]
        public string Id { get; set; }

        [XmlElement(ElementName = "Username")]
        public string UserName { get; set; }

        [XmlElement]
        public Password Password { get; set; }
    }
}