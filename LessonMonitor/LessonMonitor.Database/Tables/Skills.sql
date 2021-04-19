CREATE TABLE [dbo].[Skills]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(20) NOT NULL, 
    [ParentId] INT NULL
)
