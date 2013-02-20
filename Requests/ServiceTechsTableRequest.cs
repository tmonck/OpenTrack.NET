using System.Xml.Linq;

namespace OpenTrack.Requests
{
    public class ServiceTechsTableRequest : IRequest<ServiceTechsTable>
    {
        internal override XElement XML
        {
            get
            {
                return new XElement("ServiceTechsTableRequest", this.Dealer);
            }
        }
    }
}