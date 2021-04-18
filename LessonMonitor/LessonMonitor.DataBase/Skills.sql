CREATE TABLE [dbo].[Skills]
(
    [Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL,
    [Weight] INT NULL, 
    [Subskills] NVARCHAR(MAX) NULL, 
)
