namespace Rabobank.Training.WebApp.Models
{
    /// <summary>
    /// Class <c>GetFilePath</c> Added to Get the XML file path from appsettings.json.
    /// The FilePath Method is called from PortfolioController thorough the Interface IGetFilePath
    /// </summary>
    public class GetFilePath : IGetFilePath
    {
        private readonly IConfiguration _configuration;

        public GetFilePath(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string FilePath()
        {
            return _configuration.GetSection("XmlFileDataPath").GetChildren().FirstOrDefault(config => config.Key == "SourceFilePath").Value;
        }
    }
}