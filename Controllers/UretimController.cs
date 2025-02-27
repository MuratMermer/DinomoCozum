using Microsoft.AspNetCore.Mvc;
using cozum8.Services;
using cozum8.Models;

namespace cozum8.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UretimController : ControllerBase
    {
        private readonly DataProcessingService _dataProcessingService;

        public UretimController(DataProcessingService dataProcessingService)
        {
            _dataProcessingService = dataProcessingService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var operasyonlar = _dataProcessingService.GetUretimOperasyonlari();
            return Ok(operasyonlar);
        }
    }
}
