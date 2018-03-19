using Swapi.DataServices;
using Swapi.Mapper;
using Swapi.Model;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// The BusinessLogic namespace.
/// Namespace where put the business logic of the application
/// </summary>
namespace Swapi.BusinessLogic
{
    /// <summary>
    /// Class StarshipBusinessLogic.
    /// Class responsible of the Business logic of starships
    /// </summary>
    public class StarshipBusinessLogic
    {
        private readonly IStarshipMapper _starshipMapper;
        private readonly IStarshipDataService _starshipDataService;
        /// <summary>
        /// Initializes a new instance of the <see cref="StarshipBusinessLogic"/> class.
        /// </summary>
        /// <param name="starshipMapper">The starship mapper.</param>
        /// <param name="starshipDataService">The starship data service.</param>
        public StarshipBusinessLogic(IStarshipMapper starshipMapper, IStarshipDataService starshipDataService)
        {
            _starshipMapper = starshipMapper;
            _starshipDataService = starshipDataService;
        }

        /// <summary>
        /// Gets all the starships
        /// </summary>
        /// <returns>IEnumerable&lt;Starship&gt;.</returns>
        public IEnumerable<Starship> GetAll()
        {
            var listStarshipsDtos = _starshipDataService.GetAll();
            return listStarshipsDtos.Select(s => _starshipMapper.mapTo(s));
        }

        /// <summary>
        /// Gets the number of jumps needed to travel a distance
        /// </summary>
        /// <param name="starship">The starship.</param>
        /// <param name="distance">The distance.</param>
        /// <returns>System.Nullable&lt;System.Int32&gt;.</returns>
        public int? GetNumberOfJumps(Starship starship, int distance)
        {
            if (starship.DistanceWithoutStop != null)
            {
                return (int) Math.Ceiling((double) (distance / (int) starship.DistanceWithoutStop));
            }

            return null;
        }
    }
}
