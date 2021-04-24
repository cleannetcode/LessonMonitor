CREATE TABLE [dbo].[Questions]
(
    [QuestionId] INT NOT NULL PRIMARY KEY,
    [LessonId] INT NOT NULL,
    [TopicId] INT NULL,
    [MemberId] INT NOT NULL, 
    [QuestionText] NVARCHAR(MAX) NOT NULL
)
