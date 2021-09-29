CREATE DATABASE Homework_2
USE Homework_2

--DROP DATABASE Homework_2

CREATE TABLE [dbo].[Lessons]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(20) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [Duration] TIMESTAMP NOT NULL, 
    [StartDate] DATETIME NULL, 
    [EndDate] DATETIME NULL
)

CREATE TABLE [dbo].[Homeworks]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(20) NOT NULL, 
    [Body] NVARCHAR(MAX) NULL, 
    [LessonId] INT NULL FOREIGN KEY REFERENCES [dbo].[Lessons](Id)
)

CREATE TABLE [dbo].[Members]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [NickName] NVARCHAR(20) NOT NULL, 
    [FullName] NVARCHAR(100) NOT NULL, 
    [Age] INT NULL, 
    [GitHubLink] NVARCHAR(50) NULL
)

CREATE TABLE [dbo].[MemberStatistics]
(
	[Id] INT NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES [dbo].[Members](Id), 
    [NumberLessonsAttended] INT NULL, 
    [NumberOfPasses] INT NULL, 
)

CREATE TABLE [dbo].[MembersLessons]
(
	[MemberId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Members](Id), 
    [LessonId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Lessons](Id), 
    PRIMARY KEY ([MemberId], [LessonId])
)

CREATE TABLE [dbo].[Questions]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(50) NOT NULL, 
    [Body] NVARCHAR(MAX) NULL, 
    [Status] NCHAR(20) NULL,
    [MemberId] INT NULL FOREIGN KEY REFERENCES [dbo].[Members](Id)
)

CREATE TABLE [dbo].[Skills]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(20) NOT NULL, 
    [Level] NVARCHAR(20) NULL, 
    [MemberId] INT NULL FOREIGN KEY REFERENCES [dbo].[Members](Id)
)