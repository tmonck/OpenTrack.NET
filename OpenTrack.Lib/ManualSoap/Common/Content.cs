using System.Xml.Serialization;

namespace OpenTrack.ManualSoap.Common
{
    public abstract class Content
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }
}