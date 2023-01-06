CREATE TABLE [dbo].[LessonTopics]
(
	[LessonId] INT NOT NULL, 
    [TopicId] INT NOT NULL,
	PRIMARY KEY ([LessonId], [TopicId]),
	FOREIGN KEY ([LessonId]) REFERENCES [Lessons]([Id])
	ON DELETE CASCADE,
	FOREIGN KEY ([TopicId]) REFERENCES [Topics]([Id])
	ON DELETE CASCADE
)
