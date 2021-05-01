CREATE TABLE [dbo].[Achievements]
(
	[Id] INT NOT NULL IDENTITY (1, 1), 
    [Name] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT [PK_Achievements] PRIMARY KEY CLUSTERED ([Id] ASC)
)
