Use LessonMonitorDb

--вывод имени участников и названий посещённых лекций, сорировка по дате лекций
SELECT 
    s.Nickname, 
	l.Name,
	l.Date
FROM 
    LessonsStudents ls
    RIGHT JOIN Students s ON s.Id = ls.StudentId
	FULL OUTER JOIN Lessons l ON l.Id = ls.LessonId
ORDER BY
	l.Date
	
--вывод количества посещённых занятий каждым студентом
SELECT 
	s.Nickname,
	COUNT(ls.LessonId) AS 'visit count'
FROM
	LessonsStudents ls
	RIGHT JOIN Students s ON s.Id = ls.StudentId
GROUP BY
	s.Nickname

--вывод количества заданных вопросов каждым студентом
SELECT 
    s.Nickname, 
	COUNT(q.Id) AS 'questions count'
FROM 
    QuestionsStudents qs
    RIGHT JOIN Students s ON s.Id = qs.StudentId
	FULL OUTER JOIN Questions q ON q.Id = qs.QuestionId
GROUP BY
	s.Nickname

--вывод количества таймкодов по каждой лекции
SELECT 
    l.Name, 
	COUNT(lt.TimecodesId) As 'timecodes count'
FROM 
    LessonsTimecodes lt
    RIGHT JOIN Lessons l ON l.Id = lt.LessonId
GROUP BY
	l.Name

--вывод названия и времени таймкодов по каждой лекции
SELECT 
    l.Name, 
	t.Name,
	t.Timecode
FROM 
    LessonsTimecodes lt
    RIGHT JOIN Lessons l ON l.Id = lt.LessonId
	FULL OUTER JOIN Timecodes t ON t.Id = lt.TimecodesId
	