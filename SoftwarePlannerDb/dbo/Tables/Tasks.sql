CREATE TABLE [dbo].[Tasks]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[TaskDescription] NVARCHAR(500) NOT NULL, 
	[StatusId] Int NOT NULL,
	[PriorityId] Int NOT NULL,
	[TaskCreated] DATETIME2 NOT NULL, 
	[TaskClosed] DATETIME2 NOT NULL, 
	[TaskTargetDate] DATETIME2 NOT NULL,
	[CreatorId] NVARCHAR(450) NOT NULL, 
	[ChangeId] INT NULL, 
	CONSTRAINT [FK_Tasks_Creator] FOREIGN KEY (CreatorId) REFERENCES AspNetUsers(Id),
	CONSTRAINT [FK_Tasks_Priority] FOREIGN KEY (PriorityId) REFERENCES Priority(Id), 
	CONSTRAINT [FK_Tasks_Status] FOREIGN KEY (StatusId) REFERENCES Status(Id), 
	CONSTRAINT [FK_Tasks_Changes] FOREIGN KEY (ChangeId) REFERENCES Changes(Id)
)
