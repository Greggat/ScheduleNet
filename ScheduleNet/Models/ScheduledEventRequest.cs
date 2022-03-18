using ScheduleNet.Models.Enums;

namespace ScheduleNet.Models
{
    //TODO: Move to DataAccess
    public class ScheduledEventRequest
    {
        public ulong Id { get; init; }
        public ScheduledEventStage Stage { get; private set; }
        public string RequesterEmail { get; init; } = null!;
        public ScheduledEventType Type { get; private set; }
    }
}
