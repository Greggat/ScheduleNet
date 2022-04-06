using Microsoft.AspNetCore.Mvc;
using ScheduleNet.Models;
using ScheduleNet.Models.Scheduler;
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
        public async Task<IActionResult> Create(ScheduleCreateViewModel model)
        {
            Guid guid = Guid.NewGuid();
            ScheduledEvent scheduledEvent = new(guid, model.Type, model.CreatorEmail, model.OtherEmail, model.Name, model.Description);
            bool success = await _data.InsertScheduledEventAsync(scheduledEvent);

            //Notify the creator & requestee via email
            if (success)
            {
                return Redirect($"Success?eventId={guid}");
            }
            else
            {
                return View("Error", new ErrorViewModel());
            }
        }

        public IActionResult Success(Guid eventId)
        {
            //TODO: Create View for Success
            //TODO: Display success page and a share-able link to the event request page
            ViewBag.Guid = eventId;
            return View();
        }

        public async Task<IActionResult> Request(Guid eventId)
        {
            var ev = await _data.GetScheduledEventByGuidAsync(eventId);
            if (ev == null)
                return View("Error", new ErrorViewModel { ErrorMessage="The event you are trying to access does not exist!"});

            ViewBag.EventName = ev.Name;

            ScheduleRequestViewModel model = new ScheduleRequestViewModel
            {
                Name = ev.Name,
                Description = ev.Description,
                Type = ev.Type,
            };
            return View(model);
        }
    }
}
