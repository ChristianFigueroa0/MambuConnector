using MambuConnector.Models;
using MambuConnector.Models.Enums;
using MambuConnector.Models.Search;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MambuConnector.Interfaces.Repositories
{
    /// <summary>
    /// Define loan transactions repository.
    /// </summary>
    public interface ILoanTransactionsRepository
    {
        /// <summary>
        /// Get loan transaction by id.
        /// </summary>
        /// <param name="id">The ID or encoded key of the loan transaction.</param>
        /// <param name="detailsLevel">Details level.</param>
        /// <returns>Loan transaction data.</returns>
        Task<MambuResponse> GetById(string id, DetailsLevel detailsLevel);
        /// <summary>
        /// Get loan transaction by id.
        /// </summary>
        /// <param name="id">The ID or encoded key of the loan transaction.</param>
        /// <returns>Loan transaction data.</returns>
        Task<MambuResponse> GetById(string id);
        /// <summary>
        /// Get all transactions for a loan account.
        /// </summary>
        /// <param name="loanAccountId">The ID or encoded key of the loan account.</param>
        /// <param name="parameters">Request parameters.</param>
        /// <returns>Collection of transaction related to a loan account.</returns>
        Task<MambuResponse> GetAll(string loanAccountId, Dictionary<string, string> parameters);
        /// <summary>
        /// Get all transactions for a loan account.
        /// </summary>
        /// <param name="loanAccountId">The ID or encoded key of the loan account.</param>
        /// <returns>Collection of transaction related to a loan account.</returns>
        Task<MambuResponse> GetAll(string loanAccountId);
        /// <summary>
        /// Search transactions for a loan account.
        /// </summary>
        /// <param name="searchCriteria">Search criteria.</param>
        /// <param name="parameters">Request parameters.</param>
        /// <returns>Collection of loan transactions.</returns>
        Task<MambuResponse> Search(SearchCriteria searchCriteria, Dictionary<string, string> parameters);
        /// <summary>
        /// Search transactions for a loan account.
        /// </summary>
        /// <param name="searchCriteria">Search criteria.</param>
        /// <returns>Collection of loan transactions.</returns>
        Task<MambuResponse> Search(SearchCriteria searchCriteria);
        /// <summary>
        /// Make a disbursement on a loan.
        /// </summary>
        /// <param name="loanAccountId">The ID or encoded key of the loan account.</param>
        /// <param name="disbursementLoanTransactionInput">Input details for the disbursement transaction.</param>
        /// <returns>Loan transaction data.</returns>
        Task<MambuResponse> MakeDisbursement<T>(string loanAccountId, T disbursementLoanTransactionInput);
    }
}
