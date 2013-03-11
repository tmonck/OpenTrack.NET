using System;
using System.Xml.Linq;

namespace OpenTrack.Requests
{
    /// <summary>
    /// The CustomerLookup request is used to get a specific customer record from the DMS customer database or as part of the process for the CustomerUpdate request.
    /// Use the CustomerLookup request with the customer key to obtain the entire customer record.
    /// </summary>
    public class CustomerLookupRequest : IRequest<OpenTrack.Responses.CustomerLookupResponse>
    {
        public CustomerLookupRequest(String EnterpriseCode, String DealerCode, String ServerName)
            : base(EnterpriseCode, DealerCode, ServerName)
        {
        }

        public String CustomerNumber { get; set; }

        internal override XElement Elements
        {
            get
            {
                return new XElement("CustomerLookup",
                    this.Dealer,
                    new XElement("CustomerNumber", this.CustomerNumber)
                    );
            }
        }
    }
}