using MambuConnector.Models;
using MambuConnector.Models.Enums;
using MambuConnector.Models.Search;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MambuConnector.Interfaces.Repositories
{
    /// <summary>
    /// Define groups repository.
    /// </summary>
    public interface IGroupsRepository
    {
        /// <summary>
        /// Get all groups.
        /// </summary>
        /// <param name="parameters">Request parameters.</param>
        /// <returns>Collection of groups.</returns>
        Task<MambuResponse> GetAll(Dictionary<string, string> parameters);
        /// <summary>
        /// Get all groups.
        /// </summary>
        /// <returns>Collection of groups.</returns>
        Task<MambuResponse> GetAll();
        /// <summary>
        /// Get group by id.
        /// </summary>
        /// <param name="id">The ID or encoded key of the group.</param>
        /// <param name="detailsLevel">Details level.</param>
        /// <returns>Group data.</returns>
        Task<MambuResponse> GetById(string id, DetailsLevel detailsLevel);
        /// <summary>
        /// Get group by id.
        /// </summary>
        /// <param name="id">The ID or encoded key of the group.</param>
        /// <returns>Group data.</returns>
        Task<MambuResponse> GetById(string id);
        /// <summary>
        /// Search groups.
        /// </summary>
        /// <param name="searchCriteria">Search criteria.</param>
        /// <param name="parameters">Request parameters.</param>
        /// <returns>Collection of groups.</returns>
        Task<MambuResponse> Search(SearchCriteria searchCriteria, Dictionary<string, string> parameters);
        /// <summary>
        /// Search groups.
        /// </summary>
        /// <param name="searchCriteria">Search criteria.</param>
        /// <returns>Collection of groups.</returns>
        Task<MambuResponse> Search(SearchCriteria searchCriteria);
    }
}
