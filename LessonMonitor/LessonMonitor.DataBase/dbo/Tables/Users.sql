CREATE TABLE [dbo].[Users] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Nicknames]   NVARCHAR (100) NULL,
    [Email]       NVARCHAR (200) NULL,
    [CreatedDate] DATETIME2 (7)  NOT NULL,
    [UpdatedDate] DATETIME2 (7)  NOT NULL,
    [DeletedDate] DATETIME2 (7)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

