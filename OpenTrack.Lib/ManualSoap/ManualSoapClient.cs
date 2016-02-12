using System;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using OpenTrack.ManualSoap.Common;

namespace OpenTrack.ManualSoap
{
    public class ManualSoapClient : IManualSoapClient
    {
        private readonly Action<string> _onSendAction;
        private readonly Action<string> _onRecieveAction;
        private static readonly XmlSerializerNamespaces _xmlSerializerNamespaces;

        static ManualSoapClient()
        {
            _xmlSerializerNamespaces = new XmlSerializerNamespaces();
            _xmlSerializerNamespaces.Add("s", "http://www.w3.org/2003/05/soap-envelope");
            _xmlSerializerNamespaces.Add("o", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
            _xmlSerializerNamespaces.Add("u", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");
            _xmlSerializerNamespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            _xmlSerializerNamespaces.Add("xsd", "http://www.w3.org/2001/XMLSchema");
        }

        public ManualSoapClient()
        {
            
        }

        public ManualSoapClient(Action<string> onSendAction, Action<string> onRecieveAction)
        {
            _onSendAction = onSendAction;
            _onRecieveAction = onRecieveAction;
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
            using (var xmlWriter = XmlWriter.Create(requestStream, new XmlWriterSettings { OmitXmlDeclaration = true, Indent = false, Encoding = Encoding.UTF8}))
            {
                if (_onSendAction != null)
                {
                    using (var stringWriter = new StringWriter())
                    using (var xmlLogWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { OmitXmlDeclaration = true, Indent = true, Encoding = Encoding.UTF8}))
                    {
                        serializer.Serialize(xmlLogWriter, requestEnvelope, _xmlSerializerNamespaces);
                        var xmlString = stringWriter.ToString();
                        xmlString = xmlString.Replace(requestEnvelope.Header.Security.UserNameToken.Password.Value,
                            string.Empty);
                        _onSendAction(xmlString);
                    }
                }
                serializer.Serialize(xmlWriter, requestEnvelope, _xmlSerializerNamespaces);
                
            }

            var webResponse = webRequest.GetResponse();
            using (var responseStream = webResponse.GetResponseStream())
            {
                if (_onRecieveAction != null)
                {
                    using (var streamReader = new StreamReader(responseStream))
                    {
                        var streamString = streamReader.ReadToEnd();
                        _onRecieveAction(streamString);
                        using (var stringReader = new StringReader(streamString))
                        using (var xmlReader = XmlReader.Create(stringReader))
                        {
                            return Deserialize<TResponse>(xmlReader);
                        }
                    }
                }
                return Deserialize<TResponse>(responseStream);
            }
        }

        private static Envelope<TResponse> Deserialize<TResponse>(Stream stream)
        {
            var deserializer = new XmlSerializer(typeof(Envelope<TResponse>));

            return (Envelope<TResponse>)deserializer.Deserialize(stream);
        }

        private static Envelope<TResponse> Deserialize<TResponse>(XmlReader reader)
        {
            var deserializer = new XmlSerializer(typeof(Envelope<TResponse>));

            return (Envelope<TResponse>)deserializer.Deserialize(reader);
        } 
    }
}