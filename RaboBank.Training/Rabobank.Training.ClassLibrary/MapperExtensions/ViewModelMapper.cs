using Rabobank.Training.ClassLibrary.Models;
using Rabobank.Training.ClassLibrary.ViewModels;

namespace Rabobank.Training.ClassLibrary.MapperExtensions
{
    public static class ViewModelMapper
    {
        public static MandateVM? ToMandateVM(this FundsOfMandatesData fundsOfMandatesData)
        {
            if (fundsOfMandatesData != null)
            {
                return new MandateVM
                {
                    Name = fundsOfMandatesData.FundsOfMandates.FirstOrDefault().Mandates.FirstOrDefault().MandateName,
                };
            }
            return null;
        }

        public static PortfolioVM ToPortfolioVM(this FundsOfMandatesData fundsOfMandatesData)
        {
            if (fundsOfMandatesData != null)
            {
                var portfolioVM = new PortfolioVM();
                foreach (var position in fundsOfMandatesData.FundsOfMandates)
                {
                    portfolioVM.Positions.Add(new PositionVM
                    {
                        Code = position.InstrumentCode,
                        Name = position.InstrumentName,
                        Value = GetValue(position.InstrumentName),
                        Mandates = position.Mandates?.Select(x => new MandateVM
                        {
                            Name = x.MandateName,
                            Allocation = x.Allocation,
                            Value = Math.Round(GetValue(position.InstrumentName) * x.Allocation / 100, 1),
                        }).ToList()
                    });
                }
                return portfolioVM;
            }
            return null;
        }

        private static int GetValue(string InstrumentName)

        {
            switch (InstrumentName.ToLower())
            {
                case "heineken":
                    return 12345;

                case "optimix mix fund":
                    return 23456;

                case "dp global strategy l high":
                    return 34567;

                case "rabobank core aandelen fonds t2":
                    return 45678;

                case "morgan stanley invest us gr fnd":
                    return 56789;

                default:
                    return 0;
            }
        }
    }
}