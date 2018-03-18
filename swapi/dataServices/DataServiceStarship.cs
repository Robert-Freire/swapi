using Newtonsoft.Json;
using Swapi.DataServices;
using Swapi.DataServices.Model;
using Swapi.Model;
using Swapi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace Swapi.DataServices
{
    /// <summary>
    /// Class DataServiceStarship.
    /// Responsible of the communication with the Swapi API of starships
    /// </summary>
    public class StarshipDataService : IStarshipDataService
    {
       
        private readonly IAppConfigurationManager _appConfigurationManager;
        private readonly IHttpClientHandler _httpClientHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="StarshipDataService" /> class.
        /// </summary>
        /// <param name="httpClientHandler">The HTTP client handler.</param>
        /// <param name="appConfigurationManager">The application configuration manager.</param>
        public StarshipDataService(IHttpClientHandler httpClientHandler, IAppConfigurationManager appConfigurationManager)
        {
            _appConfigurationManager = appConfigurationManager;
            _httpClientHandler = httpClientHandler;
        }


        /// <summary>
        /// Gets all the starships.
        /// </summary>
        /// <returns>IList&lt;StarshipDTO&gt;.</returns>
        public IEnumerable<StarshipDTO> GetAll()
        {
            const string starshipsPage = "starships/";
            var nextPage = string.Format("{0}{1}", _appConfigurationManager.AppServer, starshipsPage);
            var listStarships = new List<StarshipDTO>();
            do
            {
                var result = Get(nextPage);
                listStarships = listStarships.Concat(result.Results).ToList();
                nextPage = result.Next;

            } while (!String.IsNullOrEmpty(nextPage));

            return listStarships;
        }
        /// <summary>
        /// Gets a page of the list of starships
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns>A page result with a list of starships</returns>
        private PageResult<StarshipDTO> Get(string page)
        {
            PageResult<StarshipDTO> model = null;
            var task = _httpClientHandler.GetAsync(page)
                                .ContinueWith((taskResponse) =>
           {
               var a = taskResponse.Result;
               var response = a.Content.ReadAsStringAsync();
               response.Wait();
               model = JsonConvert.DeserializeObject<PageResult<StarshipDTO>>(response.Result);
           });
            task.Wait();
            return model;
         }
    }
}
