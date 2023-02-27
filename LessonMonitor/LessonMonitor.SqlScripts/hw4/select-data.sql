USE [LessonMonitor.Database]

SELECT sub2.[Name], sub2.[Title], sub2.[Timecodes], sub2.[Questions], sub1.[LessonVisited], sub2.[Scheduled] 
FROM 
	(SELECT m.[Name], COUNT(DISTINCT c.[LessonId]) as [LessonVisited] 
		FROM [Comments] c
		JOIN [Members] m ON (c.MemberId = m.Id)
		JOIN [Lessons] l ON (c.LessonId = l.Id)
		GROUP BY m.[Name]) sub1
JOIN
	(SELECT q.[Name], q.[Title], COUNT(q.[Questions]) AS [Questions], COUNT(q.[Timecodes]) AS [Timecodes], q.[Scheduled]
		FROM 
		(SELECT m.[Name], l.[Title], l.[Scheduled], c.*, c.[CommentTypeId] AS [Timecodes], NULL AS [Questions] 
			FROM [Comments] c
			JOIN [Members] m ON (c.MemberId = m.Id)
			JOIN [Lessons] l ON (c.LessonId = l.Id)
			WHERE c.[CommentTypeId] = 1
		UNION 
		SELECT m.[Name], l.[Title], l.[Scheduled], c.*, NULL AS [Timecodes], c.[CommentTypeId] AS [Questions] 
			FROM [Comments] c
			JOIN [Members] m ON (c.MemberId = m.Id)
			JOIN [Lessons] l ON (c.LessonId = l.Id)
			WHERE c.[CommentTypeId] = 2) q
	GROUP BY q.[Name], q.[Title], q.[Scheduled]) sub2 
ON (sub1.Name = sub2.Name)
ORDER BY sub2.[Scheduled];

