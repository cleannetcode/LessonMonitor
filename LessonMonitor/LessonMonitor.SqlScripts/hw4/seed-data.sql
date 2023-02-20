USE [LessonMonitor.Database]

INSERT INTO [dbo].[Members] ([Name]) VALUES
(N'opaga'),
(N'Maxim'),
(N'Антон Васильев'),
(N'John Doe'),
(N'nif-nif')
GO

INSERT INTO [dbo].[Topics] ([Name]) VALUES
(N'C# Basics'),
(N'ASP.NET'),
(N'MS SQL Server')
GO

INSERT INTO [dbo].[Lessons] ([Title], [Scheduled]) VALUES
(N'Рефлексия и атрибуты', CONVERT(DATETIME, '2020-02-01 15:00')),
(N'Основы ASP.NET Core', CONVERT(DATETIME, '2020-02-02 15:00')),
(N'Начинаем работу с MS SQL Server', CONVERT(DATETIME, '2020-02-04 11:00'))
GO

INSERT INTO [dbo].[LessonTopics] ([LessonId], [TopicId]) VALUES
(1, 1),
(2, 2),
(3, 3)
GO

INSERT INTO [dbo].[CommentTypes] ([Type]) VALUES
('Таймкод'),
('Вопрос')
GO

INSERT INTO [dbo].[Comments] ([Text], [Created], [CommentTypeId], [LessonId], [MemberId]) VALUES
(N'Ожидаем...', CONVERT(DATETIME, '2020-02-01 15:00'), 1, 1, 5),
(N'Разбираемся с рефлексией', CONVERT(DATETIME, '2020-02-01 15:04'), 1, 1, 5),
(N'Пример работы с рефлексией', CONVERT(DATETIME, '2020-02-01 15:30'), 1, 1, 5),
(N'Создаем свой атрибут', CONVERT(DATETIME, '2020-02-02 16:12'), 1, 1, 4),
(N'Домашка', CONVERT(DATETIME, '2020-02-02 16:41'), 1, 1, 4),

(N'Ожидаем...', CONVERT(DATETIME, '2020-02-01 15:00'), 1, 2, 5),
(N'Разбираемся со структурой веб-приложения', CONVERT(DATETIME, '2020-02-01 15:06'), 1, 2, 4),
(N'Пишем свой пример', CONVERT(DATETIME, '2020-02-01 15:58'), 1, 2, 5),
(N'Начальная информация о контроллерах', CONVERT(DATETIME, '2020-02-02 16:44'), 1, 2, 4),
(N'Домашка', CONVERT(DATETIME, '2020-02-02 17:27'), 1, 2, 1),

(N'Ожидаем...', CONVERT(DATETIME, '2020-02-01 11:00'), 1, 3, 4),
(N'Обзор MS SQL Server', CONVERT(DATETIME, '2020-02-01 11:03'), 1, 3, 1),
(N'Из чего состоит СУБД', CONVERT(DATETIME, '2020-02-01 11:46'), 1, 3, 4),
(N'Пишем первый запрос', CONVERT(DATETIME, '2020-02-02 12:25'), 1, 3, 4),
(N'Домашка', CONVERT(DATETIME, '2020-02-02 12:57'), 1, 3, 4),

(N'Что такое атрибут?', CONVERT(DATETIME, '2020-02-01 15:39'), 2, 1, 1),
(N'Как создать класс?', CONVERT(DATETIME, '2020-02-01 15:12'), 2, 1, 2),
(N'Когда будет про многопоточность?', CONVERT(DATETIME, '2020-02-01 15:31'), 2, 1, 3),
(N'Как я могу сконфигурировать приложение ASP.NET?', CONVERT(DATETIME, '2020-02-02 16:24'), 2, 2, 4),
(N'Что такое middleware?', CONVERT(DATETIME, '2020-02-02 15:19'), 2, 2, 5),
(N'Как удалить таблицу?', CONVERT(DATETIME, '2020-02-04 16:08'), 2, 3, 3)
GO