CREATE PROCEDURE [dbo].[RegisterHoraire]
	@jour VARCHAR(8),
	@heureDebut VARCHAR(5),
	@heureFin VARCHAR(5)
AS
BEGIN

	INSERT INTO Horaire (jour, heureDebut, heureFin)
	OUTPUT inserted.idHoraire
	VALUES (@jour, @heureDebut, @heureFin)

END
