using MambuConnector.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MambuConnector.Models.Search
{
    /// <summary>
    /// Sorting criteria.
    /// </summary>
    public class SortingCriteria
    {
        /// <summary>
        /// Name of field to sorting.
        /// </summary>
        [JsonProperty("field")]
        public string Field { get; set; }
        /// <summary>
        /// Sorting order.
        /// </summary>
        [JsonProperty("order")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SortingOrder Order { get; set; }
    }
}
