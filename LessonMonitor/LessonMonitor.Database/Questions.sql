CREATE TABLE [dbo].[Topics]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(50) NOT NULL, 
    [Body] NVARCHAR(MAX) NULL, 
    [Status] NCHAR(20) NULL
)
