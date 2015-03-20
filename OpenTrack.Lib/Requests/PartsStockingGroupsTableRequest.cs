using System.Xml.Linq;

namespace OpenTrack.Requests
{
    public class PartsStockingGroupsTableRequest : IRequest<Responses.PartsStockingGroupsTable>
    {
        public PartsStockingGroupsTableRequest(string enterpriseCode, string dealerCode) : base(enterpriseCode, dealerCode)
        {
        }


        internal override XElement Elements
        {
            get { return new XElement("PartsStockingGroupsTableRequest", this.Dealer); }
        }
    }
}