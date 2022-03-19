CREATE TABLE [dbo].[Changes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[UpdatedItem] VARCHAR(50) NOT NULL, 
	[Description] VARCHAR(250) NOT NULL, 
	[PreviousValue] VARCHAR(250) NOT NULL, 
	[CurrentValue] VARCHAR(50) NOT NULL, 
	[DateModified] DATETIME2 NOT NULL
)

