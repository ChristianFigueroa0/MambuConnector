using MambuConnector.Models;
using MambuConnector.Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MambuConnector.Interfaces.Repositories
{
    /// <summary>
    /// Define branches repository.
    /// </summary>
    public interface IBranchesRepository
    {
        /// <summary>
        /// Get all branches.
        /// </summary>
        /// <param name="parameters">Request parameters.</param>
        /// <returns>Collection of branches.</returns>
        Task<MambuResponse> GetAll(Dictionary<string, string> parameters);
        /// <summary>
        /// Get all branches.
        /// </summary>
        /// <returns>Collection of branches.</returns>
        Task<MambuResponse> GetAll();
        /// <summary>
        /// Get branch by id.
        /// </summary>
        /// <param name="id">Branch id or encoded key.</param>
        /// <returns>Branch data.</returns>
        Task<MambuResponse> GetById(string id);
        /// <summary>
        /// Get branch by id.
        /// </summary>
        /// <param name="id">Branch id or encoded key.</param>
        /// <param name="detailsLevel">Details level.</param>
        /// <returns>Branch data.</returns>
        Task<MambuResponse> GetById(string id, DetailsLevel detailsLevel);
        /// <summary>
        /// Create a new branch.
        /// </summary>
        /// <param name="branch">Branch data.</param>
        /// <returns>Created branch.</returns>
        Task<MambuResponse> Create<T>(T branch);
    }
}
