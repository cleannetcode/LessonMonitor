CREATE TABLE [dbo].[Timecodes]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [StartPosition] INT NOT NULL, 
    [LessonId] INT NOT NULL, 
    CONSTRAINT [FK_Timecodes_Lessons] FOREIGN KEY ([LessonId]) REFERENCES [Lessons]([Id])
)
