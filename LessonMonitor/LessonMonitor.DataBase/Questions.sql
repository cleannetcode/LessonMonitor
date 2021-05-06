CREATE TABLE [dbo].[Questions]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Discription] NVARCHAR(MAX) NOT NULL, 
    [MemberName] NVARCHAR(50) NOT NULL, 
    [LessonDate] DATETIME2 NULL
)
