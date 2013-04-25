using System;
using Xunit;

namespace OpenTrack.Tests
{
    public class AppointmentUpdate
    {
        // [Fact]
        public void Test_Update_Appointment()
        {
            var api = Credentials.GetAPI();

            api.UpdateAppointment(new Requests.AppointmentUpdateRequest(Credentials.EnterpriseCode, Credentials.DealerCode, Credentials.ServerName)
            {
                AppointmentNumber = "338",
                AppointmentDateTime = new DateTime(2013, 5, 5, 12, 0, 0),
                ServiceWriterID = "DT"
            });
        }
    }
}