CREATE DATABASE LessonMonitorDb

USE LessonMonitorDb

--DROP DATABASE LessonMonitorDb

Select @@VERSION

CREATE TABLE Questions
(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Topic NVARCHAR(30) NOT NULL,
	Description NVARCHAR(200)
)

CREATE TABLE Students
(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Nickname NVARCHAR(20) NOT NULL,
	DateRegistration DATETIME,
	TypeAccount NVARCHAR(10) DEFAULT 'Watcher'
)

CREATE TABLE QuestionsStudents
(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	StudentId INT FOREIGN KEY REFERENCES Students(Id),
	QuestionId INT FOREIGN KEY REFERENCES Questions(Id)
)

CREATE TABLE Lessons
(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Name NVARCHAR(20) NOT NULL,
	Date DATETIME NOT NULL
)

CREATE TABLE LessonsStudents
(
	LessonId INT FOREIGN KEY REFERENCES Lessons(Id),
	StudentId INT FOREIGN KEY REFERENCES Students(Id),
	PRIMARY KEY(LessonId, StudentId)
)


CREATE TABLE Timecodes
(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Name NVARCHAR(30) NOT NULL,
	Timecode DATETIME
)

CREATE TABLE LessonsTimecodes
(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	TimecodesId INT FOREIGN KEY REFERENCES Timecodes(Id),
	LessonId INT FOREIGN KEY REFERENCES Lessons(Id)
)


INSERT INTO Students (Nickname, DateRegistration)
VALUES (N'Viktor', GETDATE()),
	   (N'Roman', GETDATE()),
	   (N'Pavel',N'2021-05-23 21:35:56.430')

INSERT INTO Lessons (name, Date)
VALUES (N'ASP.NET', N'2021-05-25 10:00:00.000'),
	   (N't-sql', N'2021-05-26 11:00:00.292'),
	   (N'dml',N'2021-05-27 11:59:59.999')

INSERT INTO StudentsLessons (StudentId, LessonId)
VALUES (1, 1),
	   (1, 2),
	   (1, 3),
	   (2, 2)

INSERT INTO Questions(Topic, Description)
VALUES (N'C#', N'How to write best code?'),
	   (N'ASP.NET', N'How i should do it?'),
	   (N'EF', N'What is migration?')

INSERT INTO QuestionsStudents
VALUES (3,1),
	   (2,1),
	   (1,3)

INSERT INTO Timecodes
VALUES (N'Start', N'2021-05-25 10:00:00.000'),
	   (N'Best practices', N'2021-05-25 11:59:00.000'),
	   (N'DRY', N'2021-05-25 12:10:00.000')

INSERT INTO LessonsTimecodes
VALUES (1,1),
	   (2,1),
	   (3,1)



SELECT *FROM Students
SELECT *FROM Lessons
SELECT *FROM Questions
SELECT *FROM Timecodes
SELECT *FROM StudentsLessons
SELECT *FROM QuestionsStudents
SELECT *FROM LessonsTimecodes 