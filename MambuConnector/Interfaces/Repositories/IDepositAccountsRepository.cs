using MambuConnector.Models;
using MambuConnector.Models.Enums;
using MambuConnector.Models.Search;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MambuConnector.Interfaces.Repositories
{
    /// <summary>
    /// Define deposit account repository.
    /// </summary>
    public interface IDepositAccountsRepository
    {
        /// <summary>
        /// Create a new deposit account.
        /// </summary>
        /// <param name="deposit">Deposit account data.</param>
        /// <returns>Created deposit account.</returns>
        Task<MambuResponse> Create<T>(T deposit);
        /// <summary>
        /// Change deposit account state.
        /// </summary>
        /// <param name="id">Deposit account id or encoded key.</param>
        /// <param name="action">Action details for a deposit account.</param>
        /// <returns>Deposit account.</returns>
        Task<MambuResponse> ChangeState<T>(string id, T action);
        /// <summary>
		/// Search deposit accounts.
		/// </summary>
        /// <param name="searchCriteria">Search criteria.</param>
		/// <param name="parameters">Request parameters.</param>
		/// <returns>Collection of deposit accounts.</returns>
        Task<MambuResponse> Search(SearchCriteria searchCriteria, Dictionary<string, string> parameters);
        /// <summary>
		/// Search deposit accounts.
		/// </summary>
        /// <param name="searchCriteria">Search criteria.</param>
		/// <returns>Collection of deposit accounts.</returns>
        Task<MambuResponse> Search(SearchCriteria searchCriteria);
        /// <summary>
        /// Partially update deposit account.
        /// </summary>
        /// <param name="id">The ID or encoded key of the deposit account.</param>
        /// <param name="patchOperation">Patch operations to be applied to a resource.</param>
        /// <returns>Mambu MambuResponse.</returns>
        Task<MambuResponse> Patch<T>(string id, T patchOperation);
        /// <summary>
        /// Get deposit account.
        /// </summary>
        /// <param name="id">The ID or encoded key of the deposit account.</param>
        /// <returns>Deposit account data.</returns>
        Task<MambuResponse> GetById(string id);
        /// <summary>
        /// Get deposit account.
        /// </summary>
        /// <param name="id">The ID or encoded key of the deposit account.</param>
        /// <param name="detailsLevel">Details level.</param>
        /// <returns>Deposit account data.</returns>
        Task<MambuResponse> GetById(string id, DetailsLevel detailsLevel);
    }
}
