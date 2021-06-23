USE [LessonMonitorDb]


IF (NOT EXISTS (SELECT * 
                FROM INFORMATION_SCHEMA.TABLES 
                WHERE TABLE_SCHEMA = 'dbo' 
                AND  TABLE_NAME = 'Users'))
BEGIN
    ALTER TABLE [Users]
	DROP CreatedDate,
		UpdatedDate,
		DeletedDate
END