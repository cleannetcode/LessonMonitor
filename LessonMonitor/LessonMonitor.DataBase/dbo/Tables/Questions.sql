CREATE TABLE [dbo].[Questions] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [UserId]      INT            NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [CreatedDate] DATETIME2 (7)  NOT NULL,
    [UpdatedDate] DATETIME2 (7)  NOT NULL,
    [DeletedDate] DATETIME2 (7)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Questions_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

