CREATE TABLE [dbo].[Questions]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [Text] NVARCHAR(MAX) NOT NULL, 
    [Created] DATETIME NOT NULL, 
    [LessonId] INT NOT NULL, 
    [MemberId] INT NOT NULL, 
    CONSTRAINT [FK_QuestionsToLessons] FOREIGN KEY ([LessonId]) REFERENCES [Lessons]([Id])
    ON DELETE CASCADE, 
    CONSTRAINT [FK_QuestionsToMembers] FOREIGN KEY ([MemberId]) REFERENCES [Members]([Id])
    ON DELETE NO ACTION
)
