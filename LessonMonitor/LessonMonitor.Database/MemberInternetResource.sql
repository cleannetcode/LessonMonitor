CREATE TABLE [dbo].[MemberInternetResource]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [MemberId] INT NOT NULL, 
    [NickName] varchar(200) NULL, 
    [InternetResourseName] varchar(200) NULL, 
    [Link] varchar(500) NULL, 
    CONSTRAINT [FK_MemberInternetResource_ToMembers] FOREIGN KEY ([MemberId]) REFERENCES [Members]([Id])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Ссылка на участника',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'MemberInternetResource',
    @level2type = N'COLUMN',
    @level2name = N'MemberId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Имя на ресурсе',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'MemberInternetResource',
    @level2type = N'COLUMN',
    @level2name = N'NickName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Наименование ресурса',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'MemberInternetResource',
    @level2type = N'COLUMN',
    @level2name = N'InternetResourseName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Ссылка на участника на площадке ( для простоты поиска )',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'MemberInternetResource',
    @level2type = N'COLUMN',
    @level2name = N'Link'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'интернет ресусры, таблица предназначена для отображения списка ресурсов',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'MemberInternetResource',
    @level2type = NULL,
    @level2name = NULL