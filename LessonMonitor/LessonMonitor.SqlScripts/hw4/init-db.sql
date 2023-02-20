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

CREATE TABLE [dbo].[LessonTopics]
(
	[LessonId] INT NOT NULL, 
    [TopicId] INT NOT NULL,
	PRIMARY KEY ([LessonId], [TopicId]),
	FOREIGN KEY ([LessonId]) REFERENCES [Lessons]([Id]),
	FOREIGN KEY ([TopicId]) REFERENCES [Topics]([Id])
)

CREATE TABLE [dbo].[CommentTypes]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY,
	[Type] NVARCHAR(200) NOT NULL
)

CREATE TABLE [dbo].[Comments]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [Text] NVARCHAR(MAX) NOT NULL, 
    [Created] DATETIME NOT NULL, 
	[CommentTypeId] INT NOT NULL,
    [LessonId] INT NOT NULL, 
    [MemberId] INT NOT NULL, 
	CONSTRAINT [FK_CommentsToCommentTypes] FOREIGN KEY ([CommentTypeId]) REFERENCES [CommentTypes]([Id]),
    CONSTRAINT [FK_CommentsToLessons] FOREIGN KEY ([LessonId]) REFERENCES [Lessons]([Id]), 
    CONSTRAINT [FK_CommentsToMembers] FOREIGN KEY ([MemberId]) REFERENCES [Members]([Id])
)

GO