using Microsoft.AspNetCore.Mvc;
using ScheduleNet.Models;
using System.Diagnostics;

namespace ScheduleNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IConfiguration config, ILogger<HomeController> logger)
        {
            _config = config;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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
    }
}