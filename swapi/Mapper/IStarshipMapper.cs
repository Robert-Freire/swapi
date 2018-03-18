using Swapi.DataServices.Model;
using Swapi.Model;

namespace Swapi.Mapper
{
    /// <summary>
    /// Interface IStarshipMapper
    ///  Responsible to map the starshipDTO (swapi format) at the internal format of starships of the application
    /// </summary>
    public interface IStarshipMapper
    {
        /// <summary>
        /// Maps to Starship from StarshipDTO.
        /// </summary>
        /// <param name="from">From.</param>
        /// <returns>Starship.</returns>
        Starship mapTo(StarshipDTO from);
    }
}