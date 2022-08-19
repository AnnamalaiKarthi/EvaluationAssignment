namespace Rabobank.Training.ClassLibrary.Tests.TestData
{
    using FluentAssertions;
    using Rabobank.Training.ClassLibrary.Services;
    using Rabobank.Training.ClassLibrary.ViewModels;

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
            _ = data.Positions.Count.Should().Be(mandateCount);
        }

        [TestMethod]
        public void Display()
        {
            List<PositionVM> positionsList = new List<PositionVM>();
            positionsList.Add(new PositionVM { Code = "NL0000009165", Name = "Heineken", Value = 12345 });
            positionsList.Add(new PositionVM { Code = "NL0000287100", Name = "Optimix Mix Fund", Value = 23456 });
            positionsList.Add(new PositionVM { Code = "LU0035601805", Name = "DP Global Strategy L High", Value = 34567 });
            positionsList.Add(new PositionVM { Code = "NL0000292332", Name = "Rabobank Core Aandelen Fonds T2", Value = 45678 });
            positionsList.Add(new PositionVM { Code = "LU0042381250", Name = "Morgan Stanley Invest US Gr Fnd", Value = 56789 });

            _fundOfMandatesService.Display(positionsList);
        }
    }
}