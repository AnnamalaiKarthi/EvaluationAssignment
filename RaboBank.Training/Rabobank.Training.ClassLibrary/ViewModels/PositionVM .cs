namespace Rabobank.Training.ClassLibrary.ViewModels
{
    public class PositionVM
    {
        public PositionVM()
        {
            Mandates = new List<MandateVM>();
        }

        public string? Code { get; set; }
        public string? Name { get; set; }
        public decimal Value { get; set; }
        public List<MandateVM> Mandates { get; set; }
    }
}