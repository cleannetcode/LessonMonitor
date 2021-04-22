CREATE TABLE [dbo].[Lessons]
(
	[LessonId] INT NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL
)
