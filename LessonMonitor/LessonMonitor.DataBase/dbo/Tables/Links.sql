CREATE TABLE [dbo].[Links] (
    [UserId]   INT            NOT NULL,
    [GitHub]   NVARCHAR (MAX) NULL,
    [Discord]  NVARCHAR (MAX) NULL,
    [YouTube]  NVARCHAR (MAX) NULL,
    [VK]       NVARCHAR (MAX) NULL,
    [Facebook] NVARCHAR (MAX) NULL,
    [Twitter]  NVARCHAR (MAX) NULL,
    CONSTRAINT [FK_Links_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

