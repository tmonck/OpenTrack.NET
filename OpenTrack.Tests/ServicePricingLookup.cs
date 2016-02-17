using System.Collections.Generic;
using OpenTrack.ManualSoap.Requests;
using Xunit;

namespace OpenTrack.Tests
{
    public class ServicePricingLookup
    {
        [Fact]
        public void Verify_call_works()
        {
            // arrange
            var api = Credentials.GetAPI();
            var request = new ServicePricingLookupRequestBody
            {
                ServicePricingLookup = new ManualSoap.Requests.ServicePricingLookup
                {
                    Dealer = new Dealer
                    {
                        EnterpriseCode = Credentials.EnterpriseCode,
                        CompanyNumber = Credentials.DealerNumber
                    },
                    RequestInfo = new ServicePricingLookupRequestInfo
                    {
                        ServicePricingLookupLabors = new List<ServicePricingLookupLabor>
                        {
                            new ServicePricingLookupLabor
                            {
                                LaborOpCode = "LABOR2",
                                ServiceType = "BS",
                                PaymentMethod = "C",
                                Manufacturer = "GM",
                                LaborHours = 2
                            },
                            new ServicePricingLookupLabor
                            {
                                LaborOpCode = "LABORXXX",
                                ServiceType = "MR",
                                PaymentMethod = "C",
                                Manufacturer = "GM",
                                LaborHours = 2
                            }
                        }
                    }
                }
            };

            // act
            var response = api.ServicePricingLookup(request);

            // assert
            Assert.NotNull(response);
        }
    }
}