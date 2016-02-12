using System;
using System.Xml.Serialization;
using OpenTrack.ManualSoap.Common;

namespace OpenTrack.ManualSoap.Responses
{
    [Serializable]
    public class VehicleLookupResponseContent : Content
    {
        [XmlElement(Namespace = "")]
        public VehicleLookupResponse VehicleLookupResponse { get; set; }
    }
}