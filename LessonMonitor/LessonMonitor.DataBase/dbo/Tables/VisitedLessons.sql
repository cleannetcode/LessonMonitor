CREATE TABLE [dbo].[VisitedLessons] (
    [MemberId]    INT           NOT NULL,
    [LessonId]    INT           NOT NULL,
    [CreatedDate] DATETIME2 (7) DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_MemberId_LessonId] PRIMARY KEY CLUSTERED ([MemberId] ASC, [LessonId] ASC),
    CONSTRAINT [FK_VisitedLessons_Lessons] FOREIGN KEY ([LessonId]) REFERENCES [dbo].[Lessons] ([Id]),
    CONSTRAINT [FK_VisitedLessons_Members] FOREIGN KEY ([MemberId]) REFERENCES [dbo].[Members] ([Id])
);

