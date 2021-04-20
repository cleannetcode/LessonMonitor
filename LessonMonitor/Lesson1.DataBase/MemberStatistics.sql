CREATE TABLE [dbo].[MemberStatistics]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [MembersId] INT FOREIGN KEY REFERENCES [Members](Id) NULL, 
    [NumberOfHomeworkDone] INT NULL, 
    [VisitedLessons] INT FOREIGN KEY REFERENCES [Lessons](Id) NULL 
 )
