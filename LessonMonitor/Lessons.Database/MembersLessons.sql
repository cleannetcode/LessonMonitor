CREATE TABLE [dbo].[MembersLessons]
(
	[MemberId] INT NOT NULL , 
    [LessonId] INT NOT NULL, 
    CONSTRAINT [PK_MembersLessons] PRIMARY KEY ([LessonId], [MemberId]), 
    CONSTRAINT [FK_MembersLessons_Members] FOREIGN KEY ([MemberId]) REFERENCES [Members]([Id]), 
    CONSTRAINT [FK_MembersLessons_Lessons] FOREIGN KEY ([LessonId]) REFERENCES [Lessons]([Id]) 
)
