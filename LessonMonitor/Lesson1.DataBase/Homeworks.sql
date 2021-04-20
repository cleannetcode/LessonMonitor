CREATE TABLE [dbo].[Homeworks]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [Date] DATETIME NULL, 
    [MemberId] INT FOREIGN KEY REFERENCES [Members](Id) NULL
)
