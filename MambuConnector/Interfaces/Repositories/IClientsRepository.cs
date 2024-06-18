using MambuConnector.Models;
using MambuConnector.Models.Enums;
using MambuConnector.Models.Search;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MambuConnector.Interfaces.Repositories
{
    /// <summary>
    /// Define client repository.
    /// </summary>
    public interface IClientsRepository
    {
        /// <summary>
        /// Create a new client.
        /// </summary>
        /// <param name="client">Client data.</param>
        /// <returns>Created client.</returns>
        Task<MambuResponse> Create<T>(T client);
        /// <summary>
        /// Search clients.
        /// </summary>
        /// <param name="searchCriteria">Search criteria.</param>
        /// <param name="parameters">Request parameters.</param>
        /// <returns>Collection of clients.</returns>
        Task<MambuResponse> Search(SearchCriteria searchCriteria, Dictionary<string, string> parameters);
        /// <summary>
        /// Search clients.
        /// </summary>
        /// <param name="searchCriteria">Search criteria.</param>
        /// <returns>Collection of clients.</returns>
        Task<MambuResponse> Search(SearchCriteria searchCriteria);
        /// <summary>
        /// Get client by Id or Encoded key, defining detail level of the information.
        /// </summary>
        /// <param name="id">Client id or encoded key.</param>
        /// <param name="detailsLevel">Details level.</param>
        /// <returns>Client data.</returns>
        Task<MambuResponse> GetById(string id, DetailsLevel detailsLevel);
        /// <summary>
        /// Get client by id.
        /// </summary>
        /// <param name="id">Client id or encoded key.</param>
        /// <returns>Client data.</returns>
        Task<MambuResponse> GetById(string id);
    }
}
