CREATE TABLE [dbo].[MemberStatistics]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [MemberId] INT NOT NULL, 
    [Questions] INT NOT NULL DEFAULT 0, 
    [Homeworks] INT NOT NULL DEFAULT 0, 
    [Lessons] INT NOT NULL DEFAULT 0 
)
