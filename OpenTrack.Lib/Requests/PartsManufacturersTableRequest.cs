using System;
using System.Xml.Linq;

namespace OpenTrack.Requests
{
    public class PartsManufacturersTableRequest : IRequest<OpenTrack.Responses.PartsManufacturersTable>
    {
        public PartsManufacturersTableRequest(String EnterpriseCode, String DealerCode)
            : base(EnterpriseCode, DealerCode)
        {
        }

        internal override XElement Elements
        {
            get
            {
                return new XElement("PartsManufacturersTableRequest", this.Dealer);
            }
        }
    }
}