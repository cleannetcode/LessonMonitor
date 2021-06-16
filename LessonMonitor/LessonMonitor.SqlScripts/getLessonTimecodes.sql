CREATE FUNCTION [dbo].[getLessonTimecodes]
(
	-- Add the parameters for the function here
	@LessonId int
)
RETURNS 
@LessonTime TABLE 
(
	-- Add the column definitions for the TABLE variable here
	LessonId int,
	Title nvarchar(200),
	LessonDescription nvarchar(500),
	CodeDescriprion nvarchar(600),
	TimecodeDate time(3)
)
AS
BEGIN
	-- Fill the table variable with the rows for your result set
	INSERT INTO @LessonTime
	SELECT
	l.Id,
	l.Title,
	l.Description,
	t.Description,
	t.Timecode
	FROM Lessons l
	INNER JOIN Timecodes t on t.LessonId = l.Id
	WHERE l.Id = @LessonId
	RETURN 
END