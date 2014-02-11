using System.Xml.Linq;

namespace OpenTrack.Requests
{
    public class VehicleUpdateRequest : IRequest<OpenTrack.Responses.VehicleUpdateResponse>
    {
        public VehicleUpdateRequest(string EnterpriseCode, string CompanyNumber) : base(EnterpriseCode, CompanyNumber)
        {
        }

        public VehicleUpdateRequest(string EnterpriseCode, string CompanyNumber, string ServerName) : base(EnterpriseCode, CompanyNumber, ServerName)
        {
        }

        internal override XElement Elements
        {
            get { return new XElement("VehicleUpdate", this.Dealer, SerializeToXml<Vehicle>(this.Vehicle)); }
        }

        public Vehicle Vehicle { get; set; }
    }
}