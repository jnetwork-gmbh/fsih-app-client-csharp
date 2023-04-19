using System;
using System.Threading.Tasks;

namespace ch.jnetwork.fsih.api.client.client
{
    /// <summary>
    /// REST API Client Interface
    /// </summary>
    public interface IRestClient : IDisposable
    {
        T Get<T>(string url) where T : class;

        Task<T> GetAsync<T>(string url) where T : class;
    }
}