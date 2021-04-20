CREATE TABLE [dbo].[Questions]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Text] NVARCHAR(MAX) NULL, 
    [MemberId] INT NULL, 
    [AnswerId] INT NOT NULL, 
    [Hastags] VARBINARY(50) NOT NULL
)
