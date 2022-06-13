CREATE TABLE [dbo].[Lessons]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [StartDate] DATETIME NOT NULL, 
    [Duration] FLOAT NOT NULL, 
    [Difficulty] NCHAR(10) NULL, 
    [Skills] NVARCHAR(50) NOT NULL
)
