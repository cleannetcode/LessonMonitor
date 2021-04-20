CREATE TABLE [dbo].[Questions]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [CreateDate] DATETIME2 NULL, 
    [TopicId] INT NOT NULL, 
    [MemberId] INT NOT NULL
)
