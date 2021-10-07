CREATE DATABASE HomeWorkSQL3

USE HomeWorkSQL3

CREATE TABLE Accounts (
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Type NVARCHAR (50) NOT NULL,
)

CREATE TABLE Students (
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    NickName NVARCHAR(50) NOT NULL,
    DateOfRegistration DATETIME2 NOT NULL,
	AccountId INT NOT NULL,
	CONSTRAINT [FK_Students_Accounts] FOREIGN KEY (AccountId) REFERENCES Accounts(Id),
)

CREATE TABLE Achievements (
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR (50) NOT NULL,
    CreateDate DATETIME2 DEFAULT GETDATE()
)

CREATE TABLE StudentAchievements(
    AchievementId INT NOT NULL,
    StudentId INT NOT NULL,
    DateOfReseiving INT NOT NULL,
    CONSTRAINT [PK_AchievementsId_StudentsId] PRIMARY KEY (AchievementId,StudentId),
    CONSTRAINT [FK_StudentAchievements_Achievements] FOREIGN KEY (AchievementId) REFERENCES Achievements(Id),
    CONSTRAINT [FK_StudentAchievements_Students] FOREIGN KEY (StudentId) REFERENCES Students(Id)
)

CREATE TABLE Lectures (
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(50) NOT NULL,
    StartDate DATETIME2 NOT NULL
)

CREATE TABLE StudentLectures(
    LectureId INT NOT NULL,
    StudentId INT NOT NULL,
    CONSTRAINT [PK_LectureId_StudentId] PRIMARY KEY (LectureId, StudentId),
    CONSTRAINT [FK_StudentLectures_Lectures] FOREIGN KEY (LectureId) REFERENCES Lectures(Id),
    CONSTRAINT [FK_StudentLectures_Students] FOREIGN KEY (StudentId) REFERENCES Students(Id)
)

CREATE TABLE LectureSkills (
    LectureId INT NOT NULL,
    SkillId INT NOT NULL,
	DateOfReseiving INT NOT NULL,
    CONSTRAINT [PK_SkillId_LectureId] PRIMARY KEY (SkillId,LectureId),
    CONSTRAINT [FK_LectureSkills_Lectures] FOREIGN KEY (LectureId) REFERENCES Lectures(Id)
)