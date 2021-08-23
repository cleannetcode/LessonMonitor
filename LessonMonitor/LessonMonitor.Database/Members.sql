CREATE TABLE [dbo].Members
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FullName] NVARCHAR(50) NOT NULL, 
    [Age] INT NULL,
    [Nickname] NVARCHAR(MAX) NULL, 
    [Phone] NVARCHAR(20) NULL, 
    [Email] NVARCHAR(50) NULL
)
