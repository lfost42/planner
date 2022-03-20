CREATE TABLE [dbo].[TeamNotes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[TeamId] INT NOT NULL,
	[NoteId] INT NOT NULL, 
	[AssignedId] INT NOT NULL, 
	[ChangeId] INT NULL, 
	CONSTRAINT [FK_TeamNotes_TeamId] FOREIGN KEY (TeamId) REFERENCES Teams(Id),
	CONSTRAINT [FK_TeamNotes_Notes] FOREIGN KEY (NoteId) REFERENCES Notes(Id),	
	CONSTRAINT [FK_TeamNotes_Assigned] FOREIGN KEY (AssignedId) REFERENCES Assigned(Id),
	CONSTRAINT [FK_TeamNotes_Changes] FOREIGN KEY (ChangeId) REFERENCES Changes(Id)

)
