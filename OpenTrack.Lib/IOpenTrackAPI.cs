using OpenTrack.Requests;
using System.Collections.Generic;

namespace OpenTrack
{
    /// <summary>
    /// Provides an interface to interacting with the OpenTrack API
    /// </summary>
    public interface IOpenTrackAPI
    {
        IEnumerable<ServiceLaborOpcodesTableServiceLaborOpcodeRecord> GetOpcodes(ServiceLaborOpcodesTableRequest query);

        /// <summary>
        /// Returns a list of open repair orders matching the given query criteria.
        /// </summary>
        IEnumerable<OpenRepairOrderLookupResponseOpenRepairOrder> FindOpenRepairOrders(OpenRepairOrderLookup query);

        /// <summary>
        /// Returns a list of closed repair orders matching the given query criteria.
        /// </summary>
        IEnumerable<ClosedRepairOrdersClosedRepairOrder> FindClosedRepairOrders(GetClosedRepairOrderRequest query);

        /// <summary>
        /// Returns a list of service advisors for the dealership.
        /// </summary>
        IEnumerable<ServiceWritersTableServiceWriterRecord> GetServiceAdvisors(ServiceWritersTableRequest query);

        /// <summary>
        /// Returns a list of technicians for the dealership.
        /// </summary>
        IEnumerable<ServiceTechsTableServiceTechRecord> GetTechnicians(ServiceTechsTableRequest query);

        /// <summary>
        /// Get detailed information about an individual repair order.
        /// </summary>
        GetClosedRepairOrderDetailResponseRepairOrdersRepairOrder GetRepairOrder(GetRepairOrderDetail query);
    }
}