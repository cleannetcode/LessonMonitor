CREATE TABLE [dbo].[Questions]
(
	[Id] INT NOT NULL IDENTITY (1, 1), 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [CreateDate] DATETIME2 NULL, 
    [TopicId] INT NOT NULL, 
    [MemberId] INT NOT NULL,
    CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED ([Id] ASC)
)
