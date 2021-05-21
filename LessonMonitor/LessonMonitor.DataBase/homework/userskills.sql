CREATE TABLE [dbo].[userskills]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [idUser] INT NOT NULL, 
    [idSkill] INT NOT NULL,
    [idSkillLevel] INT NOT NULL,
    [dateGotSkill] DATETIME NOT NULL, 
    CONSTRAINT [FK_userskills_users] FOREIGN KEY (idUser) REFERENCES users(id), 
    CONSTRAINT [FK_userskills_skill] FOREIGN KEY (idSkill) REFERENCES skills(id), 
    CONSTRAINT [FK_userskills_skilllevels] FOREIGN KEY (idSkillLevel) REFERENCES skilllevels(id)
    
)
