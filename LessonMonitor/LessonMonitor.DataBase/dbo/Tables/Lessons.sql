CREATE TABLE [dbo].[Lessons] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [TopicId]     INT             NULL,
    [Title]       NVARCHAR (200)  NOT NULL,
    [Description] NVARCHAR (1000) NULL,
    [StartDate]   DATETIME2 (7)   NULL,
    [CreatedDate] DATETIME2 (7)   DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Lessons_Topics] FOREIGN KEY ([TopicId]) REFERENCES [dbo].[Topics] ([Id])
);

