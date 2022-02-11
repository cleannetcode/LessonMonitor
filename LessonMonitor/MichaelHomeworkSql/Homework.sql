CREATE TABLE [dbo].[Homework]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Url] NVARCHAR(MAX) NOT NULL, 
    [LessonId] INT NOT NULL, 
    [MemberId] INT NOT NULL
)
