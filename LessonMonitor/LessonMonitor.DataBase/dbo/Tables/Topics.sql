CREATE TABLE [dbo].[Topics] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Theme]       NVARCHAR (200) NULL,
    [CreatedDate] DATETIME2 (7)  NOT NULL,
    [UpdatedDate] DATETIME2 (7)  NOT NULL,
    [DeletedDate] DATETIME2 (7)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

