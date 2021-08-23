CREATE TABLE [dbo].Homeworks
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MemberId] INT NOT NULL, 
    [LessonId] INT NOT NULL, 
    [Link] NVARCHAR(MAX) NOT NULL, 
    FOREIGN KEY (MemberId) REFERENCES Members(Id),
    FOREIGN KEY (LessonId) REFERENCES Lessons(Id)
)
