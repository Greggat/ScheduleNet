CREATE TABLE [dbo].[ScheduledEvents]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Guid] NCHAR(36) NOT NULL, 
    [ConfirmedDate] DATETIME NULL, 
    [CreatorEmail] NVARCHAR(320) NOT NULL, 
    [OtherEmail] NVARCHAR(320) NOT NULL, 
    [EventType] TINYINT NULL, 
    [EventStage] TINYINT NULL DEFAULT 1 --1 is Created Stage
, 
    [EventTitle] NVARCHAR(50) NULL, 
    [EventDesc] NVARCHAR(300) NULL)
