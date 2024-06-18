using MambuConnector.Models;
using MambuConnector.Models.Enums;
using MambuConnector.Models.Search;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MambuConnector.Interfaces.Repositories
{
    /// <summary>
    /// Define loan accounts repository
    /// </summary>
    public interface ILoanAccountsRepository
    {
        /// <summary>
        /// Search loan accounts.
        /// </summary>
        /// <param name="searchCriteria">Search criteria.</param>
        /// <param name="parameters">Request parameters.</param>
        /// <returns>Collection of loan accounts.</returns>
        Task<MambuResponse> Search(SearchCriteria searchCriteria, Dictionary<string, string> parameters);
        /// <summary>
        /// Search loan accounts.
        /// </summary>
        /// <param name="searchCriteria">Search criteria.</param>
        /// <returns>Collection of loan accounts.</returns>
        Task<MambuResponse> Search(SearchCriteria searchCriteria);
        /// <summary>
        /// Create a new loan account.
        /// </summary>
        /// <param name="loanAccount">Loan account data.</param>
        /// <returns>Created loan account.</returns>
        Task<MambuResponse> Create<T>(T loanAccount);
        /// <summary>
        /// Partially update loan account.
        /// </summary>
        /// <param name="id">The ID or encoded key of the loan account.</param>
        /// <param name="patchOperation">Patch operations to be applied to a resource.</param>
        /// <returns>Mambu MambuResponse.</returns>
        Task<MambuResponse> Patch<T>(string id, T patchOperation);
        /// <summary>
        /// Get loan account schedule.
        /// </summary>
        /// <param name="id">The ID or encoded key of the loan account.</param>
        /// <param name="detailsLevel">Details level.</param>
        /// <returns>Loan account schedule.</returns>
        Task<MambuResponse> GetScheduleForLoanAccount(string id, DetailsLevel detailsLevel);
        /// <summary>
        /// Get loan account schedule.
        /// </summary>
        /// <param name="id">The ID or encoded key of the loan account.</param>
        /// <returns>Loan account schedule.</returns>
        Task<MambuResponse> GetScheduleForLoanAccount(string id);
        /// <summary>
        /// Get loan account by id.
        /// </summary>
        /// <param name="id">The ID or encoded key of the loan account.</param>
        /// <param name="detailsLevel">Details level.</param>
        /// <returns>Loan account data.</returns>
        Task<MambuResponse> GetById(string id, DetailsLevel detailsLevel);
        /// <summary>
        /// Get loan account by id.
        /// </summary>
        /// <param name="id">The ID or encoded key of the loan account.</param>
        /// <returns>Loan account data.</returns>
        Task<MambuResponse> GetById(string id);
        /// <summary>
        /// Change loan account state.
        /// </summary>
        /// <param name="id">Loan account id or encoded key.</param>
        /// <param name="action">Action details for a deposit account.</param>
        /// <returns>Loan account.</returns>
        Task<MambuResponse> ChangeState<T>(string id, T action);
    }
}
