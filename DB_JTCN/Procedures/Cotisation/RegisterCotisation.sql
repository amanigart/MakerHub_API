CREATE PROCEDURE [dbo].[RegisterCotisation]
	@dateDebut DATE,
	@dateFin DATE,
	@estPaye BIT,
	@idTarif INT,
	@idMembre INT
AS
BEGIN

	INSERT INTO Cotisation (dateDebut, dateFin, estPaye, idTarif, idMembre)
	OUTPUT inserted.idCotisation
	VALUES (@dateDebut, @dateFin, @estPaye, @idTarif, @idMembre)

END
