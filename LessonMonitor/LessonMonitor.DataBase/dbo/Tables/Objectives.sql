CREATE TABLE [dbo].[Objectives] (
    [Id]          INT             NOT NULL,
    [Title]       NVARCHAR (200)  NOT NULL,
    [Description] NVARCHAR (1000) NOT NULL,
    [HomeworkId]  INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([HomeworkId]) REFERENCES [dbo].[Homeworks] ([Id])
);

