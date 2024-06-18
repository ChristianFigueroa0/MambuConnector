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
    /// Implementation of <see cref="ILoanAccountsRepository"/>.
    /// </summary>
    internal class LoanAccountsRepository : BaseRepository, ILoanAccountsRepository
    {
        /// <summary>
        /// Url to search loan accounts.
        /// </summary>
        private const string SearchUrl = "loans:search";
        /// <summary>
        /// Url to create a new loan account.
        /// </summary>
        private const string CreateUrl = "loans/";
        /// <summary>
        /// Url to patch loan account.
        /// </summary>
        private const string PatchUrl = "loans/{0}";
        /// <summary>
        /// Url to get loan account schedule.
        /// </summary>
        private const string GetScheduleUrl = "loans/{0}/schedule";
        /// <summary>
        /// Url to get loan account by id.
        /// </summary>
        private const string GetByIdUrl = "loans/{0}";
        /// <summary>
        /// Url to change state of a loan account.
        /// </summary>
        private const string ChangeStateUrl = "loans/{0}:changeState";
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="httpClientFactory">Factory to create http client instances.</param>
        /// <param name="logger">Injected logger.</param>
        public LoanAccountsRepository(IHttpClientFactory httpClientFactory, ILogger<LoanAccountsRepository> logger) : base(httpClientFactory, logger) { }
        /// <summary>
        /// Change loan account state.
        /// </summary>
        /// <param name="id">Loan account id or encoded key.</param>
        /// <param name="action">Action details for a deposit account.</param>
        /// <returns>Loan account.</returns>
        public async Task<MambuResponse> ChangeState<T>(string id, T action)
        {
            var uri = new Uri(string.Format(ChangeStateUrl, id), UriKind.Relative);
            return await SendRequest(uri, HttpMethod.Post, HttpStatusCode.OK, action);
        }
        /// <summary>
        /// Create a new loan account.
        /// </summary>
        /// <param name="loanAccount">Loan account data.</param>
        /// <returns>Created loan account.</returns>
        public async Task<MambuResponse> Create<T>(T loanAccount)
            => await SendRequest(new Uri(CreateUrl, UriKind.Relative), HttpMethod.Post, HttpStatusCode.Created, loanAccount);
        /// <summary>
        /// Get loan account by id.
        /// </summary>
        /// <param name="id">The ID or encoded key of the loan account.</param>
        /// <param name="detailsLevel">Details level.</param>
        /// <returns>Loan account data.</returns>
        public async Task<MambuResponse> GetById(string id, DetailsLevel detailsLevel)
        {
            var uri = QueryHelpers.AddQueryString(GetByIdUrl, "detailsLevel", detailsLevel.ToString());
            return await SendRequest(new Uri(string.Format(uri, id), UriKind.Relative), HttpMethod.Get, HttpStatusCode.OK);
        }
        /// <summary>
        /// Get loan account by id.
        /// </summary>
        /// <param name="id">The ID or encoded key of the loan account.</param>
        /// <returns>Loan account data.</returns>
        public async Task<MambuResponse> GetById(string id)
             => await GetById(id, DetailsLevel.BASIC);
        /// <summary>
        /// Get loan account schedule.
        /// </summary>
        /// <param name="id">The ID or encoded key of the loan account.</param>
        /// <param name="detailsLevel">Details level.</param>
        /// <returns>Loan account schedule.</returns>
        public async Task<MambuResponse> GetScheduleForLoanAccount(string id, DetailsLevel detailsLevel)
        {
            var uri = QueryHelpers.AddQueryString(GetScheduleUrl, "detailsLevel", detailsLevel.ToString());
            return await SendRequest(new Uri(string.Format(uri, id), UriKind.Relative), HttpMethod.Get, HttpStatusCode.OK);
        }
        /// <summary>
        /// Get loan account schedule.
        /// </summary>
        /// <param name="id">The ID or encoded key of the loan account.</param>
        /// <returns>Loan account schedule.</returns>
        public async Task<MambuResponse> GetScheduleForLoanAccount(string id)
            => await GetScheduleForLoanAccount(id, DetailsLevel.BASIC);
        /// <summary>
        /// Partially update loan account.
        /// </summary>
        /// <param name="id">The ID or encoded key of the loan account.</param>
        /// <param name="patchOperation">Patch operations to be applied to a resource.</param>
        /// <returns>Mambu MambuResponse.</returns>
        public async Task<MambuResponse> Patch<T>(string id, T patchOperation)
            => await SendRequest(new Uri(string.Format(PatchUrl, id), UriKind.Relative), HttpMethod.Patch, HttpStatusCode.NoContent, patchOperation);
        /// <summary>
        /// Search loan accounts.
        /// </summary>
        /// <param name="searchCriteria">Search criteria.</param>
        /// <param name="parameters">Request parameters.</param>
        /// <returns>Collection of loan accounts.</returns>
        public async Task<MambuResponse> Search(SearchCriteria searchCriteria, Dictionary<string, string> parameters)
        {
            var uri = Uri.EscapeDataString(SearchUrl);
            if (parameters != null && parameters.Any())
                uri = QueryHelpers.AddQueryString(uri, parameters);

            return await SendRequest(new Uri(uri, UriKind.Relative), HttpMethod.Post, HttpStatusCode.OK, searchCriteria);
        }
        /// <summary>
        /// Search loan accounts.
        /// </summary>
        /// <param name="searchCriteria">Search criteria.</param>
        /// <returns>Collection of loan accounts.</returns>
        public async Task<MambuResponse> Search(SearchCriteria searchCriteria)
            => await Search(searchCriteria, null);
    }
}