USE [LessonMonitorDb]

IF (EXISTS (SELECT * 
            FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_SCHEMA = 'dbo' 
            AND  TABLE_NAME = 'Homeworks'))
BEGIN
    ALTER TABLE [Homeworks]
	ADD CreatedDate DATETIME2(7) NOT NULL,
		UpdatedDate DATETIME2(7) NOT NULL,
		DeletedDate DATETIME2(7) NULL
END
