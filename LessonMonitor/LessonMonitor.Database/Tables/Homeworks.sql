CREATE TABLE [dbo].[Homeworks]
(
    [Id] INT NOT NULL PRIMARY KEY,
    [LessonId] INT NOT NULL, 
    [MemberId] INT NOT NULL, 
    [GithubLink] NVARCHAR(200) NOT NULL, 
    [HomeworkStateId] INT NOT NULL, 
    [Comment] NVARCHAR(MAX) NULL
)
