USE LessonMonitorDB

IF (EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'Members'))
BEGIN
    ALTER TABLE Members
    ADD Age int NOT NULL,
        UpdatedDate DATETIME2(7) NOT NULL,
        DeletedDate DATETIME2(7) 
END