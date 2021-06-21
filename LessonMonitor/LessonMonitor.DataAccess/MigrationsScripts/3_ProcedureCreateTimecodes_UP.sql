USE [LessonMonitorDb]

IF (NOT EXISTS (SELECT * 
				FROM INFORMATION_SCHEMA.ROUTINES
				WHERE SPECIFIC_SCHEMA = 'dbo'
				AND ROUTINE_TYPE = 'PROCEDURE'
				AND SPECIFIC_NAME = 'createTimecode'))

BEGIN
	EXEC ('
	CREATE PROCEDURE [dbo].[createTimecode]
		@LessonId int,
		@Description nvarchar(500)

	AS
	BEGIN

		SET NOCOUNT ON

		IF EXISTS (SELECT Id FROM Timecodes
		WHERE LessonId = @LessonId)
		BEGIN
			INSERT INTO Timecodes (LessonId, [Description], Timecode)
			VALUES (@LessonId, @Description, CONVERT(TIME, GETDATE()))

			PRINT SCOPE_IDENTITY()
		END
		ELSE
		RETURN ERROR_MESSAGE()
	END
	')
END
