CREATE TABLE [dbo].[Skils]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Weight] INT NULL, 
    [Subskills] NVARCHAR(MAX) NULL
)
