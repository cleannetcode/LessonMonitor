USE [LessonMonitorDb]


IF (NOT EXISTS (SELECT * 
                FROM INFORMATION_SCHEMA.TABLES 
                WHERE TABLE_SCHEMA = 'dbo' 
                AND  TABLE_NAME = 'Homeworks'))
BEGIN
    ALTER TABLE [Homeworks]
	DROP CreatedDate,
		UpdatedDate,
		DeletedDate
END