using MambuConnector.Interfaces.Repositories;
using MambuConnector.Models;
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
    /// Implementation of <see cref="ITransactionChannelsRepository"/>
    /// </summary>
    internal class TransactionChannelsRepository : BaseRepository, ITransactionChannelsRepository
    {
        /// <summary>
        /// Url to get transaction channel by id.
        /// </summary>
        private const string GetByIdUrl = "organization/transactionChannels/{0}";
        /// <summary>
        /// Url to get all transaction channels.
        /// </summary>
        private const string GetAllUrl = "organization/transactionChannels";
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="httpClientFactory">Factory to create http client instances.</param>
        /// <param name="logger">Injected logger.</param>
        public TransactionChannelsRepository(IHttpClientFactory httpClientFactory, ILogger<TransactionChannelsRepository> logger) : base(httpClientFactory, logger) { }
        /// <summary>
        /// Get all transaction channels.
        /// </summary>
        /// <param name="parameters">Request parameters.</param>
        /// <returns>Collection of transaction channels.</returns>
        public async Task<MambuResponse> GetAll(Dictionary<string, string> parameters)
        {
            var uri = GetAllUrl;
            if (parameters != null && parameters.Any())
                uri = QueryHelpers.AddQueryString(uri, parameters);
            return await SendRequest(new Uri(uri, UriKind.Relative), HttpMethod.Get, HttpStatusCode.OK);
        }
        /// <summary>
        /// Get all transaction channels.
        /// </summary>
        /// <returns>Collection of transaction channels.</returns>
        public async Task<MambuResponse> GetAll()
            => await GetAll(null);
        /// <summary>
        /// Get all transaction channels.
        /// </summary>
        /// <returns>Collection of transaction channels.</returns>
        public async Task<MambuResponse> GetById(string id)
            => await SendRequest(new Uri(string.Format(GetByIdUrl, id), UriKind.Relative), HttpMethod.Get, HttpStatusCode.OK);
    }
}
