CREATE TABLE [dbo].[Topics]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Theme] NVARCHAR(50) NULL, 
    [HomeworkId] INT NULL, 
    [QuestionId] INT NULL
)
