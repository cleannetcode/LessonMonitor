CREATE TABLE [dbo].[UsersLessons] (
    [UserId]      INT           NOT NULL,
    [LessonId]    INT           NOT NULL,
    [CreatedDate] DATETIME2 (7) DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_UserId_LessonId] PRIMARY KEY CLUSTERED ([UserId] ASC, [LessonId] ASC),
    CONSTRAINT [FK_VisitedLessons_Lessons] FOREIGN KEY ([LessonId]) REFERENCES [dbo].[Lessons] ([Id]),
    CONSTRAINT [FK_VisitedLessons_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

