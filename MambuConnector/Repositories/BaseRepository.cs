using MambuConnector.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MambuConnector.Repositories
{
    /// <summary>
    /// Base repository.
    /// </summary>
    internal class BaseRepository
    {
        /// <summary>
        /// Name of http client.
        /// </summary>
        private const string HttpClientName = "MAMBU";
        /// <summary>
        /// Factory of http clients.
        /// </summary>
        private readonly IHttpClientFactory _httpClientFactory;
        /// <summary>
        /// Logger.
        /// </summary>
        private readonly ILogger<BaseRepository> _logger;
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="httpClientFactory">Factory to create http client instances.</param>
        /// <param name="logger">Injected logger.</param>
        public BaseRepository(
            IHttpClientFactory httpClientFactory,
            ILogger<BaseRepository> logger)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        /// <summary>
        /// Send http request.
        /// </summary>
        /// <param name="url">URL to which the request will be send.</param>
        /// <param name="method">HTTP method used to send request.</param>
        /// <param name="successStatusCode">HTTP status code that indicates a successful MambuResponse.</param>
        /// <returns>Mambu MambuResponse.</returns>
        protected async Task<MambuResponse> SendRequest(Uri url, HttpMethod method, HttpStatusCode successStatusCode)
            => await SendRequest(url, method, successStatusCode, null);
        /// <summary>
        /// Send http request.
        /// </summary>
        /// <param name="url">URL to which the request will be send.</param>
        /// <param name="method">HTTP method used to send request.</param>
        /// <param name="successStatusCode">HTTP status code that indicates a successful MambuResponse.</param>
        /// <param name="body">Request content.</param>
        /// <returns>Mambu MambuResponse.</returns>
        protected async Task<MambuResponse> SendRequest(Uri url, HttpMethod method, HttpStatusCode successStatusCode, object body)
        {
            try
            {
                using var client = _httpClientFactory.CreateClient(HttpClientName);
                var requestMessage = new HttpRequestMessage(method, url);
                var bodyyyy = JsonConvert.SerializeObject(body);

                if (body != null)
                    requestMessage.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

                var MambuResponse = await client.SendAsync(requestMessage);
                var content = await MambuResponse.Content.ReadAsStringAsync();

                if (MambuResponse.StatusCode != successStatusCode)
                    return new MambuResponse(JsonConvert.DeserializeObject<MambuErrorMambuResponse>(content), (int)MambuResponse.StatusCode);

                return new MambuResponse(content, (int)MambuResponse.StatusCode);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, $"An error occurred in request: {url}.");
                return new MambuResponse(ex);
            }
        }
    }
}
