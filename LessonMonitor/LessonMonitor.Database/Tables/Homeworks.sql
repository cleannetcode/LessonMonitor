CREATE TABLE [dbo].[Homeworks]
(
    [LessonId] INT NOT NULL, 
    [MemberId] INT NOT NULL, 
    [GithubLink] NVARCHAR(200) NOT NULL, 
    [HomeworkStateId] INT NOT NULL, 
    PRIMARY KEY ([LessonId], [MemberId]), 
)
