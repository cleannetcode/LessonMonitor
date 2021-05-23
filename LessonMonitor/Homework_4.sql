CREATE DATABASE Homework_4
USE Homework_4

--Таймкода, Вопросы, Уроки, Участники
CREATE TABLE Questions
(
	ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Name NVARCHAR(30) NOT NULL
)
ALTER TABLE Questions
ADD Description NVARCHAR(200)
Exec sp_rename 'Questions.Name', 'Topic', 'COLUMN'

CREATE TABLE Students
(
	ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Nickname NVARCHAR(20) NOT NULL,
	DateRegistration DATETIME,
	TypeAccount NVARCHAR(10) DEFAULT 'Watcher'
)

CREATE TABLE QuestionStudent
(
	ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	StudentID INT FOREIGN KEY REFERENCES Students(ID),
	QuestionID INT FOREIGN KEY REFERENCES Questions(ID)
)

CREATE TABLE VisitorsLessons
(
	ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	StudentID INT FOREIGN KEY REFERENCES Students(ID),
	LessonID INT FOREIGN KEY REFERENCES Lessons(ID)
)

CREATE TABLE Lessons
(
	ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Name NVARCHAR(20) NOT NULL,
	Date DATETIME NOT NULL
)

CREATE TABLE Timecodes
(
	ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Name NVARCHAR(30) NOT NULL
)
ALTER TABLE Timecodes
ADD Timecode DATETIME

CREATE TABLE LessonsTimecodes
(
	ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	TimecodesID INT FOREIGN KEY REFERENCES Timecodes(ID),
	LessonID INT FOREIGN KEY REFERENCES Lessons(ID)
)

INSERT INTO Students (Nickname, DateRegistration)
VALUES ('Sasha1010', GETDATE()),
	   ('00Gena99', GETDATE()),
	   ('eniluck','2021-05-23 21:35:56.430')

INSERT INTO Lessons (name, Date)
VALUES ('ASP.NET', '2021-05-25 10:00:00.000'),
	   ('t-sql', '2021-05-26 11:00:00.292'),
	   ('dml','2021-05-27 11:59:59.999')

INSERT INTO VisitorsLessons (StudentID, LessonID)
VALUES (1, 1),
	   (1, 2),
	   (1, 3),
	   (2, 2)

INSERT INTO Questions(Topic, Description)
VALUES ('C#', 'Что такое for?'),
	   ('ASP.NET', '???'),
	   ('EF','Когда будем учить EF?')

INSERT INTO QuestionStudent
VALUES (3,1),
	   (2,1),
	   (1,3)

INSERT INTO Timecodes
VALUES ('Начало', '2021-05-25 10:00:00.000'),
	   ('Домашка', '2021-05-25 11:59:00.000'),
	   ('Конец','2021-05-25 12:10:00.000')

INSERT INTO LessonsTimecodes
VALUES (1,1),
	   (2,1),
	   (3,1)



SELECT *FROM Students
SELECT *FROM Lessons
SELECT *FROM Questions
SELECT *FROM Timecodes
SELECT *FROM VisitorsLessons
SELECT *FROM QuestionStudent
SELECT *FROM LessonsTimecodes