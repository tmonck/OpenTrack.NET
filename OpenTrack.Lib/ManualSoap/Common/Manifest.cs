using System;
using System.Xml.Serialization;

namespace OpenTrack.ManualSoap.Common
{
    [Serializable]
    public class Manifest
    {
        [XmlAttribute(AttributeName = "contentID")]
        public string ContentId { get; set; }

        [XmlAttribute(AttributeName = "namespaceURI")]
        public string NamespaceUri { get; set; }

        [XmlAttribute(AttributeName = "element")]
        public string Element { get; set; }

        [XmlAttribute(AttributeName = "relatedID")]
        public string RelatedId { get; set; }

        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }
    }
}