
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[createLesson]
	-- Add the parameters for the stored procedure here
	@TopicId INT,
	@Title nvarchar(200),
	@Description nvarchar(500)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF NOT EXISTS (SELECT Id FROM Lessons
	WHERE Title = @Title)
	BEGIN
		INSERT INTO Lessons
		VALUES (@TopicId, @Title, @Description, GETDATE(), GETDATE())

		PRINT SCOPE_IDENTITY()
	END
	ELSE
	RETURN ERROR_MESSAGE()
END