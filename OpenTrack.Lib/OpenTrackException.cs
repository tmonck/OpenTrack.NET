using System;
using System.Runtime.Serialization;

namespace OpenTrack
{
    // 100 Authentication error: An error occured during security token authentication.
    // 101 Authentication error: The password provided by the SecurityTokenManager does not match the one on the incoming token.
    // 200: Process Message
    // 201 Process Message: Null value received for SoapContext.
    // 202 Process Message: The request is not signed with an acceptable signature.
    // 203 Process Message: Payload is missing or invalid.
    // 204 Process Message: Payload Content is missing or invalid.
    // 205 Process Message: Invalid request type.
    // 300 Access validation error.
    // 301 Access validation error: Server address is blank.
    // 302 Access validation error: Enterprise code is blank.
    // 303 Access validation error: Company number is blank.
    // 304 Access validation error: API user is blank.
    // 305 Access validation error: Vendor is not valid.
    // 306 Access validation error: Vendor is not active.
    // 307 Access validation error: Integration Code is not valid.
    // 308 Access validation error: Integration Code is not active.
    // 309 Access validation error: Vendor does not have access to Integration Code.
    // 310 Access validation error: Vendor access to Integration Code is not active.
    // 311 Access validation error: Dealer has not granted access to Vendor.
    // 312 Access validation error: Dealer access for Vendor has expired.
    // 313 Access validation error: Access to this API is not set up or is turned off.
    // 314 Access validation error: Dealer access start date is a future date.

    public class OpenTrackException : Exception, ISerializable
    {
        // http://stackoverflow.com/questions/4791823/what-are-industry-standard-best-practices-for-implementing-custom-exceptions-in

        public String ErrorCode { get; private set; }

        public String ErrorMessage { get; private set; }

        public OpenTrackException(String ErrorMessage)
            : base(ErrorMessage)
        {
            this.ErrorCode = "Unknown";
            this.ErrorMessage = ErrorMessage;
        }

        public OpenTrackException(String ErrorCode, String ErrorMessage)
            : base(String.Format("{0}: {1}", ErrorCode, ErrorMessage))
        {
            this.ErrorCode = ErrorCode;
            this.ErrorMessage = ErrorMessage;
        }
    }
}