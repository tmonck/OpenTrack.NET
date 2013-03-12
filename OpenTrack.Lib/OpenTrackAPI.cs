using OpenTrack.Definitions;
using OpenTrack.Requests;
using OpenTrack.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Xml;

namespace OpenTrack
{
    // Dev URL: https://opentrackqa.arkona.com
    // Test URL: https://opentrackcert.arkona.com/{serviceapi.asmx}
    // Production URL: https://aws.arkona.com/OpenTrack/serviceapi.asmx

    /// <summary>
    /// Basic implementation of the OpenTrack API interface that performs and processes the requests.
    /// </summary>
    public class OpenTrackAPI : IOpenTrackAPI
    {
        /// <summary>
        /// The Url of the web service end point
        /// </summary>
        public String Url { get; private set; }

        /// <summary>
        /// The username to authenticate with the web service.
        /// </summary>
        public String Username { get; private set; }

        /// <summary>
        /// The password to authenticate with the web service.
        /// </summary>
        public String Password { get; private set; }

        public OpenTrackAPI(String Url, String Username, String Password)
        {
            this.Url = Url;
            this.Username = Username;
            this.Password = Password;
        }

        public IEnumerable<OpenRepairOrderLookupResponseOpenRepairOrder> FindOpenRepairOrders(OpenRepairOrderLookup query)
        {
            return SubmitRequest<OpenRepairOrderLookupResponse>(query).Items;
        }

        public IEnumerable<ClosedRepairOrdersClosedRepairOrder> FindClosedRepairOrders(GetClosedRepairOrderRequest query)
        {
            return SubmitRequest<ClosedRepairOrders>(query).Items;
        }

        public IEnumerable<ServiceWritersTableServiceWriterRecord> GetServiceAdvisors(ServiceWritersTableRequest query)
        {
            return SubmitRequest<ServiceWritersTable>(query).Items;
        }

        public IEnumerable<ServiceTechsTableServiceTechRecord> GetTechnicians(ServiceTechsTableRequest query)
        {
            return SubmitRequest<ServiceTechsTable>(query).Items;
        }

        public IEnumerable<ServiceLaborOpcodesTableServiceLaborOpcodeRecord> GetOpcodes(ServiceLaborOpcodesTableRequest query)
        {
            return SubmitRequest<ServiceLaborOpcodesTable>(query).Items;
        }

        public GetClosedRepairOrderDetailResponseRepairOrdersRepairOrder GetRepairOrder(GetRepairOrderDetail query)
        {
            return SubmitRequest<GetClosedRepairOrderDetailResponse>(query).Items.First().RepairOrder.First();
        }

        public IEnumerable<PartsInventoryResponsePart> GetPartsInventory(PartsInventoryRequest query)
        {
            return SubmitRequest<PartsInventoryResponse>(query).Items;
        }

        public void AddRepairOrder(AddRepairOrderRequest query)
        {
            // TODO What to check on the response?

            var response = SubmitRequest<AddRepairOrderResponse>(query);
        }

        public void AddRepairOrderLines(AddRepairOrderLinesRequest query)
        {
            // TODO What to check on the response?

            var response = SubmitRequest<AddRepairOrderLinesResponse>(query);
        }

        public CustomerSearchResponse FindCustomers(CustomerSearchRequest query)
        {
            return SubmitRequest<CustomerSearchResponse>(query);
        }

        public CustomerLookupResponseCustomer GetCustomer(CustomerLookupRequest query)
        {
            return SubmitRequest<CustomerLookupResponse>(query).Items.Single();
        }

        public void AddCustomer(CustomerAddRequest query)
        {
            // TODO What to check on the response?

            var response = SubmitRequest<CustomerAddResponse>(query);
        }

        public void UpdateCustomer(CustomerUpdateRequest query)
        {
            // TODO What to check on the response?

            var response = SubmitRequest<CustomerUpdateResponse>(query);
        }

        public IEnumerable<VehicleInventoryResponseVehicle> GetVehicleInventory(VehicleInventoryRequest query)
        {
            return SubmitRequest<VehicleInventoryResponse>(query).Items;
        }

        public VehicleLookupResponseVehicle GetVehicle(VehicleLookupRequest query)
        {
            return SubmitRequest<VehicleLookupResponse>(query).Items.SingleOrDefault();
        }

        public IEnumerable<VehicleSearchResponseVehicleSearchResult> FindVehicles(VehicleSearchRequest query)
        {
            return SubmitRequest<VehicleSearchResponse>(query).Items;
        }

        public IEnumerable<AppointmentLookupResponseAppointment> FindAppointments(AppointmentLookupRequest query)
        {
            return SubmitRequest<AppointmentLookupResponse>(query).Items;
        }

        public void AddAppointment(AppointmentAddRequest query)
        {
            // TODO What to check on the response?

            var response = SubmitRequest<AppointmentAddResponse>(query);
        }

        public void UpdateAppointment(AppointmentUpdateRequest query)
        {
            // TODO What to check on the response?

            var response = SubmitRequest<AppointmentUpdateResponse>(query);
        }

        public void DeleteAppointment(AppointmentDeleteRequest query)
        {
            // TODO What to check on the response?

            var response = SubmitRequest<AppointmentDeleteResponse>(query);
        }

        /// <summary>
        /// Submit the prepared request to the OpenTrack API and get the response back for processing.
        /// </summary>
        /// <param name="request"></param>
        /// <remarks>
        /// Some of this is cribbed from http://www.starstandard.org/guidelines/Architecture/QuickStart2011v1/ch05s04.html#NETClient.
        /// Go ahead and read some of the STAR spec. It'll make you weep for humanity.
        /// </remarks>
        internal virtual T SubmitRequest<T>(IRequest<T> request)
        {
            // <soap:Envelope>
            //            <soap:Header>
            //                <wsse:Security>
            //                    <wsse:UsernameToken>
            //                        <wsse:Username>${USERNAME}</wsse:Username>
            //                        <wsse:Password>${PASSWORD}</wsse:Password>
            //                    </wsse:UsernameToken>
            //                </wsse:Security>
            //                <tran:PayloadManifest>
            //                    <tran:manifest contentID="Content0" namespaceURI="CrownDMSInterop" element="1" relatedID="1" version="1.0"/>
            //                </tran:PayloadManifest>
            //            </soap:Header>
            //            <soap:Body>
            //                <tran:ProcessMessage>
            //                    <tran:payload>
            //                        <tran:content id="Content0">
            //                          ${REQUEST_CONTENT}
            //                        </tran:content>
            //               </tran:payload>
            //        </tran:ProcessMessage>
            //    </soap:Body>
            // </soap:Envelope>

            if (String.IsNullOrWhiteSpace(request.DealerCode)) throw new ArgumentNullException("Invalid DealerCode provided.");

            if (String.IsNullOrWhiteSpace(request.EnterpriseCode)) throw new ArgumentNullException("Invalid EnterpriseCode provided.");

            if (String.IsNullOrEmpty(request.ServerName)) throw new ArgumentNullException("Invalid ServerName provided.");

            using (var svc = GetService())
            {
                var xml = new XmlDocument();

                // Load up the request XML into a document object.
                xml.LoadXml(request.XML);

                // Create a unique request identifier.
                var requestId = Guid.NewGuid().ToString();

                var element = xml.DocumentElement;

                // Create the message payload that will be processed.
                var payload = new Payload()
                {
                    content = new Content[]
                    {
                        new Content()
                        {
                            id = requestId,
                            Any = element
                        }
                    }
                };

                // Tell the web service how to interpret the XML we're sending along.
                var manifest = new PayloadManifest()
                {
                    manifest = new[]
                    {
                        new Manifest()
                        {
                            element = element.LocalName,
                            namespaceURI = element.NamespaceURI,
                            contentID = requestId
                        }
                    }
                };

                // Send the message and it'll load the response into the same object.
                svc.ProcessMessage(ref manifest, ref payload);

                // Take the element from the first content item of the response payload.
                var response = payload.content[0].Any;

                // Check for errors
                ErrorCheck(response);

                // In debug, let's write out all of the XML to files.
#if DEBUG
                using (var w = new StreamWriter(String.Format("{0}.xml", Guid.NewGuid())))
                {
                    w.Write(response.OuterXml);
                }
#endif

                // Process the request with the appropriate parser/handler.
                return request.ProcessResponse(response);
            }
        }

        internal virtual void ErrorCheck(XmlElement xml)
        {
            // TODO This could probably be done more efficiently?

            foreach (XmlNode child in xml.ChildNodes)
            {
                if ("Error" == child.Name)
                {
                    // <Error>
                    //      <Code>311</Code>  {{optional}}
                    //      <Message>Access validation error: Dealer has not granted access to Vendor.</Message>
                    // </Error>

                    String errorCode = "Unknown";
                    String message = child.InnerText;

                    foreach (XmlNode n in child.ChildNodes)
                    {
                        if (n.Name == "ErrorCode")
                        {
                            errorCode = n.InnerText;
                        }
                        else if (n.Name == "Message")
                        {
                            message = n.InnerText;
                        }
                    }

                    throw new OpenTrackException(errorCode, message);
                }
            }
        }

        /// <summary>
        /// Return a configured proxy reference to the web service.
        /// </summary>
        internal virtual Definitions.starTransportClient GetService()
        {
            var binding = new BasicHttpBinding();

            // We could be getting back a lot of data. Let's just try and get it all!
            binding.MaxReceivedMessageSize = int.MaxValue;

            // We need to send the credential along with the message.
            binding.Security.Mode = BasicHttpSecurityMode.TransportWithMessageCredential;

            // Create a client with the given endpoint.
            var client = new starTransportClient(binding, new EndpointAddress(this.Url));

            client.ClientCredentials.UserName.UserName = this.Username;
            client.ClientCredentials.UserName.Password = this.Password;

            return client;
        }
    }
}