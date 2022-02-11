CREATE TABLE [dbo].[Member]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Age] INT NULL, 
    [NickNames] NVARCHAR(MAX) NULL
)
