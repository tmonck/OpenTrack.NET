﻿using System;
using System.Xml.Linq;

namespace OpenTrack.Requests
{
    public class ServiceWritersTableRequest : IRequest<OpenTrack.Responses.ServiceWritersTable>
    {
        public ServiceWritersTableRequest(String EnterpriseCode, String DealerCode)
            : base(EnterpriseCode, DealerCode)
        {
        }

        internal override XElement Elements
        {
            get
            {
                return new XElement("ServiceWritersTableRequest", this.Dealer);
            }
        }
    }
}