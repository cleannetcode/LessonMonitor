CREATE TABLE [dbo].[UsersAchievements] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [UserId]        INT           NOT NULL,
    [AchievementId] INT           NOT NULL,
    [CreatedDate]   DATETIME2 (7) DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_UserId_AchievementId] PRIMARY KEY CLUSTERED ([UserId] ASC, [AchievementId] ASC),
    CONSTRAINT [FK_UsersAchievements_Achievements] FOREIGN KEY ([AchievementId]) REFERENCES [dbo].[Achievements] ([Id]),
    CONSTRAINT [FK_UsersAchievements_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

