USE master

DROP DATABASE HomeWork4Db

CREATE DATABASE HomeWork4Db

USE HomeWork4Db

CREATE TABLE Member (
    Id INT PRIMARY KEY IDENTITY(1,1),
    NickName NVARCHAR(50) NOT NULL,
    RegistrationDate DATETIME2 NOT NULL,
    AcountType NVARCHAR(50) NOT NULL,
)

CREATE TABLE Lesson (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL,
    CreateDate DATETIME2 NOT NULL,
)

CREATE TABLE MemberToLesson (
    Id Int PRIMARY KEY IDENTITY(1,1),
    LessonId INT NOT NULL,
    MemberId INT NOT NULL,
    CONSTRAINT FK_ML_To_Member FOREIGN KEY (MemberId) REFERENCES Member (Id),
    CONSTRAINT FK_ML_To_Lesson FOREIGN KEY (LessonId) REFERENCES Lesson (Id),
)

CREATE TABLE Question (
    Id Int PRIMARY KEY IDENTITY(1,1),
    MemberId INT NOT NULL,
    LessonId INT NOT NULL,
    Text NVARCHAR(100) NOT NULL,
    CONSTRAINT FK_Q_To_Member FOREIGN KEY (MemberId) REFERENCES Member (Id),
    CONSTRAINT FK_Q_To_Lesson FOREIGN KEY (LessonId) REFERENCES Lesson (Id),
)

CREATE TABLE TimeCode(
    Id Int PRIMARY KEY IDENTITY(1,1),
    MemberId INT NOT NULL,
    LessonId INT NOT NULL,
    Name NVARCHAR(50) NOT NULL,
    Time TIME NOT NULL,
    CONSTRAINT FK_TC_To_Member FOREIGN KEY (MemberId) REFERENCES Member (Id),
    CONSTRAINT FK_TC_To_Lesson FOREIGN KEY (LessonId) REFERENCES Lesson (Id),
)

INSERT INTO Member (NickName, RegistrationDate, AcountType)
VALUES (N'Michael Kharchenko', GETDATE(), N'YouTube'),
        (N'Katerina Sorokolat', GETDATE(), N'YouTube'),
        (N'Veronika Ogurtsova', GETDATE(), N'YouTube'),
        (N'Serhii Deinik', GETDATE(), N'YouTube'),
        (N'Fedor Kharchenko', GETDATE(), N'YouTube'),
        (N'Tim Vdovychenko', GETDATE(), N'YouTube'),
        (N'Gleb Slipchenko', GETDATE(), N'YouTube'),
        (N'Denis Rudenko', GETDATE(), N'YouTube'),
        (N'Dima Reznik', GETDATE(), N'YouTube')

SELECT * FROM Member

INSERT INTO Lesson (Name, CreateDate)
VALUES (N'T-SQL 1', GETDATE()),
        (N'T-SQL 2', GETDATE()),
        (N'T-SQL 3', GETDATE()),
        (N'T-SQL 4', GETDATE()),
        (N'ASP.NET 1', GETDATE()),
        (N'ASP.NET 2', GETDATE()),
        (N'ASP.NET 3', GETDATE()),
        (N'ASP.NET 4', GETDATE())

SELECT * FROM Lesson

INSERT INTO MemberToLesson (LessonId, MemberId)
SELECT TOP 6 1, Id FROM Member

INSERT INTO MemberToLesson (LessonId, MemberId)
SELECT TOP 4 2, Id FROM Member
ORDER BY Id DESC

INSERT INTO MemberToLesson (LessonId, MemberId)
SELECT TOP 5 3, Id FROM Member
ORDER BY NickName DESC

INSERT INTO MemberToLesson (LessonId, MemberId)
SELECT TOP 2 4, Id FROM Member
ORDER BY NickName DESC

INSERT INTO MemberToLesson (LessonId, MemberId)
SELECT 5, Id FROM Member
WHERE NickName LIKE N'%Kha%'

INSERT INTO MemberToLesson (LessonId, MemberId)
SELECT 6, Id FROM Member
WHERE NickName LIKE N'D%'

INSERT INTO MemberToLesson (LessonId, MemberId)
SELECT 7, Id FROM Member
WHERE NickName LIKE N'%ko'

INSERT INTO MemberToLesson (LessonId, MemberId)
SELECT 8, Id FROM Member
WHERE Id IN (4,6,7)

SELECT * FROM MemberToLesson

INSERT INTO Question (MemberId, LessonId, Text)
SELECT TOP 5 m.Id, l.Id, N'Як справи?' FROM Member m
INNER JOIN MemberToLesson ml ON m.Id = ml.MemberId
INNER JOIN Lesson l ON l.Id = ml.LessonId
WHERE l.Id IN (1,5,7)

INSERT INTO Question (MemberId, LessonId, Text)
SELECT TOP 2 m.Id, l.Id, N'Як почати програмувати?' FROM Member m
INNER JOIN MemberToLesson ml ON m.Id = ml.MemberId
INNER JOIN Lesson l ON l.Id = ml.LessonId
WHERE l.Id IN (1,2,3,5,7)
ORDER BY m.Id DESC

INSERT INTO Question (MemberId, LessonId, Text)
SELECT TOP 7 m.Id, l.Id, N'Що тут коється?'  FROM Member m
INNER JOIN MemberToLesson ml ON m.Id = ml.MemberId
INNER JOIN Lesson l ON l.Id = ml.LessonId
WHERE l.Id IN (1,4,6,7)
ORDER BY NickName DESC

INSERT INTO Question (MemberId, LessonId, Text)
SELECT TOP 6 m.Id, l.Id, N'А українською курс є?' FROM Member m
INNER JOIN MemberToLesson ml ON m.Id = ml.MemberId
INNER JOIN Lesson l ON l.Id = ml.LessonId
WHERE l.Id IN (2,4,7)
ORDER BY NickName DESC

INSERT INTO Question (MemberId, LessonId, Text)
SELECT m.Id, l.Id, N'Де взяти дані для заповнення бази?' FROM Member m
INNER JOIN MemberToLesson ml ON m.Id = ml.MemberId
INNER JOIN Lesson l ON l.Id = ml.LessonId
WHERE l.Id IN (1,6,8) AND NickName LIKE N'%o%'

INSERT INTO Question (MemberId, LessonId, Text)
SELECT m.Id, l.Id, N'Мені єдиному нудно заповнювати базу якимись данними?' FROM Member m
INNER JOIN MemberToLesson ml ON m.Id = ml.MemberId
INNER JOIN Lesson l ON l.Id = ml.LessonId
WHERE l.Id IN (2,5,6,8) AND NickName LIKE N'%i%'

INSERT INTO Question (MemberId, LessonId, Text)
SELECT m.Id, l.Id, N'Не знаю, що ще запитати?' FROM Member m
INNER JOIN MemberToLesson ml ON m.Id = ml.MemberId
INNER JOIN Lesson l ON l.Id = ml.LessonId
WHERE l.Id IN (1,3,4,6,8) AND NickName LIKE N'%e%'

INSERT INTO Question (MemberId, LessonId, Text)
SELECT m.Id, l.Id, N'Цього достатньо?' FROM Member m
INNER JOIN MemberToLesson ml ON m.Id = ml.MemberId
INNER JOIN Lesson l ON l.Id = ml.LessonId
WHERE l.Id IN (1,5,6,7) AND m.Id IN (2,3,4,6,7)

SELECT * FROM Question

INSERT INTO TimeCode (MemberId, LessonId, Name, Time)
SELECT m.Id, l.Id, N'розбір домашки', '0:0:0' FROM Member m
INNER JOIN MemberToLesson ml ON m.Id = ml.MemberId
INNER JOIN Lesson l ON l.Id = ml.LessonId
WHERE m.Id IN (2,3,4,6,7)


INSERT INTO TimeCode (MemberId, LessonId, Name, Time)
SELECT m.Id, l.Id, N'домашка', '3:10:5' FROM Member m
INNER JOIN MemberToLesson ml ON m.Id = ml.MemberId
INNER JOIN Lesson l ON l.Id = ml.LessonId
WHERE m.Id IN (1,5,7)


INSERT INTO TimeCode (MemberId, LessonId, Name, Time)
SELECT m.Id, l.Id, N'перерва', '1:13:45' FROM Member m
INNER JOIN MemberToLesson ml ON m.Id = ml.MemberId
INNER JOIN Lesson l ON l.Id = ml.LessonId
WHERE m.Id IN (2,6,7) AND l.Id IN (3,4,6)


INSERT INTO TimeCode (MemberId, LessonId, Name, Time)
SELECT m.Id, l.Id, N'перерва', '2:43:36' FROM Member m
INNER JOIN MemberToLesson ml ON m.Id = ml.MemberId
INNER JOIN Lesson l ON l.Id = ml.LessonId
WHERE m.Id IN (2,3,4,7) AND l.Id IN (2,5,8)

SELECT * FROM TimeCode

SELECT m.NickName, Count(q.Id) as N'Кількість питань', Count(tc.Id) as N'Кількість таймкодів', Count(ml.LessonId) as N'Кількість відвіданих курсів'  FROM Member m
LEFT JOIN MemberToLesson ml ON m.Id = ml.MemberId
LEFT JOIN Question q ON m.Id = q.MemberId
LEFT JOIN TimeCode tc ON m.Id = tc.MemberId
GROUP BY m.NickName

SELECT l.Name, Count(q.Id) as N'Кількість питань', Count(tc.Id) as N'Кількість таймкодів', Count(ml.MemberId) as N'Кількість студентів на курсі'  FROM Lesson l
LEFT JOIN MemberToLesson ml ON l.Id = ml.LessonId
LEFT JOIN Question q ON l.Id = q.LessonId
LEFT JOIN TimeCode tc ON l.Id = tc.LessonId
GROUP BY l.Name, l.CreateDate
ORDER BY l.CreateDate

SELECT * FROM Member

UPDATE Member
SET NickName = N'bot'
WHERE Id = 2

SELECT * FROM Member

DELETE MemberToLesson
WHERE MemberId In (
    SELECT Id FROM Member
    WHERE NickName LIKE '%bot%'
    )

DELETE Question
WHERE MemberId In (
    SELECT Id FROM Member
    WHERE NickName LIKE '%bot%'
    )

DELETE TimeCode
WHERE MemberId In (
    SELECT Id FROM Member
    WHERE NickName LIKE '%bot%'
    )

DELETE Member
WHERE NickName LIKE '%bot%'

SELECT * FROM Member


SELECT  m.NickName, tc.Name, tc.Time FROM Lesson l
LEFT JOIN TimeCode tc ON l.Id = tc.LessonId
LEFT JOIN Member m ON m.Id = tc.MemberId
WHERE l.Id = 3