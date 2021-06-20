CREATE TABLE [dbo].[Lessons] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (200)  NOT NULL,
    [Description] NVARCHAR (1000) NULL,
    [StartDate]   DATETIME2 (7)   NOT NULL,
    [CreatedDate] DATETIME2 (7)   DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Lessons_TitleDescription]
    ON [dbo].[Lessons]([Title] ASC, [Description] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Lessons_Title]
    ON [dbo].[Lessons]([Title] ASC);

