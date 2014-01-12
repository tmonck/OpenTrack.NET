using System;
using System.Xml.Linq;

namespace OpenTrack.Requests
{
    public class ServiceTechsTableRequest : IRequest<OpenTrack.Responses.ServiceTechsTable>
    {
        public ServiceTechsTableRequest(String EnterpriseCode, String DealerCode)
            : base(EnterpriseCode, DealerCode)
        {
        }

        public ServiceTechsTableRequest(String EnterpriseCode, String DealerCode, String ServerName)
            : base(EnterpriseCode, DealerCode, ServerName)
        {
        }

        internal override XElement Elements
        {
            get
            {
                return new XElement("ServiceTechsTableRequest", this.Dealer);
            }
        }
    }
}