CREATE TABLE [dbo].[Questions] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [UserId]      INT            NOT NULL,
    [Discription] NVARCHAR (MAX) NOT NULL,
    [CreatedDate] DATETIME2 (7)  DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Questions_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

