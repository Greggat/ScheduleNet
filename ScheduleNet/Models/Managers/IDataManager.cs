using ScheduleNet.Models.Enums;

namespace ScheduleNet.Models.Managers
{
    public interface IDataManager
    {
        Task<bool> InsertScheduledEventAsync(ScheduledEvent scheduledEvent);
        Task<ScheduledEvent> GetScheduledEventByGuidAsync(Guid guid);
        Task<IEnumerable<DateTime>?> GetRequestedDatesAsync(long scheduleEventId);
        Task<bool> InsertRequestedDateAsync(long scheduleEventId, DateTime date);
        Task<bool> UpdateScheduledEventStage(Guid scheduleEventGuid, ScheduledEventStage stage);
    }
}
