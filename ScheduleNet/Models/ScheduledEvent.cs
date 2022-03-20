using ScheduleNet.Models.Enums;

namespace ScheduleNet.Models
{
    public class ScheduledEvent
    {
        public long Id { get; init; } = 0;
        public Guid Guid { get; init; }
        public string Name { get; private set; } = "";
        public string Description { get; private set; } = "";
        public ScheduledEventType Type { get; init; }
        public ScheduledEventStage Stage { get; private set; }
        public string CreatorEmail { get; private set; } = null!;
        public string OtherEmail { get; private set; } = null!;
        public DateTime? Date { get; private set; }

        public ScheduledEvent(Guid guid, ScheduledEventType type, string creatorEmail, string otherEmail, string name = "", string desc = "",
            long id = 0, ScheduledEventStage stage = ScheduledEventStage.Created, DateTime date = default)
        {
            Id = id;
            Guid = guid;
            CreatorEmail = creatorEmail;
            OtherEmail = otherEmail;
            Type = type;
            Stage = stage;
            Name = name;
            Description = desc;
            Date = date;
        }
    }
}
