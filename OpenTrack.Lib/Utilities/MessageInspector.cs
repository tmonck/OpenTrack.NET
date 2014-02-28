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
        public string Path { get; set; }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.ClientMessageInspectors.Add(new RawMessageInspector { Path = this.Path });
        }

        private class RawMessageInspector : IClientMessageInspector
        {
            public string Path { get; set; }

            public void AfterReceiveReply(ref Message reply, object correlationState)
            {
                var fileName = string.Format("Response.{0}.xml", Guid.NewGuid());
                var filePath = string.IsNullOrWhiteSpace(this.Path) ? fileName : System.IO.Path.Combine(this.Path, fileName);

                using (var w = new StreamWriter(filePath))
                {
                    w.Write(reply.ToString());
                }
            }

            public object BeforeSendRequest(ref Message request, IClientChannel channel)
            {
                var fileName = string.Format("Request.{0}.xml", Guid.NewGuid());
                var filePath = string.IsNullOrWhiteSpace(this.Path) ? fileName : System.IO.Path.Combine(this.Path, fileName);

                using (var w = new StreamWriter(filePath))
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