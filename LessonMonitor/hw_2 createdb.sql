CREATE DATABASE Homework_2
USE Homework_2

CREATE TABLE Members
(
	ID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	UserName NVARCHAR(30) NOT NULL,
	Age INT,
	Link NVARCHAR(MAX)
)

CREATE TABLE MembersLessons
(
	ID INT,
	MemberID INT,
	LessonID INT
	CONSTRAINT [FK_MembersLessons_To_Members] FOREIGN KEY (MemberID) REFERENCES Members (ID),
	CONSTRAINT [FK_MembersLessons_To_Lessons] FOREIGN KEY (LessonID) REFERENCES Lessons (ID)
)
CREATE TABLE Lessons
(
	ID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name NVARCHAR(20) NOT NULL,
	Topic NVARCHAR(20) NOT NULL,
	TimeCodes NVARCHAR(50)
)

CREATE TABLE Questions
(
	MemberID INT NOT NULL,	
	MemberName NVARCHAR(20) NOT NULL,
	Topic NVARCHAR(20),
	Question NVARCHAR(MAX) NOT NULL
	CONSTRAINT [FK_Questions_To_Members] FOREIGN KEY (MemberID) REFERENCES Members (ID)
)

CREATE TABLE TimeCodes
(
	LessonID INT NOT NULL,
	UserName NVARCHAR(20) NOT NULL,
	Name NVARCHAR(20) NOT NULL,
	TimeCode FLOAT
	CONSTRAINT [FK_TimeCodes_To_Lessons] FOREIGN KEY (LessonID) REFERENCES Lessons (ID)
)

CREATE TABLE Topics
(
	ID INT NOT NULL,
	Name NVARCHAR(20) NOT NULL,
	Difficult BIT CHECK(Difficult >= 0 AND Difficult <= 10) DEFAULT 0,
	UsefulLink NVARCHAR(50)
	CONSTRAINT [FK_Topics_To_Lessons] FOREIGN KEY (ID) REFERENCES Lessons (ID)
)

-- SELECT * FROM Members
-- SELECT * FROM Lessons
-- SELECT * FROM Questions
-- SELECT * FROM Timecodes
-- SELECT * FROM Topics

-- INSERT INTO Members (UserName)
-- VALUES ('ARTEM')
-- INSERT INTO Members (UserName)
-- VALUES ('ROMA')

-- INSERT INTO Questions (MemberID, MemberName, Question)
-- VALUES (1, 'ARTEM', 'question')
-- INSERT INTO Questions (MemberID, MemberName, Question)
-- VALUES (1, 'ARTEM', 'question2')
-- INSERT INTO Questions (MemberID, MemberName, Question)
-- VALUES (2, 'ROMA', 'question3')

-- INSERT INTO Lessons (Name, Topic)
-- VALUES ('sql', 't-sql')

-- INSERT INTO TimeCodes (LessonID, UserName, Name, TimeCode)
-- VALUES (1, 'ARTEM', 'Begin', 0.03)
-- INSERT INTO TimeCodes (LessonID, UserName, Name, TimeCode)
-- VALUES (1, 'ROMA', 'End', 2.45)

-- INSERT INTO Topics (ID, Name)
-- VALUES (1, 't-sql')

-- DROP TABLE Members
-- DROP TABLE Lessons
-- DROP TABLE Questions
-- DROP TABLE Topics
-- DROP TABLE TimeCodes
-- DROP DATABASE Homework_2