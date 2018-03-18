using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Swapi.DataServices;
using Moq;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Swapi.Model;
using System.Collections.Generic;
using Newtonsoft.Json;
using Swapi.DataServices.Model;
using System.Linq;

namespace Swapi.UnitTest
{
    [TestClass]
    public class StarshipDataServiceUnitTest
    {
        StarshipDataService dataServiceStarshipUT;
        Mock<IHttpClientHandler> httpClientHandlerMock;
        [TestInitialize]
        public void initialize()
        {
            httpClientHandlerMock = new Mock<IHttpClientHandler>();
            var appConfigurationManager = new Mock<IAppConfigurationManager>();
            appConfigurationManager.SetupGet(c => c.AppServer).Returns("Some server");
            dataServiceStarshipUT = new StarshipDataService(httpClientHandlerMock.Object, appConfigurationManager.Object);
        }

        /// <summary>
        /// DatasServiceStarship when a call to the GetAll does not return next page then return the result of the call.
        /// </summary>
        [TestMethod]
        public void DataServiceStarshipGetAll_whenACallToTheServiceDoesNotReturnNextPage_ThenReturnTheResultOfTheCall()
        {
            // Arrange
            var result =
                new PageResult<StarshipDTO>
                {
                    Next = "",
                    Results = new List<StarshipDTO>()
                    {
                        new StarshipDTO()
                    }
                };

            var httpResponse = new System.Net.Http.HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new System.Net.Http.StringContent(JsonConvert.SerializeObject(result))
            };
            httpClientHandlerMock.Setup(ch => ch.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(httpResponse));

            // Act
            var starships = dataServiceStarshipUT.GetAll();

            //Assert
            httpClientHandlerMock.Verify(ch => ch.GetAsync(It.IsAny<string>()), Times.Once());
            Assert.AreEqual(1, starships.Count());
        }
    }
}
