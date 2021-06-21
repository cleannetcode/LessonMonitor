CREATE TABLE [dbo].[Homeworks] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [TopicId]    INT            NULL,
    [Name]       NVARCHAR (100) NOT NULL,
    [Link]       NVARCHAR (MAX) NULL,
    [Grade]      INT            NULL,
    [CreateDate] DATETIME2 (7)  DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Homeworks_Topics] FOREIGN KEY ([TopicId]) REFERENCES [dbo].[Topics] ([Id])
);



