CREATE TABLE [dbo].[TicketNotes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[TicketId] INT NOT NULL, 
	[NoteId] INT NOT NULL, 
	[AssignedId] INT NOT NULL, 
	[CreatorId] INT NOT NULL, 
	[ChangeId] INT NULL, 
	CONSTRAINT [FK_TicketNotes_Tickets] FOREIGN KEY (TicketId) REFERENCES Tickets(Id), 
	CONSTRAINT [FK_TicketNotes_Notes] FOREIGN KEY (NoteId) REFERENCES Notes(Id), 
	CONSTRAINT [FK_TicketNotes_Creators] FOREIGN KEY (CreatorId) REFERENCES Creators(Id), 
	CONSTRAINT [FK_TicketNotes_Assigned] FOREIGN KEY (AssignedId) REFERENCES Assigned(Id),
	CONSTRAINT [FK_TicketNotes_Changes] FOREIGN KEY (ChangeId) REFERENCES Changes(Id)
	
)
