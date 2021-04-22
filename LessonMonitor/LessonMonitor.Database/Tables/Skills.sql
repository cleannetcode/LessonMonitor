CREATE TABLE [dbo].[Skills]
(
	[SkillId] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(20) NOT NULL, 
    [ParentId] INT NULL
)
