CREATE TABLE [dbo].[Lessons]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] varchar(200) NULL, 
    [Theme] varchar(200) NULL, 
    [LessonType] varchar(200) NULL, 
    [StartDate] DATETIME NULL, 
    [Duration] INT NULL 
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Продолжительность ( секунды )',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Lessons',
    @level2type = N'COLUMN',
    @level2name = N'Duration'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Начало урока',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Lessons',
    @level2type = N'COLUMN',
    @level2name = N'StartDate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Тип урока: Лекция, Общение в дискорде, хакатон',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Lessons',
    @level2type = N'COLUMN',
    @level2name = N'LessonType'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Основная тема урока',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Lessons',
    @level2type = N'COLUMN',
    @level2name = N'Theme'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Название урока',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Lessons',
    @level2type = N'COLUMN',
    @level2name = N'Name'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'урок для участников по определенной теме на каких то площадках',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Lessons',
    @level2type = NULL,
    @level2name = NULL