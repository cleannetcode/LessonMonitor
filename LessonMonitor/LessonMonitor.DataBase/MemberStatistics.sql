CREATE TABLE [dbo].[MemberStatistics]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Rating] INT NULL,
    [MemberId] INT NULL,
    FOREIGN KEY (MemberId) REFERENCES Members (Id) ON DELETE SET NULL,
    [HomeworkId] INT NULL,
    FOREIGN KEY (HomeworkId) REFERENCES Homeworks (Id) ON DELETE SET NULL,
    [LessonId] INT NULL,
    FOREIGN KEY (LessonId) REFERENCES Lessons (Id) ON DELETE SET NULL

    
)
