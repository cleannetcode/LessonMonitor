CREATE TABLE [dbo].[Skills]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NCHAR(10) NOT NULL, 
    [Description] NVARCHAR(50) NULL, 
    [Difficulty] NCHAR(10) NULL
)
