CREATE TABLE [dbo].[Members]
(
    [Id] INT NOT NULL PRIMARY KEY, 
    [FullName] NVARCHAR(50) NOT NULL, 
    [Age] INT NULL, 
    [Nicknames] NVARCHAR(MAX) NULL, 
    [Links] NVARCHAR(MAX) NULL
)
