namespace Rabobank.Training.ClassLibrary.Services
{
    using System.Xml.Serialization;
    using Rabobank.Training.ClassLibrary.MapperExtensions;
    using Rabobank.Training.ClassLibrary.Models;
    using Rabobank.Training.ClassLibrary.ViewModels;

    public class FundOfMandatesService : IFundOfMandatesService
    {
        public async Task<FundsOfMandatesData?> GetFundsOfMandatesDataAsync(string fileName)
        {
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(FundsOfMandatesData), "http://amt.rnss.rabobank.nl/");
                using var reader = new StreamReader(fileName);
                var data = await Task.FromResult((FundsOfMandatesData?)deserializer.Deserialize(reader));
                if (data != null && data.FundsOfMandates != null)
                {
                    AddLiquidity(data);

                    data.FundsOfMandates.AddRange(new List<FundsOfMandatesDataFundOfMandates>
                   {
                        new FundsOfMandatesDataFundOfMandates
                        {
                            InstrumentCode="NL0000009165",
                            InstrumentName="Heineken",
                        },
                         new FundsOfMandatesDataFundOfMandates
                        {
                            InstrumentCode="LU0035601805",
                            InstrumentName="DP Global Strategy L High",
                        },
                          new FundsOfMandatesDataFundOfMandates
                        {
                            InstrumentCode="LU0042381250",
                            InstrumentName="Morgan Stanley Invest US Gr Fnd",
                         },
                });
                    return data;
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PortfolioVM?> GetPortfolioAsync(string fileName)
        {
            var data = await GetFundsOfMandatesDataAsync(fileName);
            if (data != null)
            {
                var result = data.ToPortfolioVM();
                return result;
            }
            else
            {
                return null;
            }
        }

        public void Display(List<PositionVM> portfolioList)
        {
            foreach (var portfolio in portfolioList)
            {
                Console.WriteLine(portfolio.Name);
            }
        }

        private void AddLiquidity(FundsOfMandatesData data)
        {
            if (data.FundsOfMandates != null)
            {
                foreach (var item in data.FundsOfMandates)
                {
                    if (item.Mandates != null)
                    {
                        item.Mandates.Add(new FundsOfMandatesDataFundOfMandatesMandate
                        {
                            MandateName = "Liquidity",
                            Allocation = item.LiquidityAllocation,
                        });
                    }
                }
            }
        }
    }
}