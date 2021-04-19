CREATE TABLE [dbo].[Questions]
(
    [Id] INT NOT NULL,
    [LessonId] INT NOT NULL, 
    [MemberId] INT NOT NULL, 
    [QuestionText] NVARCHAR(MAX) NOT NULL, 
    PRIMARY KEY ([Id] )
)
