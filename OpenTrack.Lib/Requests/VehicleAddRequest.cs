using System;
using System.Xml.Linq;

namespace OpenTrack.Requests
{
    public class VehicleAddRequest : IRequest<OpenTrack.Responses.VehicleAddResponse>
    {
        public VehicleAddRequest(string EnterpriseCode, string CompanyNumber) : base(EnterpriseCode, CompanyNumber)
        {
        }

        public VehicleAddRequest(string EnterpriseCode, string CompanyNumber, string ServerName) : base(EnterpriseCode, CompanyNumber, ServerName)
        {
        }

        internal override XElement Elements
        {
            get { throw new NotImplementedException(); }
        }
    }

}