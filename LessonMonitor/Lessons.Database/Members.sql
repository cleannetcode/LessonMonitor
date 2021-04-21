CREATE TABLE [dbo].[Members]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FullName] NVARCHAR(50) NOT NULL, 
    [Birthday] DATE NULL, 
    [Email] NVARCHAR(100) NOT NULL, 
    [CreatedAt] DATETIME NOT NULL DEFAULT GETDATE()
)

GO

CREATE UNIQUE INDEX [IX_Members_Email] ON [dbo].[Members] ([Email])
