using MambuConnector.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace MambuConnector.Models.Search
{
    /// <summary>
    /// Filter criteria.
    /// </summary>
    public class FilterCriteria
    {
        /// <summary>
        /// Field to search.
        /// </summary>
        [JsonProperty("field")]
        public string Field { get; set; }
        /// <summary>
        /// Filter operator.
        /// </summary>
        [JsonProperty("operator")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FilterOperator Operator { get; set; }
        /// <summary>
        /// The value to match the searching criteria.
        /// </summary>
        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }
        /// <summary>
        /// The second value to match the searching criteria, when the BETWEEN operator is used.
        /// </summary>
        [JsonProperty("secondValue", NullValueHandling = NullValueHandling.Ignore)]
        public string SecondValue { get; set; }
        /// <summary>
        /// List of values when the IN operator is used.
        /// </summary>
        [JsonProperty("values", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> Values { get; set; }
    }
}
