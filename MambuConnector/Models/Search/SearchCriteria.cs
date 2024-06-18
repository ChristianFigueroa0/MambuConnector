using Newtonsoft.Json;
using System.Collections.Generic;

namespace MambuConnector.Models.Search
{
    /// <summary>
    /// Search criteria.
    /// </summary>
    public class SearchCriteria
    {
        /// <summary>
        /// The list of filtering criteria.
        /// </summary>
        [JsonProperty("filterCriteria")]
        public IEnumerable<FilterCriteria> FilterCriteria { get; set; }
        /// <summary>
        /// The sorting criteria used for searching.
        /// </summary>
        [JsonProperty("sortingCriteria", NullValueHandling = NullValueHandling.Ignore)]
        public SortingCriteria SortingCriteria { get; set; }
    }
}
