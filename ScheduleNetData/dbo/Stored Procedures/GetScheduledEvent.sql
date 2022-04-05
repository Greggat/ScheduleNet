CREATE PROCEDURE [dbo].[GetScheduledEventByGuid]
	@Guid nchar(36)
AS
	SELECT Guid, EventType, CreatorEmail, OtherEmail, EventTitle, EventDesc
	FROM ScheduledEvents
	WHERE @Guid = Guid
RETURN 0
