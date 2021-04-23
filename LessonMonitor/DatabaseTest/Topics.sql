CREATE TABLE [dbo].[Topics]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(20) NOT NULL, 
    [Difficult (0 - 10)] BIT NULL DEFAULT 0 , 
    [UsefullLink] NVARCHAR(MAX) NULL
)
