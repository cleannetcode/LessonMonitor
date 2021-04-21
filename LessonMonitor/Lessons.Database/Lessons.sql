CREATE TABLE [dbo].[Lessons]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [LevelId] INT NOT NULL, 
    [StartDate] DATETIME NOT NULL, 
    [EndDate] DATETIME NULL, 
    CONSTRAINT [FK_Lessons_Levels] FOREIGN KEY ([LevelId]) REFERENCES [Levels]([Id]), 
)
