using System.ComponentModel.DataAnnotations;
using ScheduleNet.Models.Enums;

namespace ScheduleNet.Models.Scheduler
{
    public class ScheduleRequestViewModel
    {
        ///<summary
        /// The name of the event
        /// </summary>
        [Display(Name = "Event Name")]
        public string Name { get; set; } = string.Empty;

        ///<summary
        /// The description of the event
        /// </summary>
        [Display(Name = "Event Description")]
        public string Description { get; set; } = string.Empty;

        ///<summary
        /// The type of event
        /// </summary>
        public ScheduledEventType Type { get; set; }
    }
}
