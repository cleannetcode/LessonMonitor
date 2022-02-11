CREATE TABLE [dbo].[Lesson]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NULL, 
    [TopicId] INT NULL, 
    [Url] NVARCHAR(MAX) NULL
)
