CREATE DATABASE LessonMonitorDB
-- DROP TABLE MemberAccounts

CREATE TABLE Lessons (
   Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
   Title NVARCHAR(200) NOT NULL,
   [Description] NVARCHAR(200) NULL,
   StartDate DATETIME2 NOT NULL,
   Duration INT NULL,
   Difficulty INT NULL, 
   [Group] NVARCHAR(50) NULL
)

CREATE TABLE Members (
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(50) NOT NULL,
    Age INT NULL,
    CreateDate DATETIME2 DEFAULT GETDATE()
)

CREATE TABLE Questions (
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Description] NVARCHAR(MAX) NOT NULL,
    MemberId INT NOT NULL,
    CreateDate DATETIME2 DEFAULT GETDATE(),
    CONSTRAINT [FK_Questions_Members] FOREIGN KEY (MemberId) REFERENCES Members(Id)
)

CREATE TABLE Skills (
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(50) NOT NULL,
    [Weight] INT NULL,
    SubSkills NVARCHAR(MAX) NULL,
    CreateDate DATETIME2 DEFAULT GETDATE()
)

CREATE TABLE VisitedLessons (
    MemberId INT NOT NULL,
    LessonId INT NOT NULL,
    CreateDate DATETIME2 DEFAULT GETDATE(),
    CONSTRAINT [PK_MemberId_LessonId] PRIMARY KEY (MemberId,LessonId),
    CONSTRAINT [FK_VisitedLessons_Members] FOREIGN KEY (MemberId) REFERENCES Members(Id),
    CONSTRAINT [FK_VisitedLessons_Lessons] FOREIGN KEY (LessonId) REFERENCES Lessons(Id)
)

CREATE TABLE MemberAccounts (
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    MemberId INT NOT NULL,
    UserName NVARCHAR(50) NOT NULL,
    Link NVARCHAR (200) NULL,
    CreateDate DATETIME2 DEFAULT GETDATE(),
    CONSTRAINT [FK_MemberAccounts_Members] FOREIGN KEY (MemberId) REFERENCES Members(Id)
)

INSERT INTO Members (FullName)
VALUES 
(N'Евгения Медведева'),
(N'Александр Пономарев'),
(N'SHILY'),
(N'Михаил Кодер')

INSERT MemberAccounts (MemberId, UserName, Link)
VALUES (1, N'emedvedeva', N'https://github.com/emedvedeva')

INSERT INTO  Lessons (Title, [Description], StartDate)
VALUES 
(N'Знакомимся с t-sql', N'Знакомимся с t-sql', '2021-04-25T15:00:00'),
(N'T-SQL и DML, управляем данными', N'T-SQL и DML, управляем данными', '2021-05-23T15:00:00')

INSERT  Questions ([Description], MemberId)
VALUES (N'!q а "- -" - это отмечается комментарий - неисполняемый скрипт?', 1)

INSERT INTO VisitedLessons (MemberId, LessonId)
VALUES 
(1, 1),
(2, 1),
(4, 1),
(1, 2),
(2, 2)

SELECT * FROM Members
SELECT * FROM MemberAccounts
SELECT * FROM Lessons
SELECT * FROM VisitedLessons
SELECT * FROM Skills

-- ALTER TABLE Members 
-- ADD CONSTRAINT FK_Members_Skills FOREIGN KEY(SkillId) REFERENCES Skills(Id)

INSERT Skills (Title)
VALUES ('Пользователь GIT')

-- INSERT Members (FullName, SkillId)
-- VALUES ('eniluck', 1)

-- ALTER TABLE Members
-- DROP CONSTRAINT FK_Members_Skills, 
-- COLUMN SkillId

-- DELETE
-- FROM Members
-- WHERE Id = 5

CREATE TABLE MemberSkills (
    MemberId INT NOT NULL,
    SkillId INT NOT NULL,
    CreateDate DATETIME2 DEFAULT GETDATE(),
    CONSTRAINT [PK_MemberId_SkillId] PRIMARY KEY (MemberId,SkillId),
    CONSTRAINT [FK_MemberSkills_Members] FOREIGN KEY (MemberId) REFERENCES Members(Id),
    CONSTRAINT [FK_MemberSkills_Skills] FOREIGN KEY (SkillId) REFERENCES Skills(Id) 
)

INSERT INTO MemberSkills (MemberId, SkillId)
VALUES 
(1, 1),
(2, 1),
(4, 1),
(3, 1)

SELECT * FROM MemberSkills
