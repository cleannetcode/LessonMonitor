CREATE TABLE [dbo].[Achievements]
(
	[Id] INT NOT NULL PRIMARY KEY  IDENTITY (1, 1), 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [MemberId] INT NOT NULL,
)
