CREATE TABLE [dbo].[Questions]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserName] NVARCHAR(20) NOT NULL, 
    [Topic] NVARCHAR(20) NULL,
    [Question] NVARCHAR(MAX) NOT NULL 
    
)
