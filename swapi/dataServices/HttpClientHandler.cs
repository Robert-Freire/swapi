using System.Net.Http;
using System.Threading.Tasks;

namespace Swapi.DataServices
{
    /// <summary>
    /// Class HttpClientHandler.
    /// Wrapper class for HttpClass used for unit testing
    /// </summary>
    /// <seealso cref="Swapi.DataServices.IHttpClientHandler" />
    public class HttpClientHandler : IHttpClientHandler
    {
        private readonly HttpClient client = new HttpClient();
        /// <summary>
        /// Gets the url asynchronous.
        /// </summary>
        /// <param name="requestUri">The request URI.</param>
        /// <returns>HttpResponseMessage.</returns>
        public Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            return client.GetAsync(requestUri);
        }
    }
}
