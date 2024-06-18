using MambuConnector.Models;
using MambuConnector.Models.Search;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MambuConnector.Interfaces.Repositories
{
    /// <summary>
    /// Define deposit transactions repository.
    /// </summary>
    public interface IDepositTransactionsRepository
    {
        /// <summary>
        /// Get all transactions for a deposit account.
        /// </summary>
        /// <param name="depositAccountId">The ID or encoded key of the deposit account.</param>
        /// <param name="parameters">Request parameters.</param>
        /// <returns>Collection of transaction related to a deposit account.</returns>
        Task<MambuResponse> GetAll(string depositAccountId, Dictionary<string, string> parameters);
        /// <summary>
        /// Get all transactions for a deposit account.
        /// </summary>
        /// <param name="depositAccountId">The ID or encoded key of the deposit account.</param>
        /// <returns>Collection of transaction related to a deposit account.</returns>
        Task<MambuResponse> GetAll(string depositAccountId);
        /// <summary>
        /// Search transactions for a deposit account.
        /// </summary>
        /// <param name="searchCriteria">Search criteria.</param>
        /// <param name="parameters">Request parameters.</param>
        /// <returns>Collection of deposit transactions.</returns>
        Task<MambuResponse> Search(SearchCriteria searchCriteria, Dictionary<string, string> parameters);
        /// <summary>
        /// Search transactions for a deposit account.
        /// </summary>
        /// <param name="searchCriteria">Search criteria.</param>
        /// <returns>Collection of deposit transactions.</returns>
        Task<MambuResponse> Search(SearchCriteria searchCriteria);
    }
}
