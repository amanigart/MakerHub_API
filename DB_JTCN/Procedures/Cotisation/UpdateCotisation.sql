CREATE PROCEDURE [dbo].[UpdateCotisation]
	@idCotisation INT,
	@dateDebut DATE,
	@dateFin DATE,
	@estPaye BIT,
	@idTarif INT,
	@idMembre INT
AS
BEGIN

	UPDATE Cotisation
	SET dateDebut = @dateDebut,
		dateFin = @dateFin,
		estPaye = @estPaye,
		idTarif = @idTarif,
		idMembre = @idMembre
	WHERE idCotisation = @idCotisation

END
