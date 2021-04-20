CREATE TABLE [dbo].[MemberStatistics]
(
	[Id] INT NOT NULL PRIMARY KEY  IDENTITY (1, 1), 
    [CheckCount] INT NULL, 
    [MemberId] INT NOT NULL,
)
