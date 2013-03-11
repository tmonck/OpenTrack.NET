using System;
using System.Xml.Linq;

namespace OpenTrack.Requests
{
    /// <summary>
    /// The CustomerLookup request is used to get a list of customer records from the DMS customer database or as part of the process for the CustomerUpdate request.
    /// The CustomerLookup request can only be used between 08:00:00 and 10:00:00 UTC
    /// </summary>
    public class CustomerListRequest : IRequest<OpenTrack.Responses.CustomerListResponse>
    {
        public CustomerListRequest(String EnterpriseCode, String DealerCode, String ServerName)
            : base(EnterpriseCode, DealerCode, ServerName)
        {
        }

        /// <summary>
        /// Y/N
        /// </summary>
        public String IncludeCompanies { get; set; }

        public String ZipCode { get; set; }

        /// <summary>
        /// Y/N
        /// </summary>
        public String ExcludeBlankAddress { get; set; }

        /// <summary>
        /// Y/N
        /// </summary>
        public String ExcludeBlankPhone { get; set; }

        /// <summary>
        /// Y/N
        /// </summary>
        public String ExcludeBlankEmail { get; set; }

        internal override XElement Elements
        {
            get
            {
                return new XElement("CustomerList",
                    this.Dealer,
                    new XElement("ListParms",
                        new XElement("IncludeCompanies", this.IncludeCompanies),
                        new XElement("ZipCode", this.ZipCode),
                        new XElement("ExcludeBlankAddress", this.ExcludeBlankAddress),
                        new XElement("ExcludeBlankPhone", this.ExcludeBlankPhone),
                        new XElement("ExcludeBlankEmail", this.ExcludeBlankEmail)
                        )
                    );
            }
        }
    }
}