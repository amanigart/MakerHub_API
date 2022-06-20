CREATE PROCEDURE [dbo].[SwitchPaymentStatus]
	@idCotisation INT
AS
BEGIN

	DECLARE @status BIT

	IF (SELECT estPaye FROM Cotisation WHERE idCotisation = @idCotisation) = 0
		SET @status = 1
	ELSE
		SET @status = 0

	UPDATE Cotisation
	SET estPaye = @status
	WHERE idCotisation = @idCotisation

END
