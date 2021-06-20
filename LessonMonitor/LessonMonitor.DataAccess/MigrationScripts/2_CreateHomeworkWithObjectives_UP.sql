USE LessonMonitorDB

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'Homeworks'))
BEGIN
    CREATE TABLE Homeworks (
        Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
        Title NVARCHAR(200) NOT NULL,
        Description NVARCHAR(1000) NOT NULL,
        Link NVARCHAR(1000) NOT NULL,
    )
END

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'Objectives'))
BEGIN
    CREATE TABLE Objectives (
        Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
        Title NVARCHAR(200) NOT NULL,
        Description NVARCHAR(1000) NOT NULL,
        HomeworkId INT NOT NULL,
        FOREIGN KEY (HomeworkId) REFERENCES Homeworks(Id)
    )
END
