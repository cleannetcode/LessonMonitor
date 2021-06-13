
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