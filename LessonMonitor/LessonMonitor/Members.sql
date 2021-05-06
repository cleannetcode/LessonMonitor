CREATE TABLE [dbo].[Members]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [SecondName] NVARCHAR(50) NOT NULL, 
    [Age] INT NOT NULL, 
    [NickName] NVARCHAR(50) NULL,
    UNIQUE(FirstName, SecondName)
)
