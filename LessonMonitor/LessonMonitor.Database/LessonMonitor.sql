CREATE TABLE dbo.Courses
(
    Id INT NOT NULL IDENTITY(1,1), 
    Name NVARCHAR(100) NOT NULL, 
    Description NVARCHAR(500) NULL,
    CONSTRAINT PK_Courses PRIMARY KEY (Id)
)

CREATE TABLE dbo.Lessons
(
    Id INT NOT NULL IDENTITY(1,1), 
    Name NVARCHAR(100) NOT NULL, 
    StartDate DATETIME2 NOT NULL, 
    EndDate DATETIME2 NULL,
    CONSTRAINT PK_Lessons PRIMARY KEY (Id)
)

CREATE TABLE dbo.CourseLessons
(
    CourseId INT NOT NULL,
    LessonId INT NOT NULL,
    CONSTRAINT PK_CourseLessons PRIMARY KEY (CourseId, LessonId),
    CONSTRAINT FK_CourseLessons_Courses FOREIGN KEY (CourseId) REFERENCES Courses(Id),
    CONSTRAINT FK_CourseLessons_Lesson FOREIGN KEY (LessonId) REFERENCES Lessons(Id)
)

CREATE TABLE dbo.Announcements
(
    Id INT NOT NULL IDENTITY(1,1), 
    Title NVARCHAR(100) NOT NULL, 
    Message NVARCHAR(1000) NULL, 
    Date DATETIME2 NOT NULL DEFAULT GETDATE(), 
    CourseId INT NULL,
    CONSTRAINT PK_Announcements PRIMARY KEY (Id),
    CONSTRAINT FK_Announcements_Courses FOREIGN KEY (CourseId) REFERENCES Courses(Id)
)

CREATE TABLE dbo.Members
(
    Id INT NOT NULL IDENTITY(1,1), 
    FullName NVARCHAR(100) NOT NULL, 
    Age INT NULL, 
    Email NVARCHAR(50) NOT NULL, 
    Link NVARCHAR(50) NULL
    CONSTRAINT PK_Members PRIMARY KEY (Id)
)

CREATE TABLE dbo.MemberCourses
(
    MemberId INT NOT NULL,
    CourseId INT NOT NULL,
    CONSTRAINT PK_MemberCourses PRIMARY KEY (MemberId, CourseId),
    CONSTRAINT FK_MemberCourses_Members FOREIGN KEY (MemberId) REFERENCES Members(Id),
    CONSTRAINT FK_MemberCourses_Courses FOREIGN KEY (CourseId) REFERENCES Courses(Id)
)

CREATE TABLE dbo.MemberStatistics
(
    MemberId INT NOT NULL,
    Rating INT NOT NULL,
    CONSTRAINT PK_MemberStatistics PRIMARY KEY (MemberId),
    CONSTRAINT FK_MemberStatistics_Members FOREIGN KEY (MemberId) REFERENCES Members(Id)
)

CREATE TABLE dbo.Skills
(
    Id INT NOT NULL IDENTITY(1,1), 
    Name NVARCHAR(100) NOT NULL, 
    Weight INT NULL, 
    Description NVARCHAR(500) NULL, 
    MemberId INT NOT NULL,
    CONSTRAINT PK_Skills PRIMARY KEY (Id),
    CONSTRAINT FK_Skills_Members FOREIGN KEY (MemberId) REFERENCES Members(Id)
)
