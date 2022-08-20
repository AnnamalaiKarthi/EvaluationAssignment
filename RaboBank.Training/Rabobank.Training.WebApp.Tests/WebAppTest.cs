using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Rabobank.Training.ClassLibrary.Services;
using Rabobank.Training.WebApp.Controllers;
using Rabobank.Training.WebApp.Models;
using Xunit;

namespace Rabobank.Training.WebApp.Tests

{
    /// <summary>
    /// Class <c>WebAppTest</c> Created to Test WebApp functions.
    /// </summary>
    public class WebAppTest
    {
        private readonly Mock<IFundOfMandatesService> _fundOfMandatesServiceMock;
        private readonly Mock<ILogger<PortfolioController>> _logger;
        private readonly string xmlFileDataPath = AppDomain.CurrentDomain.BaseDirectory + "TestData\\FundsOfMandatesData.xml";
        private readonly Mock<IConfiguration> _configurationMock;
        private readonly Mock<IApplicationConfig> _getFilePathMock;

        public WebAppTest()
        {
            _fundOfMandatesServiceMock = new Mock<IFundOfMandatesService>();
            _logger = new Mock<ILogger<PortfolioController>>();
            _configurationMock = new Mock<IConfiguration>();
            _getFilePathMock = new Mock<IApplicationConfig>();
        }

        /// <summary>
        /// Test Method <M>Get</> Created to Test WebApp portfoliocontroller Get function.
        /// </summary>
        [Fact]
        public async Task Get()
        {
            // Arrange
            PortfolioController portfolioController = new PortfolioController(_logger.Object, _fundOfMandatesServiceMock.Object, _getFilePathMock.Object);
            Environment.SetEnvironmentVariable("XmlFileDataPath", xmlFileDataPath);
            // Act
            var result = await portfolioController.Get();
            // Assert
            Assert.NotNull(result);
        }
    }
}