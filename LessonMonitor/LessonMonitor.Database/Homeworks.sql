CREATE TABLE [dbo].[Homeworks]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(20) NOT NULL, 
    [Body] NVARCHAR(MAX) NULL, 
    [Mark] INT NULL
)
