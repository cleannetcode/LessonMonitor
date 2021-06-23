USE [LessonMonitorDb]


IF (NOT EXISTS (SELECT * 
                FROM INFORMATION_SCHEMA.TABLES 
                WHERE TABLE_SCHEMA = 'dbo' 
                AND  TABLE_NAME = 'Topics'))
BEGIN
    ALTER TABLE [Topics]
	DROP CreatedDate,
		 UpdatedDate,
		 DeletedDate
END