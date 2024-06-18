using Newtonsoft.Json;

namespace MambuConnector.Models
{
    /// <summary>
    /// Mambu error.
    /// </summary>
    public class MambuError
    {
        /// <summary>
        /// Error code.
        /// </summary>
        [JsonProperty("errorCode")]
        public int ErrorCode { get; set; }
        /// <summary>
        /// Error reason.
        /// </summary>
        [JsonProperty("errorReason")]
        public string ErrorReason { get; set; }
        /// <summary>
        /// Error source.
        /// </summary>
        [JsonProperty("errorSource")]
        public string ErrorSource { get; set; }
    }
}
