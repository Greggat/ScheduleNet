using Microsoft.AspNetCore.Mvc;
using ScheduleNet.Models;

namespace ScheduleNet.Controllers
{
    public class ScheduleController : Controller
    {
        IConfiguration _config;

        public ScheduleController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View("CreateScheduledEventView");
        }

        [HttpPost]
        public IActionResult Create(CreateScheduledEventViewModel model)
        {
            //Create the event
            Guid guid = Guid.NewGuid();

            //Notify the creator & requestee via email

            //redirect to success?
            HttpContext.Response.Redirect($"Success?id={123}");
            return Content(model.CreatorEmail);
        }

        public IActionResult Success(ulong id)
        {
            return Content($"Success! {id}");
        }
    }
}
