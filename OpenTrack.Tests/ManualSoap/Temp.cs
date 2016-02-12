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

        [Fact]
        public void PartAdd()
        {
            var createTime = DateTime.UtcNow;
            var contentId = Guid.NewGuid().ToString();
            var env = new Envelope<StarRequestBody<PartAddContent>>
            {
                Header = new Header
                {
                    PayloadManifest = new PayloadManifest
                    {
                        Manifest = new Manifest
                        {
                            ContentId = contentId,
                            NamespaceUri = "",
                            Element = "PartAdd"
                        }
                    },
                    Security = new SecurityHeader
                    {
                        Timestamp = new Timestamp
                        {
                            Created = createTime.ToString("o"),
                            Expires = createTime.AddMinutes(5).ToString("o"),
                            Id = Guid.NewGuid().ToString()
                        },
                        UserNameToken = new UserNameToken
                        {
                            Id = Guid.NewGuid().ToString(),
                            UserName = Credentials.Username,
                            Password =
                                new Password
                                {
                                    Value = Credentials.Password,
                                    Type =
                                        "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText"
                                }
                        }
                    }
                },
                Body = new StarRequestBody<PartAddContent>
                {
                    ProcessMessage = new ProcessMessage<PartAddContent>
                    {
                        Payload = new Payload<PartAddContent>
                        {
                            Content = new PartAddContent
                            {
                                Id = contentId,
                                PartAdd = new PartAdd
                                {
                                    Dealer = new Dealer
                                    {
                                        EnterpriseCode = Credentials.EnterpriseCode,
                                        CompanyNumber = Credentials.DealerNumber
                                    },
                                    Part = new PartAddPart
                                    {
                                        Manufacturer = "GM",
                                        PartNumber = "9M905061",
                                        PartDescription = "SAMPLERPK (08800-BOPCKT)",
                                        StockingGroup = "200",
                                        Status = "A",
                                        BinLocation = "4",
                                        Cost = 600,
                                        Cps = "OTV"
                                    }
                                }
                            }
                        }
                    }
                }
            };

            var manualSoapClient = new ManualSoapClient();

            var response = manualSoapClient.ExecuteRequest<StarResponseBody<PartAddResponseContent>, StarRequestBody<PartAddContent>>(
                "https://otstaging.arkona.com/opentrack/WebService.asmx",
                "\"http://www.starstandards.org/webservices/2005/10/transport/operations/ProcessMessage\"", env);

            Assert.NotNull(response);
        }
    }
}