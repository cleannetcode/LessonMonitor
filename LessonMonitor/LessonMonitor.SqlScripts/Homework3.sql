USE master

DROP DATABASE HomeWork3Db

CREATE DATABASE HomeWork3Db

USE HomeWork3Db

CREATE TABLE Member (
    Id INT PRIMARY KEY,
    NickName NVARCHAR(50) NOT NULL,
    RegistrationDate DATETIME2 NOT NULL,
    AcountType NVARCHAR(50) NOT NULL,
)

CREATE TABLE Achivement (
    Id INT PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
)

CREATE TABLE AchivementToMember (
    Id Int PRIMARY KEY,
    AchivementId INT NOT NULL,
    MemberId INT NOT NULL,
    AchivementDate DATETIME2 NOT NULL,
    CONSTRAINT FK_AM_To_Member FOREIGN KEY (MemberId) REFERENCES Member (Id),
    CONSTRAINT FK_AM_To_Achivement FOREIGN KEY (AchivementId) REFERENCES Achivement (Id),
)

CREATE TABLE Skill (
    Id Int PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
)

CREATE TABLE Lection(
    Id Int PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    Date DATETIME2 NOT NULL,
    SkillId Int NOT NULL,
    CONSTRAINT FK_Lection_To_Skill FOREIGN KEY (SkillId) REFERENCES Skill (Id)
)

CREATE TABLE SkillToMember(
    Id Int PRIMARY KEY,
    SkillId INT NOT NULL,
    MemberId INT NOT NULL,
    CONSTRAINT FK_SM_To_Skill FOREIGN KEY (SkillId) REFERENCES Skill (Id),
    CONSTRAINT FK_SM_To_Member FOREIGN KEY (MemberId) REFERENCES Member (Id),
)

