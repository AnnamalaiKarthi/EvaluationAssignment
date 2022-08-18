namespace Rabobank.Training.WebApp.Models
{
    public class GetFilePath : IGetFilePath
    {
        public string? xmlFilePath { get; set; }
        private readonly IConfiguration _configuration;

        public GetFilePath(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string FilePath()
        {
            var xmlFilePath = _configuration.GetSection("XmlFileDataPath").GetChildren().FirstOrDefault(config => config.Key == "SourceFilePath").Value;
            return xmlFilePath;
        }
    }
}