using Microsoft.AspNetCore.Mvc;
using ScheduleNet.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ScheduleNet.Models
{
    public class CreateScheduledEventViewModel
    {
        ///<summary>
        /// The email of the creator of the event
        ///</summary>
        [Required]
        [EmailAddress]
        [Display(Name = "Your Email")]
        public string CreatorEmail { get; set; } = null!;

        ///<summary>
        /// The email of the requester of the event
        ///</summary>
        [Required]
        [EmailAddress]
        [Display(Name = "Other Parties Email")]
        public string OtherEmail { get; set; } = null!;

        ///<summary
        /// The type of event
        /// </summary>
        public ScheduledEventType Type { get; set; }

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
    }
}
