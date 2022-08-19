namespace Rabobank.Training.ClassLibrary.Tests.TestData
{
    using FluentAssertions;
    using Rabobank.Training.ClassLibrary.Services;

    [TestClass]
    public class GetFundOfMandatesObjectsTest
    {
        private readonly FundOfMandatesService _fundOfMandatesService;
        private readonly string xmlFileDataPath = AppDomain.CurrentDomain.BaseDirectory + "TestData\\FundsOfMandatesData.xml";

        public GetFundOfMandatesObjectsTest()
        {
            _fundOfMandatesService = new FundOfMandatesService();
        }

        [TestMethod]
        public async Task FundsOfMandatesDataTest()
        {
            var data = await _fundOfMandatesService.GetFundsOfMandatesDataAsync(xmlFileDataPath);
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public async Task GetPortfolioTest()
        {
            var data = await _fundOfMandatesService.GetPortfolioAsync(xmlFileDataPath);
            int mandateCount = 6;
            Assert.IsNotNull(data);
            if (data.Positions != null)
            {
                _ = data.Positions.Count.Should().Be(mandateCount);
            }
        }
    }
}