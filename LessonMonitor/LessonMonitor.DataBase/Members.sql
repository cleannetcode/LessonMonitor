CREATE TABLE [dbo].[Members]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1), 
    [Name] NVARCHAR(50) NOT NULL, 
    [Nicknames] NVARCHAR(MAX) NULL, 
    [Email] NVARCHAR(50) NULL, 
    [Links] NVARCHAR(MAX) NULL, 
    [Grade] NVARCHAR(50) NULL, 
    [CreateDate] DATETIME2 NULL, 
    [AchievementId] INT NOT NULL, 
    [HomeworkId] INT NOT NULL, 
    [QuestionId] INT NOT NULL, 
    [MemberStatisticId] INT NOT NULL,
)
