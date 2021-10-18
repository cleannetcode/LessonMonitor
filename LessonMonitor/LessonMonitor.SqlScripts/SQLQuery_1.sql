DROP DATABASE [LessonMonitor.DataBase]

CREATE DATABASE [LessonMonitor.DataBase]

-- DROP TABLE Members

USE [LessonMonitor.DataBase]

-- CREATE TABLE Members
-- (
--     Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
--     Name NVARCHAR(50),
--     Surname NVARCHAR(50) NOT NULL,
--     MiddleName NVARCHAR(50) NULL,
--     Birthday DATE NOT NULL
-- )

-- SELECT * FROM Members

-- ALTER TABLE Members
-- ALTER COLUMN Name NVARCHAR(50) NOT NULL



CREATE TABLE Members
(
    Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    MemberStatisticId INT NULL,
    Name NVARCHAR(50),
    Surname NVARCHAR(50) NOT NULL,
    MiddleName NVARCHAR(50) NULL,
    Birthday DATE NOT NULL
)

CREATE TABLE Lessons
(
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL,
    Description NVARCHAR(1000),
    StartDateTime DATETIME2 NOT NULL, 
    EndtDateTime DATETIME2 NOT NULL
)

CREATE TABLE Homeworks
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
    LessonId INT NULL, 
    Name NVARCHAR(50) NULL, 
    Description NVARCHAR(MAX) NULL,
    CONSTRAINT FK_Homeworks_Lessons FOREIGN KEY (LessonId) REFERENCES Lessons(Id)
)

CREATE TABLE Skills
(
    Id INT NOT NULL PRIMARY KEY,
	Name NVARCHAR(20) NOT NULL
)

CREATE TABLE LessonsSkills
(
    LessonId INT NOT NULL, 
    SkillId INT NOT NULL, 
    CONSTRAINT PK_LessonId_SkillId PRIMARY KEY (LessonId,SkillId),
    CONSTRAINT FK_LessonsSkills_Skills FOREIGN KEY (SkillId) REFERENCES Skills(Id),
    CONSTRAINT FK_LessonsSkills_Lessonrs FOREIGN KEY (LessonId) REFERENCES Lessons(Id)
)

CREATE TABLE MemberStatistics
(
    LessonId INT NOT NULL, 
    MemberId INT NOT NULL,
    Rating INT NULL,
    CONSTRAINT PK_LessonId_MemberId PRIMARY KEY (LessonId,MemberId),
    CONSTRAINT FK_MemberStatistics_Members FOREIGN KEY (MemberId) REFERENCES Members(Id),
    CONSTRAINT FK_MemberStatistics_Lessonrs FOREIGN KEY (LessonId) REFERENCES Lessons(Id)
)

CREATE TABLE VisitedLessons
( 
    MemberId INT NOT NULL,
    LessonId INT NOT NULL,
    CONSTRAINT PK_MemberId_LessonId PRIMARY KEY (MemberId,LessonId),
    CONSTRAINT FK_VisitedLessons_Members FOREIGN KEY (MemberId) REFERENCES Members(Id),
    CONSTRAINT FK_VisitedLessons_Lessonrs FOREIGN KEY (LessonId) REFERENCES Lessons(Id)
)
DROP TABLE VisitedLessons
