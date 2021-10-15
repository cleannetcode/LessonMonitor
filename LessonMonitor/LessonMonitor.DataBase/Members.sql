CREATE TABLE [dbo].[Members]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	[Surname] NVARCHAR(30) NOT NULL,
	[MiddleName] NVARCHAR(30),
	[Birthday] DATE NOT NULL,
	[MemberStatisticId] INT NULL,
	FOREIGN KEY (MemberStatisticId) REFERENCES MemberStatistics (Id) ON DELETE SET NULL,
	[LessonId] INT NULL,
	FOREIGN KEY (LessonId) REFERENCES Lessons (Id) ON DELETE SET NULL,
	[HomeworkId] INT NULL,
	FOREIGN KEY (HomeworkId) REFERENCES Homeworks (Id) ON DELETE SET NULL
)
