using Microsoft.AspNetCore.Mvc;
using Rabobank.Training.ClassLibrary.Services;
using Rabobank.Training.WebApp.Models;

namespace Rabobank.Training.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IFundOfMandatesService _fundOfMandatesService;

        private readonly ILogger<PortfolioController> _logger;

        private readonly IConfiguration _configuration;
        private readonly IGetFilePath _getFilePath;

        public PortfolioController(ILogger<PortfolioController> logger, IFundOfMandatesService fundOfMandatesService, IConfiguration configuaration, IGetFilePath getFilePath)
        {
            _logger = logger;
            _fundOfMandatesService = fundOfMandatesService;
            _configuration = configuaration;
            _getFilePath = getFilePath;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string? filePath = _getFilePath.FilePath();
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