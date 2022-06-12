CREATE PROCEDURE [dbo].[SwitchCotisationArchiveStatus]
	@idCotisation INT
AS
BEGIN

	DECLARE @status BIT

	IF (SELECT estArchive FROM Cotisation) = 0
		SET @status = 1
	ELSE
		SET @status = 0

	UPDATE Cotisation
	SET estArchive = @status
	WHERE idCotisation = @idCotisation

END
