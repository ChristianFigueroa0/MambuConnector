using System;

namespace MambuConnector.Models
{
    /// <summary>
    /// Mambu MambuResponse.
    /// </summary>
    public class MambuResponse
    {
        /// <summary>
        /// Response data.
        /// </summary>
        public string Data { get; }
        /// <summary>
        /// Define if request was success.
        /// </summary>
        public bool Success { get; }
        /// <summary>
        /// Status code of MambuResponse.
        /// </summary>
        public int StatusCode { get; }
        /// <summary>
        /// Unhandled exception.
        /// </summary>
        public Exception Exception { get; }
        /// <summary>
        /// Error MambuResponse.
        /// </summary>
        public MambuErrorMambuResponse MambuErrorMambuResponse { get; }
        /// <summary>
        /// Constructor with mambu error.
        /// </summary>
        /// <param name="errorMambuResponse">Error MambuResponse.</param>
        /// <param name="statusCode">Received status code.</param>
        public MambuResponse(MambuErrorMambuResponse errorMambuResponse, int statusCode)
        {
            MambuErrorMambuResponse = errorMambuResponse;
            StatusCode = statusCode;
            Success = false;
        }
        /// <summary>
        /// Constructor with data.
        /// </summary>
        /// <param name="data">Data MambuResponse.</param>
        /// <param name="statusCode">Received status code.</param>
        public MambuResponse(string data, int statusCode)
        {
            Data = data;
            StatusCode = statusCode;
            Success = true;
        }
        /// <summary>
        /// Constructor with exception.
        /// </summary>
        /// <param name="ex">Exception.</param>
        public MambuResponse(Exception ex)
        {
            Exception = ex;
            Success = false;
        }
    }
}
