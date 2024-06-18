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
    /// Implementation of <see cref="IGroupsRepository"/>.
    /// </summary>
    internal class GroupsRepository : BaseRepository, IGroupsRepository
    {
        /// <summary>
        /// Url to get group by id.
        /// </summary>
        private const string GetByIdUrl = "groups/{0}";
        /// <summary>
        /// Url to get all groups.
        /// </summary>
        private const string GetAllUrl = "groups";
        /// <summary>
		/// Url to search groups.
		/// </summary>
		private const string SearchUrl = "groups:search";
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="httpClientFactory">Factory to create http client instances.</param>
        /// <param name="logger">Injected logger.</param>
        public GroupsRepository(IHttpClientFactory httpClientFactory, ILogger<GroupsRepository> logger) : base(httpClientFactory, logger) { }
        /// <summary>
        /// Get all groups.
        /// </summary>
        /// <param name="parameters">Request parameters.</param>
        /// <returns>Collection of groups.</returns>
        public async Task<MambuResponse> GetAll(Dictionary<string, string> parameters)
        {
            var uri = GetAllUrl;
            if (parameters != null && parameters.Any())
                uri = QueryHelpers.AddQueryString(uri, parameters);

            return await SendRequest(new Uri(uri, UriKind.Relative), HttpMethod.Get, HttpStatusCode.OK);
        }
        /// <summary>
        /// Get all groups.
        /// </summary>
        /// <returns>Collection of groups.</returns>
        public async Task<MambuResponse> GetAll()
            => await GetAll(null);
        /// <summary>
        /// Get group by id.
        /// </summary>
        /// <param name="id">The ID or encoded key of the group.</param>
        /// <param name="detailsLevel">Details level.</param>
        /// <returns>Group data.</returns>
        public async Task<MambuResponse> GetById(string id, DetailsLevel detailsLevel)
        {
            var uri = QueryHelpers.AddQueryString(GetByIdUrl, "detailsLevel", detailsLevel.ToString());
            return await SendRequest(new Uri(string.Format(uri, id), UriKind.Relative), HttpMethod.Get, HttpStatusCode.OK);
        }
        /// <summary>
        /// Get group by id.
        /// </summary>
        /// <param name="id">The ID or encoded key of the group.</param>
        /// <returns>Group data.</returns>
        public async Task<MambuResponse> GetById(string id)
            => await GetById(id, DetailsLevel.BASIC);
        /// <summary>
        /// Search groups.
        /// </summary>
        /// <param name="searchCriteria">Search criteria.</param>
        /// <param name="parameters">Request parameters.</param>
        /// <returns>Collection of groups.</returns>
        public async Task<MambuResponse> Search(SearchCriteria searchCriteria, Dictionary<string, string> parameters)
        {
            var uri = Uri.EscapeDataString(SearchUrl);
            if (parameters != null && parameters.Any())
                uri = QueryHelpers.AddQueryString(uri, parameters);

            return await SendRequest(new Uri(uri, UriKind.Relative), HttpMethod.Post, HttpStatusCode.OK, searchCriteria);
        }
        /// <summary>
        /// Search groups.
        /// </summary>
        /// <param name="searchCriteria">Search criteria.</param>
        /// <returns>Collection of groups.</returns>
        public async Task<MambuResponse> Search(SearchCriteria searchCriteria)
             => await Search(searchCriteria, null);
    }
}
