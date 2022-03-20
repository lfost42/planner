CREATE TABLE [dbo].[TaskNotes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[TaskId] INT NOT NULL, 
	[NoteId] INT NOT NULL, 
	[AssignedId] INT NOT NULL, 
	[ChangeId] INT NULL, 
	CONSTRAINT [FK_TaskNotes_Tickets] FOREIGN KEY (TaskId) REFERENCES Tasks(Id), 
	CONSTRAINT [FK_TaskNotes_Notes] FOREIGN KEY (NoteId) REFERENCES Notes(Id),  
	CONSTRAINT [FK_TaskNotes_Assigned] FOREIGN KEY (AssignedId) REFERENCES Assigned(Id),
	CONSTRAINT [FK_TaskNotes_Changes] FOREIGN KEY (ChangeId) REFERENCES Changes(Id)
)
