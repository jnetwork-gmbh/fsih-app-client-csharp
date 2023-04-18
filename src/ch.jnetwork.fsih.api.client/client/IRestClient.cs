using System;
using System.Threading.Tasks;

namespace ch.jnetwork.fsih.api.client.client
{
    /// <summary>
    /// REST API Client Interface
    /// </summary>
    public interface IRestClient : IDisposable
    {
        Task<T> Get<T>(string url) where T : class;
    }
}