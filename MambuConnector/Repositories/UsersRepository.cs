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
    /// Implementation of <see cref="IUsersRepository"/>.
    /// </summary>
    internal class UsersRepository : BaseRepository, IUsersRepository
    {
        /// <summary>
        /// Url to get user by id.
        /// </summary>
        private const string GetByIdUrl = "users/{0}";
        /// <summary>
        /// Url to get all users.
        /// </summary>
        private const string GetAllUrl = "users";
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="httpClientFactory">Factory to create http client instances.</param>
        /// <param name="logger">Injected logger.</param>
        public UsersRepository(IHttpClientFactory httpClientFactory, ILogger<UsersRepository> logger) : base(httpClientFactory, logger) { }
        /// <summary>
        /// Get all users.
        /// </summary>
        /// <param name="parameters">Request parameters.</param>
        /// <returns>Collection of users.</returns>
        public async Task<MambuResponse> GetAll(Dictionary<string, string> parameters)
        {
            var uri = GetAllUrl;
            if (parameters != null && parameters.Any())
                uri = QueryHelpers.AddQueryString(uri, parameters);

            return await SendRequest(new Uri(uri, UriKind.Relative), HttpMethod.Get, HttpStatusCode.OK);
        }
        /// <summary>
        /// Get all users.
        /// </summary>
        /// <returns>Collection of users.</returns>
        public async Task<MambuResponse> GetAll()
            => await GetAll(null);
        /// <summary>
        /// Get user by id.
        /// </summary>
        /// <param name="id">The ID or encoded key of the user.</param>
        /// <param name="detailsLevel">Details level.</param>
        /// <returns>User data.</returns>
        public async Task<MambuResponse> GetById(string id, DetailsLevel detailsLevel)
        {
            var uri = QueryHelpers.AddQueryString(GetByIdUrl, "detailsLevel", detailsLevel.ToString());
            return await SendRequest(new Uri(string.Format(uri, id), UriKind.Relative), HttpMethod.Get, HttpStatusCode.OK);
        }
        /// <summary>
        /// Get user by id.
        /// </summary>
        /// <param name="id">The ID or encoded key of the user.</param>
        /// <returns>User data.</returns>
        public async Task<MambuResponse> GetById(string id)
            => await GetById(id, DetailsLevel.BASIC);
    }
}
