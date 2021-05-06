CREATE TABLE [dbo].[Lessons]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(30) NOT NULL UNIQUE, 
    [Description] NCHAR(250) NOT NULL, 
    [LinkHomeWork] NCHAR(100) NULL, 
    [LinkVideo] NCHAR(100) NULL, 
    [DataTime] DATETIME NOT NULL
)
