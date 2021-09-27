CREATE TABLE [dbo].[Members]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [NickName] NVARCHAR(20) NOT NULL, 
    [FullName] NVARCHAR(100) NOT NULL, 
    [Age] INT NULL, 
    [GitHubLink] NVARCHAR(50) NULL
)

