USE [LessonMonitorDb]


IF (NOT EXISTS (SELECT * 
                FROM INFORMATION_SCHEMA.TABLES 
                WHERE TABLE_SCHEMA = 'dbo' 
                AND  TABLE_NAME = 'Questions'))
BEGIN
    ALTER TABLE [Questions]
	DROP CreatedDate,
		UpdatedDate,
		DeletedDate
END