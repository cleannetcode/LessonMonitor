CREATE TABLE [dbo].[UsersHomeworks] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [UserId]      INT           NOT NULL,
    [HomeworkId]  INT           NOT NULL,
    [CreatedDate] DATETIME2 (7) DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_UserId_HomeworkId] PRIMARY KEY CLUSTERED ([UserId] ASC, [HomeworkId] ASC),
    CONSTRAINT [FK_UsersHomeworks_Homeworks] FOREIGN KEY ([HomeworkId]) REFERENCES [dbo].[Homeworks] ([Id]),
    CONSTRAINT [FK_UsersHomeworks_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

