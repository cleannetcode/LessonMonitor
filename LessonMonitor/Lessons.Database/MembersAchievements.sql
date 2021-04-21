CREATE TABLE [dbo].[MembersAchievements]
(
	[MemberId] INT NOT NULL , 
    [AchievementId] INT NOT NULL, 
    [RecievedAt] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [PK_MembersAchievements] PRIMARY KEY ([MemberId], [AchievementId]), 
    CONSTRAINT [FK_MembersAchievements_Members] FOREIGN KEY ([MemberId]) REFERENCES [Members]([Id]), 
    CONSTRAINT [FK_MembersAchievements_Achievements] FOREIGN KEY ([AchievementId]) REFERENCES [Achievements]([Id])
)
