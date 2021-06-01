
--CREATE DATABASE LessonDb

--DROP DATABASE LessonDb

USE [LessonDb]

CREATE TABLE [Members]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1), 
	[Name] NVARCHAR(50) NOT NULL, 
	[Nicknames] NVARCHAR(100) NULL, 
	[Email] NVARCHAR(200) NULL UNIQUE,
	[CreateDate] DATETIME2 DEFAULT GETDATE()
)

CREATE TABLE [Questions]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (4, 2),
	[MemberId] INT NOT NULL,
	[Description] NVARCHAR(300) NOT NULL, 
	[CreatedDate] DATETIME2 DEFAULT GETDATE(),
	CONSTRAINT [FK_Questions_Members] FOREIGN KEY (MemberId) REFERENCES Members(Id)
)

CREATE TABLE [Lessons]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (3,5), 
	[Title] NVARCHAR(200) NOT NULL, 
	[Description] NVARCHAR(500) NULL, 
	[StartDate] DATETIME2 NULL, 
	[CreatedDate] DATETIME2 DEFAULT GETDATE()
)

CREATE TABLE [MembersLessons]
(
	[MemberId] INT NOT NULL,
	[LessonId] INT NOT NULL,
	[CreatedDate] DATETIME2 DEFAULT GETDATE(),
	CONSTRAINT [PK_MemberId_LessonId] PRIMARY KEY (MemberId, LessonId),
	CONSTRAINT [FK_MembersLessons_Members] FOREIGN KEY (MemberId) REFERENCES Members(Id),
	CONSTRAINT [FK_MembersLessons_Lessons] FOREIGN KEY (LessonId) REFERENCES Lessons(Id)
)

CREATE TABLE [Timecodes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (2,4),
	[LessonId] INT NOT NULL,
	[Description] NVARCHAR(600) NULL,
	[Timecode] TIME(3),
	CONSTRAINT [FK_Timecodes_Lessons] FOREIGN KEY (LessonId) REFERENCES Lessons(Id)
)

-- Заполняем таблицу Members
INSERT Members (Name, Nicknames, Email, CreateDate)
VALUES (N'Evgenii', N'AshtonBro', N'ashtonBro@gmail.com', '2021-05-26T23:55:41.9341552+05:00')
INSERT Members (Name, Nicknames, Email, CreateDate)
VALUES (N'Roman', N'pingvin1308', N'pingvin1308@gmail.com', '2021-05-26T23:55:41.9341552+05:00')
INSERT Members (Name, Nicknames, Email, CreateDate)
VALUES (N'Misha', N'Misha902', N'misha902@gmail.com', '2021-05-23T00:07:50.4079379+05:00')
INSERT Members (Name, Nicknames, Email, CreateDate)
VALUES (N'Maxim', N'melnkovmaxim', N'melnkovmaxim@gmail.com', '2021-05-22T00:07:50.4079379+05:00')
INSERT Members (Name, Nicknames, Email, CreateDate)
VALUES (N'Anton', N'coder1coder', N'coder1coder@gmail.com', '2021-05-22T00:07:50.4079379+05:00')
INSERT Members (Name, Nicknames, Email, CreateDate)
VALUES (N'Andrey', N'eniluck', N'eniluck@gmail.com', '2021-05-22T00:07:50.4079379+05:00')
INSERT Members (Name, Nicknames, Email, CreateDate)
VALUES (N'Evgeniya', N'emedvedeva', N'emedvedeva@gmail.com', '2021-05-22T00:07:50.4079379+05:00')
INSERT Members (Name, Nicknames, Email, CreateDate)
VALUES (N'Nehochuha', N'Nehochuha', N'nlodir@gmail.com', '2021-05-21T00:07:50.4079379+05:00')
INSERT Members (Name, Nicknames, Email, CreateDate)
VALUES (N'Danya', N'DanyeIIo', N'danyeIIo@gmail.com', '2021-05-21T00:07:50.4079379+05:00')
INSERT Members (Name, Nicknames, Email, CreateDate)
VALUES (N'Mike', N'Dead 5thjuly', N'5thjulyr@gmail.com', '2021-07-05T00:07:50.4079379+05:00')

-- Заполняем таблицу Questions
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (1, N'Что такое рекурсия?', GETDATE())
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (1, N'Какая разница между GET и POST HTTP методами?', GETDATE())
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (1, N'Что такое JSON?', GETDATE())
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (1, N'Какую проблему решает Docker? Каковы его плюсы и минусы?', GETDATE())
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (1, N'Каковы его плюсы и минусы?', GETDATE())
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (6, N'Чем принципиально отличаются unit-тесты от интеграционных тестов?', GETDATE())
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (5, N'Что такое Exception?', GETDATE())
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (4, N' Для чего служат try, catch, finally? В каком случае может не выполниться блок finally?', GETDATE())
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (3, N'Что такое call stack? Какие ключевые слова вы знаете?', GETDATE())
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (3, N'Что такое ASP.NET?', GETDATE())
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (3, N'Какие существуют типы Action filters?', GETDATE())
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (3, N'Что такое Web Service?', GETDATE())
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (4, N'Что такое CLR?', GETDATE())
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (4, N'Что такое сборщик мусора (Garbage Collector) на базовом уровне?', GETDATE())
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (4, N'Что такое делегат?', GETDATE())
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (4, N'Отличается ли Delegate от Action?', GETDATE())
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (4, N'Какие знаете коллекции??', GETDATE())
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (4, N'Что такое enum flags?', GETDATE())
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (4, N'Что делает оператор yield?', GETDATE())
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (5, N'Что такое LINQ и для чего используется? Приведите несколько примеров применения LINQ', GETDATE())
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (5, N'Что такое пространство имен (namespace) и зачем это нужно?', GETDATE())
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (5, N'Что такое Nullable-тип?', GETDATE())
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (5, N'Что такое Key-value структуры?', GETDATE())
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (5, N'Чем отличается абстрактный класс от интерфейса?', GETDATE())
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (6, N'Что такое IaaS, PaaS, SaaS и каковы различия между ними?', GETDATE())
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (6, N'Что такое асинхронность и чем она отличается от многопоточности?', GETDATE())
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (6, N'Какие знаете паттерны?', GETDATE())
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (6, N'Для чего нужен паттерн Strategy?', GETDATE())
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (7, N'Какое различие между const и read only?', GETDATE())
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (7, N'Что такое асинхронность и чем она отличается от многопоточности?', GETDATE())
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (7, N'Что означают ключевые слова async / await?', GETDATE())
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (7, N'Какие типы JOIN существуют в SQL?', GETDATE())
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (9, N'кто такой junior?', GETDATE())
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (9, N'Какая зарплата у разработчика?', GETDATE())
INSERT Questions (MemberId, Description , CreatedDate)
VALUES (9, N'Как долго будут идти уроки?', GETDATE())

-- Заполняем таблицу Lessons
INSERT Lessons (Title, Description, StartDate, CreatedDate)
VALUES (N'SQL', N'T-SQL и DML, управляем данными', DATEADD(DAY,+7,GETDATE()), '2021-03-25 00:48:21.8733333')
INSERT Lessons (Title, Description, StartDate, CreatedDate)
VALUES (N'SQL', N'Для чего нужна нормализация базы данных', DATEADD(DAY,+7,GETDATE()), '2021-03-25 00:48:21.8733333')
INSERT Lessons (Title, Description, StartDate, CreatedDate)
VALUES (N'SQL', N'Знакомимся с t-sql и создаем схему БД', DATEADD(DAY,+7,GETDATE()), '2021-03-25 00:48:21.8733333')
INSERT Lessons (Title, Description, StartDate, CreatedDate)
VALUES (N'SQL', N'Начинаем разбираться с MSSQL', DATEADD(DAY,+7,GETDATE()), '2021-03-25 00:48:21.8733333')
INSERT Lessons (Title, Description, StartDate, CreatedDate)
VALUES (N'SQL', N'Табличные выражения - Решения', DATEADD(DAY,+7,GETDATE()), '2021-04-22 00:48:21.8733333')
INSERT Lessons (Title, Description, StartDate, CreatedDate)
VALUES (N'SQL', N'Операторы работы с наборами', DATEADD(DAY,+7,GETDATE()), '2021-04-22 00:48:21.8733333')
INSERT Lessons (Title, Description, StartDate, CreatedDate)
VALUES (N'ASPNET', N'Слоеная структура решений', DATEADD(DAY,+7,GETDATE()), '2021-04-22 00:48:21.8733333')
INSERT Lessons (Title, Description, StartDate, CreatedDate)
VALUES (N'ASPNET', N'Что такое middleware и как с ним работать?', DATEADD(DAY,+7,GETDATE()), '2021-04-22 00:48:21.8733333')
INSERT Lessons (Title, Description, StartDate, CreatedDate)
VALUES (N'ASPNET', N'Как работать с рефлексией и атрибутами в C#', DATEADD(DAY,+7,GETDATE()), '2021-05-24 00:48:21.8733333')
INSERT Lessons (Title, Description, StartDate, CreatedDate)
VALUES (N'ASPNET', N'Начинаем изучать asp.net core API', DATEADD(DAY,+7,GETDATE()), '2021-05-24 00:48:21.8733333')
INSERT Lessons (Title, Description, StartDate, CreatedDate)
VALUES (N'ASPNET', N'IWebHostEnvironment и окружение', DATEADD(DAY,+7,GETDATE()), '2021-05-24 00:48:21.8733333')
INSERT Lessons (Title, Description, StartDate, CreatedDate)
VALUES (N'C#', N'Как новичку начать писать программы на C#', DATEADD(DAY,+7,GETDATE()), '2021-05-24 00:48:21.8733333')
INSERT Lessons (Title, Description, StartDate, CreatedDate)
VALUES (N'C#', N'Создаем репозиторий на github и разбираем типы данных в С#', DATEADD(DAY,+7,GETDATE()), '2021-05-24 00:48:21.8733333')
INSERT Lessons (Title, Description, StartDate, CreatedDate)
VALUES (N'C#', N'Что такое бизнес логика и как она реализуется в приложении', DATEADD(DAY,+7,GETDATE()), '2021-05-26 00:48:21.8733333')
INSERT Lessons (Title, Description, StartDate, CreatedDate)
VALUES (N'C#', N'Разбираемся с классами C#', DATEADD(DAY,+7,GETDATE()), '2021-05-26 00:48:21.8733333')
INSERT Lessons (Title, Description, StartDate, CreatedDate)
VALUES (N'C#', N'Что такое валидация моделей и валидация вообще', DATEADD(DAY,+7,GETDATE()), '2021-05-26 00:48:21.8733333')
INSERT Lessons (Title, Description, StartDate, CreatedDate)
VALUES (N'C#', N'Ветвление, циклы и массивы в C#', DATEADD(DAY,+7,GETDATE()), '2021-05-26 00:48:21.8733333')
INSERT Lessons (Title, Description, StartDate, CreatedDate)
VALUES (N'C#', N'Структуры современных решений на .net и C#', DATEADD(DAY,+7,GETDATE()), '2021-05-26 00:48:21.8733333')
INSERT Lessons (Title, Description, StartDate, CreatedDate)
VALUES (N'C#', N'Интерфейсы в c#, боксинг и анбоксинг простых типов', DATEADD(DAY,+7,GETDATE()), '2021-05-17 00:48:21.8733333')
INSERT Lessons (Title, Description, StartDate, CreatedDate)
VALUES (N'C#', N'Структуры, пространства имен, неймспейсы и области видимости переменных', DATEADD(DAY,+7,GETDATE()), '2021-05-19 00:48:21.8733333')

--Заполняем таблицу Таймкодов
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (3, N'Вводный данные', CONVERT(VARCHAR(8), GETDATE(), 108))
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (3, N'Что такое DML', '01:12:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (3, N'T-SQL для чайников', '01:24:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (3, N'Управление данными', '02:22:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (8, N'Сказ о тегах', '04:33:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (8, N'Какие аномалии возникают', '04:45:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (8, N'Типы нормализации', '04:53:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (8, N'Практика нормализации БД', '05:10:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (8, N'Практика БД', '05:10:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (8, N'ДЗ', '05:10:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (13, N'Создаём схему БД', '07:12:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (13, N'Ошибки при создании БД', '07:22:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (13, N'Primary Key', '07:42:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (13, N'Foreign Key', '07:44:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (18, N'Начало работы с MSSQL', '08:14:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (18, N'Что такое БД', '08:25:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (18, N'Типы данных БД Sql', '08:31:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (18, N'Реляционная БД', '08:45:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (23, N'производные таблицы', '09:05:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (23, N'обобщенные табличные выражения', '09:13:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (23, N'транслятор SQL', '09:27:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (23, N'Причина ошибки', '09:34:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (28, N'ANSI оператор INTERSECT', '10:15:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (28, N'Оператор INTO', '10:15:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (28, N'DISTINCT может', '10:33:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (28, N'SELECT … UNION', '10:37:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (28, N'инструкция SELECT 1', '10:47:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (33, N'Что такое архитектура', '11:17:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (33, N'Название слоёв', '11:27:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (33, N'Плюсы слоённой архитектуры', '11:37:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (33, N'Слоённая архитектура', '11:47:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (38, N'Middleware и как с ним работать', '12:13:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (38, N'Endpoint', '12:21:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (38, N'Contex что в нём есть', '12:37:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (38, N'App.User()', '12:59:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (43, N'Reflection что это', '13:10:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (43, N'Рефлексия типов', '13:19:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (43, N'RequaredCustonAttribute', '13:23:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (43, N'что дают Attribute', '13:39:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (48, N'Web c C#', '14:11:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (48, N'Что такое ASPNET', '14:12:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (48, N'как работает swagger', '14:24:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (48, N'Контроллеры', '14:44:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (53, N'IHostingEnvironment', '15:13:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (53, N'Properties есть файл launchSettings.json', '15:17:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (53, N'ASPNETCORE_ENVIRONMENT', '15:21:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (53, N'Определение своих состояний среды', '15:42:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (58, N'Язык C# и платформа .NET', '16:06:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (58, N'Компиляция в командной строке с .NET Core CLI', '16:17:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (58, N'Структура программы', '16:24:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (58, N'Начало работы с Visual Studio. Первая программа', '16:39:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (63, N'Зачем нужен GitHub', '17:06:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (63, N'Git команды', '17:17:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (63, N'Push Pull Repository', '17:24:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (63, N'Работа с доской в команде', '17:39:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (68, N'Что такое бизнес логика', '18:26:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (68, N'Ошибка при работе с бизнесом', '18:27:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (68, N'Развиваем бизнес логику в нашем приложении', '18:24:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (68, N'Проблем в реализации', '18:29:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (68, N'Что такое класс', '18:29:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (68, N'Чем отличается класс от абстрактного класса', '18:29:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (68, N'Модификаторы доступа', '18:29:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (73, N'Что такое класс', '19:12:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (73, N'Что можно объявить в классе', '19:32:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (73, N'Конструктор и работа с классами', '19:42:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (73, N'Наследование', '19:52:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (78, N'Аттрибуты валидации моделей', '20:12:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (78, N'Обработка ошибок при валидации моделей', '20:32:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (78, N'Собственный атрибут валидации', '20:42:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (78, N'Что такое валидация', '20:52:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (78, N'Что такое аттрибуты-валидация', '20:52:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (83, N'Аттрибуты валидации моделей', '21:53:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (83, N'Обработка ошибок при валидации моделей', '21:23:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (83, N'Собственный атрибут валидации', '21:09:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (83, N'Что такое валидация', '21:40:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (88, N'Структура решение относительно слоённой архитектуры', '22:13:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (88, N'Структура решение относительно 3-х звенной архитектуры', '22:28:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (88, N'кратко о web api', '22:47:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (88, N'начало - введение в проекты', '22:48:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (93, N'Интерфейсы в C#', '23:23:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (93, N'Боксинг простых типов', '23:28:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (93, N'Анбоксинг простых типов', '23:37:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (93, N'Абстракции', '23:49:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (93, N'Какие примитивные типы знаете', '23:49:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (93, N' Что такое Nullable-тип', '23:49:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (98, N'За что отвечает неймспейс', '23:13:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (98, N'пространства имён', '23:12:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (98, N'Области видимости', '23:17:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (98, N'Структуры данных', '23:19:55.000')
INSERT Timecodes (LessonId, Description, Timecode)
VALUES (98, N'Структуры', '23:10:55.000')

-- Заполняем таблицу посещенных лекций MembersLessons
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (1, 3, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (1, 8, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (1, 13, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (1, 18, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (1, 23, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (1, 28, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (1, 33, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (1, 38, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (1, 43, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (1, 48, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (1, 53, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (1, 58, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (1, 63, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (1, 68, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (1, 73, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (1, 78, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (1, 83, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (1, 88, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (1, 93, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (1, 98, GETDATE())

INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (2, 3, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (2, 8, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (2, 13, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (2, 18, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (2, 23, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (2, 28, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (2, 33, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (2, 38, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (2, 43, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (2, 48, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (2, 53, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (2, 58, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (2, 63, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (2, 68, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (2, 73, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (2, 78, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (2, 83, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (2, 88, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (2, 93, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (2, 98, GETDATE())

INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (3, 3, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (3, 8, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (3, 13, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (3, 18, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (3, 23, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (3, 28, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (3, 33, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (3, 38, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (3, 43, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (3, 48, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (3, 53, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (3, 58, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (3, 63, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (3, 68, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (3, 73, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (3, 78, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (3, 83, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (3, 88, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (3, 93, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (3, 98, GETDATE())

INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (4, 3, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (4, 8, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (4, 13, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (4, 18, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (4, 23, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (4, 28, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (4, 33, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (4, 38, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (4, 43, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (5, 48, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (5, 53, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (5, 58, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (5, 63, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (5, 68, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (5, 73, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (5, 78, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (5, 83, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (5, 88, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (5, 93, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (5, 98, GETDATE())

INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (6, 3, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (6, 8, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (6, 13, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (6, 18, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (6, 23, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (6, 28, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (6, 33, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (6, 38, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (6, 43, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (6, 48, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (6, 53, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (6, 58, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (6, 63, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (6, 68, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (6, 73, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (6, 78, GETDATE())

INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (7, 38, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (7, 43, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (7, 48, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (7, 53, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (7, 58, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (7, 63, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (7, 68, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (7, 73, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (7, 78, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (7, 83, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (7, 88, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (7, 93, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (7, 98, GETDATE())

INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (10, 93, GETDATE())
INSERT MembersLessons (MemberId, LessonId, CreatedDate)
VALUES (10, 98, GETDATE())

-- Динамическое заполнение данных
INSERT INTO MembersLessons(MemberId, LessonId, CreatedDate)
SELECT Id, 3, GETDATE() FROM Members

INSERT INTO MembersLessons(MemberId, LessonId, CreatedDate)
SELECT Id, 8, GETDATE() FROM Members

INSERT INTO MembersLessons(MemberId, LessonId, CreatedDate)
SELECT Id, 13, GETDATE() FROM Members

-- UPDATE
UPDATE Timecodes
SET Timecodes.Description = 'Вводный данные (UPDATE)'
WHERE Id = 2

UPDATE Questions
SET Description  = 'Какие существуют типы Filters в ASP.NET? (UPDATE)'
WHERE Id = 22

-- Имя участника
SELECT Name FROM Members

-- Название урока
SELECT Description FROM Lessons

-- Кол-во вопросов
SELECT COUNT(Id) as 'Кол-во вопросов' FROM Questions

-- Кол-во таймкодов
SELECT COUNT(Id) as 'Кол-во таймкодов' FROM Timecodes

-- Кол-во посещенных занятий
SELECT COUNT(MemberId) as 'кол-во посещенных занятий' FROM MembersLessons

-- Подсчёт кол-во уроков каждой категории GROUP BY
SELECT Title, COUNT(Id) as 'Кол-во уроков' FROM Lessons
GROUP BY Title

-- DISTINCT возвращает только уникальные значения
SELECT DISTINCT Title FROM Lessons

-- Темы урока и их кол-во по темам
SELECT Title, COUNT(Title) as 'Кол-во пройденных лекция по темам' FROM Lessons
GROUP By Title

-- Сортитовка по дате
SELECT * FROM Lessons l
WHERE l.CreatedDate > '2021-05-24 00:48:21.8733333'

SELECT * FROM Lessons l
WHERE l.CreatedDate < GETDATE()

-- Количество посещений каждого участника
SELECT m.Name, COUNT(ml.LessonId) as 'Кол-во посещений' FROM Members m
LEFT JOIN MembersLessons ml ON m.Id = ml.MemberId
GROUP BY m.Name, m.Id

-- Количество таймокодов у каждой лекции
SELECT l.Description, COUNT(t.Timecode) as 'Кол-во таймкодов у каждого урока' from Lessons l
LEFT JOIN Timecodes t ON l.Id = t.LessonId
GROUP BY l.Description

-- Собираем таймкод для конкретного занятия
--Так как мы собираем таймкоды конкретного занятия, то следует использовать INNER JOIN.
--Потому что, если у занятия нету таймкодов, то мы не должны ничего вывести.
SELECT t.Timecode, t.[Description] FROM Timecodes t
INNER JOIN Lessons l ON l.Id = t.LessonId
WHERE l.Id = 13

SELECT t.Timecode, t.[Description] FROM Timecodes t
LEFT JOIN Lessons l ON l.Id = t.LessonId
WHERE l.Id IN (13, 38, 73, 58)

-- Собираем таймкод для конкретных занятий у которых в описании присутствует выражение C# 
SELECT t.Timecode, t.[Description] FROM Timecodes t
LEFT JOIN Lessons l ON l.Id = t.LessonId
WHERE l.id IN (
	SELECT Id FROM Lessons le
	WHERE le.Description like '%C#%'
)

-- Практика JOIN 
SELECT
m.[Name],
m.Nicknames,
l.Title,
l.[Description],
q.Discription,
t.Timecode

FROM Members m
LEFT JOIN MembersLessons ml on m.Id = ml.MemberId
LEFT JOIN Lessons l on l.Id = ml.LessonId
INNER JOIN Timecodes t on t.LessonId = ml.LessonId
LEFT JOIN Questions q on q.MemberId = m.Id

-- Статистика вывод Имя участника, Название урока, кол-во вопросов, кол-во таймкодов, кол-во посещенных занятий
USE [LessonDb]

SELECT
m.Id,
m.[Name],
COUNT(q.Id) as 'QuantityQuestions'

INTO CountQuestions
FROM Members m
RIGHT JOIN Questions q on q.MemberId = m.Id
GROUP BY m.Id, m.Name 

SELECT
m.Id,
m.[Name],
COUNT(l.Id) as 'QuantityVisitedLessons'

INTO CountLessons
FROM Members m
LEFT JOIN MembersLessons ml on ml.MemberId = m.Id
LEFT JOIN Lessons l on l.Id = ml.LessonId
GROUP BY m.Id, m.Name

SELECT
ml.MemberId,
l.Id as 'LessonId',
l.Title,
l.Description,
COUNT(t.Id) as 'QuantityTimecodes'

INTO LessonStatistic
FROM Lessons l
RIGHT JOIN MembersLessons ml on ml.LessonId = l.Id
RIGHT JOIN Timecodes t on t.LessonId = l.Id
GROUP BY ml.MemberId, l.Id, l.Description, l.Title
ORDER BY ml.MemberId

SELECT 
m.Id,
m.[Name],
m.Email,
cl.QuantityVisitedLessons,
cq.QuantityQuestions,
ls.LessonId,
ls.Title,
ls.[Description],
ls.QuantityTimecodes

FROM Members m
LEFT JOIN CountLessons cl on cl.Id = m.Id
LEFT JOIN CountQuestions cq on cq.Id = m.Id
LEFT JOIN LessonStatistic ls on ls.MemberId = m.Id
ORDER BY m.Id

DROP TABLE CountLessons
DROP TABLE CountQuestions
DROP TABLE LessonStatistic

-- Cделать два запроса с одинаковым планом
SELECT l.* FROM Lessons l
WHERE l.Id in (
	SELECT DISTINCT t.LessonId FROM Timecodes t
	WHERE t.Timecode BETWEEN '01:12:55.000' AND '10:33:55.000'
)

SELECT DISTINCT l.* FROM Lessons l
INNER JOIN Timecodes t on t.LessonId = l.Id 
WHERE t.Timecode BETWEEN '01:12:55.000' AND '10:33:55.000'

SELECT m.* FROM Members m
WHERE m.Id in (
	SELECT DISTINCT q.MemberId FROM Questions q
	WHERE q.Id BETWEEN 10 AND 48
)

SELECT DISTINCT m.* FROM Members m
INNER JOIN Questions q on q.MemberId = m.Id
WHERE q.Id BETWEEN 10 AND 48
