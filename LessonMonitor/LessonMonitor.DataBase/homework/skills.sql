CREATE TABLE [dbo].[skills]
(
	[Id] INT NOT NULL PRIMARY KEY, 
	[idlesson] int NOT NULL,
    [title] NCHAR(10) NOT NULL, 
    CONSTRAINT [FK_skills_lessons] FOREIGN KEY (idlesson) REFERENCES lessons(id)
)
