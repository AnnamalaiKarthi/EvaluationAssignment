using Microsoft.AspNetCore.Mvc;
using Rabobank.Training.ClassLibrary.Services;

namespace Rabobank.Training.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IFundOfMandatesService _fundOfMandatesService;

        private readonly ILogger<PortfolioController> _logger;

        private readonly IConfiguration _configuration;

        public PortfolioController(ILogger<PortfolioController> logger, IFundOfMandatesService fundOfMandatesService, IConfiguration configuaration)
        {
            _logger = logger;
            _fundOfMandatesService = fundOfMandatesService;
            _configuration = configuaration;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var filePath = _configuration.GetSection("XmlFileDataPath").GetChildren().FirstOrDefault(config => config.Key == "SourceFilePath").Value;

            if (filePath != null)
            {
                var data = await _fundOfMandatesService.GetPortfolioAsync(filePath);
                return Ok(data);
            }
            else
            {
                throw new Exception("FileName cannot be empty");
            }
        }
    }
}