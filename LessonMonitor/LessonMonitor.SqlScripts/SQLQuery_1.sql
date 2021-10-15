-- USE master
-- CREATE DATABASE LessonMonitorDb

USE LessonMonitorDb

-- CREATE TABLE Members (
--     Name NVARCHAR(50)
-- )

-- ALTER TABLE Members
-- ADD Id INT

-- ALTER TABLE Members
-- ADD CreatedDate DATETIME2

-- INSERT Members (Id, Name, CreatedDate)
-- VALUES (NULL, NULL, NULL)

-- UPDATE Members
-- SET Id = 0, CreatedDate = GETDATE(), Name = ''

-- DELETE FROM Members

-- ALTER TABLE Members
-- ALTER COLUMN Id INT NOT NULL

-- DROP TABLE Members
-- DROP TABLE MemberAccounts
-- DROP TABLE VisitedLessons

CREATE TABLE Members (
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL,
    CreatedDate DATETIME2 DEFAULT GETDATE()
)

CREATE TABLE MemberAccounts (
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    MemberId INT NOT NULL,
    Username NVARCHAR(50) NOT NULL,
    Link NVARCHAR(200) NULL,
    CreatedDate DATETIME2 DEFAULT GETDATE(),
    CONSTRAINT FK_MemberAccounts_Members FOREIGN KEY (MemberId) REFERENCES [Members](Id)
)

CREATE TABLE Lessons (
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(200) NOT NULL,
    Description NVARCHAR(1000) NULL,
    StartDate DATETIME2 NOT NULL,
    CreatedDate DATETIME2 DEFAULT GETDATE()
)

CREATE TABLE VisitedLessons (
    MemberId INT NOT NULL,
    LessonId INT NOT NULL,
    CreatedDate DATETIME2 DEFAULT GETDATE(),
    CONSTRAINT [PK_MemberId_LessonId] PRIMARY KEY (MemberId, LessonId),
    -- CONSTRAINT [FK_VisitedLessons_Members] FOREIGN KEY (MemberId) REFERENCES Members(Id),
    -- CONSTRAINT [FK_VisitedLessons_Lessons] FOREIGN KEY (LessonId) REFERENCES Lessons(Id)
)

ALTER TABLE VisitedLessons
ADD CONSTRAINT [FK_VisitedLessons_Members] FOREIGN KEY (MemberId) REFERENCES Members(Id),
    CONSTRAINT [FK_VisitedLessons_Lessons] FOREIGN KEY (LessonId) REFERENCES Lessons(Id)

INSERT Members (Name)
VALUES ('Joe 2')

INSERT MemberAccounts (MemberId, Username)
VALUES (1, 'GithubJoe')

INSERT Lessons (Title, [Description], StartDate)
VALUES (N'Знакомимся с t-sql', N'Знакомимся с t-sql', '2021-04-25T15:00:00')


INSERT VisitedLessons ([MemberId], [LessonId])
VALUES (2, 3)


INSERT VisitedLessons ([MemberId], [LessonId])
VALUES (20, 3)


-- varchar non-unicode, nvarchar - unicode

-- SELECT * FROM Members
-- SELECT * FROM MemberAccounts
-- SELECT * FROM Lessons
-- SELECT * FROM VisitedLessons

-- DROP 
-- ALTER 

-- DROP TABLE Members
