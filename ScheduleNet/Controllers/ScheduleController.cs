using Microsoft.AspNetCore.Mvc;
using ScheduleNet.Models;
using ScheduleNet.Models.Managers;

namespace ScheduleNet.Controllers
{
    public class ScheduleController : Controller
    {
        IConfiguration _config;
        IDataManager _data;

        public ScheduleController(IConfiguration config, IDataManager data)
        {
            _config = config;
            _data = data;
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
            bool success = await _data.InsertScheduledEventAsync(scheduledEvent);

            //Notify the creator & requestee via email
            if (success)
            {
                return Redirect($"Success?eventId={guid}");
            }
            else
            {
                //TODO: redirect error page?
                return Content("Critical Error");
            }
        }

        public IActionResult Success(Guid eventId)
        {
            //TODO: Create View for Success
            //TODO: Display success page and a share-able link to the event request page
            return Content($"Success! {eventId}");
        }
    }
}
