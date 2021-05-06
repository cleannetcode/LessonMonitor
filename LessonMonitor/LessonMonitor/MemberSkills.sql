CREATE TABLE [dbo].[MemberSkills]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MemberId] INT NOT NULL, 
    [SkillId] INT NOT NULL,
    [LevelId] INT NOT NULL, 
    UNIQUE(MemberId, SkillId),
    CONSTRAINT [FK_MemberSkills_ToMembers_Id] FOREIGN KEY (MemberId) REFERENCES Members(Id) ON DELETE CASCADE,
    CONSTRAINT [FK_MemberSkills_ToSkills_Id] FOREIGN KEY (SkillId) REFERENCES Skills(Id) ON DELETE CASCADE,
    CONSTRAINT [FK_MemberSkills_ToSkillsLevels_Id] FOREIGN KEY (LevelId) REFERENCES SkillLevels(Id)
)
