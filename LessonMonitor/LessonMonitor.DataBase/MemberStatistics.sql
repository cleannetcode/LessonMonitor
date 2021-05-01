CREATE TABLE [dbo].[MemberStatistics]
(
	[Id] INT NOT NULL IDENTITY (1, 1), 
    [CheckCount] INT NULL, 
    [MemberId] INT NOT NULL,
    CONSTRAINT [PK_MemberStatistics] PRIMARY KEY CLUSTERED ([Id] ASC),
)
