CREATE TABLE [dbo].[Lessons]
(
    [Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [StartDate] DATETIME2 NOT NULL, 
    [Duration] INT NULL, 
    [Members] NVARCHAR(MAX) NULL, 
    [Difficulty] INT NULL, 
    [Group] NVARCHAR(50) NULL
)
