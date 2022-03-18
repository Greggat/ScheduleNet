CREATE TABLE [dbo].[RequestedDates]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ScheduledEventId] INT NOT NULL REFERENCES ScheduledEvents(Id) , 
    [RequestedDate] DATETIME NOT NULL
)
