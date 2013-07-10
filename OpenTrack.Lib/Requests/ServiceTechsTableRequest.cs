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

        internal override XElement Elements
        {
            get
            {
                return new XElement("ServiceTechsTableRequest", this.Dealer);
            }
        }
    }
}