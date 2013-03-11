﻿using System;
using System.Xml.Linq;

namespace OpenTrack.Requests
{
    public class ServiceTechsTableRequest : IRequest<ServiceTechsTable>
    {
        public ServiceTechsTableRequest(String EnterpriseCode, String DealerCode, String ServerName)
            : base(EnterpriseCode, DealerCode, ServerName)
        {
        }

        internal override XElement XML
        {
            get
            {
                return new XElement("ServiceTechsTableRequest", this.Dealer);
            }
        }
    }
}