using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace OpenTrack
{
    /// <summary>
    /// A base class to use for requests to the OpenTrack API and handles deserializing the result to type T.
    /// </summary>
    public abstract class IRequest<T>
    {
        public const String DateFormat = "yyyyMMdd";
        public const String DateTimeFormat = "yyyyMMddHHmm";

        public String EnterpriseCode { get; private set; }

        public String DealerCode { get; private set; }

        public String ServerName { get; private set; }

        /// <summary>
        /// CompanyNumber is basically an alias for DealerCode.
        /// </summary>
        public String CompanyNumber { get { return this.DealerCode; } set { this.DealerCode = value; } }

        public IRequest(String EnterpriseCode, String DealerCode, String ServerName)
        {
            if (String.IsNullOrWhiteSpace(EnterpriseCode)) throw new ArgumentNullException("Invalid EnterpriseCode provided.");
            if (String.IsNullOrWhiteSpace(DealerCode)) throw new ArgumentNullException("Invalid DealerCode provided.");
            if (String.IsNullOrWhiteSpace(ServerName)) throw new ArgumentNullException("Invalid ServerName provided.");

            this.EnterpriseCode = EnterpriseCode;
            this.DealerCode = DealerCode;
            this.ServerName = ServerName;
        }

        /// <summary>
        /// A property representing the XML content of a specific request.
        /// </summary>
        internal abstract XElement Elements { get; }

        /// <summary>
        /// Returns the XML request as a string in the correct format.
        /// </summary>
        internal virtual String XML
        {
            get { return RemoveEmptyElements(this.Elements).ToString(); }
        }

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
        /// Serialize a C# model and convert it into an XElement for use in a request.
        /// </summary>
        internal XElement SerializeToXml<T>(Object obj)
        {
            using (var stream = new MemoryStream())
            {
                new XmlSerializer(typeof(T)).Serialize(stream, obj);

                return XElement.Parse(Encoding.ASCII.GetString(stream.ToArray()));
            }
        }

        /// <summary>
        /// Removes empty elements from the XML (i.e. <Data />)
        /// </summary>
        internal XElement RemoveEmptyElements(XElement xml)
        {
            var query = xml.Descendants().Where(c => !c.HasAttributes && c.IsEmpty);

            while (query.Any())
            {
                query.Remove();
            }

            return xml;
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