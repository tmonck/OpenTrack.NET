using System;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace OpenTrack.Utilities
{
    /// <summary>
    /// Behavior that can be added to the WCF client to getting request and response raw XML.
    /// </summary>
    internal class MessageInspectorBehavior : IEndpointBehavior
    {
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.ClientMessageInspectors.Add(new RawMessageInspector());
        }

        private class RawMessageInspector : IClientMessageInspector
        {
            private readonly int ID = new Random().Next();

            public void AfterReceiveReply(ref Message reply, object correlationState)
            {
                using (var w = new StreamWriter(String.Format("Response.{0}.xml", ID)))
                {
                    w.Write(reply.ToString());
                }
            }

            public object BeforeSendRequest(ref Message request, IClientChannel channel)
            {
                using (var w = new StreamWriter(String.Format("Request.{0}.xml", ID)))
                {
                    w.Write(request.ToString());
                }

                return null;
            }
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            // Nothing to do here.
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            // Nothing to do here.
        }

        public void Validate(ServiceEndpoint endpoint)
        {
            // Nothing to do here.
        }
    }
}