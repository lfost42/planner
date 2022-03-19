CREATE TABLE [dbo].[Assigned]
(
	[Id] INT NOT NULL PRIMARY KEY, 
	[UserId] INT NOT NULL, 
	CONSTRAINT [FK_Assigned_Users] FOREIGN KEY (UserId) REFERENCES Users(Id)
)
