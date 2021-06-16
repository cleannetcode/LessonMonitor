CREATE FUNCTION [dbo].[getMember] 
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
	Name, 
	Nicknames, 
	CreateDate
	FROM Members
	WHERE Id = @Id
)