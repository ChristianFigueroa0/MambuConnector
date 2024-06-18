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
    /// Implementation of <see cref="ILoanProductsRepository"/>
    /// </summary>
    internal class LoanProductsRepository : BaseRepository, ILoanProductsRepository
    {
        /// <summary>
        /// Url to get loan product by id.
        /// </summary>
        private const string GetByIdUrl = "loanproducts/{0}";
        /// <summary>
        /// Url to get all loan products.
        /// </summary>
        private const string GetAllUrl = "loanproducts/";
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="httpClientFactory">Factory to create http client instances.</param>
        /// <param name="logger">Injected logger.</param>
        public LoanProductsRepository(IHttpClientFactory httpClientFactory, ILogger<LoanProductsRepository> logger) : base(httpClientFactory, logger) { }
        /// <summary>
        /// Get all loan products.
        /// </summary>
        /// <param name="parameters">Request parameters.</param>
        /// <returns>Collection of loan products.</returns>
        public async Task<MambuResponse> GetAll(Dictionary<string, string> parameters)
        {
            var uri = GetAllUrl;
            if (parameters != null && parameters.Any())
                uri = QueryHelpers.AddQueryString(uri, parameters);
            return await SendRequest(new Uri(uri, UriKind.Relative), HttpMethod.Get, HttpStatusCode.OK);
        }
        /// <summary>
        /// Get all loan products.
        /// </summary>
        /// <returns>Collection of loan products.</returns>
        public async Task<MambuResponse> GetAll()
            => await GetAll(null);
        /// <summary>
        /// Get loan product by id.
        /// </summary>
        /// <param name="id">The ID or encoded key of the loan product.</param>
        /// <param name="detailsLevel">Details level.</param>
        /// <returns>Loan product data.</returns>
        public async Task<MambuResponse> GetById(string id, DetailsLevel detailsLevel)
        {
            var uri = QueryHelpers.AddQueryString(GetByIdUrl, "detailsLevel", detailsLevel.ToString());
            return await SendRequest(new Uri(string.Format(uri, id), UriKind.Relative), HttpMethod.Get, HttpStatusCode.OK);
        }
        /// <summary>
        /// Get loan product by id.
        /// </summary>
        /// <param name="id">The ID or encoded key of the loan product.</param>
        /// <returns>Loan product data.</returns>
        public async Task<MambuResponse> GetById(string id)
            => await GetById(id, DetailsLevel.FULL);
    }
}
