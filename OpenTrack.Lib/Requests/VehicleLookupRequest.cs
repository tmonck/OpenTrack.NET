﻿using System;
using System.Xml.Linq;

namespace OpenTrack.Requests
{
    /// <summary>
    /// The VehicleLookup request is used to get a specific vehicle record from the DMS vehicle database or as part of the process for the VehicleUpdate request.
    /// The VehicleSearch request returns a list of truncated records from the DMS vehicle database with a VIN for each record.
    /// Use the VehicleLookup request with the VIN to obtain the entire vehicle record.
    /// </summary>
    public class VehicleLookupRequest : IRequest<OpenTrack.Responses.VehicleLookupResponse>
    {
        public VehicleLookupRequest(String EnterpriseCode, String DealerCode)
            : base(EnterpriseCode, DealerCode)
        {
        }

        public String VIN { get; set; }

        public String StockNumber { get; set; }

        internal override XElement Elements
        {
            get
            {
                return new XElement("VehicleLookup",
                    this.Dealer,
                    new XElement("VIN", this.VIN),
                    new XElement("StockNumber", this.StockNumber)
                    );
            }
        }
    }
}