using System;
using OpenTrack.ManualSoap;
using OpenTrack.ManualSoap.Common;
using OpenTrack.ManualSoap.Requests;
using OpenTrack.ManualSoap.Responses;
using Xunit;

namespace OpenTrack.Tests.ManualSoap
{
    public class Temp
    {
        [Fact]
        public void Test()
        {
            var createTime = DateTime.UtcNow;
            string contentId = Guid.NewGuid().ToString();
            var env = new Envelope<StarRequestBody<VehicleLookupContent>>
            {
                Header = new Header
                {
                    Security = new SecurityHeader
                    {
                        UserNameToken = new UserNameToken
                        {
                            UserName = Credentials.Username,
                            Password = new Password { Value = Credentials.Password, Type = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText" },
                            Id = string.Format("uuid-{0}-1", Guid.NewGuid())
                        },
                        Timestamp = new Timestamp
                        {
                            Created = createTime.ToString("o"),
                            Expires = createTime.AddMinutes(5).ToString("o"),
                            Id = "_0"
                        }
                    },
                    PayloadManifest = new PayloadManifest
                    {
                        Manifest = new Manifest
                        {
                            ContentId = contentId,
                            Element = "VehicleLookup",
                            NamespaceUri = ""
                        }
                    }
                },
                Body = new StarRequestBody<VehicleLookupContent>
                {
                    ProcessMessage = new ProcessMessage<VehicleLookupContent>
                    {
                        Payload = new Payload<VehicleLookupContent>
                        {
                            Content = new VehicleLookupContent
                            {
                                VehicleLookup = new OpenTrack.ManualSoap.Requests.VehicleLookup
                                {
                                    Dealer = new Dealer
                                    {
                                        CompanyNumber = "ZE7",
                                        EnterpriseCode = "ZE"
                                    },
                                    Vin = "2FMDK4KC8DBA52504"
                                },
                                Id = contentId
                            }
                        }
                    }
                }
            };

            var manualSoapClient = new ManualSoapClient();
            var response = manualSoapClient
                .ExecuteRequest<StarResponseBody<VehicleLookupResponseContent>, StarRequestBody<VehicleLookupContent>>
                ("https://otstaging.arkona.com/opentrack/WebService.asmx",
                    "\"http://www.starstandards.org/webservices/2005/10/transport/operations/ProcessMessage\"", env);

            Assert.NotNull(response);
            
        }
    }
}