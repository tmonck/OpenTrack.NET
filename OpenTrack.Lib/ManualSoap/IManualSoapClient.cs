using OpenTrack.ManualSoap.Common;

namespace OpenTrack.ManualSoap
{
    /// <summary>
    /// We had to start generating SOAP requests manually because the WSDL file for opentrack has issues.
    /// Basically if we update the auto generated web client, all calls no longer work.  When they have that issue resovled,
    /// we may want to consider moving away from this.
    /// </summary>
    public interface IManualSoapClient
    {
        /// <summary>
        /// This executes SOAP requests manually based on the type.  It will serialize the xml in the request and response objects.
        /// </summary>
        Envelope<TResponse> ExecuteRequest<TResponse, TRequest>(string uri, string soapAction, Envelope<TRequest> requestEnvelope);
    }
}