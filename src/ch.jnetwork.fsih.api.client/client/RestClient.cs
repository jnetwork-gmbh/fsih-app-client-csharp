using ch.jnetwork.fsih.api.dto;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace ch.jnetwork.fsih.api.client.client
{
    /// <summary>
    /// HTTP Client to get data from FSIH App API
    /// </summary>
    internal sealed class RestClient : IRestClient, IDisposable
    {
        /// <summary>
        /// Base URI of API
        /// </summary>
        private const string BASEURL = "https://inline-hockey.ch";

        /// <summary>
        /// HTTP Client to Access the API
        /// </summary>
        private readonly HttpClient client;

        /// <summary>
        /// Constructor
        /// </summary>
        public RestClient()
        {
            client = new HttpClient();

            client.BaseAddress = new Uri(BASEURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Dispose the HTTP Client
        /// </summary>
        public void Dispose()
        {
            client.Dispose();
        }

        /// <summary>
        /// Receive json from API and convert it to Object
        /// </summary>
        /// <typeparam name="T">Target of deserialization</typeparam>
        /// <param name="url">API URL</param>
        /// <returns>Task with deserialized data</returns>
        public async Task<T> Get<T>(string url) where T : class
        {
            using (var response = await client.GetAsync(url))
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();

                var deserializedData = await JsonSerializer.DeserializeAsync<T>(apiResponse);
                return deserializedData;
            }
        }
    }
}