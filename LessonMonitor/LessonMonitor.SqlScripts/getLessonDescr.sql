CREATE FUNCTION [dbo].[getLessonDescr]
(
	@Id int
)
RETURNS nvarchar(500)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Descr nvarchar(500)

	-- Add the T-SQL statements to compute the return value here
	SELECT @Descr = Description FROM Lessons
	WHERE Id = @Id
	-- Return the result of the function
	RETURN @Descr

END