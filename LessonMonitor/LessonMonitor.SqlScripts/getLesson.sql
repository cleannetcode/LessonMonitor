CREATE FUNCTION [dbo].[getLesson] 
(	
	@Id int
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	SELECT 
	Id, 
	Title, 
	Description, 
	CreatedDate
	FROM Lessons
	WHERE Id = @Id
)
