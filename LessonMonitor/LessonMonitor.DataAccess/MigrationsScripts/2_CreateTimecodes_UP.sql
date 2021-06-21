USE [LessonMonitorDb]

IF (NOT EXISTS (SELECT * 
                FROM INFORMATION_SCHEMA.TABLES 
                WHERE TABLE_SCHEMA = 'dbo' 
                AND  TABLE_NAME = 'Timecodes'))
BEGIN
    CREATE TABLE [Timecodes] (
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (2,4),
	[LessonId] INT NOT NULL,
	[Description] NVARCHAR(600) NULL,
	[Timecode] TIME(3),
	CONSTRAINT [FK_Timecodes_Lessons] FOREIGN KEY (LessonId) REFERENCES Lessons(Id)
	)
END