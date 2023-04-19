using System;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace ch.jnetwork.fsih.api.client.client
{
    /// <summary>
    /// HTTP Client to get data from FSIH App API
    /// </summary>
    internal sealed class RestClient : IRestClient
    {
        /// <summary>
        /// Base URI of API
        /// </summary>
        private const string BASEURL = "http://inline-hockey.ch";

        /// <summary>
        /// HTTP Client to Access the API
        /// </summary>
        private readonly WebClient client;

        /// <summary>
        /// Constructor
        /// </summary>
        public RestClient()
        {
            client = new WebClient
            {
                BaseAddress = BASEURL
            };

            client.Headers.Add("Accept", "application/json");
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
        public async Task<T> GetAsync<T>(string url) where T : class
        {
            var response = await client.DownloadDataTaskAsync(new Uri(new Uri(client.BaseAddress), url));
            using (MemoryStream responseStream = new MemoryStream(response))
            {
                var deserializedData = await JsonSerializer.DeserializeAsync<T>(responseStream);
                return deserializedData;
            }
        }

        /// <summary>
        /// Receive json from API and convert it to Object
        /// </summary>
        /// <typeparam name="T">Target of deserialization</typeparam>
        /// <param name="url">API URL</param>
        /// <returns>Task with deserialized data</returns>
        public T Get<T>(string url) where T : class
        {
            var response = client.DownloadData(new Uri(new Uri(client.BaseAddress), url));
            using (MemoryStream responseStream = new MemoryStream(response))
            {
                var deserializedData = JsonSerializer.Deserialize<T>(responseStream);
                return deserializedData;
            }
        }
    }
}