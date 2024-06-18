using MambuConnector.Interfaces.Repositories;
using MambuConnector.Models;
using MambuConnector.Models.Enums;
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
    /// Implementation of <see cref="IBranchesRepository"/>.
    /// </summary>
    internal class BranchesRepository : BaseRepository, IBranchesRepository
    {
        /// <summary>
        /// Url to get branch by id
        /// </summary>
        private const string GetByIdUrl = "branches/{0}";
        /// <summary>
        /// Url to get all branches
        /// </summary>
        private const string GetAllUrl = "branches/";
        /// <summary>
        /// Url to create a new branch
        /// </summary>
        private const string CreateUrl = "branches/";
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="httpClientFactory">Factory to create http client instances.</param>
        /// <param name="logger">Injected logger.</param>
        public BranchesRepository(IHttpClientFactory httpClientFactory, ILogger<BranchesRepository> logger) : base(httpClientFactory, logger) { }
        /// <summary>
        /// Create a new branch.
        /// </summary>
        /// <param name="branch">Branch data.</param>
        /// <returns>Created branch.</returns>
        public async Task<MambuResponse> Create<T>(T branch)
            => await SendRequest(new Uri(CreateUrl, UriKind.Relative), HttpMethod.Post, HttpStatusCode.Created, branch);
        /// <summary>
        /// Get all branches.
        /// </summary>
        /// <param name="parameters">Request parameters.</param>
        /// <returns>Collection of branches.</returns>
        public async Task<MambuResponse> GetAll(Dictionary<string, string> parameters)
        {
            var uri = GetAllUrl;
            if (parameters != null && parameters.Any())
                uri = QueryHelpers.AddQueryString(uri, parameters);

            return await SendRequest(new Uri(uri, UriKind.Relative), HttpMethod.Get, HttpStatusCode.OK);
        }
        /// <summary>
        /// Get all branches.
        /// </summary>
        /// <returns>Collection of branches.</returns>
        public async Task<MambuResponse> GetAll()
            => await GetAll(null);
        /// <summary>
        /// Get branch by id.
        /// </summary>
        /// <param name="id">Branch id or encoded key.</param>
        /// <param name="detailsLevel">Details level.</param>
        /// <returns>Branch data.</returns>
        public async Task<MambuResponse> GetById(string id)
            => await GetById(id, DetailsLevel.BASIC);
        /// <summary>
        /// Get branch by id.
        /// </summary>
        /// <param name="id">Branch id or encoded key.</param>
        /// <returns>Branch data.</returns>
        public async Task<MambuResponse> GetById(string id, DetailsLevel detailsLevel)
        {
            var uri = QueryHelpers.AddQueryString(GetByIdUrl, "detailsLevel", detailsLevel.ToString());
            return await SendRequest(new Uri(uri, UriKind.Relative), HttpMethod.Get, HttpStatusCode.OK);
        }
    }
}