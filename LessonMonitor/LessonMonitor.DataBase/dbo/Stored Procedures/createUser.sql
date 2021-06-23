
CREATE PROCEDURE [dbo].[createUser]
	-- Add the parameters for the stored procedure here
	@Name nvarchar(50),
	@Nickname nvarchar(100),
	@Email nvarchar(200)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT Id FROM Users
	WHERE Name = @Name)
	BEGIN
		INSERT INTO Users
		VALUES (@Name, @Nickname, @Email, GETDATE())

		PRINT SCOPE_IDENTITY()
	END
	ELSE
	RETURN ERROR_MESSAGE()

END