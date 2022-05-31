CREATE PROCEDURE [dbo].[UpdateEntrainement]
	@idEntrainement INT,
	@date DATETIME2(7),
	@idHoraire INT,
	@idGestionnaire INT
AS
BEGIN

	UPDATE Entrainement
	SET dateEntrainement = @date,
		idHoraire = @idHoraire,
		idGestionnaire = @idGestionnaire
	WHERE idEntrainement = @idEntrainement

END
