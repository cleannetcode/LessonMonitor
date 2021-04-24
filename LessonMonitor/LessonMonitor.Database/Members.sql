CREATE TABLE [dbo].[Members]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FullName] NVARCHAR(100) NOT NULL, 
    [Age] INT NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [Link] NVARCHAR(MAX) NULL, 
    [CourseId] INT NULL FOREIGN KEY REFERENCES Courses(Id)
)
