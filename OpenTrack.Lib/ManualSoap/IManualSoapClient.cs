using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using OpenTrack.ManualSoap.Common;

namespace OpenTrack.ManualSoap
{
    public interface IManualSoapClient
    {
        Envelope<TResponse> ExecuteRequest<TResponse, TRequest>(string uri, string soapAction, Envelope<TRequest> requestEnvelope);
    }

    public class ManualSoapClient : IManualSoapClient
    {
        private static XmlSerializerNamespaces xmlSerializerNamespaces;

        static ManualSoapClient()
        {
            xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add("s", "http://www.w3.org/2003/05/soap-envelope");
            xmlSerializerNamespaces.Add("o", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
            xmlSerializerNamespaces.Add("u", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");
            xmlSerializerNamespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xmlSerializerNamespaces.Add("xsd", "http://www.w3.org/2001/XMLSchema");
        }

        public Envelope<TResponse> ExecuteRequest<TResponse, TRequest>(string uri, string soapAction, Envelope<TRequest> requestEnvelope)
        {
            var serializer = new XmlSerializer(typeof (Envelope<TRequest>));

            var webRequest = HttpWebRequest.Create(uri);
            webRequest.Method = "POST";
            webRequest.ContentType = "text/xml; charset=utf-8";
            webRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
            webRequest.Headers.Add("SOAPAction", soapAction);

            using (var requestStream = webRequest.GetRequestStream())
            using (var xmlWriter = XmlWriter.Create(requestStream, new XmlWriterSettings { OmitXmlDeclaration = true, Indent = false }))
            {
                serializer.Serialize(xmlWriter, requestEnvelope, xmlSerializerNamespaces);

            }

            var webResponse = webRequest.GetResponse();
            using (var responseStream = webResponse.GetResponseStream())
            using (var streamReader = new StreamReader(responseStream))
            {
                var deserializer = new XmlSerializer(typeof (Envelope<TResponse>));
                return (Envelope<TResponse>)deserializer.Deserialize(streamReader);
            }
        }
    }
}