using OpenTrack.Requests;
using OpenTrack.Responses;
using System;
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
        [Obsolete("This method is being phased out by DealerTrack")]
        IEnumerable<ClosedRepairOrderLookupResponseClosedRepairOrder> FindClosedRepairOrders(GetClosedRepairOrderRequest query);

        /// <summary>
        /// Returns a list of service advisors for the dealership.
        /// </summary>
        IEnumerable<ServiceWritersTableServiceWriterRecord> GetServiceAdvisors(ServiceWritersTableRequest query);

        /// <summary>
        /// Returns a list of technicians for the dealership.
        /// </summary>
        IEnumerable<ServiceTechsTableServiceTechRecord> GetTechnicians(ServiceTechsTableRequest query);

        /// <summary>
        ///  Get the parts inventory or a specific part in inventory from the DMS Parts Inventory database.
        /// </summary>
        IEnumerable<PartsInventoryResponsePart> GetPartsInventory(PartsInventoryRequest query);

        /// <summary>
        ///  Get the parts inventory or a specific part in inventory from the DMS Parts Inventory database.
        /// </summary>
        IEnumerable<PartsTransactionsResponseTransactions> GetPartsTransactions(PartsTransactionsRequest query);

        /// <summary>
        /// Add a new repair order to the DMS.
        /// </summary>
        AddRepairOrderResponse AddRepairOrder(AddRepairOrderRequest query);

        /// <summary>
        /// Add repair order lines to an existing repair order.
        /// </summary>
        AddRepairOrderLinesResponse AddRepairOrderLines(AddRepairOrderLinesRequest query);

        /// <summary>
        /// Find a list of customers matching the given criteria.
        /// </summary>
        CustomerSearchResponse FindCustomers(CustomerSearchRequest query);

        /// <summary>
        /// Find a single customer by number.
        /// </summary>
        CustomerLookupResponseCustomer GetCustomer(CustomerLookupRequest query);

        /// <summary>
        /// Add a new customer to the DMS. Must have DataToken property filled in from the customer search or lookup methods.
        /// </summary>
        CustomerAddResponse AddCustomer(CustomerAddRequest query);

        /// <summary>
        /// Update an existing customer in the DMS.
        /// </summary>
        CustomerUpdateResponse UpdateCustomer(CustomerUpdateRequest query);

        /// <summary>
        /// Return a list of vehicles in the DMS inventory.
        /// </summary>
        IEnumerable<VehicleInventoryResponseVehicle> GetVehicleInventory(VehicleInventoryRequest query);

        /// <summary>
        /// Return a single vehicle's information by VIN or Stock Number. Will return null if none were found.
        /// </summary>
        VehicleLookupResponseVehicle GetVehicle(VehicleLookupRequest query);

        /// <summary>
        /// Find vehicles matching given criteria in the DMS.
        /// </summary>
        IEnumerable<VehicleSearchResponseVehicleSearchResult> FindVehicles(VehicleSearchRequest query);

        /// <summary>
        /// Returns a list of appointments which match the given criteria in the DMS.
        /// </summary>
        IEnumerable<AppointmentLookupResponseAppointment> FindAppointments(AppointmentLookupRequest query);

        /// <summary>
        /// Add a new appointment to the DMS. Returns the created appointment number.
        /// </summary>
        AppointmentAddResponse AddAppointment(AppointmentAddRequest query);

        /// <summary>
        /// Update an existing appointment in the DMS.
        /// </summary>
        AppointmentUpdateResponse UpdateAppointment(AppointmentUpdateRequest query);

        /// <summary>
        /// Delete an existing appointment in the DMS.
        /// </summary>
        AppointmentDeleteResponse DeleteAppointment(AppointmentDeleteRequest query);

        /// <summary>
        /// Retrieves the list of parts manufacturers configured for a dealership
        /// </summary>
        IEnumerable<PartsManufacturersTablePartsManufacturer> GetPartManufacturers(PartsManufacturersTableRequest query);

        /// <summary>
        /// Retrieves a list of closed repair order headers for a given dealership and timeframe
        /// </summary>
        IEnumerable<References.ClosedRepairOrder> GetClosedRepairOrders(GetClosedRepairOrdersRequest request);

        /// <summary>
        /// Retrieve the details of a single clsoed repair order by number
        /// </summary>
        References.ClosedRepairOrder GetClosedRepairOrderDetails(GetClosedRepairOrderDetailsRequest request);
    }
}