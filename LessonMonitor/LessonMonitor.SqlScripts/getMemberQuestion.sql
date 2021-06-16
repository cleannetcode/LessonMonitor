CREATE FUNCTION [dbo].[getMemberQuestion]
(	
	@MemberId int
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here

	SELECT
	m.Id,
	m.Email,
	q.Id as 'QuestionId',
	q.Description,
	q.CreatedDate as 'CreatedQuestion'
	
	FROM Members m 
	INNER JOIN Questions q on q.MemberId = m.Id
	WHERE m.Id = @MemberId 
)