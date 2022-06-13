CREATE TABLE [dbo].[Topics]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [Skills] NCHAR(10) NULL
)
