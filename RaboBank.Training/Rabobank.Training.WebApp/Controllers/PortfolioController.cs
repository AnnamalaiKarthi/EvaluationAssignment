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

        private readonly IApplicationConfig _applicationConfig;

        public PortfolioController(ILogger<PortfolioController> logger, IFundOfMandatesService fundOfMandatesService, IApplicationConfig applicationConfig)
        {
            _logger = logger;
            _fundOfMandatesService = fundOfMandatesService;
            _applicationConfig = applicationConfig;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                string? filePath = _applicationConfig.GetFilePath();
                _logger.LogInformation($"Getting Portfolio Data from Path: {filePath}");
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
            catch (Exception ex)
            {
                _logger.LogError($"Error Occurred: {ex}");
                throw;
            }
        }
    }
}