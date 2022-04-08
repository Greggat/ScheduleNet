CREATE PROCEDURE [dbo].[UpdateScheduledEventStage]
	@Guid uniqueidentifier,
	@EventStage tinyint
AS
	UPDATE ScheduledEvents SET EventStage = @EventStage WHERE Guid = @Guid
RETURN 0
