CREATE TABLE [dbo].[Homeworks]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(50) NULL, 
    [Body] NVARCHAR(MAX) NULL, 
    [MemberId] UNIQUEIDENTIFIER NOT NULL, 
    [StartDate] NCHAR(10) NOT NULL, 
    [CompletionDate] DATE NULL, 
    [Remarks] NVARCHAR(MAX) NULL
)
