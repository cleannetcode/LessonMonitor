CREATE TABLE [dbo].[Members]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NCHAR(30) NOT NULL, 
    [SecondName] NCHAR(30) NOT NULL, 
    [Age] INT NOT NULL, 
    [NickName] NCHAR(25) NULL,
    UNIQUE(FirstName, SecondName)
)
