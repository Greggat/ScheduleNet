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
            throw new NotImplementedException();
        }

        public async Task<bool> InsertScheduledEventAsync(ScheduledEvent scheduledEvent)
        {
            throw new NotImplementedException();
        }
    }
}
