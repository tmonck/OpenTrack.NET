using System;
using System.Xml.Serialization;

namespace OpenTrack.ManualSoap.Common
{
    [Serializable]
    public class PayloadManifest
    {
        [XmlElement(ElementName = "manifest", Namespace = "")]
        public Manifest Manifest { get; set; }
    }
}