using System.Net.Http;
using System.Threading.Tasks;

namespace Swapi.DataServices
{
    /// <summary>
    /// Interface IHttpClientHandler
    /// Wrapper class for HttpClass used for unit testing
    /// </summary>
    public interface IHttpClientHandler
    {
        /// <summary>
        /// Gets the url asynchronous.
        /// </summary>
        /// <param name="requestUri">The request URI.</param>
        /// <returns>Task&lt;HttpResponseMessage&gt;.</returns>
        Task<HttpResponseMessage> GetAsync(string requestUri);
    }
}