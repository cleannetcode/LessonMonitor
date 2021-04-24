CREATE TABLE [dbo].[Members]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [LastName] varchar(200) NULL, 
    [FirstName] varchar(200) NULL, 
    [Patronomyc] varchar(200) NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Фамилия',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Members',
    @level2type = N'COLUMN',
    @level2name = N'LastName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Имя',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Members',
    @level2type = N'COLUMN',
    @level2name = N'FirstName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Отчество',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Members',
    @level2type = N'COLUMN',
    @level2name = N'Patronomyc'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Участники, таблица предназначена для однозначной идентификации участника',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Members',
    @level2type = NULL,
    @level2name = NULL