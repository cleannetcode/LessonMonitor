USE LessonMonitor

--DROP TABLE [MemberSkills], [SkillLevels], [TimeCodes], [Lessons], [Members], [Skills]

CREATE TABLE [dbo].[Members]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [SecondName] NVARCHAR(50) NOT NULL, 
    [Age] INT NOT NULL, 
    [NickName] NVARCHAR(50) NULL,
    UNIQUE(FirstName, SecondName)
)


CREATE TABLE [dbo].[Lessons]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(30) NOT NULL UNIQUE, 
    [Description] NVARCHAR(250) NOT NULL, 
    [LinkHomeWork] NVARCHAR(100) NULL, 
    [LinkVideo] NVARCHAR(100) NULL, 
    [DataTime] DATETIME NOT NULL
)

CREATE TABLE [dbo].[TimeCodes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(100) NOT NULL UNIQUE, 
    [LessonId] INT NOT NULL, 
    [MemberId] INT NOT NULL, 
    [Time] TIME NOT NULL, 
    CONSTRAINT [FK_TimeCodes_ToMembers_Id] FOREIGN KEY (MemberId) REFERENCES Members(Id) ON DELETE CASCADE, 
    CONSTRAINT [FK_TimeCodes_ToLessons_Id] FOREIGN KEY (LessonId) REFERENCES Lessons(Id) ON DELETE CASCADE
)


CREATE TABLE [dbo].[Skills]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL UNIQUE 
)


CREATE TABLE [dbo].[SkillLevels]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Level] NVARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE [dbo].[MemberSkills]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MemberId] INT NOT NULL, 
    [SkillId] INT NOT NULL,
    [LevelId] INT NOT NULL, 
    UNIQUE(MemberId, SkillId),
    CONSTRAINT [FK_MemberSkills_ToMembers_Id] FOREIGN KEY (MemberId) REFERENCES Members(Id) ON DELETE CASCADE,
    CONSTRAINT [FK_MemberSkills_ToSkills_Id] FOREIGN KEY (SkillId) REFERENCES Skills(Id) ON DELETE CASCADE,
    CONSTRAINT [FK_MemberSkills_ToSkillsLevels_Id] FOREIGN KEY (LevelId) REFERENCES SkillLevels(Id)
)

INSERT Skills (Name) VALUES ("Junior")
INSERT Skills (Name) VALUES ("Middle")
INSERT Skills (Name) VALUES ("Senior")