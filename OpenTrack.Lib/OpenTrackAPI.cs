using OpenTrack.Definitions;
using OpenTrack.Requests;
using System;
using System.Collections.Generic;
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
            CheckDealerInfo(query);

            var response = SubmitRequest<OpenRepairOrderLookupResponse>(query);

            // TODO Handle errors?

            return response.Items;
        }

        public IEnumerable<ClosedRepairOrderLookupResponseClosedRepairOrder> FindClosedRepairOrders(ClosedRepairOrderLookup query)
        {
            CheckDealerInfo(query);

            var response = SubmitRequest<ClosedRepairOrderLookupResponse>(query);

            // TODO Handle errors?

            return response.Items;
        }

        internal void CheckDealerInfo<T>(IRequest<T> request)
        {
            if (String.IsNullOrWhiteSpace(request.DealerCode)) throw new ArgumentNullException("Invalid DealerCode provided.");

            if (String.IsNullOrWhiteSpace(request.EnterpriseCode)) throw new ArgumentNullException("Invalid EnterpriseCode provided.");
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

            using (var svc = GetService())
            {
                var xml = new XmlDocument();

                // Load up the request XML into a document object.
                xml.LoadXml(request.XML.ToString());

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

                // Process the request with the appropriate parser/handler.
                return request.ProcessResponse(response);
            }
        }

        internal virtual void ErrorCheck(XmlElement xml)
        {
            foreach (XmlNode child in xml.ChildNodes)
            {
                // <Error>
                //      <Code>311</Code>
                //      <Message>Access validation error: Dealer has not granted access to Vendor.</Message>
                // </Error>

                if ("Error" == child.Name)
                {
                    // TODO Check error codes

                    throw new Exception(child.InnerXml);
                }
            }
        }

        /// <summary>
        /// Return a configured proxy reference to the web service.
        /// </summary>
        internal virtual Definitions.starTransportClient GetService()
        {
            var binding = new BasicHttpBinding();

            binding.Security.Mode = BasicHttpSecurityMode.TransportWithMessageCredential;

            var client = new starTransportClient(binding, new EndpointAddress(this.Url));

            client.ClientCredentials.UserName.UserName = this.Username;
            client.ClientCredentials.UserName.Password = this.Password;

            return client;
        }
    }
}