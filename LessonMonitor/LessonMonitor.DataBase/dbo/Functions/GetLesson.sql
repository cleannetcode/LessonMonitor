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
	Description nvarchar(1000),
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