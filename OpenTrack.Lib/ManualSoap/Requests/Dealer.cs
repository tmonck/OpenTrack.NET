using System;
using System.Xml.Serialization;

namespace OpenTrack.ManualSoap.Requests
{
    [Serializable]
    public class Dealer
    {
        [XmlElement]
        public string EnterpriseCode { get; set; }

        [XmlElement]
        public string CompanyNumber { get; set; }

        [XmlElement]
        public string ServerName { get; set; }
    }
}