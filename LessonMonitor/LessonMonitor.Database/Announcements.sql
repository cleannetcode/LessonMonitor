CREATE TABLE [dbo].[Announcements]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(100) NOT NULL, 
    [Message] NVARCHAR(1000) NULL, 
    [Date] DATETIME2 NOT NULL, 
    [CourseId] INT NULL FOREIGN KEY REFERENCES Courses(Id)
)
