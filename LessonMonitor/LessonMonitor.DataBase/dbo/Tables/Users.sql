CREATE TABLE [dbo].[Users] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50)  NOT NULL,
    [Nicknames]  NVARCHAR (100) NULL,
    [Email]      NVARCHAR (200) NULL,
    [CreateDate] DATETIME2 (7)  DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

