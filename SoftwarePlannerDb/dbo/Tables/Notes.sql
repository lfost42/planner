CREATE TABLE [dbo].[Notes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[Note] VARCHAR(500) NOT NULL, 
	[NoteCreated] DATETIME2 NOT NULL, 
	[Creator] NVARCHAR(450) NOT NULL, 
	[PriorityId] INT NOT NULL, 
	[StatusId] INT NOT NULL, 
	CONSTRAINT [FK_Notes_AspNetUsers] FOREIGN KEY (Creator) REFERENCES AspNetUsers(Id), 
	CONSTRAINT [FK_Notes_Priority] FOREIGN KEY (PriorityId) REFERENCES Priority(Id), 
	CONSTRAINT [FK_Notes_Status] FOREIGN KEY (StatusId) REFERENCES Status(Id)
)
