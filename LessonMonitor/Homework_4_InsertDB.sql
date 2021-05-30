use Homework_4
INSERT INTO Students (Nickname, DateRegistration)
VALUES ('Sasha1010', GETDATE()),
	   ('00Gena99', GETDATE()),
	   ('eniluck', '2021-05-23 21:35:56.430')
INSERT INTO Students (Nickname, DateRegistration)
VALUES ('melnkovmaxim', GETDATE()),
	   ('AshtonBro', '2021-04-21 04:00'),
	   ('Misha902', '2021-04-12 07:00'),
	   ('coder1coder', '2021-04-11 09:00'),
	   ('trulander', '2021-04-27 14:00'),
	   ('catdog50rus', '2021-07-01 18:00'),
	   ('trulander', '2021-04-27 19:29'),
	   ('DanyeIIo', '2021-04-17 14:00')
UPDATE Students
SET TypeAccount = 'Admin'
WHERE ID = 1

INSERT INTO Lessons (name, Date)
VALUES ('ASP.NET', '2021-05-25 10:00:00.000'),
	   ('t-sql', '2021-05-26 11:00:00.292'),
	   ('dml','2021-05-27 11:59:59.999')

INSERT INTO Lessons
VALUES ('Многопоточность', '2021-03-25 15:00'),
	   ('Reflection', '2021-02-11 16:00')	

INSERT INTO VisitorsLessons (StudentID, LessonID)
VALUES (1, 1),
	   (1, 2),
	   (1, 3),
	   (2, 2)

UPDATE VisitorsLessons
SET CreatedDate = GETDATE()
WHERE ID < 5

INSERT INTO VisitorsLessons
VALUES (11, 5, GETDATE()),
	   (10, 4, GETDATE()),
	   (9, 3, GETDATE()),
	   (8, 2, GETDATE()),
	   (7, 1, GETDATE()),
	   (6, 2, GETDATE()),
	   (5, 3, GETDATE()),
	   (4, 4, GETDATE()),
	   (3, 5, GETDATE()),
	   (2, 3, GETDATE()),
	   (1, 2, GETDATE()),
	   (10, 5, GETDATE())

INSERT INTO Questions(Topic, Description, StudentId)
VALUES ('C#', 'Что такое for?', 1),
	   ('ASP.NET', '???', 1),
	   ('EF','Когда будем учить EF?', 3)
UPDATE Questions
SET Description = '????????'
WHERE ID = 2

DELETE Questions
WHERE ID = 3

INSERT INTO Timecodes
VALUES ('Начало', '10:00:00.000', 1),
	   ('Домашка', '11:59:00.000', 1),
	   ('Конец','12:10:00.000', 1)

INSERT INTO Timecodes
VALUES ('Begin', '11:00:00.000', 2),
	   ('Приветсвие', '11:15:23.000', 2),
	   ('Проверка дз', '11:20:48.000', 2),
	   ('Команды t-sql', '11:30:12.000', 2),
	   ('домашка', '11:45:01.000', 2),

	   ('Компилируем занятие', '11:59:59.999', 3),
	   ('проверка дз', '12:10:32.000', 3),
	   ('разбираем команды dml', '13:10:42.000', 3),
	   ('SELECT', '13:12:00.000', 3),
	   ('INSERT', '13:19:32.000', 3),
	   ('перерыв', '13:28:21.000', 3),
	   ('продолжение', '13:33:19.000', 3),
	   ('еще про SELECT и %LIKE%', '13:45:02.000', 3),
	   ('BETWEEN', '13:55:51.000', 3),
	   ('ORDER BY', '13:59:59.000', 3),
	   ('GROUP BY (DISTINCT)', '14:04:08.000', 3),
	   ('IN', '14:14:14.000', 3),
	   ('JOIN', '14:21:12.000', 3),
	   ('реализуем INNER JOIN', '14:27:51.000', 3),
	   ('LEFT JOIN', '14:32:46.000', 3),
	   ('CROSS JOIN', '14:40:49.000', 3),
	   ('домашка', '14:45:10.000', 3),

	   ('Begin', '15:00:33.000', 4),
	   ('MultiThread', '15:10:28.000', 4),
	   ('practice', '15:37:16.000', 4),
	   ('Homework', '15:48:55.000', 4),
	   ('End', '16:10:00.000', 4),

	   ('Begin', '16:00:44.000', 5),
	   ('Что такое Reflection', '16:10:11.000', 5),
	   ('Зачем', '16:40:00.000', 5),
	   ('Почему', '17:01:07.000', 5),
	   ('КАК', '17:20:21.000', 5)