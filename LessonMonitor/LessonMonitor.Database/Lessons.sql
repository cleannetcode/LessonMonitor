CREATE TABLE [dbo].[Lessons]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(100) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [Date] DATE NOT NULL, 
    [Duration] TIME NULL
)
