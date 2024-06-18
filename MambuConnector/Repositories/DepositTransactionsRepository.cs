using MambuConnector.Interfaces.Repositories;
using MambuConnector.Models;
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
    /// Implementation of <see cref="IDepositTransactionsRepository"/>.
    /// </summary>
    internal class DepositTransactionsRepository : BaseRepository, IDepositTransactionsRepository
    {
        /// <summary>
		/// Url to search deposit transactions.
		/// </summary>
		private const string SearchUrl = "deposits/transactions";
        /// <summary>
        /// Prefix of search url.
        /// </summary>
        private const string SearchPrefix = ":search";
        /// <summary>
        /// Url to get all transaction related to deposit account.
        /// </summary>
        private const string GetAllUrl = "deposits/{0}/transactions/";
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="httpClientFactory">Factory to create http client instances.</param>
        /// <param name="logger">Injected logger.</param>
        public DepositTransactionsRepository(IHttpClientFactory httpClientFactory, ILogger<DepositTransactionsRepository> logger) : base(httpClientFactory, logger) { }
        /// <summary>
        /// Get all transactions for a deposit account.
        /// </summary>
        /// <param name="depositAccountId">The ID or encoded key of the deposit account.</param>
        /// <param name="parameters">Request parameters.</param>
        /// <returns>Collection of transaction related to a deposit account.</returns>
        public async Task<MambuResponse> GetAll(string depositAccountId, Dictionary<string, string> parameters)
        {
            var uri = GetAllUrl;
            if (parameters != null && parameters.Any())
                uri = QueryHelpers.AddQueryString(uri, parameters);

            return await SendRequest(new Uri(string.Format(uri, depositAccountId), UriKind.Relative), HttpMethod.Get, HttpStatusCode.OK);
        }
        /// <summary>
        /// Get all transactions for a deposit account.
        /// </summary>
        /// <param name="depositAccountId">The ID or encoded key of the deposit account.</param>
        /// <returns>Collection of transaction related to a deposit account.</returns>
        public async Task<MambuResponse> GetAll(string depositAccountId)
            => await GetAll(depositAccountId, null);
        /// <summary>
        /// Search transactions for a deposit account.
        /// </summary>
        /// <param name="searchCriteria">Search criteria.</param>
        /// <param name="parameters">Request parameters.</param>
        /// <returns>Collection of deposit transactions.</returns>
        public async Task<MambuResponse> Search(SearchCriteria searchCriteria, Dictionary<string, string> parameters)
        {
            var uri = SearchUrl + Uri.EscapeDataString(SearchPrefix);
            if (parameters != null && parameters.Any())
                uri = QueryHelpers.AddQueryString(uri, parameters);
            return await SendRequest(new Uri(uri, UriKind.Relative), HttpMethod.Post, HttpStatusCode.OK, searchCriteria);
        }
        /// <summary>
        /// Search transactions for a deposit account.
        /// </summary>
        /// <param name="searchCriteria">Search criteria.</param>
        /// <returns>Collection of deposit transactions.</returns>
        public async Task<MambuResponse> Search(SearchCriteria searchCriteria)
             => await Search(searchCriteria, null);
    }
}
