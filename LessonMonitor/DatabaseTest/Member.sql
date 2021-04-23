CREATE TABLE [dbo].[Member]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FullName] NVARCHAR(50) NOT NULL, 
    [Age] INT NULL, 
    [Link] NVARCHAR(MAX) NULL
)
