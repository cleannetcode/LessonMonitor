
USE LessonDb2

-- Members
DECLARE @Id int
SET @Id = 1

WHILE @Id <= 1000000

BEGIN

INSERT INTO Members VALUES (
	CAST(NEWID() as NVARCHAR(36)) + ' -Member',
	CAST(NEWID() as NVARCHAR(36)) + ' -Nickname',
	CAST(NEWID() as NVARCHAR(36)) + ' -Email',
	GETDATE(),
	GETDATE())

	SET @Id = @Id + 1 
END

-- Lessons
DECLARE @Id int
SET @Id = 1

WHILE @Id <= 1000
BEGIN

INSERT INTO Lessons VALUES (
	CAST(NEWID() as NVARCHAR(36)) + ' -Title',
	CAST(NEWID() as NVARCHAR(36)) + ' -Description',
	GETDATE(),
	GETDATE())

	SET @Id = @Id + 1 
END

-- VisitedLessons
SELECT * FROM Members

DECLARE @Id int
SET @Id = 1

WHILE @Id <= 1000
BEGIN

DECLARE @LessonId int
INSERT INTO Lessons VALUES (
	CAST(NEWID() as NVARCHAR(36)) + ' -Title',
	CAST(NEWID() as NVARCHAR(36)) + ' -Description',
	GETDATE(),
	GETDATE())
	SELECT @LessonId = SCOPE_IDENTITY()

	INSERT INTO MembersLessons
	SELECT Id, @LessonId, GETDATE() FROM Members

	SET @Id = @Id + 1 
END

-- Call "heavy" query
SELECT TOP 100 * FROM Members m
INNER JOIN MembersLessons ml on m.Id = ml.MemberId
INNER JOIN Lessons l on l.Id = ml.LessonId
WHERE l.Title like '939177AC-8%'
ORDER BY m.Id


------------------------------# Create Procedure

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE create_members
	-- Add the parameters for the stored procedure here
	@Name nvarchar(50),
	@Nickname nvarchar(100),
	@Email nvarchar(200)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT Id FROM Members
	WHERE Name = @Name)
	BEGIN
		INSERT INTO Members
		VALUES (@Name, @Nickname, @Email, GETDATE())

		PRINT SCOPE_IDENTITY()
	END
	ELSE
	RETURN ERROR_MESSAGE()

END
GO

------------------------------# Create member by procedure
DECLARE @return_value int

EXEC @return_value = [dbo].[create_members] 'Test', 'Test2', 'Test3'

SELECT * FROM Members
where Name = 'Test'



-- Create Scalar

-- ================================================
-- Template generated from Template Explorer using:
-- Create Scalar Function (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION getMemberName
(
	-- Add the parameters for the function here
	@Id int
)
RETURNS nvarchar(50)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Name nvarchar(50)

	-- Add the T-SQL statements to compute the return value here
	SELECT @Name = Name FROM Members
	WHERE Id = @Id

	-- Return the result of the function
	RETURN @Name

END
GO

------------------------------# Create Multi-Statement Function

-- ================================================
-- Template generated from Template Explorer using:
-- Create Multi-Statement Function (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION GetLesson
(
	-- Add the parameters for the function here
	@Id int
)
RETURNS 
@Lesson TABLE 
(
	-- Add the column definitions for the TABLE variable here

	Id int,
	Title nvarchar(200),
	Description nvarchar(500),
	StartDate datetime2(7),
	CreatedDate datetime2(7)
)
AS
BEGIN
	-- Fill the table variable with the rows for your result set
	INSERT INTO @Lesson
	SELECT
	Id,
	Title,
	Description,
	StartDate,
	CreatedDate
	FROM Lessons
	WHERE Id = @Id
	
	RETURN
END
GO

-- RUN FUNCTIONS

SELECT getMemberName(644871)

SELECT * FROM GetMember(644871)

SELECT * FROM GetLesson(58)

------------------------------# CREATED VIEW WITH MSSMS

-- Select date from view
SELECT TOP(1000) *
FROM [dbo].[GetVisitedLessons] as gvl
WHERE gvl.Member = 'AAFA737D-7A85-42F6-937C-2155BC6DED5B -Member'


-- HOMEWORK
------------------------------# CREATED NONCLUSTERED INDEX
CREATE NONCLUSTERED INDEX IX_Members_Name_Nickname
	ON Members (Name, Nicknames);
GO

CREATE NONCLUSTERED INDEX IX_Lessons_Title
	ON Lessons (Title);
GO

CREATE NONCLUSTERED INDEX IX_Lessons_Title_Descr
	ON Lessons (Title, Description);
GO

CREATE NONCLUSTERED INDEX IX_Questions_MemberId_LessonId
	On Questions (MemberId, LessonId)
GO

CREATE NONCLUSTERED INDEX IX_Questions_Description
	On Questions (Description)
GO

------------------------------# CREATED View
CREATE VIEW [dbo].[GetVisitedLessons]
AS
SELECT dbo.Lessons.Id, dbo.Lessons.Title, dbo.Members.Name AS Member, dbo.MembersLessons.CreatedDate AS VisitedDate
FROM   dbo.Members INNER JOIN
             dbo.MembersLessons ON dbo.Members.Id = dbo.MembersLessons.MemberId INNER JOIN
             dbo.Lessons ON dbo.MembersLessons.LessonId = dbo.Lessons.Id
GO
-- =============================================
CREATE VIEW [dbo].[MembersStatistic]
AS
SELECT m.Id, m.Name, m.Nicknames, l.Title, l.Description, q.Description AS Expr1, t.Timecode
FROM   dbo.Members AS m LEFT OUTER JOIN
             dbo.MembersLessons AS ml ON m.Id = ml.MemberId LEFT OUTER JOIN
             dbo.Lessons AS l ON l.Id = ml.LessonId INNER JOIN
             dbo.Timecodes AS t ON t.LessonId = ml.LessonId LEFT OUTER JOIN
             dbo.Questions AS q ON q.MemberId = m.Id
GO

------------------------------# CREATED StoredProcedure
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
CREATE PROCEDURE [dbo].[createLesson]
	-- Add the parameters for the stored procedure here
	@Title nvarchar(200),
	@Description nvarchar(500)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF NOT EXISTS (SELECT Id FROM Lessons
	WHERE Title = @Title)
	BEGIN
		INSERT INTO Lessons
		VALUES (@Title, @Description, GETDATE(), GETDATE())

		PRINT SCOPE_IDENTITY()
	END
	ELSE
	RETURN ERROR_MESSAGE()
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
CREATE PROCEDURE [dbo].[createMember]
	-- Add the parameters for the stored procedure here
	@Name nvarchar(50),
	@Nicknames nvarchar(100),
	@Email nvarchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF NOT EXISTS (SELECT Id FROM Members
	WHERE Name = @Name)
	BEGIN
		INSERT INTO Members
		VALUES (@Name, @Nicknames, @Email, GETDATE())

		PRINT SCOPE_IDENTITY()
	END
	ELSE
	RETURN ERROR_MESSAGE()
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
CREATE PROCEDURE [dbo].[createTimecode]
	-- Add the parameters for the stored procedure here
	@LessonId int,
	@Description nvarchar(500)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF EXISTS (SELECT Id FROM Timecodes
	WHERE LessonId = @LessonId)
	BEGIN
		INSERT INTO Timecodes
		VALUES (@LessonId, @Description, CONVERT(TIME, GETDATE()))

		PRINT SCOPE_IDENTITY()
	END
	ELSE
	RETURN ERROR_MESSAGE()
END
