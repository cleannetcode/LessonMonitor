CREATE TABLE [dbo].[Timecodes] (
    [Id]          INT            IDENTITY (2, 4) NOT NULL,
    [LessonId]    INT            NOT NULL,
    [Description] NVARCHAR (600) NULL,
    [Timecode]    TIME (3)       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Timecodes_Lessons] FOREIGN KEY ([LessonId]) REFERENCES [dbo].[Lessons] ([Id])
);

