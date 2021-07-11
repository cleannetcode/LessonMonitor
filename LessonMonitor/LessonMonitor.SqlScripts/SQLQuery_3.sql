CREATE DATABASE HomeWorkSQL3

-- DROP DATABASE HomeWorkSQL3
-- DROP TABLE Lecture

CREATE TABLE Students (
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    NickName NVARCHAR(50) NOT NULL,
    DateOfRegistration DATETIME2 NOT NULL,
    Account NVARCHAR (50) NULL
)

CREATE TABLE Attainments (
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR (50) NOT NULL,
    CreateDate DATETIME2 DEFAULT GETDATE()
)

CREATE TABLE Skills (
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(50) NOT NULL
)

CREATE TABLE Lectures (
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(50) NOT NULL,
    StartDate DATETIME2 NOT NULL
)

CREATE TABLE StudentSkills(
    SkillId INT NOT NULL,
    StudentId INT NOT NULL,
    DateOfReseiving INT NOT NULL,
    CONSTRAINT [PK_SkillId_StudentId] PRIMARY KEY (SkillId,StudentId),
    CONSTRAINT [FK_StudentSkills_Skills] FOREIGN KEY (SkillId) REFERENCES Skills(Id),
    CONSTRAINT [FK_StudentSkills_Students] FOREIGN KEY (StudentId) REFERENCES Students(Id)
)

CREATE TABLE LectureSkills (
    LectureId INT NOT NULL,
    SkillId INT NOT NULL,
    CONSTRAINT [PK_SkillId_LectureId] PRIMARY KEY (SkillId,LectureId),
    CONSTRAINT [FK_LectureSkills_Skills] FOREIGN KEY (SkillId) REFERENCES Skills(Id),
    CONSTRAINT [FK_LectureSkills_Lectures] FOREIGN KEY (LectureId) REFERENCES Lectures(Id)
)

CREATE TABLE StudentAttainments(
    AttainmentId INT NOT NULL,
    StudentId INT NOT NULL,
    DateOfReseiving INT NOT NULL,
    CONSTRAINT [PK_AttainmentId_StudentId] PRIMARY KEY (AttainmentId,StudentId),
    CONSTRAINT [FK_StudentAttainments_Attainments] FOREIGN KEY (AttainmentId) REFERENCES Attainments(Id),
    CONSTRAINT [FK_StudentAttainments_Students] FOREIGN KEY (StudentId) REFERENCES Students(Id)
)

