CREATE TABLE [dbo].[LessonMembers]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [MemberId] INT NOT NULL, 
    [LessonId] INT NOT NULL, 
    CONSTRAINT [FK_LessonMembers_ToMembers] FOREIGN KEY (MemberId) REFERENCES Members(id), 
    CONSTRAINT [FK_LessonMembers_ToLessons] FOREIGN KEY (LessonId) REFERENCES Lessons(id)

)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'ссылка на участника',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'LessonMembers',
    @level2type = N'COLUMN',
    @level2name = N'MemberId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'ссылка на урок',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'LessonMembers',
    @level2type = N'COLUMN',
    @level2name = N'LessonId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'участники обучения на уроке',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'LessonMembers',
    @level2type = NULL,
    @level2name = NULL