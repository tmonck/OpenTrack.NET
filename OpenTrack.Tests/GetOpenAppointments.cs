using System;
using System.Linq;
using Xunit;

namespace OpenTrack.Tests
{
    public class GetOpenAppointments
    {
        [Fact]
        public void Test_Get_Appointments()
        {
            var api = Credentials.GetAPI();

            var result = api.FindAppointments(new Requests.AppointmentLookupRequest(Credentials.EnterpriseCode, Credentials.DealerNumber)
            {
                DateFrom = DateTime.Today.AddDays(-30),
                DateTo = DateTime.Today
            });

            Assert.True(result.Any());

            foreach (var appt in result)
            {
                Assert.False(String.IsNullOrWhiteSpace(appt.AppointmentNumber));
            }
        }
    }
}