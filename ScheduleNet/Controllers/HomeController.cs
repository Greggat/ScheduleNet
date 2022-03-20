using Microsoft.AspNetCore.Mvc;
using ScheduleNet.Models;
using ScheduleNet.Models.Managers;
using System.Diagnostics;

namespace ScheduleNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ILogger<HomeController> _logger;
        private readonly IDataManager _data;

        public HomeController(IConfiguration config, ILogger<HomeController> logger, IDataManager data)
        {
            _config = config;
            _logger = logger;
            _data = data;
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