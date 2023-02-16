DROP DATABASE IF EXISTS [LessonMonitor.Database]
GO

CREATE DATABASE [LessonMonitor.Database]
GO

USE [LessonMonitor.Database]

CREATE TABLE [dbo].[Topics]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(100) NOT NULL
)

CREATE TABLE [dbo].[Members]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [Name] NVARCHAR(100) NOT NULL
)

CREATE TABLE [dbo].[Lessons]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(1000) NOT NULL, 
    [Scheduled] DATETIME NOT NULL
)

CREATE TABLE [dbo].[Questions]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [Text] NVARCHAR(MAX) NOT NULL, 
    [Created] DATETIME NOT NULL, 
    [LessonId] INT NOT NULL, 
    [MemberId] INT NOT NULL, 
    CONSTRAINT [FK_QuestionsToLessons] FOREIGN KEY ([LessonId]) REFERENCES [Lessons]([Id])
    ON DELETE CASCADE, 
    CONSTRAINT [FK_QuestionsToMembers] FOREIGN KEY ([MemberId]) REFERENCES [Members]([Id])
    ON DELETE NO ACTION
)

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

GO
