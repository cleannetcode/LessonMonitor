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
(N'Рефлексия и атрибуты', GETDATE()),
(N'Основы ASP.NET Core', GETDATE()),
(N'Начинаем работу с MS SQL Server', GETDATE())
GO

INSERT INTO [dbo].[LessonTopics] ([LessonId], [TopicId]) VALUES
(1, 1),
(2, 2),
(3, 3)
GO

INSERT INTO [dbo].[Questions] ([Text], [Created], [LessonId], [MemberId]) VALUES
(N'Что такое атрибут?', GETDATE(), 1, 1),
(N'Как создать класс?', GETDATE(), 1, 2),
(N'Когда будет про многопоточность?', GETDATE(), 1, 3),
(N'Как я могу сконфигурировать приложение ASP.NET?', GETDATE(), 2, 4),
(N'Что такое middleware?', GETDATE(), 2, 5),
(N'Как удалить таблицу?', GETDATE(), 3, 3)
GO
