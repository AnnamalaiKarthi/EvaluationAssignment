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

        public PortfolioController(ILogger<PortfolioController> logger, IFundOfMandatesService fundOfMandatesService)
        {
            _logger = logger;
            _fundOfMandatesService = fundOfMandatesService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var filePath = Environment.GetEnvironmentVariable("XmlFileDataPath");
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