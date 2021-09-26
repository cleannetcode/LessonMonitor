CREATE TABLE [dbo].[Questions]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(50) NOT NULL, 
    [Body] NVARCHAR(MAX) NULL, 
    [Status] NCHAR(20) NULL,
    [MemberId] INT NULL FOREIGN KEY REFERENCES [dbo].[Members](Id)
)
