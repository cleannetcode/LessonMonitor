CREATE TABLE [dbo].[MemberSkills]
(
    [MemberId] INT NOT NULL,
    [SkillId] INT NOT NULL, 
    CONSTRAINT [PK_MemberSkills] PRIMARY KEY ([MemberId], [SkillId])
)
