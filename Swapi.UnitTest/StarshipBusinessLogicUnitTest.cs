using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Swapi.BusinessLogic;
using Swapi.Mapper;
using Moq;
using Swapi.DataServices;
using Swapi.DataServices.Model;
using Swapi.Model;
using System.Linq;
using System.Collections.Generic;

namespace Swapi.UnitTest
{
    /// <summary>
    /// Class StarshipBusinessLogicUnitTest.
    /// </summary>
    [TestClass]
    public class StarshipBusinessLogicUnitTest
    {
        StarshipBusinessLogic starshipBusinessLogicUT;
        Mock<IStarshipMapper> starshipMapper;
        Mock<IStarshipDataService> starshipDataService;


        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            starshipMapper = new Mock<IStarshipMapper>();
            starshipDataService = new Mock<IStarshipDataService>();
            starshipBusinessLogicUT = new StarshipBusinessLogic(starshipMapper.Object, starshipDataService.Object);
        }

        /// <summary>
        /// StarshipBusinessLogic getAll method when there are element they are converted.
        /// </summary>
        [TestMethod]
        public void StarshipBusinessLogic_GetAll_WhenThereAreElementTheyAreConverted()
        {
            // Arrange
            starshipMapper.Setup(m => m.mapTo(It.IsAny<StarshipDTO>())).Returns(new Starship(""));
            starshipDataService.Setup(d => d.GetAll()).Returns(new List<StarshipDTO>() { new StarshipDTO() });

            //Act
            var starships = starshipBusinessLogicUT.GetAll();

            // Assert
            Assert.AreEqual(1, starships.Count());

        }

        /// <summary>
        /// StarshipBusinessLogic numberOfJumps method when 1000000 MGL and a y-wing then 74 jumps.
        /// </summary>
        [TestMethod]
        public void StarshipBusinessLogic_NumberOfJumps_When1000000YWing_Then74()
        {
            // Arrange
            var starShip = new Starship("Y-wing")
            {
                ConsumablesHours = 168,
                MGLT = 80
            };
            //Act
            var jumps = starshipBusinessLogicUT.GetNumberOfJumps(starShip, 1000000);

            // Assert
            Assert.AreEqual(74, jumps);

        }

        /// <summary>
        /// StarshipBusinessLogic numberOfJumps method when 1000000 MGL and a Millennium then 9 jumps
        /// </summary>
        [TestMethod]
        public void StarshipBusinessLogic_NumberOfJumps_When1000000Millennium_Then9()
        {
            // Arrange
            var starShip = new Starship("Y-wing")
            {
                ConsumablesHours = 2* 30 * 24,
                MGLT = 75
            };
            //Act
            var jumps = starshipBusinessLogicUT.GetNumberOfJumps(starShip, 1000000);

            // Assert
            Assert.AreEqual(9, jumps);

        }

        /// <summary>
        /// StarshipBusinessLogic numberOfJumps method when 1000000 MGL and a Rebel transport then 9 jumps
        /// </summary>
        [TestMethod]
        public void StarshipBusinessLogic_NumberOfJumps_When1000000RebelTransport_Then9()
        {
            // Arrange
            var starShip = new Starship("Y-wing")
            {
                ConsumablesHours = 6 * 30 * 24,
                MGLT = 20
            };
            //Act
            var jumps = starshipBusinessLogicUT.GetNumberOfJumps(starShip, 1000000);

            // Assert
            Assert.AreEqual(11, jumps);

        }

        /// <summary>
        /// StarshipBusinessLogic numberOfJumps method when 1000000 MGL and a Rebel transport then 9 jumps
        /// </summary>
        [TestMethod]
        public void StarshipBusinessLogic_NumberOfJumps_When1000000RebelCR90Corvette_Then9()
        {
            // Arrange
            var starShip = new Starship("CR90 Corvette")
            {
                ConsumablesHours = 1 * 365 * 24,
                MGLT = 60
            };
            //Act
            var jumps = starshipBusinessLogicUT.GetNumberOfJumps(starShip, 1000000);

            // Assert
            Assert.AreEqual(1, jumps);

        }
    }
}
