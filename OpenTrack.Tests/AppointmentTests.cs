using System;
using System.Collections.Generic;
using Xunit;
using OpenTrack;
using OpenTrack.Requests;
using OpenTrack.Responses;


namespace OpenTrack.Tests
{
    public class AppointmentTests
    {
        [Fact(Skip = "This should not be automated since it will actually update an appointment.")]
        public void Test_Update_Appointment()
        {
            var api = Credentials.GetAPI();

            api.UpdateAppointment(new Requests.AppointmentUpdateRequest(Credentials.EnterpriseCode, Credentials.DealerNumber)
            {
                AppointmentNumber = "338",
                AppointmentDateTime = new DateTime(2013, 5, 5, 12, 0, 0),
                ServiceWriterID = "DT"
            });
        }

        [Fact(Skip="This should not be automated since it will actually add an appointment.")]
        public void Test_Add_Appointment()
        {
            var api = Credentials.GetAPI();

            DateTime appointmentDate = DateTime.Today;
            var vin = "3GSCL53788S535015";
            var customerKey = "1037156";

            // get the vehicle so we can update it if need be.
            var getVehicleResponse =
                api.GetVehicle(new VehicleLookupRequest(Credentials.EnterpriseCode,
                   Credentials.DealerNumber) { VIN = vin });
            var vehicle = Mapper.MapVehicle(getVehicleResponse);

            // if the customer isn't the owner on the vehicle, update it.
            if (vehicle.CustomerKey != customerKey)
            {
                vehicle.CustomerKey = customerKey;
                try
                {
                    api.UpdateVehicle(
                        new VehicleUpdateRequest(Credentials.EnterpriseCode,
                            Credentials.DealerNumber) { Vehicle = vehicle });
                }
                catch (Exception ex)
                {                    
                    throw ex;
                }
            }
            api.AddAppointment(new Requests.AppointmentAddRequest(Credentials.EnterpriseCode, Credentials.DealerNumber)
            {
                AppointmentDateTime = new DateTime(appointmentDate.Year, appointmentDate.Month, appointmentDate.Day, 12, 0, 0),

                CustomerKey = customerKey, // need customer number
                CustomerName = "OpenTrack.NET Test", // need customer name: appointment.Customer.FirstName + " " + appointment.Customer.LastName,
                CustomerPhoneNumber = "555-123-4567",// need customer phone number:  appointment.Customer.HomePhone,
                OdometerIn = (new Random()).Next(100, 500000),
                VIN = vin,// need a VIN: Appointment.Vehicle.VIN,
                Details = new List<AppointmentAddRequest.AppointmentDetail>
                {
                    new AppointmentAddRequest.AppointmentDetail()
                    {
                    LaborOpCode = "*", // See ServiceLaborOpcodesTable, * for undefined
                    ServiceLineNumber = "1", // The line # this detail refers to, grouped together by this
                    SequenceNumber = "0",
                    LinePaymentMethod = "C",
                    LineType = "A", // A = Labor Op Code Line Desc
                    Comments = "This is a test line!", // Optional
                    ServiceType = "MR",
                    LaborHours = Convert.ToDecimal(".5")
                    }
                },
                
                ServiceWriterID = "999"
            });
        }
    }
}