-- SELECT * FROM Members

-- DELETE FROM Members
-- WHERE Name = 'Joe'

-- SELECT * FROM MemberAccounts

-- DELETE FROM MemberAccounts

-- INSERT INTO Members(Name, CreatedDate)
-- VALUES (N'Maksims Sol', GETDATE()),
--        (N'Александр Пономарев', GETDATE())


-- INSERT INTO Members(Name, CreatedDate)
-- VALUES (N'Евгений С.', GETDATE()),
--        (N'Глеб Ежов', GETDATE()),
--        (N'Василий', GETDATE()),
--        (N'died 5thjuly', GETDATE()),
--        (N'Евгения Медведева', GETDATE())

-- INSERT INTO Lessons(Title, Description, StartDate, CreatedDate)
-- VALUES (N'T-SQL и DML, управляем данными', 
--         N'Всем привет, на этом занятии мы начнем рассматривать язык DML',
--         '2021-05-23 11:00:00',
--         '2021-05-21 16:00:00')

-- SELECT GETDATE()

-- SELECT * FROM Lessons

-- INSERT INTO VisitedLessons(MemberId, LessonId, CreatedDate)
-- SELECT ID, 4, GETDATE() FROM Members

-- SELECT * FROM VisitedLessons
-- SELECT * FROM Lessons
-- SELECT * FROM Members

-- UPDATE Lessons
-- SET StartDate = '2021-05-23 8:00:00.0000000'
-- WHERE Id = 4

-- SELECT * FROM Lessons
-- WHERE Title LIKE N'T%у%и'


-- SELECT * FROM Lessons
-- WHERE StartDate > '2021-05-23 08:00:00.0000000' AND StartDate < '2021-05-24' 

-- SELECT * FROM Lessons
-- WHERE StartDate BETWEEN '2021-05-23 08:00:00.0000000' AND '2021-05-24'

-- SELECT * FROM Lessons
-- WHERE Title LIKE '%sql%' AND Description NOT LIKE N'%привет%'


-- SELECT * FROM Members
-- ORDER BY CreatedDate DESC

-- SELECT * FROM Members
-- ORDER BY CreatedDate DESC, Name DESC

-- Count, SUM, AVG, MAX, MIN
SELECT Count(*) FROM VisitedLessons
WHERE LessonId = 4

-- -- Сколько человек посетило лекции
-- SELECT LessonId, COUNT(*) FROM VisitedLessons
-- GROUP BY LessonId

-- -- Самая популярная лекция
-- SELECT TOP 1 LessonId, COUNT(MemberId) FROM VisitedLessons
-- GROUP BY LessonId
-- ORDER BY COUNT(MemberId) DESC

-- SELECT LessonId, COUNT(*) FROM VisitedLessons
-- GROUP BY LessonId
-- HAVING COUNT(*) < 4

-- SELECT * FROM Members
-- WHERE Id IN (5, 7, 9) - в IN может быть только 4000 записей

-- SELECT * FROM Members
-- WHERE Id = 5 OR Id = 7 OR Id = 9

-- SELECT * FROM Members
-- WHERE Id IN (
--     SELECT MemberId FROM VisitedLessons
--     WHERE LessonId = 3
-- )

-- SELECT DISTINCT LessonId FROM VisitedLessons

-- JOIN - объединение таблиц

--SELECT Name, LessonId, vl.CreatedDate FROM Members m
--INNER JOIN VisitedLessons vl ON m.Id = vl.MemberId
--ORDER BY LessonId

--SELECT * FROM VisitedLessons vl
--INNER JOIN Members m ON m.Id = vl.MemberId

--SELECT l.Title, m.Name, vl.CreatedDate FROM Members m
--INNER JOIN VisitedLessons vl ON m.Id = vl.MemberId
--INNER JOIN Lessons l ON l.Id = vl.LessonId
--ORDER BY LessonId

--SELECT l.Id, l.Title, COUNT(*) FROM Members m
--INNER JOIN VisitedLessons vl ON m.Id = vl.MemberId
--INNER JOIN Lessons l ON l.Id = vl.LessonId
--GROUP BY Title, l.Id
--ORDER BY l.Id

--INSERT INTO Members(Name, CreatedDate)
--VALUES (N'pingvin1308', GETDATE())

--SELECT * FROM Members m
--LEFT JOIN VisitedLessons vl ON m.Id = vl.MemberId 


--SELECT * FROM Members m
--LEFT JOIN VisitedLessons vl ON m.Id = vl.MemberId
--WHERE vl.MemberId IS NULL


--SELECT l.Title, m.Name, vl.CreatedDate FROM Members m
--INNER JOIN VisitedLessons vl ON m.Id = vl.MemberId
--INNER JOIN Lessons l ON l.Id = vl.LessonId
--WHERE m.Name = N'pingvin1308'
--ORDER BY LessonId


--SELECT * FROM VisitedLessons vl
--RIGHT JOIN Members m ON m.Id = vl.MemberId 

--SELECT * FROM VisitedLessons vl
--RIGHT JOIN Members m ON m.Id = vl.MemberId
--WHERE vl.MemberId IS NULL

--SELECT * FROM Members m
--FULL OUTER JOIN VisitedLessons vl ON m.Id = vl.MemberId

--SELECT * FROM Members m
--FULL OUTER JOIN VisitedLessons vl ON m.Id = vl.MemberId
--WHERE m.Id IS NULL OR vl.MemberId IS NULL

--SELECT m.Name, l.Title FROM Members m, Lessons l

--SELECT m.Name, l.Title FROM Members m
--CROSS JOIN Lessons l
