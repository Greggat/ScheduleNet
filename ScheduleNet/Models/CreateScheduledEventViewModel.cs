using Microsoft.AspNetCore.Mvc;

namespace ScheduleNet.Models
{
    public class CreateScheduledEventViewModel
    {
        ///<summary>
        /// The email of the creator of the event
        ///</summary>
        public string CreatorEmail { get; set; } = null!;

        ///<summary>
        /// The email of the requester of the event
        ///</summary>
        public string RequestorEmail { get; set; } = null!;
    }
}
