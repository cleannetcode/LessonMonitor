
--CREATE DATABASE LessonMonitorDb

--DROP DATABASE LessonMonitorDb

USE LessonMonitorTestDb

--DROP TABLE Members

CREATE TABLE [Members] (
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(50),
	[CreatedDate] DATETIME2 DEFAULT GETDATE()
)

CREATE TABLE [MemberAccounts]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
	[MemberId] INT NOT NULL,
	[UserName] NVARCHAR(50) NOT NULL,
	[Link] NVARCHAR(200) NULL, 
    [CreatedDate] DATETIME2 DEFAULT GETDATE(),
	CONSTRAINT [FK_MemberAccounts_Members] FOREIGN KEY (MemberId) REFERENCES Members(Id)
)

CREATE TABLE [Lessons]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [Title] NVARCHAR(200) NOT NULL, 
    [Description] NVARCHAR(1000) NULL, 
    [StartDate] DATETIME2 NULL, 
    [CreatedDate] DATETIME2 DEFAULT GETDATE()
)

CREATE TABLE [VisitedLessons]
(
    [MemberId] INT NOT NULL,
	[LessonId] INT NOT NULL,
	[CreatedDate] DATETIME2 DEFAULT GETDATE(),
	CONSTRAINT [PK_MemberId_LessonId] PRIMARY KEY (MemberId, LessonId),
	CONSTRAINT [FK_VisitedLessons_Members] FOREIGN KEY (MemberId) REFERENCES Members(Id),
	CONSTRAINT [FK_VisitedLessons_Lessons] FOREIGN KEY (LessonId) REFERENCES Lessons(Id)
)

INSERT Members (Name)
VALUES ('Max')

INSERT MemberAccounts (MemberId, UserName)
VALUES (1, 'GitHub')

INSERT Lessons (Title, [Description], StartDate)
VALUES (N'Знакомимся с t-sql', 'создаем схему БД', GETDATE())

INSERT VisitedLessons (MemberId, LessonId)
VALUES (1, 1)

SELECT * FROM Members m
INNER JOIN MemberAccounts ma on ma.MemberId = m.Id
INNER JOIN VisitedLessons vs on vs.LessonId = m.Id
INNER JOIN Lessons les on les.Id = vs.LessonId