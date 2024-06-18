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
    /// Implementation of <see cref="IDepositAccountsRepository"/>.
    /// </summary>
    internal class DepositAccountsRepository : BaseRepository, IDepositAccountsRepository
    {
        /// <summary>
        /// Url to create a new deposit account.
        /// </summary>
        private const string CreateUrl = "deposits/";
        /// <summary>
        /// Url to change state of a deposit account.
        /// </summary>
        private const string ChangeStateUrl = "deposits/{0}:changeState";
        /// <summary>
		/// Url to search deposit accounts.
		/// </summary>
		private const string SearchUrl = "deposits:search";
        /// <summary>
		/// Url to path a deposit account.
		/// </summary>
		private const string PatchUrl = "deposits/{0}";
        /// <summary>
        /// Url to get deposit account by id.
        /// </summary>
        private const string GetByIdUrl = "deposits/{0}";
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="httpClientFactory">Factory to create http client instances.</param>
        /// <param name="logger">Injected logger.</param>
        public DepositAccountsRepository(IHttpClientFactory httpClientFactory, ILogger<DepositAccountsRepository> logger) : base(httpClientFactory, logger) { }
        /// <summary>
        /// Change deposit account state.
        /// </summary>
        /// <param name="id">Deposit account id or encoded key.</param>
        /// <param name="action">Action details for a deposit account.</param>
        public async Task<MambuResponse> ChangeState<T>(string id, T action)
        {
            var uri = new Uri(string.Format(ChangeStateUrl, id), UriKind.Relative);
            return await SendRequest(uri, HttpMethod.Post, HttpStatusCode.OK, action);
        }
        /// <summary>
        /// Create a new deposit account.
        /// </summary>
        /// <param name="deposit">Deposit account data.</param>
        /// <returns>Created deposit account.</returns>
        public async Task<MambuResponse> Create<T>(T deposit)
            => await SendRequest(new Uri(CreateUrl, UriKind.Relative), HttpMethod.Post, HttpStatusCode.Created, deposit);
        /// <summary>
        /// Get deposit account.
        /// </summary>
        /// <param name="id">The ID or encoded key of the deposit account.</param>
        /// <returns>Deposit account data.</returns>
        public async Task<MambuResponse> GetById(string id)
            => await GetById(id, DetailsLevel.BASIC);
        /// <summary>
        /// Get deposit account.
        /// </summary>
        /// <param name="id">The ID or encoded key of the deposit account.</param>
        /// <param name="detailsLevel">Details level.</param>
        /// <returns>Deposit account data.</returns>
        public async Task<MambuResponse> GetById(string id, DetailsLevel detailsLevel)
        {
            var uri = QueryHelpers.AddQueryString(GetByIdUrl, "detailsLevel", detailsLevel.ToString());
            return await SendRequest(new Uri(string.Format(uri, id), UriKind.Relative), HttpMethod.Get, HttpStatusCode.OK);
        }
        /// <summary>
        /// Partially update deposit account.
        /// </summary>
        /// <param name="id">The ID or encoded key of the deposit account.</param>
        /// <param name="patchOperation">Patch operations to be applied to a resource.</param>
        /// <returns>Mambu MambuResponse.</returns>
        public async Task<MambuResponse> Patch<T>(string id, T patchOperation)
            => await SendRequest(new Uri(string.Format(PatchUrl, id), UriKind.Relative), HttpMethod.Patch, HttpStatusCode.NoContent, patchOperation);
        /// <summary>
        /// Search deposit accounts.
        /// </summary>
        /// <param name="searchCriteria">Search criteria.</param>
        /// <param name="parameters">Request parameters.</param>
        /// <returns>Collection of deposit accounts.</returns>
        public async Task<MambuResponse> Search(SearchCriteria searchCriteria, Dictionary<string, string> parameters)
        {
            var uri = Uri.EscapeDataString(SearchUrl);
            if (parameters != null && parameters.Any())
                uri = QueryHelpers.AddQueryString(uri, parameters);

            return await SendRequest(new Uri(uri, UriKind.Relative), HttpMethod.Post, HttpStatusCode.OK, searchCriteria);
        }
        /// <summary>
        /// Search deposit accounts.
        /// </summary>
        /// <param name="searchCriteria">Search criteria.</param>
        /// <returns>Collection of deposit accounts.</returns>
        public async Task<MambuResponse> Search(SearchCriteria searchCriteria)
            => await Search(searchCriteria, null);
    }
}
