
--CREATE DATABASE LessonMonitorDb

--DROP DATABASE LessonMonitorDb

USE [LessonMonitorDb]

CREATE TABLE [Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1), 
    [Name] NVARCHAR(50) NOT NULL, 
    [Nicknames] NVARCHAR(100) NULL, 
    [Email] NVARCHAR(200) NULL, 
    --[LinksId] INT NOT NULL,
    [CreateDate] DATETIME2 DEFAULT GETDATE()
)

-- 1 к 1 (1 Links 1 Users)
CREATE TABLE [Links] 
(
    [UserId] INT NOT NULL,
    [GitHub] NVARCHAR(MAX) NULL,
    [Discord] NVARCHAR(MAX) NULL,
    [YouTube] NVARCHAR(MAX) NULL,
    [VK] NVARCHAR(MAX) NULL,
    [Facebook] NVARCHAR(MAX) NULL,
    [Twitter] NVARCHAR(MAX) NULL,
    CONSTRAINT [FK_Links_Users] FOREIGN KEY (UserId) REFERENCES Users(Id)
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

-- Промежуточная между Users и Homeworks
-- Много ко многим (Много Member много Homeworks и наоборот)
CREATE TABLE [UsersHomeworks]
(
    [Id] INT NOT NULL IDENTITY (1, 1),
    [UserId] INT NOT NULL,
    [HomeworkId] INT NOT NULL,
    [CreatedDate] DATETIME2 DEFAULT GETDATE(),
    CONSTRAINT [PK_UserId_HomeworkId] PRIMARY KEY (UserId, HomeworkId),
    CONSTRAINT [FK_UsersHomeworks_Users] FOREIGN KEY (UserId) REFERENCES Users(Id),
    CONSTRAINT [FK_UsersHomeworks_Homeworks] FOREIGN KEY (HomeworkId) REFERENCES Homeworks(Id)
)

-- 1 ко многим (1 Member много Questions)
CREATE TABLE [Questions]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
    [UserId] INT NOT NULL,
    [Discription] NVARCHAR(MAX) NOT NULL, 
    [CreatedDate] DATETIME2 DEFAULT GETDATE(),
    CONSTRAINT [FK_Questions_Users] FOREIGN KEY (UserId) REFERENCES Users(Id)
)

CREATE TABLE [Achievements]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
    [Name] NVARCHAR(200) NOT NULL,
    [Rank] NVARCHAR(100) NOT NULL
)

-- Промежуточная между Users и Achievements
-- Много ко многим (Много Achievements много Users и наоборот)
CREATE TABLE [UsersAchievements]
(
    [Id] INT NOT NULL IDENTITY (1, 1),
    [UserId] INT NOT NULL,
    [AchievementId] INT NOT NULL,
    [CreatedDate] DATETIME2 DEFAULT GETDATE(),
    CONSTRAINT [PK_UserId_AchievementId] PRIMARY KEY (UserId, AchievementId),
    CONSTRAINT [FK_UsersAchievements_Users] FOREIGN KEY (UserId) REFERENCES Users(Id),
    CONSTRAINT [FK_UsersAchievements_Achievements] FOREIGN KEY (AchievementId) REFERENCES Achievements(Id)
)

CREATE TABLE [Lessons]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [Title] NVARCHAR(200) NOT NULL, 
    [Description] NVARCHAR(1000) NULL, 
    [StartDate] DATETIME2 NULL, 
    [CreatedDate] DATETIME2 DEFAULT GETDATE()
)

CREATE TABLE [UsersLessons]
(
    [UserId] INT NOT NULL,
	[LessonId] INT NOT NULL,
	[CreatedDate] DATETIME2 DEFAULT GETDATE(),
	CONSTRAINT [PK_UserId_LessonId] PRIMARY KEY (UserId, LessonId),
	CONSTRAINT [FK_VisitedLessons_Users] FOREIGN KEY (UserId) REFERENCES Users(Id),
	CONSTRAINT [FK_VisitedLessons_Lessons] FOREIGN KEY (LessonId) REFERENCES Lessons(Id)
)

CREATE TABLE [Timecodes]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [LessonId] INT NOT NULL,
    [Timecode] DATETIME2 DEFAULT GETDATE(),
	CONSTRAINT [FK_Timecodes_Lessons] FOREIGN KEY (LessonId) REFERENCES Lessons(Id)
)