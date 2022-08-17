namespace Rabobank.Training.ClassLibrary.ViewModels
{
    public class PortfolioVM
    {
        public PortfolioVM()
        {
            Positions = new List<PositionVM>();
        }

        public List<PositionVM>? Positions { get; set; }
    }
}