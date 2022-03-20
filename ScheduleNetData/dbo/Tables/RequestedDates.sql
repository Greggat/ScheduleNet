CREATE TABLE [dbo].[RequestedDates]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [ScheduledEventId] BIGINT NOT NULL REFERENCES ScheduledEvents(Id) , 
    [RequestedDate] DATETIME NOT NULL
)
