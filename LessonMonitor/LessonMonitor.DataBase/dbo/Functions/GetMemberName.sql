-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION GetMemberName 
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