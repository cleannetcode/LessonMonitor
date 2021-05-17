IF DB_ID('LessonMonitor') IS NULL  
	CREATE DATABASE LessonMonitor
GO

USE LessonMonitor
GO

-- Удалить если существуют таблицы
IF OBJECT_ID ('dbo.Homeworks', 'U') IS NOT NULL  
   DROP TABLE dbo.Homeworks; 

IF OBJECT_ID ('dbo.LessonMembers', 'U') IS NOT NULL  
   DROP TABLE dbo.LessonMembers;  

IF OBJECT_ID ('dbo.Lessons', 'U') IS NOT NULL  
   DROP TABLE dbo.Lessons;

IF OBJECT_ID ('dbo.MemberInternetResource', 'U') IS NOT NULL  
   DROP TABLE dbo.MemberInternetResource;  

IF OBJECT_ID ('dbo.Members', 'U') IS NOT NULL  
   DROP TABLE dbo.Members;  

-- Создание таблиц
CREATE TABLE dbo.Members(
	Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
	LastName NVARCHAR(200) NULL,
	FirstName NVARCHAR(200) NULL,
	Patronomyc NVARCHAR(200) NULL
)

insert into dbo.Members (LastName, FirstName, Patronomyc) values (N'Тестовый', N'Тест', N'Тестович');
GO

CREATE TABLE dbo.MemberInternetResource(
	Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
	MemberId int NOT NULL,
	NickName NVARCHAR(200) NULL,
	InternetResourseName NVARCHAR(200) NULL,
	Link NVARCHAR(500) NULL,
	CONSTRAINT [FK_MemberInternetResource_Members] FOREIGN KEY (MemberId) REFERENCES Members(Id)
) 

insert into dbo.MemberInternetResource (MemberId, NickName, InternetResourseName, Link) values (1, N'Test', N'GitHub', N'http://github.com/test');
GO

CREATE TABLE dbo.Lessons(
	Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(200) NULL,
	Theme NVARCHAR(200) NULL,
	Description NVARCHAR(1000) NULL,
	StartDate datetime NULL,
	Duration int NULL
) 

insert into dbo.Lessons (
	Name, 
	Theme, 
	Description, 
	StartDate, 
	Duration) 
values (N'Знакомимся с t-sql и создаем схему БД', 
		N'SQL SERVER', 
		N'На этом занятии мы начнем изучать язык t-sql. Посмотрим что такое DDL, как строится схема базы данных. увидим что такое: CREATE, ALTER, DROP для таблиц и колонок',
		convert(date,'25.04.2021',104),
		160
	);
GO

CREATE TABLE dbo.LessonMembers(
	Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
	MemberId int NOT NULL,
	LessonId int NOT NULL,
	CONSTRAINT [FK_LessonMembers_Members] FOREIGN KEY (MemberId) REFERENCES Members(Id),
	CONSTRAINT [FK_LessonMembers_Lessons] FOREIGN KEY (LessonId) REFERENCES Lessons(Id)
)  

insert into dbo.LessonMembers (MemberId, LessonId) values (1, 1);
GO 

CREATE TABLE dbo.Homeworks(
	Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
	MemberId int NULL,
	LessonId int NULL,
	Verified bit NULL,
	Mark int NULL,
	GithubLink NVARCHAR(500) NULL,
	CONSTRAINT [FK_Homeworks_Members] FOREIGN KEY (MemberId) REFERENCES Members(Id),
	CONSTRAINT [FK_Homeworks_Lessons] FOREIGN KEY (LessonId) REFERENCES Lessons(Id)
)

insert into dbo.Homeworks (MemberId, LessonId,Verified,Mark,GithubLink)
values (1, 1, 0, null, N'https://github.com/cleannetcode/LessonMonitor/pull/57');