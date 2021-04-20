CREATE TABLE [dbo].[Timecodes]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [VideoId] INT NOT NULL, 
    [TimeStart] TIME NOT NULL, 
    [TimeEnd] TIME NOT NULL, 
    [Hashtags] VARCHAR(50) NULL, 
    [Description] NVARCHAR(50) NULL
)
