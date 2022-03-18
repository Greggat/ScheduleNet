CREATE PROCEDURE [dbo].[InsertRequestedDate]
	@ScheduledEventsId int,
	@RequestedDate datetime
AS
	INSERT INTO RequestedDates (ScheduledEventId, RequestedDate)
	VALUES (@ScheduledEventsId, @RequestedDate)
RETURN 0
