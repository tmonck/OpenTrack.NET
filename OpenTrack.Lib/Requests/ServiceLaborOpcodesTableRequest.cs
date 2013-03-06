using System.Xml.Linq;

namespace OpenTrack.Requests
{
    public class ServiceLaborOpcodesTableRequest : IRequest<ServiceLaborOpcodesTable>
    {
        internal override XElement XML
        {
            get
            {
                return new XElement("ServiceLaborOpcodesTableRequest", this.Dealer);
            }
        }
    }
}