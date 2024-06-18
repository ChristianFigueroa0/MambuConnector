using Newtonsoft.Json;
using System.Collections.Generic;

namespace MambuConnector.Models
{
    /// <summary>
    /// Mambu error MambuResponse.
    /// </summary>
    public class MambuErrorMambuResponse
    {
        /// <summary>
        /// Collection with errors.
        /// </summary>
        [JsonProperty("errors")]
        public IReadOnlyCollection<MambuError> Errors { get; set; }
    }
}
