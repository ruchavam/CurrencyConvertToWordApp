using Microsoft.AspNetCore.Mvc;
using CurrencyConverterApp.Models;
using CurrencyConverterApp.Services;
using Microsoft.Extensions.Logging;
using CurrencyConverterApp.IServices;

namespace CurrencyConverterApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ILogger<CurrencyController> _logger;
        private readonly ICurrencyConverterService _converterService;

        public CurrencyController(ILogger<CurrencyController> logger, ICurrencyConverterService converterService)
        {
            _logger = logger;
            _converterService = converterService;
        }

        [HttpPost("convert")]
        public IActionResult ConvertCurrency([FromBody] CurrencyInput input)
        {
            try
            {
                if (input == null)
                {
                    return BadRequest("Invalid input: Amount is required.");
                }

                String result = _converterService.ConvertCurrencyToWords(input.Amount);
                return Ok(new { Result = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while converting currency.");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
