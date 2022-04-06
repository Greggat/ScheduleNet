using ScheduleNet.Models.Enums;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;

namespace ScheduleNet.Models.Managers
{
    public class DataManager : IDataManager
    {
        private readonly IConfiguration _config;
        private readonly ILogger _log;
        private readonly SqlConnection _con;

        public DataManager(IConfiguration config, ILogger<DataManager> logger)
        {
            _config = config;
            _log = logger;
            _con = new SqlConnection(_config.GetConnectionString("ScheduleNetDb"));
        }

        public async Task<IEnumerable<DateTime>?> GetRequestedDatesAsync(long scheduleEventId)
        {
            SqlCommand cmd = new("GetRequestedDatesByScheduledEventsId", _con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ScheduledEventsId", scheduleEventId);

            try
            {
                await _con.OpenAsync();
                SqlDataReader dr = await cmd.ExecuteReaderAsync();

                List<DateTime> dates = new();
                while(await dr.ReadAsync())
                {
                    dates.Add(dr.GetDateTime("RequestedDate"));
                }
                await _con.CloseAsync();
                return dates;
            }
            catch (Exception e)
            {
                if(_con.State != ConnectionState.Closed)
                {
                    await _con.CloseAsync();
                }
                _log.LogCritical(e.ToString());
                //TODO: Return null or throw to caller
                return null;
            }
        }

        public async Task<bool> InsertRequestedDateAsync(long scheduleEventId, DateTime date)
        {
            SqlCommand cmd = new("InsertRequestedDate", _con);
            cmd.CommandType = CommandType.StoredProcedure;

            //@ScheduledEventsId, @RequestedDate
            cmd.Parameters.AddWithValue("@ScheduledEventsId", scheduleEventId);
            cmd.Parameters.AddWithValue("@RequestedDate", date);

            try
            {
                await _con.OpenAsync();
                var res = await cmd.ExecuteNonQueryAsync();
                await _con.CloseAsync();
                return res == 1;
            }
            catch (Exception e)
            {
                _log.LogCritical(e.ToString());
                return false;
            }
        }

        public async Task<ScheduledEvent> GetScheduledEventByGuidAsync(Guid guid)
        {
            SqlCommand cmd = new("GetScheduledEventByGuid", _con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Guid", guid);

            try
            {
                await _con.OpenAsync();
                SqlDataReader dr = await cmd.ExecuteReaderAsync();

                if(!dr.Read())
                {
                    //No event with that GUID exists
                    return null;
                }

                //Guid, EventType, CreatorEmail, OtherEmail, EventTitle, EventDesc
                ScheduledEvent ev = new(
                    dr.GetGuid("Guid"),
                    (ScheduledEventType)dr.GetByte("EventType"),
                    dr.GetString("CreatorEmail"),
                    dr.GetString("OtherEmail"),
                    !await dr.IsDBNullAsync("EventTitle") ? dr.GetString("EventTitle") : string.Empty,
                    !await dr.IsDBNullAsync("EventDesc") ? dr.GetString("EventDesc") : string.Empty
                );

                await _con.CloseAsync();

                return ev;
            }
            catch (Exception e)
            {
                if (_con.State != ConnectionState.Closed)
                {
                    await _con.CloseAsync();
                }
                _log.LogCritical(e.ToString());
                //TODO: Return null or throw to caller
                return null;
            }
        }
        
        public async Task<bool> InsertScheduledEventAsync(ScheduledEvent scheduledEvent)
        {
            SqlCommand cmd = new("CreateScheduledEvent", _con);
            cmd.CommandType = CommandType.StoredProcedure;

            //@Guid, @EventType, @CreatorEmail, @OtherEmail, @EventTitle, @EventDesc
            cmd.Parameters.AddWithValue("@Guid", scheduledEvent.Guid);
            cmd.Parameters.AddWithValue("@EventType", scheduledEvent.Type);
            cmd.Parameters.AddWithValue("@CreatorEmail", scheduledEvent.CreatorEmail);
            cmd.Parameters.AddWithValue("@OtherEmail", scheduledEvent.OtherEmail);
            cmd.Parameters.AddWithValue("@EventTitle", scheduledEvent.Name);
            cmd.Parameters.AddWithValue("@EventDesc", scheduledEvent.Description);

            try
            {
                await _con.OpenAsync();
                var res = await cmd.ExecuteNonQueryAsync();
                await _con.CloseAsync();
                return res == 1;
            }
            catch (Exception e)
            { 
                _log.LogCritical(e.ToString());
                return false;
            }
        }
    }
}
