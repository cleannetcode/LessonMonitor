USE [LessonMonitor.Database]

SELECT CAST(c.[Created] AS TIME) AS [Timecode Time], c.[Text] FROM [Comments] c
JOIN [Lessons] l ON (c.LessonId = l.Id)
WHERE LessonId = 3 AND c.CommentTypeId = 1;