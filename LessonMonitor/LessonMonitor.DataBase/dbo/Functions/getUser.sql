
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[getUser] 
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
	Email,
	CreatedDate
	FROM Users
	WHERE Id = @Id
)