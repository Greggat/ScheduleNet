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
            //TODO: Create About or forward to creation page
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateScheduledEventViewModel model)
        {
            //Create the event
            Guid guid = Guid.NewGuid();
            ScheduledEvent scheduledEvent = new(guid, model.Type, model.CreatorEmail, model.OtherEmail, model.Name, model.Description);
            //TODO: await DataManager.CreateEvent(...)

            //Notify the creator & requestee via email

            HttpContext.Response.Redirect($"Success?event={guid}");
            return Content(model.CreatorEmail);
        }

        public IActionResult Success(Guid eventId)
        {
            //TODO: Create View for Success
            //TODO: Display success page and a share-able link to the event request page
            return Content($"Success! {eventId}");
        }
    }
}
