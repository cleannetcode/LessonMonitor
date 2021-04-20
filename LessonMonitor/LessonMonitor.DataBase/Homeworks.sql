CREATE TABLE [dbo].[Homeworks]
(
	[Id] INT NOT NULL PRIMARY KEY  IDENTITY (1, 1), 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [Grade] INT NULL, 
    [CreateDate] DATETIME2 NULL, 
    [TopicId] INT NOT NULL, 
    [MemberId] INT NOT NULL, 
)
