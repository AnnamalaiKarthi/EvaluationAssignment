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

        public WebAppTest()
        {
            _fundOfMandatesServiceMock = new Mock<IFundOfMandatesService>();
            _logger = new Mock<ILogger<PortfolioController>>();
        }

        [Fact]
        public async Task Get()
        {
            // Arrange

            PortfolioController portfolioController = new PortfolioController(_logger.Object, _fundOfMandatesServiceMock.Object);
            Environment.SetEnvironmentVariable("XmlFileDataPath", xmlFileDataPath);
            // Act
            var result = portfolioController.Get();
            // Assert
            Assert.NotNull(result);
        }
    }
}