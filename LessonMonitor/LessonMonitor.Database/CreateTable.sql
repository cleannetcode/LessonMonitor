use Homework2

CREATE TABLE [dbo].Members
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FullName] NVARCHAR(50) NOT NULL, 
    [Age] INT NULL,
    [Nickname] NVARCHAR(MAX) NULL, 
    [Phone] NVARCHAR(20) NULL, 
    [Email] NVARCHAR(50) NULL
)

CREATE TABLE [dbo].Homeworks
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MemberId] INT NOT NULL, 
    [LessonId] INT NOT NULL, 
    [Link] NVARCHAR(MAX) NOT NULL, 
    FOREIGN KEY (MemberId) REFERENCES Members(Id),
    FOREIGN KEY (LessonId) REFERENCES Lessons(Id)
)

CREATE TABLE [dbo].Lessons
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [StartDate] DATETIME2 NOT NULL, 
    [Durations] INT NULL, 
    [Members] NVARCHAR(MAX) NULL, 
    [Group] NVARCHAR(50) NULL, 
    [Difficulty] INT NULL,

)

CREATE TABLE [dbo].Skills
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Weight] INT NULL, 
    [Subskills] NVARCHAR(MAX) NULL, 
    [MemberId] INT NULL, 
    FOREIGN KEY (MemberId) REFERENCES Members(Id)

)
CREATE TABLE [dbo].Timecodes
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NULL, 
    [LessonId] INT NOT NULL, 
    [Time] INT NOT NULL, 
    FOREIGN KEY (LessonId) REFERENCES Lessons(Id)


)

alter table Timecodes
ADD MemberId int not null;

alter table Timecodes
Add FOREIGN KEY (MemberId) REFERENCES Members(id)

