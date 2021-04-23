CREATE TABLE [dbo].[Homeworks]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [LessonId] INT NOT NULL, 
    [FinishDate] DATE NOT NULL, 
    [HomeworkText] NVARCHAR(MAX) NULL, 
    [Difficulty] INT NULL, 
    [links] NVARCHAR(50) NULL
)
