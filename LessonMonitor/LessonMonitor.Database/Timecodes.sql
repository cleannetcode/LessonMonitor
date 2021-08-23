CREATE TABLE [dbo].Timecodes
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NULL, 
    [LessonId] INT NOT NULL, 
    [Time] INT NOT NULL, 
    FOREIGN KEY (LessonId) REFERENCES Lessons(Id)
    
    
)
