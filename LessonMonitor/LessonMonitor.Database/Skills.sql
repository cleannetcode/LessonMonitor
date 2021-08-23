CREATE TABLE [dbo].Skills
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Weight] INT NULL, 
    [Subskills] NVARCHAR(MAX) NULL, 
    [MemberId] INT NULL, 
    FOREIGN KEY (MemberId) REFERENCES Members(Id)
    
)
