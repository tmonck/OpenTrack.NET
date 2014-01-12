using System;
using System.Xml.Linq;

namespace OpenTrack.Requests
{
    /// <summary>
    /// The CustomerSearch request is used to search for a specific customer record from the DMS customer database or as
    /// part of the process for the CustomerAdd or CustomerUpdate request.
    /// </summary>
    public class CustomerSearchRequest : IRequest<OpenTrack.Responses.CustomerSearchResponse>
    {
        public CustomerSearchRequest(String EnterpriseCode, String DealerCode)
            : base(EnterpriseCode, DealerCode)
        {
        }

        public CustomerSearchRequest(String EnterpriseCode, String DealerCode, String ServerName)
            : base(EnterpriseCode, DealerCode, ServerName)
        {
        }

        public String LastName { get; set; }

        public String FirstName { get; set; }

        public String Phone { get; set; }

        public String Email { get; set; }

        /// <summary>
        /// YYYY-MM-DDTHH:MM:SSZ
        /// </summary>
        public String CreatedDateTimeStart { get; set; }

        /// <summary>
        /// YYYY-MM-DDTHH:MM:SSZ
        /// </summary>
        public String CreatedDateTimeEnd { get; set; }

        /// <summary>
        /// YYYY-MM-DDTHH:MM:SSZ
        /// </summary>
        public String UpdatedDateTimeStart { get; set; }

        /// <summary>
        /// YYYY-MM-DDTHH:MM:SSZ
        /// </summary>
        public String UpdatedDateTimeEnd { get; set; }

        public String ZipCode { get; set; }

        public String State { get; set; }

        /// <summary>
        /// Y/N
        /// </summary>
        public String AllowContactByEmail { get; set; }

        /// <summary>
        /// Y/N
        /// </summary>
        public String AllowContactByPhone { get; set; }

        /// <summary>
        /// Y/N
        /// </summary>
        public String AllowContactByPostal { get; set; }

        internal override XElement Elements
        {
            get
            {
                return new XElement("CustomerSearch",
                    this.Dealer,
                    new XElement("SearchParms",
                        new XElement("LastName", this.LastName),
                        new XElement("FirstName", this.FirstName),
                        new XElement("Phone", this.Phone),
                        new XElement("Email", this.Email),
                        new XElement("CreatedDateTimeStart", this.CreatedDateTimeStart),
                        new XElement("CreatedDateTimeEnd", this.CreatedDateTimeEnd),
                        new XElement("UpdatedDateTimeStart", this.UpdatedDateTimeStart),
                        new XElement("UpdatedDateTimeEnd", this.UpdatedDateTimeEnd),
                        new XElement("ZipCode", this.ZipCode),
                        new XElement("State", this.State),
                        new XElement("AllowContactByEmail", this.AllowContactByEmail),
                        new XElement("AllowContactByPhone", this.AllowContactByPhone),
                        new XElement("AllowContactByPostal", this.AllowContactByPostal)
                        )
                    );
            }
        }
    }
}