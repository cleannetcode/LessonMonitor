CREATE TABLE [dbo].[MemberStatistics]
(
    [MemberId] INT NOT NULL PRIMARY KEY, 
    [Questions] INT NOT NULL DEFAULT 0, 
    [Homeworks] INT NOT NULL DEFAULT 0, 
    [Lessons] INT NOT NULL DEFAULT 0 
)
