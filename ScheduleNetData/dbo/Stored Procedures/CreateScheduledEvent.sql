CREATE PROCEDURE [dbo].[CreateScheduledEvent]
	@Guid nchar(36),
	@CreatorEmail nvarchar(320),
	@OtherEmail nvarchar(320),
	@EventType tinyint
AS
	INSERT INTO ScheduledEvents (Guid, EventType, CreatorEmail, OtherEmail)
	VALUES (@Guid, @EventType, @CreatorEmail, @OtherEmail)
RETURN 0
