CREATE TABLE [dbo].[Homeworks]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [StartDate] DATETIME NOT NULL, 
    [EndDate] DATETIME NOT NULL, 
    [CompleteDate] DATETIME NOT NULL, 
    [IsComplete] BIT NULL, 
    [Score] FLOAT NOT NULL
)
