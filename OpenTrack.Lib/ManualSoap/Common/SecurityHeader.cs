using System;
using System.Xml.Serialization;

namespace OpenTrack.ManualSoap.Common
{
    [Serializable]
    public class SecurityHeader
    {
        public SecurityHeader()
        {
            this.MustUnderstand = 1;
        }

        [XmlAttribute(Namespace = "http://www.w3.org/2003/05/soap-envelope", AttributeName = "mustUnderstand")]
        public int MustUnderstand { get; set; }

        [XmlElement(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd")]
        public Timestamp Timestamp { get; set; }

        [XmlElement(ElementName = "UsernameToken")]
        public UserNameToken UserNameToken { get; set; }

        
    }
}