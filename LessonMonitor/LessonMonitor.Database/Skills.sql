CREATE TABLE [dbo].[Skills]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(100) NOT NULL, 
    [Weight] INT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [MemberId] INT NOT NULL FOREIGN KEY REFERENCES Members(Id)
)
