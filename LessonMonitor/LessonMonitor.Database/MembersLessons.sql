CREATE TABLE [dbo].[MembersLessons]
(
	[MemberId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Members](Id), 
    [LessonId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Lessons](Id), 
    PRIMARY KEY ([MemberId], [LessonId])
)
