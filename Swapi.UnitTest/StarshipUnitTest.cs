using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Swapi.Model;

namespace Swapi.UnitTest
{
    /// <summary>
    /// Class StarshipUnitTest.
    /// </summary>
    [TestClass]
    public class StarshipUnitTest
    {
        private Starship starshipUT;

        /// <summary>
        /// Starships the when MGMT and hours are informed then distance without stop is calculated.
        /// </summary>
        [TestMethod]
        public void Starship_WhenMGMTAndHoursAreInformed_ThenDistanceWithoutStopIsCalculated()
        {
            //Arrange
            var starshipUT = new Starship("Some name")
            {
                MGLT = 4,
                ConsumablesHours = 23

            };

            //Act

            //Assert
            Assert.AreEqual(4 * 23, starshipUT.DistanceWithoutStop);

        }

        [TestMethod]
        public void Starship_WhenMGMTAndHoursAreNotInformed_ThenDistanceWithoutStopIsNotCalculated()
        {
            //Arrange
            var starshipUT = new Starship("Some name")
            {
                MGLT = 4,
            };

            //Act

            //Assert
            Assert.IsNull(starshipUT.DistanceWithoutStop);

        }
    }
 }
