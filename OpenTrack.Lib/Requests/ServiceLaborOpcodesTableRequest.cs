using System;
using System.Xml.Linq;

namespace OpenTrack.Requests
{
    public class ServiceLaborOpcodesTableRequest : IRequest<OpenTrack.Responses.ServiceLaborOpcodesTable>
    {
        public ServiceLaborOpcodesTableRequest(String EnterpriseCode, String DealerCode)
            : base(EnterpriseCode, DealerCode)
        {
        }

        internal override XElement Elements
        {
            get
            {
                return new XElement("ServiceLaborOpcodesTableRequest", this.Dealer);
            }
        }
    }
}