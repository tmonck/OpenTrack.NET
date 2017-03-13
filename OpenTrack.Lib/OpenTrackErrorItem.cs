namespace OpenTrack
{
    public class OpenTrackErrorItem
    {
        /// <summary>
        /// The DealerTrack error code from the response.
        /// </summary>
        public string ErrorCode { get; private set; }

        /// <summary>
        /// The DealerTrack error message from the response.
        /// </summary>
        public string ErrorMessage { get; private set; }

        public OpenTrackErrorItem(string errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }
    }
}