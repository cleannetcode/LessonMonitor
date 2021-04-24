CREATE TABLE [dbo].[MemberStatistics]
(
	[Id] INT NOT NULL PRIMARY KEY,
    [Rating] INT NOT NULL,  
    [MemberId] INT NOT NULL FOREIGN KEY REFERENCES Members(Id) 
)
