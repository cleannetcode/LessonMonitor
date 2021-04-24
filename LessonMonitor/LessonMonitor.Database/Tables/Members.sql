CREATE TABLE [dbo].[Members]
(
	[MemberId] INT NOT NULL  PRIMARY KEY, 
    [UserName] NVARCHAR(50) NOT NULL, 
    [NickName] NVARCHAR(20) NOT NULL, 
    [RangId] INT NULL
)
