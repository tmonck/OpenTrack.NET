using System.Xml.Linq;

namespace OpenTrack.Requests
{
    public class ServiceWritersTableRequest : IRequest<ServiceWritersTable>
    {
        internal override XElement XML
        {
            get
            {
                return new XElement("ServiceWritersTableRequest", this.Dealer);
            }
        }
    }
}