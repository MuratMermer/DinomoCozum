using cozum8.Models;
using cozum8.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace cozum8.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataProcessingService _dataProcessingService;

        public HomeController(ILogger<HomeController> logger, DataProcessingService dataProcessingService)
        {
            _logger = logger;
            _dataProcessingService = dataProcessingService;
        }

        public IActionResult Index()
        {
            var uretimVerileri = _dataProcessingService.GetAllServices();
            ViewBag.StandartDuruslar = _dataProcessingService.StandartDuruslar;
            return View(uretimVerileri);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult tablogoster()
        {
            return View();
        }

        public IActionResult Services()
        {
            var uretimVerileri = _dataProcessingService.GetAllServices();
            ViewBag.StandartDuruslar = _dataProcessingService.StandartDuruslar;
            return View(uretimVerileri);
        }

        [HttpGet]
        public IActionResult GetBirlesikVeriler()
        {
            var birlesikVeriler = _dataProcessingService.GetUretimOperasyonlari();
            return Json(birlesikVeriler);
        }
    }
}