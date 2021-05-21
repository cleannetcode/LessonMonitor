CREATE TABLE [dbo].[users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [nickname] NVARCHAR(50) NOT NULL, 
    [dataRegistration] DATETIME NOT NULL, 
    [typeAccount] INT NOT NULL, 
    CONSTRAINT [FK_users_accounttype] FOREIGN KEY ([typeAccount]) REFERENCES accounttypes(id)
)
