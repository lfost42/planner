CREATE TABLE [dbo].[ProjectNotes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[ProjectId] INT NOT NULL, 
	[NoteId] INT NOT NULL, 
	[AssignedId] INT NOT NULL, 
	[ChangeId] INT NULL, 
	CONSTRAINT [FK_ProjectNotes_Projects] FOREIGN KEY (ProjectId) REFERENCES Projects(Id),
	CONSTRAINT [FK_ProjectNotes_Notes] FOREIGN KEY (NoteId) REFERENCES Notes(Id),	
	CONSTRAINT [FK_ProjectNotes_Assigned] FOREIGN KEY (AssignedId) REFERENCES Assigned(Id),
	CONSTRAINT [FK_ProjectNotes_Changes] FOREIGN KEY (ChangeId) REFERENCES Changes(Id)

)
