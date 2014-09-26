using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace OpenTrack
{
    public abstract class IRequest
    {
        public const String DateFormat = "yyyyMMdd";
        public const String DateTimeFormat = "yyyyMMddHHmm";
        public const String DateTimeBracketFormat = "yyyy-MM-ddTHH:mm:ssZ";

        public String EnterpriseCode { get; set; }

        public String CompanyNumber { get; set; }

        public String ServerName { get; set; }

        public IRequest(String EnterpriseCode, String CompanyNumber)
        {
            if (String.IsNullOrWhiteSpace(EnterpriseCode)) throw new ArgumentNullException("Invalid EnterpriseCode provided.");
            if (String.IsNullOrWhiteSpace(CompanyNumber)) throw new ArgumentNullException("Invalid CompanyNumber provided.");

            this.EnterpriseCode = EnterpriseCode;
            this.CompanyNumber = CompanyNumber;
        }

        public IRequest(String EnterpriseCode, String CompanyNumber, String ServerName) : this(EnterpriseCode, CompanyNumber)
        {
            if (String.IsNullOrWhiteSpace(ServerName)) throw new ArgumentNullException("ServerName");

            this.ServerName = ServerName;
        }

        internal virtual ServiceAPI.DealerInfo Dealer
        {
            get
            {
                return new ServiceAPI.DealerInfo
                {
                    EnterpriseCode = this.EnterpriseCode,
                    CompanyNumber = this.CompanyNumber,
                    ServerName = this.ServerName
                };
            }
        }
    }

    /// <summary>
    /// A base class to use for requests to the OpenTrack API and handles deserializing the result to type T.
    /// </summary>
    public abstract class IRequest<T> : IRequest
    {
        public IRequest(String EnterpriseCode, String CompanyNumber)
            : base(EnterpriseCode, CompanyNumber)
        {
        }

        public IRequest(String EnterpriseCode, String CompanyNumber, String ServerName)
            : base(EnterpriseCode, CompanyNumber, ServerName)
        {
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
                var dealerElement = new XElement("Dealer",
                    new XElement("EnterpriseCode", this.EnterpriseCode),
                    new XElement("CompanyNumber", this.CompanyNumber)
                    );

                if (!String.IsNullOrWhiteSpace(ServerName))
                {
                    dealerElement.Add(new XElement("ServerName", ServerName));
                }

                return dealerElement;
            }
        }
    }
}