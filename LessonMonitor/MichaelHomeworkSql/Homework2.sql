USE master

ALTER DATABASE [HomeWork2Db] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
DROP DATABASE [HomeWork2Db] 

CREATE DATABASE HomeWork2Db

USE HomeWork2Db

CREATE TABLE Member (
    Id INT PRIMARY KEY IDENTITY,
    Age INT NOT NULL,
    Name NVARCHAR(50) NOT NULL,
)

CREATE TABLE Account (
    MemberId INT PRIMARY KEY,
    NickName NVARCHAR(50) NOT NULL,
    Type NVARCHAR(50) NOT NULL,
    CONSTRAINT FK_Account_To_Member FOREIGN KEY (MemberId) REFERENCES Member (Id),
)

CREATE TABLE Lesson (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(50),
)

CREATE TABLE CheckMemberInLesson (
    MemberId Int,
    LessonId Int,
    CONSTRAINT PK_Member_Lesson PRIMARY KEY (MemberId, LessonId),
    CONSTRAINT FK_Check_To_Member FOREIGN KEY (MemberId) REFERENCES Member (Id),
    CONSTRAINT FK_Check_To_Lesson FOREIGN KEY (LessonId) REFERENCES Lesson (Id)
)

CREATE Table TimeCode (
    Id INT PRIMARY KEY IDENTITY,
    TimePosition TIMESTAMP NOT NULL,
    Name NVARCHAR(50) NOT NULL,
    LessonId INT NOT NULL,
    MemberId INT NOT NULL,
    CONSTRAINT FK_TimeCode_To_Lesson FOREIGN KEY (LessonId) REFERENCES Lesson (Id),
    CONSTRAINT FK_TimeCode_To_Member FOREIGN KEY (MemberId) REFERENCES Member (Id)
)


CREATE Table Question (
    Id INT PRIMARY KEY IDENTITY,
    Question NVARCHAR(50) NOT NULL,
    LessonId INT NOT NULL,
    MemberId INT NOT NULL,
    CONSTRAINT FK_Question_To_Lesson FOREIGN KEY (LessonId) REFERENCES Lesson (Id),
    CONSTRAINT FK_Question_To_Member FOREIGN KEY (MemberId) REFERENCES Member (Id)
)