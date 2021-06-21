USE [LessonMonitorDb]

IF (EXISTS (SELECT * 
            FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_SCHEMA = 'dbo' 
            AND  TABLE_NAME = 'Timecodes'))
BEGIN
   DROP TABLE [dbo].[Timecodes]
END