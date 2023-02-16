USE [LessonMonitor.Database]

SELECT m.[Name] AS [MemberName], q.[Text] as [Question Title], q.[Created] AS [Posted],
	l.[Title] AS [LessonTitle], l.Scheduled
	FROM [dbo].[Questions] AS q
	JOIN [dbo].[Lessons] AS l ON (q.LessonId = l.Id)
	JOIN [dbo].[Members] AS m ON (q.MemberId = m.Id)
GO