CREATE TABLE [dbo].[Homeworks]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(MAX) NULL,
    [LessonId] INT NULL ,
    FOREIGN KEY (LessonId) REFERENCES Lessons (Id) ON DELETE SET NULL
)
