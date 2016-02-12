using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using OpenTrack.ManualSoap.Common;

namespace OpenTrack.ManualSoap.Responses
{
    [Serializable]
    public class VehicleLookupResponse
    {
        [XmlElement(ElementName = "Error")]
        public List<Error> Errors { get; set; }

        [XmlElement]
        public VehicleLookupResponseVehicle Vehicle { get; set; }
    }
}