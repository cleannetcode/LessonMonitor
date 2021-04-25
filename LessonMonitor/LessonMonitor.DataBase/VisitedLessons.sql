CREATE TABLE [dbo].[VisitedLessons]
(
    [MemberId] INT NOT NULL, 
    [LessonId] INT NOT NULL, 
    PRIMARY KEY ([LessonId], [MemberId]), 
    FOREIGN KEY (LessonId) REFERENCES Lessons(Id),
    FOREIGN KEY (MemberId) REFERENCES Members(Id)
)
