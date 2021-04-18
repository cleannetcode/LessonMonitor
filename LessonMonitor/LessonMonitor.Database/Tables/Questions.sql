CREATE TABLE [dbo].[Questions]
(
    [LessonId] INT NOT NULL, 
    [MemberId] INT NOT NULL, 
    [QuestionText] NVARCHAR(MAX) NOT NULL, 
    PRIMARY KEY ([LessonId], [MemberId] )
)
