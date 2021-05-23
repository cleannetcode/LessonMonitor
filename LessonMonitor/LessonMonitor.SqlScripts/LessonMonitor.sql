IF DB_ID(N'LessonMonitor') IS NULL
    CREATE DATABASE LessonMonitor

BEGIN TRAN

USE LessonMonitor

CREATE TABLE dbo.AccountTypes (
    Id INT NOT NULL IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL,
    CONSTRAINT PK_AccountTypes PRIMARY KEY (Id)
)

CREATE TABLE dbo.Skills (
    Id INT NOT NULL IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL
    CONSTRAINT PK_Skills PRIMARY KEY (Id)
)

CREATE TABLE dbo.Achievements (
    Id INT NOT NULL IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL,
    CONSTRAINT PK_Achievements PRIMARY KEY (Id)
)

CREATE TABLE dbo.Lectures (
    Id INT NOT NULL IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL,
    CONSTRAINT PK_Lectures PRIMARY KEY (Id)
)

CREATE TABLE dbo.LectureSkills (
    LectureId INT NOT NULL,
    SkillId INT NOT NULL,
    SkillReceivedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    CONSTRAINT PK_LectureSkills PRIMARY KEY (LectureId, SkillId),
    CONSTRAINT FK_LectureSkills_Lectures FOREIGN KEY (LectureId) REFERENCES Lectures(Id),
    CONSTRAINT FK_LectureSkills_Skills FOREIGN KEY (SkillId) REFERENCES Skills(Id)
)

CREATE TABLE dbo.Accounts (
    Id INT NOT NULL IDENTITY(1,1),
    Nickname NVARCHAR(20) NOT NULL,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    TypeId INT NOT NULL,
    CONSTRAINT PK_Accounts PRIMARY KEY (Id),
    CONSTRAINT FK_Accounts_AccountTypes FOREIGN KEY (TypeId) REFERENCES AccountTypes(Id)
)

CREATE TABLE dbo.AccountLectures (
    AccountId INT NOT NULL,
    LectureId INT NOT NULL,
    CONSTRAINT PK_AccountLectures PRIMARY KEY (AccountId, LectureId),
    CONSTRAINT FK_AccountLectures_Accounts FOREIGN KEY (AccountId) REFERENCES Accounts(Id),
    CONSTRAINT FK_AccountLectures_Lectures FOREIGN KEY (LectureId) REFERENCES Lectures(Id)
)

CREATE TABLE dbo.AccountAchievements (
    AccountId INT NOT NULL,
    AchievementId INT NOT NULL,
    AchievementReceivedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    CONSTRAINT PK_AccountAchievements PRIMARY KEY (AccountId, AchievementId),
    CONSTRAINT FK_AccountAchievements_Accounts FOREIGN KEY (AccountId) REFERENCES Accounts(Id),
    CONSTRAINT FK_AccountAchievements_Achievements FOREIGN KEY (AchievementId) REFERENCES Achievements(Id)
)

IF @@ERROR <> 0
    ROLLBACK TRAN
ELSE
    COMMIT TRAN