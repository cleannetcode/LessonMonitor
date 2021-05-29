CREATE TABLE [dbo].[VisitedLessons]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [LessonId] INT NOT NULL, 
    [MemberId] INT NULL
)
