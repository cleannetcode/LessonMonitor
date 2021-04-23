CREATE TABLE [dbo].[Lessons]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(20) NOT NULL, 
    [Topic] NVARCHAR(30) NULL, 
    [Timecode] NVARCHAR(30) NULL
)
