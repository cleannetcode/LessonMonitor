CREATE TABLE [dbo].[Homeworks] (
    [Id]          INT             NOT NULL,
    [Title]       NVARCHAR (200)  NOT NULL,
    [Description] NVARCHAR (1000) NOT NULL,
    [Link]        NVARCHAR (1000) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


