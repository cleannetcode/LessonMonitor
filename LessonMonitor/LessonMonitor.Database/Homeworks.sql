CREATE TABLE [dbo].[Homeworks]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [MemberId] INT NULL, 
    [LessonId] INT NULL, 
    [Verified] BIT NULL, 
    [RevisionList] varchar(Max) NULL,  
    [Mark] INT NULL, 
    [GithubLink] varchar(500) NULL, 
    CONSTRAINT [FK_Homeworks_ToMember] FOREIGN KEY (MemberId) REFERENCES Members(id), 
    CONSTRAINT [FK_Homeworks_ToLesson] FOREIGN KEY ([LessonId]) REFERENCES Lessons(Id)

)

GO

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Домашние работы участников',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Homeworks',
    @level2type = NULL,
    @level2name = NULL
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'домашка проверена или нет ',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Homeworks',
    @level2type = N'COLUMN',
    @level2name = N'Verified'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'по какому уроку домашка',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Homeworks',
    @level2type = N'COLUMN',
    @level2name = 'LessonId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'ссылка на участника',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Homeworks',
    @level2type = N'COLUMN',
    @level2name = N'MemberId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Список того что нужно доделать',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Homeworks',
    @level2type = N'COLUMN',
    @level2name = N'RevisionList'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Оценка ( 1.. 5)',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Homeworks',
    @level2type = N'COLUMN',
    @level2name = 'Mark'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Ссылка на гитхаб решение',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Homeworks',
    @level2type = N'COLUMN',
    @level2name = N'GithubLink'