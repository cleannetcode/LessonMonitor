CREATE TABLE [dbo].[Skills]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Position] NVARCHAR(50) NULL, 
    [Subskills] NVARCHAR(MAX) NULL
)
