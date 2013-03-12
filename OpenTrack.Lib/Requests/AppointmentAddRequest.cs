using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace OpenTrack.Requests
{
    public class AppointmentAddRequest : IRequest<OpenTrack.Responses.AppointmentAddResponse>
    {
        public AppointmentAddRequest(String EnterpriseCode, String DealerCode, String ServerName)
            : base(EnterpriseCode, DealerCode, ServerName)
        {
        }

        public RepairOrder RO { get; set; }

        internal override XElement Elements
        {
            get
            {
                return new XElement("AppointmentAdd",
                    this.Dealer,
                    SerializeToXml<RepairOrder>(this.RO)
                    );
            }
        }
    }

    public class AppointmentUpdateRequest : IRequest<OpenTrack.Responses.AppointmentUpdateResponse>
    {
        public AppointmentUpdateRequest(String EnterpriseCode, String DealerCode, String ServerName)
            : base(EnterpriseCode, DealerCode, ServerName)
        {
        }

        public RepairOrder RO { get; set; }

        internal override XElement Elements
        {
            get
            {
                return new XElement("AppointmentUpdate",
                    this.Dealer,
                    SerializeToXml<RepairOrder>(this.RO)
                    );
            }
        }
    }

    public class AppointmentDeleteRequest : IRequest<OpenTrack.Responses.AppointmentDeleteResponse>
    {
        public AppointmentDeleteRequest(String EnterpriseCode, String DealerCode, String ServerName)
            : base(EnterpriseCode, DealerCode, ServerName)
        {
        }

        public String AppointmentNumber { get; set; }

        internal override XElement Elements
        {
            get
            {
                return new XElement("AppointmentDelete",
                    this.Dealer,
                    new XElement("AppointmentNumber", this.AppointmentNumber)
                    );
            }
        }
    }
}