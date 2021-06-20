CREATE TABLE [dbo].[MemberAccounts] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [MemberId]    INT            NOT NULL,
    [Username]    NVARCHAR (50)  NOT NULL,
    [Link]        NVARCHAR (200) NULL,
    [CreatedDate] DATETIME2 (7)  DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MemberAccounts_Members] FOREIGN KEY ([MemberId]) REFERENCES [dbo].[Members] ([Id])
);

