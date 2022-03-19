CREATE PROCEDURE [dbo].[CreateScheduledEvent]
	@Guid nchar(36),
	@CreatorEmail nvarchar(320),
	@OtherEmail nvarchar(320),
	@EventType tinyint,
	@EventTitle nvarchar(50) = '',
	@EventDesc nvarchar(300) = ''
AS
	INSERT INTO ScheduledEvents (Guid, EventType, CreatorEmail, OtherEmail, EventTitle, EventDesc)
	VALUES (@Guid, @EventType, @CreatorEmail, @OtherEmail, @EventTitle, @EventDesc)
RETURN 0
