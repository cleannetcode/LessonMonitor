USE LessonMonitorDB

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'Homeworks'))
BEGIN
    ALTER TABLE Homeworks
	DROP CreatedDate,
		UpdatedDate,
		DeletedDate
END

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'Objectives'))
BEGIN
    ALTER TABLE Objectives
	DROP CreatedDate,
		UpdatedDate,
		DeletedDate
END
