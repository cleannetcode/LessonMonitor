BEGIN TRAN

USE [LessonMonitor.Database]

UPDATE [dbo].[Members]
SET [Name] = 'Johnny'
WHERE [Name] = 'opaga';

SELECT * FROM [dbo].[Members];


DELETE [dbo].[Comments] 
WHERE 
	[CommentTypeId] = (SELECT TOP(1) [Id] FROM [CommentTypes] WHERE [Type] = 'Вопрос')
	AND [Created] BETWEEN CONVERT(DATETIME, '2020-02-01') AND CONVERT(DATETIME, '2020-02-03')
 
SELECT * FROM [dbo].[Comments];

ROLLBACK TRAN;