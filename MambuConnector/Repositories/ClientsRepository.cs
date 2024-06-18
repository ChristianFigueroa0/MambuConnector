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
    /// Implementation of <see cref="IClientsRepository"/>
    /// </summary>
    internal class ClientsRepository : BaseRepository, IClientsRepository
    {
        /// <summary>
        /// Url to create a client
        /// </summary>
        private const string CreateUrl = "clients/";
        /// <summary>
        /// Url to search client
        /// </summary>
        private const string SearchUrl = "clients:search";
        /// <summary>
        /// Url to get a client by id
        /// </summary>
        private const string GetByIdUrl = "clients/{0}";
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="httpClientFactory">Factory to create http client instances.</param>
        /// <param name="logger">Injected logger.</param>
        public ClientsRepository(IHttpClientFactory httpClientFactory, ILogger<ClientsRepository> logger) : base(httpClientFactory, logger) { }
        /// <summary>
        /// Create a new client.
        /// </summary>
        /// <param name="client">Client data.</param>
        /// <returns>Created client.</returns>
        public async Task<MambuResponse> Create<T>(T client)
            => await SendRequest(new Uri(CreateUrl, UriKind.Relative), HttpMethod.Post, HttpStatusCode.Created, client);
        /// <summary>
        /// Search clients.
        /// </summary>
        /// <param name="searchCriteria">Search criteria.</param>
        /// <param name="parameters">Request parameters.</param>
        /// <returns>Collection of clients.</returns>
        public async Task<MambuResponse> Search(SearchCriteria searchCriteria, Dictionary<string, string> parameters)
        {
            var uri = Uri.EscapeDataString(SearchUrl);
            if (parameters != null && parameters.Any())
                uri = QueryHelpers.AddQueryString(uri, parameters);

            return await SendRequest(new Uri(uri, UriKind.Relative), HttpMethod.Post, HttpStatusCode.OK, searchCriteria);
        }
        /// <summary>
        /// Search clients.
        /// </summary>
        /// <param name="searchCriteria">Search criteria.</param>
        /// <returns>Collection of clients.</returns>
        public async Task<MambuResponse> Search(SearchCriteria searchCriteria)
             => await Search(searchCriteria, null);
        /// <summary>
        /// Get client by Id or Encoded key, defining detail level of the information.
        /// </summary>
        /// <param name="id">Client id or encoded key.</param>
        /// <param name="detailsLevel">Details level.</param>
        /// <returns>Client data.</returns>
        public async Task<MambuResponse> GetById(string id, DetailsLevel detailsLevel)
        {
            var uri = QueryHelpers.AddQueryString(GetByIdUrl, "detailsLevel", detailsLevel.ToString());
            return await SendRequest(new Uri(string.Format(uri, id), UriKind.Relative), HttpMethod.Get, HttpStatusCode.OK);
        }
        /// <summary>
        /// Get client by id.
        /// </summary>
        /// <param name="id">Client id or encoded key.</param>
        /// <returns>Client data.</returns>
        public async Task<MambuResponse> GetById(string id)
            => await GetById(id, DetailsLevel.BASIC);
    }
}
