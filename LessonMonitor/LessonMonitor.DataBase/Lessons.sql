CREATE TABLE [dbo].[Lessons]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL, 
	[Description] NVARCHAR(MAX) NOT NULL,
    [StartDate] DATETIME2 NULL, 
    [Duration] INT NULL
)
