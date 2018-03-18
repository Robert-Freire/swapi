using Microsoft.VisualStudio.TestTools.UnitTesting;
using Swapi.Configuration;
using Swapi.DataServices.Model;
using Swapi.Mapper;

namespace Swapi.UnitTest
{
    /// <summary>
    /// Class StarshipMapperUnitTest.
    /// </summary>
    [TestClass]
    public class StarshipMapperUnitTest
    {
        private StarshipMapper starshipMapperUT;
        /// <summary>
        /// Initializes this instance.
        /// </summary>

        [TestInitialize]
        public void Initialize()
        {
            starshipMapperUT = new StarshipMapper();
        }

        /// <summary>
        /// Mappers the starship map to when MGMT is not informed then no maps MGMT.
        /// </summary>
        [TestMethod]
        public void MapperStarship_MapTo_WhenMGMTIsNotInformed_ThenNoMapsMGMT()
        {
            //Arrange
            var starShipDto = new StarshipDTO()
            {
                Name = "Some name",
                MGLT = "unknow"
            };

            //Act
            var starship = starshipMapperUT.mapTo(starShipDto);

            //Assert
            Assert.AreEqual(starShipDto.Name, starship.Name);
            Assert.IsNull( starship.MGLT);

        }

        
        [TestMethod]
        public void MapperStarship_MapTo_WhenMGMTIsInformed_ThenMapsMGMT()
        {
            //Arrange
            var starShipDto = new StarshipDTO()
            {
                Name = "Some name",
                MGLT = "25"
            };

            //Act
            var starship = starshipMapperUT.mapTo(starShipDto);

            //Assert
            Assert.AreEqual(starShipDto.Name, starship.Name);
            Assert.AreEqual(starShipDto.MGLT, starship.MGLT.ToString());

        }

        [TestMethod]
        public void MapperStarship_MapTo_WhenConsumablesIsMothInformed_ThenMapsConsumables()
        {
            var numberConsumables = 2;
            //Arrange
            var starShipDto = new StarshipDTO()
            {
                Name = "Some name",
                Consumables = string.Format("{0} months", numberConsumables)
            };

            //Act
            var starship = starshipMapperUT.mapTo(starShipDto);

            //Assert
            Assert.AreEqual(numberConsumables * HoursForPeriod.Month, starship.ConsumablesHours);

        }

        [TestMethod]
        public void MapperStarship_MapTo_WhenConsumablesIsYearInformed_ThenMapsConsumables()
        {
            var numberConsumables = 1;
            //Arrange
            var starShipDto = new StarshipDTO()
            {
                Name = "Some name",
                Consumables = string.Format("{0} year", numberConsumables)
            };

            //Act
            var starship = starshipMapperUT.mapTo(starShipDto);

            //Assert
            Assert.AreEqual(numberConsumables * HoursForPeriod.Year, starship.ConsumablesHours);

        }

        [TestMethod]
        public void MapperStarship_MapTo_WhenConsumablesIsFaysInformed_ThenMapsConsumables()
        {
            var numberConsumables = 3;
            //Arrange
            var starShipDto = new StarshipDTO()
            {
                Name = "Some name",
                Consumables = string.Format("{0} days", numberConsumables)
            };

            //Act
            var starship = starshipMapperUT.mapTo(starShipDto);

            //Assert
            Assert.AreEqual(numberConsumables * HoursForPeriod.Day, starship.ConsumablesHours);

        }
    }
}
