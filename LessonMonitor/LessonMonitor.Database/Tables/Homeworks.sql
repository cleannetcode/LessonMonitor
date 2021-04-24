CREATE TABLE [dbo].[Homeworks]
(
    [HomeworkId] INT NOT NULL PRIMARY KEY,
    [LessonId] INT NOT NULL, 
    [MemberId] INT NOT NULL, 
    [GithubLink] NVARCHAR(200) NOT NULL, 
    [HomeworkStateId] INT NOT NULL, 
    [Comment] NVARCHAR(MAX) NULL, 
    [CreatedAt] DATETIME2 NOT NULL DEFAULT GETDATE(),
    [UpdatedAt] DATETIME2 NOT NULL DEFAULT GETDATE()
)
