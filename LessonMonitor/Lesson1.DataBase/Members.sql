CREATE TABLE [dbo].[Members]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Full name] NVARCHAR(50) NOT NULL, 
    [Age] INT NULL, 
    [Nicknames] NVARCHAR(MAX) NULL, 
    [Links] NVARCHAR(MAX) NULL, 
    [SkillsId] INT REFERENCES [dbo].[Skills](Id) NULL
)
