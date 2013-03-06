using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace OpenTrack
{
    public abstract class IRequest<T>
    {
        // Not sure if these are per-dealer yet or what.
        public String EnterpriseCode { get; set; }

        public String DealerCode { get; set; }

        public String ServerName { get; set; }

        /// <summary>
        /// A property representing the XML content of a specific request.
        /// </summary>
        internal abstract XElement XML { get; }

        /// <summary>
        /// Process the xml response from the web service.
        /// </summary>
        internal virtual T ProcessResponse(XmlElement xml)
        {
            using (var reader = XmlReader.Create(new StringReader(xml.OuterXml)))
            {
                return (T)new XmlSerializer(typeof(T)).Deserialize(reader);
            }
        }

        /// <summary>
        /// The text content of the 'dealer' elements, specific to a dealership for the request.
        /// </summary>
        internal virtual XElement Dealer
        {
            get
            {
                return new XElement("Dealer",
                    new XElement("EnterpriseCode", this.EnterpriseCode),
                    new XElement("CompanyNumber", this.DealerCode),
                    new XElement("ServerName", this.ServerName)
                    );
            }
        }
    }
}