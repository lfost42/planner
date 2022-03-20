CREATE TABLE [dbo].[Projects]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[ProjectName] VARCHAR(50) NULL, 
	[ProjectDescription] VARBINARY(500) NOT NULL, 
	[TargetDate] DATETIME2 NOT NULL, 
	[ProjectCreated] DATETIME2 NOT NULL, 
	[ProjectStatus] VARCHAR(50) NOT NULL
)
