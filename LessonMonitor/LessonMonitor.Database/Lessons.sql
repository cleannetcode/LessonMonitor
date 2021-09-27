CREATE TABLE [dbo].[Lessons]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(20) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [Duration] TIMESTAMP NOT NULL, 
    [StartDate] DATETIME NULL, 
    [EndDate] DATETIME NULL
)
