using Swapi;
using Swapi.DataServices;
using Swapi.Mapper;
using Swapi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapi.BusinessLogic
{
    public class StarshipBusinessLogic
    {
        private readonly IStarshipMapper _starshipMapper;
        private readonly IStarshipDataService _starshipDataService;
        public StarshipBusinessLogic(IStarshipMapper starshipMapper, IStarshipDataService starshipDataService)
        {
            _starshipMapper = starshipMapper;
            _starshipDataService = starshipDataService;
        }

        public IEnumerable<Starship> GetAll()
        {
            var listStarshipsDtos = _starshipDataService.GetAll();
            return listStarshipsDtos.Select(s => _starshipMapper.mapTo(s));
        }

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
