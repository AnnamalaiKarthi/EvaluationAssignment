namespace Rabobank.Training.ClassLibrary.Services

{
    using Rabobank.Training.ClassLibrary.Models;
    using Rabobank.Training.ClassLibrary.ViewModels;

    public interface IFundOfMandatesService
    {
        Task<FundsOfMandatesData> GetFundsOfMandatesDataAsync(string fileName);

        Task<PortfolioVM> GetPortfolioAsync(string fileName);

        void Display(List<PositionVM> portfolioList);
    }
}