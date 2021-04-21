CREATE TABLE [dbo].[HomeWorks]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [MemberId] INT NOT NULL, 
    [LessonId] INT NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(), 
    [UpdatedAt] DATETIME NOT NULL DEFAULT GETDATE(), 
    [Link] NVARCHAR(200) NOT NULL, 
    [Mark] INT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_HomeWorks_Lessons] FOREIGN KEY ([LessonId]) REFERENCES [Lessons]([Id]), 
    CONSTRAINT [FK_HomeWorks_Members] FOREIGN KEY ([MemberId]) REFERENCES [Members]([Id])
)
