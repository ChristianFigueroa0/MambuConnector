using MambuConnector.Interfaces.Repositories;
using MambuConnector.Models;
using MambuConnector.Models.Enums;
using MambuConnector.Models.Search;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MambuConnector.Repositories
{
    /// <summary>
    /// Implementation of <see cref="ILoanTransactionsRepository"/>.
    /// </summary>
    internal class LoanTransactionsRepository : BaseRepository, ILoanTransactionsRepository
    {
        /// <summary>
        /// Url to get loan transaction by id.
        /// </summary>
        private const string GetByIdUrl = "loans/transactions/{0}";
        /// <summary>
        /// Url to get all loans transaction related to a loan account.
        /// </summary>
        private const string GetAllUrl = "loans/{0}/transactions";
        /// <summary>
        /// Url to search loan transactions.
        /// </summary>
        private const string SearchUrl = "loans/transactions";
        /// <summary>
        /// Prefix of search url.
        /// </summary>
        private const string SearchPrefix = ":search";
        /// <summary>
        /// Url to make disbursement.
        /// </summary>
        private const string MakeDisbursementUrl = "loans/{0}/disbursement-transactions";
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="httpClientFactory">Factory to create http client instances.</param>
        /// <param name="logger">Injected logger.</param>
        public LoanTransactionsRepository(IHttpClientFactory httpClientFactory, ILogger<LoanTransactionsRepository> logger) : base(httpClientFactory, logger) { }
        /// <summary>
        /// Get all transactions for a loan account.
        /// </summary>
        /// <param name="loanAccountId">The ID or encoded key of the loan account.</param>
        /// <param name="parameters">Request parameters.</param>
        /// <returns>Collection of transaction related to a loan account.</returns>
        public async Task<MambuResponse> GetAll(string loanAccountId, Dictionary<string, string> parameters)
        {
            var uri = GetAllUrl;
            if (parameters != null && parameters.Any())
                uri = QueryHelpers.AddQueryString(uri, parameters);
            return await SendRequest(new Uri(string.Format(uri, loanAccountId), UriKind.Relative), HttpMethod.Get, HttpStatusCode.OK);
        }
        /// <summary>
        /// Get all transactions for a loan account.
        /// </summary>
        /// <param name="loanAccountId">The ID or encoded key of the loan account.</param>
        /// <returns>Collection of transaction related to a loan account.</returns>
        public async Task<MambuResponse> GetAll(string loanAccountId)
            => await GetAll(loanAccountId, null);
        /// <summary>
        /// Get loan transaction by id.
        /// </summary>
        /// <param name="id">The ID or encoded key of the loan transaction.</param>
        /// <param name="detailsLevel">Details level.</param>
        /// <returns>Loan transaction data.</returns>
        public async Task<MambuResponse> GetById(string id, DetailsLevel detailsLevel)
        {
            var uri = QueryHelpers.AddQueryString(GetByIdUrl, "detailsLevel", detailsLevel.ToString());
            return await SendRequest(new Uri(string.Format(uri, id), UriKind.Relative), HttpMethod.Get, HttpStatusCode.OK);
        }
        /// <summary>
        /// Get loan transaction by id.
        /// </summary>
        /// <param name="id">The ID or encoded key of the loan transaction.</param>
        /// <returns>Loan transaction data.</returns>
        public async Task<MambuResponse> GetById(string id)
             => await GetById(id, DetailsLevel.BASIC);
        /// <summary>
        /// Make a disbursement on a loan.
        /// </summary>
        /// <param name="loanAccountId">The ID or encoded key of the loan account.</param>
        /// <param name="disbursementLoanTransactionInput">Input details for the disbursement transaction.</param>
        /// <returns>Loan transaction data.</returns>
        public async Task<MambuResponse> MakeDisbursement<T>(string loanAccountId, T disbursementLoanTransactionInput)
             => await SendRequest(new Uri(string.Format(MakeDisbursementUrl, loanAccountId), UriKind.Relative), HttpMethod.Post, HttpStatusCode.Created, disbursementLoanTransactionInput);
        /// <summary>
        /// Search transactions for a loan account.
        /// </summary>
        /// <param name="searchCriteria">Search criteria.</param>
        /// <param name="parameters">Request parameters.</param>
        /// <returns>Collection of loan transactions.</returns>
        public async Task<MambuResponse> Search(SearchCriteria searchCriteria, Dictionary<string, string> parameters)
        {
            var uri = SearchUrl + Uri.EscapeDataString(SearchPrefix);
            if (parameters != null && parameters.Any())
                uri = QueryHelpers.AddQueryString(uri, parameters);

            return await SendRequest(new Uri(uri, UriKind.Relative), HttpMethod.Post, HttpStatusCode.OK, searchCriteria);
        }
        /// <summary>
        /// Search transactions for a loan account.
        /// </summary>
        /// <param name="searchCriteria">Search criteria.</param>
        /// <returns>Collection of loan transactions.</returns>
        public async Task<MambuResponse> Search(SearchCriteria searchCriteria)
            => await Search(searchCriteria, null);
    }
}
