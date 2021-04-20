CREATE TABLE [dbo].[Topics]
(
	[Id] INT NOT NULL, 
    [Theme] NVARCHAR(50) NULL, 
    [HomeworkId] INT NULL, 
    [QuestionId] INT NULL,
    CONSTRAINT [PK_Topics] PRIMARY KEY CLUSTERED ([Id] ASC),
)
