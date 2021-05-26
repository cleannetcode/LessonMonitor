
--CREATE DATABASE LessonMonitorDb

--DROP DATABASE LessonMonitorDb

USE [LessonMonitorDb]

CREATE TABLE [Members]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1), 
    [Name] NVARCHAR(50) NOT NULL, 
    [Nicknames] NVARCHAR(100) NULL, 
    [Email] NVARCHAR(200) NULL, 
    --[LinksId] INT NOT NULL,
    [CreateDate] DATETIME2 DEFAULT GETDATE()
)

-- 1 к 1 (1 Links 1 Members)
CREATE TABLE [Links] 
(
    [MemberId] INT NOT NULL,
    [GitHub] NVARCHAR(MAX) NULL,
    [Discord] NVARCHAR(MAX) NULL,
    [YouTube] NVARCHAR(MAX) NULL,
    [VK] NVARCHAR(MAX) NULL,
    [Facebook] NVARCHAR(MAX) NULL,
    [Twitter] NVARCHAR(MAX) NULL,
    CONSTRAINT [FK_Links_Members] FOREIGN KEY (MemberId) REFERENCES Members(Id)
)

CREATE TABLE [Topics]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1), 
    [Theme] NVARCHAR(200) NULL
)

-- 1 ко Многим (1 Topics много Homeworks)
CREATE TABLE [Homeworks]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
    [TopicId] INT NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    [Link] NVARCHAR(MAX) NULL,
    [Grade] INT NULL, 
    [CreateDate] DATETIME2 DEFAULT GETDATE(),
    CONSTRAINT [FK_Homeworks_Topics] FOREIGN KEY (TopicId) REFERENCES Topics(Id)
)

-- Промежуточная между Members и Homeworks
-- Много ко многим (Много Member много Homeworks и наоборот)
CREATE TABLE [MembersHomeworks]
(
    [Id] INT NOT NULL IDENTITY (1, 1),
    [MemberId] INT NOT NULL,
    [HomeworkId] INT NOT NULL,
    [CreatedDate] DATETIME2 DEFAULT GETDATE(),
    CONSTRAINT [PK_MemberId_HomeworkId] PRIMARY KEY (MemberId, HomeworkId),
    CONSTRAINT [FK_MembersHomeworks_Members] FOREIGN KEY (MemberId) REFERENCES Members(Id),
    CONSTRAINT [FK_MembersHomeworks_Homeworks] FOREIGN KEY (HomeworkId) REFERENCES Homeworks(Id)
)

-- 1 ко многим (1 Member много Questions)
CREATE TABLE [Questions]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
    [MemberId] INT NOT NULL,
    [Discription] NVARCHAR(MAX) NOT NULL, 
    [CreatedDate] DATETIME2 DEFAULT GETDATE(),
    CONSTRAINT [FK_Questions_Members] FOREIGN KEY (MemberId) REFERENCES Members(Id)
)

CREATE TABLE [Achievements]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
    [Name] NVARCHAR(200) NOT NULL,
    [Rank] NVARCHAR(100) NOT NULL
)

-- Промежуточная между Members и Achievements
-- Много ко многим (Много Achievements много Members и наоборот)
CREATE TABLE [MembersAchievements]
(
    [Id] INT NOT NULL IDENTITY (1, 1),
    [MemberId] INT NOT NULL,
    [AchievementId] INT NOT NULL,
    [CreatedDate] DATETIME2 DEFAULT GETDATE(),
    CONSTRAINT [PK_MemberId_AchievementId] PRIMARY KEY (MemberId, AchievementId),
    CONSTRAINT [FK_MembersAchievements_Members] FOREIGN KEY (MemberId) REFERENCES Members(Id),
    CONSTRAINT [FK_MembersAchievements_Achievements] FOREIGN KEY (AchievementId) REFERENCES Achievements(Id)
)

CREATE TABLE [Lessons]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [Title] NVARCHAR(200) NOT NULL, 
    [Description] NVARCHAR(1000) NULL, 
    [StartDate] DATETIME2 NULL, 
    [CreatedDate] DATETIME2 DEFAULT GETDATE()
)

CREATE TABLE [MembersLessons]
(
    [MemberId] INT NOT NULL,
	[LessonId] INT NOT NULL,
	[CreatedDate] DATETIME2 DEFAULT GETDATE(),
	CONSTRAINT [PK_MemberId_LessonId] PRIMARY KEY (MemberId, LessonId),
	CONSTRAINT [FK_VisitedLessons_Members] FOREIGN KEY (MemberId) REFERENCES Members(Id),
	CONSTRAINT [FK_VisitedLessons_Lessons] FOREIGN KEY (LessonId) REFERENCES Lessons(Id)
)

CREATE TABLE [Timecodes]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [LessonId] INT NOT NULL,
    [Timecode] DATETIME2 DEFAULT GETDATE(),
	CONSTRAINT [FK_Timecodes_Lessons] FOREIGN KEY (LessonId) REFERENCES Lessons(Id)
)