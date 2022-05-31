CREATE PROCEDURE [dbo].[UpdateHoraire]
	@idHoraire INT,
	@jour VARCHAR(8),
	@heureDebut VARCHAR(5),
	@heureFin VARCHAR(5)
AS
BEGIN

	UPDATE Horaire
	SET jour = @jour,
		heureDebut = @heureDebut,
		heureFin = @heureFin
	WHERE idHoraire = @idHoraire

END
