﻿CREATE TABLE [dbo].[Topics]
(
	[TopicId] INT NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	[LessonId] INT NOT NULL
)
