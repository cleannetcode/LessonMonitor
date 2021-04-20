CREATE TABLE [dbo].[Lessons]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [StartDate] DATETIME2 NULL, 
    [Duration] TIME NULL, 
    [MembersId] INT REFERENCES [dbo].[Members](Id) NULL, 
    [Group] NVARCHAR(50) NULL, 
    [Difficulty] NVARCHAR(50) NULL 
)
