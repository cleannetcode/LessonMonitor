CREATE TABLE [dbo].[Questions]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Text] NVARCHAR(MAX) NOT NULL, 
    [MemberId] INT NOT NULL, 
    [AnswerId] NVARCHAR(50) NULL, 
    [Hastags] VARBINARY(50) NOT NULL
)
