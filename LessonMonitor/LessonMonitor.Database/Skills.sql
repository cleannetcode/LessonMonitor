CREATE TABLE [dbo].[Skills]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(20) NOT NULL, 
    [Level] NVARCHAR(20) NULL, 
    [MemberId] INT NULL FOREIGN KEY REFERENCES [dbo].[Members](Id)
)
