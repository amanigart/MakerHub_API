CREATE PROCEDURE [dbo].[RegisterEntrainement]
	@date DATETIME2(7),
	@idHoraire INT,
	@idGestionnaire INT
AS
BEGIN

	INSERT INTO Entrainement (dateEntrainement, idHoraire, idGestionnaire)
	OUTPUT inserted.idEntrainement
	VALUES (@date, @idHoraire, @idGestionnaire)

END
