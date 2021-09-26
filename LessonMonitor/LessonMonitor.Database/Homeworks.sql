CREATE TABLE [dbo].[Homeworks]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(20) NOT NULL, 
    [Body] NVARCHAR(MAX) NULL, 
    [LessonId] INT NULL FOREIGN KEY REFERENCES [dbo].[Lessons](Id)
)
