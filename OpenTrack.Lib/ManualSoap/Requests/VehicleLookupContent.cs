using System;
using System.Xml.Serialization;
using OpenTrack.ManualSoap.Common;

namespace OpenTrack.ManualSoap.Requests
{
    [Serializable]
    public class VehicleLookupContent : Content
    {
        [XmlElement(Namespace = "")]
        public VehicleLookup VehicleLookup { get; set; }
    }
}