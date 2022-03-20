namespace ScheduleNet.Models.Managers
{
    public interface IDataManager
    {
        Task<bool> InsertScheduledEventAsync(ScheduledEvent scheduledEvent);
        Task<IEnumerable<DateTime>?> GetRequestedDatesAsync(long scheduleEventId);
        Task<bool> InsertRequestedDateAsync(long scheduleEventId, DateTime date);
    }
}
