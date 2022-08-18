using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Rabobank.Training.ClassLibrary.Services;
using Rabobank.Training.WebApp.Controllers;
using Xunit;

namespace Rabobank.Training.WebApp.Tests

{
    public class WebAppTest
    {
        private readonly Mock<IFundOfMandatesService> _fundOfMandatesServiceMock;
        private readonly Mock<ILogger<PortfolioController>> _logger;
        private readonly string xmlFileDataPath = AppDomain.CurrentDomain.BaseDirectory + "TestData\\FundsOfMandatesData.xml";
        private readonly Mock<IConfiguration> _configurationMock;

        public WebAppTest()
        {
            _fundOfMandatesServiceMock = new Mock<IFundOfMandatesService>();
            _logger = new Mock<ILogger<PortfolioController>>();
            _configurationMock = new Mock<IConfiguration>();
        }

        [Fact]
        public async Task Get()
        {
            // Arrange
            PortfolioController portfolioController = new PortfolioController(_logger.Object, _fundOfMandatesServiceMock.Object, _configurationMock.Object);
            Environment.SetEnvironmentVariable("XmlFileDataPath", xmlFileDataPath);
            // Act
            var result = portfolioController.Get();
            // Assert
            Assert.NotNull(result);
        }
    }
}