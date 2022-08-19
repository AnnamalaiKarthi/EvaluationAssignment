namespace Rabobank.Training.WebApp.Models
{
    /// <summary>
    /// Interface <i>IGetFilePath</i> Added to Get the XML file path from appsettings.json.
    /// Called from PortfolioController
    /// </summary>
    public interface IGetFilePath
    {
        string FilePath();
    }
}