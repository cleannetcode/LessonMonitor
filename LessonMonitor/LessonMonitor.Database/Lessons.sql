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
