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
    /// Implementation of <see cref="IDepositProductsRepository"/>
    /// </summary>
    internal class DepositProductsRepository : BaseRepository, IDepositProductsRepository
    {
        /// <summary>
        /// Url to get deposit product by id.
        /// </summary>
        private const string GetByIdUrl = "depositproducts/{0}";
        /// <summary>
        /// Url to get all deposit products.
        /// </summary>
        private const string GetAllUrl = "depositproducts/";
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="httpClientFactory">Factory to create http client instances.</param>
        /// <param name="logger">Injected logger.</param>
        public DepositProductsRepository(IHttpClientFactory httpClientFactory, ILogger<DepositProductsRepository> logger) : base(httpClientFactory, logger) { }
        /// <summary>
        /// Get all deposit products.
        /// </summary>
        /// <param name="parameters">Request parameters.</param>
        /// <returns>Collection of deposit products.</returns>
        public async Task<MambuResponse> GetAll(Dictionary<string, string> parameters)
        {
            var uri = GetAllUrl;
            if (parameters == null || parameters.Any())
                uri = QueryHelpers.AddQueryString(uri, parameters);

            return await SendRequest(new Uri(uri, UriKind.Relative), HttpMethod.Get, HttpStatusCode.OK);
        }
        /// <summary>
        /// Get all deposit products.
        /// </summary>
        /// <returns>Collection of deposit products.</returns>
        public async Task<MambuResponse> GetAll()
            => await GetAll(new Dictionary<string, string>() { { "detailsLevel", "FULL" } });
        /// <summary>
        /// Get deposit product.
        /// </summary>
        /// <param name="id">The ID or encoded key of the deposit product to be returned.</param>
        /// <returns>Deposit product data.</returns>
        public async Task<MambuResponse> GetById(string id)
             => await GetById(id, DetailsLevel.FULL);
        /// <summary>
        /// Get deposit product.
        /// </summary>
        /// <param name="id">The ID or encoded key of the deposit product to be returned.</param>
        /// <param name="detailsLevel">Details level.</param>
        /// <returns>Deposit product data.</returns>
        public async Task<MambuResponse> GetById(string id, DetailsLevel detailsLevel)
        {
            var uri = QueryHelpers.AddQueryString(GetByIdUrl, "detailsLevel", detailsLevel.ToString());
            return await SendRequest(new Uri(string.Format(uri, id), UriKind.Relative), HttpMethod.Get, HttpStatusCode.OK);
        }
    }
}
