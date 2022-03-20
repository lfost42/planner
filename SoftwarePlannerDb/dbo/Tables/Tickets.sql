CREATE TABLE [dbo].[Tickets]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[TicketName] VARCHAR(50) NOT NULL, 
	[TicketDescription] VARCHAR(500) NOT NULL,
	[TicketTypeId] int NOT NULL,
	[TicketCreated] DATETIME2 NOT NULL, 
	[TicketUpdated] DATETIME2 NOT NULL, 
	[ChangeId] INT NULL, 
	CONSTRAINT [FK_Tickets_Changes] FOREIGN KEY (ChangeId) REFERENCES Changes([Id]), 
	CONSTRAINT [FK_Tickets_TicketType] FOREIGN KEY (TicketTypeId) REFERENCES TicketTypes(Id)

)
