using System.Collections.Generic;
using Swapi.DataServices.Model;

namespace Swapi.DataServices
{
    /// <summary>
    /// Interface IDataServiceStarship
    /// Responsible of the communication with the Swapi API of starships
    /// </summary>
    public interface IStarshipDataService
    {
        /// <summary>
        /// Gets all the starships.
        /// </summary>
        /// <returns>IList&lt;StarshipDTO&gt;.</returns>
        IEnumerable<StarshipDTO> GetAll();
    }
}