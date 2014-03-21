using System;
using Xunit;
using OpenTrack;
using OpenTrack.Requests;
using OpenTrack.Responses;


namespace OpenTrack.Tests
{
    public class AppointmentUpdate
    {
        // [Fact]
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

        [Fact]
        public void Test_Add_Appointment()
        {
            var api = Credentials.GetAPI();

            DateTime appointmentDate = DateTime.Today;
            var vin = "4S4BRBJC2C3210598";
            var customerKey = "1";

            // get the vehicle so we can update it if need be.
            var getVehicleResponse =
                api.GetVehicle(new VehicleLookupRequest(Credentials.EnterpriseCode,
                   Credentials.DealerNumber) { VIN = vin });
            var vehicle = DealerTrackMapper.MapVehicle(getVehicleResponse);

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
                
                ServiceWriterID = "999"
            });
        }
    }
}