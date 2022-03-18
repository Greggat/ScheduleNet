CREATE PROCEDURE [dbo].[GetRequestedDatesByScheduledEventsId]
	@ScheduledEventsId int
AS
	SELECT [RequestedDate] FROM RequestedDates WHERE ScheduledEventId = @ScheduledEventsId
RETURN 0
