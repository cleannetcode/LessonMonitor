CREATE TABLE [dbo].[RoadMap]
(
	[Id] INT NOT NULL, 
    [Member] INT NOT NULL, 
    [Lesson] INT NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [Create] DATETIME NOT NULL, 
    [Ending] DATETIME NULL, 
    CONSTRAINT [PK_RoadMap] PRIMARY KEY ([Id]) 
)